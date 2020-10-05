/*
	This file is part of HnD.
	HnD is (c) 2002-2020 Solutions Design.
	https://www.llblgen.com
	https://www.sd.nl

	HnD is free software; you can redistribute it and/or modify
	it under the terms of version 2 of the GNU General Public License as published by
	the Free Software Foundation.

	HnD is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
	GNU General Public License for more details.

	You should have received a copy of the GNU General Public License
	along with HnD, please see the LICENSE.txt file; if not, write to the Free Software
	Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using SD.HnD.BL;
using SD.HnD.DALAdapter.EntityClasses;
using SD.HnD.Gui.Models;

namespace SD.HnD.Gui.Controllers
{
	/// <summary>
	/// Controller for Support Queue related actions. 
	/// </summary>
	/// <remarks>The async methods don't use an Async suffix. This is by design, due to: https://github.com/dotnet/aspnetcore/issues/8998</remarks>
	public class SupportQueueController : Controller
	{
		private IMemoryCache _cache;


		public SupportQueueController(IMemoryCache cache)
		{
			_cache = cache;
		}


		[Authorize]
		[ValidateAntiForgeryToken]
		[HttpPost]
		public async Task<ActionResult> ClaimThread(int threadId, int pageNo)
		{
			var (result, thread) = await PerformSecurityCheckAsync(threadId);
			if(result != null)
			{
				return result;
			}

			await SupportQueueManager.ClaimThreadAsync(this.HttpContext.Session.GetUserID(), threadId);
			return RedirectToAction("Index", "Thread", new {threadId = threadId, pageNo = pageNo});
		}


		[Authorize]
		[ValidateAntiForgeryToken]
		[HttpPost]
		public async Task<ActionResult> ReleaseThread(int threadId, int pageNo)
		{
			var (result, thread) = await PerformSecurityCheckAsync(threadId);
			if(result != null)
			{
				return result;
			}

			await SupportQueueManager.ReleaseClaimOnThreadAsync(threadId);
			return RedirectToAction("Index", "Thread", new {threadId = threadId, pageNo = pageNo});
		}


		[Authorize]
		[HttpGet]
		public async Task<ActionResult> EditMemo(int threadId = 0, int pageNo = 1)
		{
			var (result, thread) = await PerformSecurityCheckAsync(threadId);
			if(result != null)
			{
				return result;
			}

			var forum = await _cache.GetForumAsync(thread.ForumID);
			if(forum == null)
			{
				// orphaned thread
				return RedirectToAction("Index", "Home");
			}

			var messageData = new MessageData()
							  {
								  MessageText = thread.Memo + string.Format("  {2}**-----------------------------------------------------------------  {2}{1} {0} wrote:** ",
																			this.HttpContext.Session.GetUserNickName(), DateTime.Now.ToString(@"dd-MMM-yyyy HH:mm:ss"), 
																			Environment.NewLine),
								  CurrentUserID = this.HttpContext.Session.GetUserID(),
								  ForumID = forum.ForumID,
								  ThreadID = thread.ThreadID,
								  ForumName = forum.ForumName,
								  SectionName = await _cache.GetSectionNameAsync(forum.SectionID),
								  ThreadSubject = thread.Subject,
								  PageNo = (pageNo < 1 ? 1 : pageNo),
							  };
			return View(messageData);
		}


		[Authorize]
		[ValidateAntiForgeryToken]
		[HttpPost]
		public async Task<ActionResult> EditMemo([Bind("MessageText")] MessageData messageData, string submitButton, int threadId = 0, int pageNo = 1)
		{
			if(!ModelState.IsValid)
			{
				return RedirectToAction("Index", "Home");
			}

			var (result, thread) = await PerformSecurityCheckAsync(threadId);
			if(result != null)
			{
				return result;
			}

			await ThreadManager.UpdateMemoAsync(thread.ThreadID, messageData.MessageText);
			if(this.HttpContext.Session.CheckIfNeedsAuditing(AuditActions.AuditEditMemo))
			{
				await SecurityManager.AuditEditMemoAsync(this.HttpContext.Session.GetUserID(), thread.ThreadID);
			}

			return RedirectToAction("Index", "Thread", new {threadId = threadId, pageNo = pageNo});
		}


		[Authorize]
		[ValidateAntiForgeryToken]
		[HttpPost]
		public async Task<ActionResult> MoveToQueue(int threadId = 0, int pageNo = 1, int queueId = 0)
		{
			var (result, thread) = await PerformSecurityCheckAsync(threadId);
			if(result != null)
			{
				return result;
			}

			var containingQueue = await SupportQueueGuiHelper.GetQueueOfThreadAsync(threadId);

			// now set the queue if: 
			// a) the thread isn't in a queue and the selected queueID > 0 (so not None)
			// b) the thread is in a queue and the selected queueuID isn't the id of the queue containing the thread
			if(((containingQueue == null) && (queueId > 0)) || ((containingQueue != null) && (containingQueue.QueueID != queueId)))
			{
				// Set the queue. if the new queue is 0, remove from queue.
				if(queueId > 0)
				{
					await SupportQueueManager.AddThreadToQueueAsync(threadId, queueId, this.HttpContext.Session.GetUserID(), null);
				}
				else
				{
					await SupportQueueManager.RemoveThreadFromQueueAsync(threadId, null);
				}
				// reset the cached value how much messages are in the queues. 
				ApplicationAdapter.InvalidateCachedNumberOfThreadsInSupportQueues();
			}

			return RedirectToAction("Index", "Thread", new {threadId = threadId, pageNo = pageNo});
		}


		[Authorize]
		[HttpGet]
		public async Task<ActionResult> ListQueues()
		{
			if(!this.HttpContext.Session.HasSystemActionRight(ActionRights.QueueContentManagement))
			{
				return RedirectToAction("Index", "Home");
			}

			// these queues are pre-sorted, so no need to sort them again.
			var supportQueues = (await _cache.GetAllSupportQueuesAsync()).ToList();
			var supportQueueContents = await SupportQueueGuiHelper.GetAllThreadsInSpecifiedSupportQueuesAsync(
																				  this.HttpContext.Session.GetForumsWithActionRight(ActionRights.AccessForum),
																				  supportQueues.Select(e => e.QueueID).ToArray());
			if(supportQueueContents == null)
			{
				return RedirectToAction("Index", "Home");
			}

			var data = new SupportQueuesData()
					   {
						   AvailableSupportQueues = supportQueues,
						   AllVisibleSupportQueueContents = supportQueueContents,
						   UserLastVisitDate = this.HttpContext.Session.GetLastVisitDate()
					   };
			return View(data);
		}


		[Authorize]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> UpdateQueues(string threadClaimButton)
		{
			if(!this.HttpContext.Session.HasSystemActionRight(ActionRights.QueueContentManagement))
			{
				return RedirectToAction("Index", "Home");
			}

			var buttonIdClicked = threadClaimButton ?? string.Empty;
			if(string.IsNullOrWhiteSpace(buttonIdClicked))
			{
				return RedirectToAction("Index", "Home");
			}

			var idFragments = buttonIdClicked.Split('_');
			if(idFragments.Length != 2)
			{
				return RedirectToAction("Index", "Home");
			}

			var threadId = 0;
			if(!Int32.TryParse(idFragments[1], out threadId))
			{
				return RedirectToAction("Index", "Home");
			}

			var (result, thread) = await PerformSecurityCheckAsync(threadId);
			if(result != null)
			{
				return result;
			}

			switch(idFragments[0])
			{
				case "releaseButton":
					await SupportQueueManager.ReleaseClaimOnThreadAsync(threadId);
					break;
				case "claimButton":
					await SupportQueueManager.ClaimThreadAsync(this.HttpContext.Session.GetUserID(), threadId);
					break;
				default:
					return RedirectToAction("Index", "Home");
			}

			// it's either claim or release, go back to the original view for all queues
			return RedirectToAction("ListQueues", "SupportQueue");
		}


		/// <summary>
		/// Returns a tuple with an action result and the thread with the id specified if valid.
		/// if security check failed the action result will be set to the action to redirect to, otherwise it will return null.
		/// </summary>
		/// <param name="threadId">the threadid to check security for</param>
		/// <returns></returns>
		private async Task<(ActionResult redirectResult, ThreadEntity thread)> PerformSecurityCheckAsync(int threadId)
		{
			var thread = await ThreadGuiHelper.GetThreadAsync(threadId);
			if(thread == null)
			{
				// not found, return to start page
				return (RedirectToAction("Index", "Home"), null);
			}

			// Check credentials
			bool userHasAccess = this.HttpContext.Session.CanPerformForumActionRight(thread.ForumID, ActionRights.AccessForum);
			if(!userHasAccess)
			{
				// doesn't have access to this forum. redirect
				return (RedirectToAction("Index", "Home"), null);
			}

			// check if the user can view this thread. If not, don't continue.
			if(thread.StartedByUserID != this.HttpContext.Session.GetUserID() &&
			   !this.HttpContext.Session.CanPerformForumActionRight(thread.ForumID, ActionRights.ViewNormalThreadsStartedByOthers) &&
			   !thread.IsSticky)
			{
				// can't view this thread, it isn't visible to the user
				return (RedirectToAction("Index", "Home"), null);
			}

			if(!this.HttpContext.Session.HasSystemActionRight(ActionRights.QueueContentManagement))
			{
				return (RedirectToAction("Index", "Home"), null);
			}

			// All ok
			return (null, thread);
		}
	}
}