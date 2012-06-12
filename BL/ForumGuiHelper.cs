/*
	This file is part of HnD.
	HnD is (c) 2002-2007 Solutions Design.
    http://www.llblgen.com
	http://www.sd.nl

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
using System.Data;
using System.Text;
using System.Collections;
using System.Collections.Generic;

using SD.LLBLGen.Pro.ORMSupportClasses;
using SD.LLBLGen.Pro.QuerySpec;
using SD.LLBLGen.Pro.QuerySpec.SelfServicing;
using SD.HnD.DAL.CollectionClasses;
using SD.HnD.DAL.TypedListClasses;
using SD.HnD.DAL.FactoryClasses;
using SD.HnD.DAL;
using SD.HnD.DAL.HelperClasses;
using SD.HnD.DAL.EntityClasses;
using SD.HnD.DAL.DaoClasses;

namespace SD.HnD.BL
{
	/// <summary>
	/// Class to provide essential data for the Forum Gui
	/// </summary>
	public class ForumGuiHelper
    {
		/// <summary>
		/// Returns a TypedList which contains the last (amount) posted messages in
		/// the forum given. For RSS production.
		/// </summary>
		/// <param name="amount">limit of amount of messages to return</param>
		/// <param name="forumID">ID of forum to pull the messages for</param>
		/// <returns>typed list with data requested</returns>
		public static ForumMessagesTypedList GetLastPostedMessagesInForum(int amount, int forumID)
		{
			ForumMessagesTypedList forumMessages = new ForumMessagesTypedList();
			forumMessages.Fill(amount, new SortExpression(MessageFields.PostingDate.Ascending()), false,
							   (ForumFields.ForumID == forumID).And(ForumFields.HasRSSFeed == true));
			return forumMessages;
		}

		
		/// <summary>
		/// Returns a DataView object that contains a complete list of threads list for
		/// the requested forum and required date & time interval
		/// </summary>
		/// <param name="forumID">ID of Forum for which the Threadlist is required</param>
		/// <param name="limiter">Limits the Threadlist to between now and; last 48 Hrs, Last Week, Last Month, Last Year</param>
		/// <param name="minNumberOfThreadsToFetch">The minimum number of threads to fetch if there are less threads available in the limiter interval</param>
		/// <param name="minNumberOfNonStickyVisibleThreads">The minimum number of non-sticky visible threads to show. If the # of threads is lower than 
		/// this number (due to the limiter value), the minNumberOfThreadsToFetch are fetched</param>
		/// <param name="canViewNormalThreadsStartedByOthers">If set to true, the user calling the method has the right to view threads started by others.
		/// Otherwise only the threads started by the user calling the method are returned.</param>
		/// <param name="userID">The userid of the user calling the method.</param>
		/// <returns>DataView with all the threads</returns>
		public static DataView GetAllThreadsInForumAsDataView(int forumID, ThreadListInterval limiter, short minNumberOfThreadsToFetch, 
				short minNumberOfNonStickyVisibleThreads, bool canViewNormalThreadsStartedByOthers, int userID)
		{
			DateTime limiterDate;

			// convert the limiter enum to a datetime which we can use in the filters on the thread data, where we'll use the limiter date
			// as a filter for the last posting date of a post in a given thread. 
            switch (limiter)
            {
				case ThreadListInterval.Last24Hours:
					limiterDate = DateTime.Today.AddHours(-24);
					break;
                case ThreadListInterval.Last48Hours:
					limiterDate = DateTime.Today.AddHours(-48);
                    break;
                case ThreadListInterval.LastWeek:
					limiterDate = DateTime.Today.AddDays(-7);
                    break;
                case ThreadListInterval.LastMonth:
					limiterDate = DateTime.Today.AddMonths(-1);
                    break;
                case ThreadListInterval.LastYear:
					limiterDate = DateTime.Today.AddYears(-1);
                    break;
				default:
					limiterDate = DateTime.Today.AddHours(-48);
					break;
            }

            // We'll use a dynamic list to retrieve all threads for the given forum in the right order, for the given limiter.
			ResultsetFields fields = ThreadGuiHelper.BuildDynamicListForAllThreadsWithStats();

			// now build the relations for the dynamic list. We'll join User twice: once for the startuser and one for the lastpost user. 
			// also, we'll join the last message to the thread. The last message is joined with a custom filter added to the relation. 
			RelationCollection relations = ThreadGuiHelper.BuildRelationsForAllThreadsWithStats();

            // Set up query conditions using Predicate Expressions
			// we'll keep the sticky threads filter and the forum filter in separate variables as we'll re-use them later on.
			FieldCompareValuePredicate stickyThreadsFilter = (FieldCompareValuePredicate)(ThreadFields.IsSticky == true);
			var forumFilter = ThreadFields.ForumID == forumID;
			var filter = forumFilter.And(stickyThreadsFilter.Or(ThreadFields.ThreadLastPostingDate >= limiterDate));

			// if the user can't view threads started by others, filter out threads started by users different from userID
			if(!canViewNormalThreadsStartedByOthers)
			{
				// caller can't view threads started by others: add a filter so that threads not started by calling user aren't enlisted. 
				// however sticky threads are always returned so the filter contains a check so the limit is only applied on threads which aren't sticky
				// add a filter for sticky threads, add it with 'OR', so sticky threads are always accepted
				filter.AddWithAnd((ThreadFields.StartedByUserID == userID).Or(ThreadFields.IsSticky == true));
			}
            
            //Set up the sort expressions
			SortExpression sorter = new SortExpression(ThreadFields.IsSticky.Descending());
			sorter.Add(ThreadFields.IsClosed.Ascending());
			sorter.Add(ThreadFields.ThreadLastPostingDate.Descending());

			DataTable threads = new DataTable();
			TypedListDAO dao = new TypedListDAO();
            
            // Get the data by fetching the dynamic list into the datatable using the filter and the sorter we just setup.
			dao.GetMultiAsDataTable(fields, threads, 0, sorter, filter, relations, true, null, null, 0, 0);
         
			// count # non-sticky threads. If it's below a given minimum, refetch everything, but now don't fetch on date filtered but at least the
			// set minimum. Do this ONLY if the user can view other user's threads. If that's NOT the case, don't refetch anything.
			DataView stickyThreads = new DataView(threads, ThreadFieldIndex.IsSticky.ToString() + "=false", "", DataViewRowState.CurrentRows);
			if((stickyThreads.Count < minNumberOfNonStickyVisibleThreads) && canViewNormalThreadsStartedByOthers)
			{
				// not enough threads available, fetch again, 
				threads = new DataTable();

				// first fetch the sticky threads. 
				filter = forumFilter.And(stickyThreadsFilter);
                sorter = new SortExpression(ThreadFields.ThreadLastPostingDate.Descending());
				dao.GetMultiAsDataTable(fields, threads, 0, sorter, filter, relations, true, null, null, 0, 0);

				// then fetch the rest. Fetch it into the same datatable object to append the rows to the already fetched sticky threads (if any)
				stickyThreadsFilter.Value=false;
				dao.GetMultiAsDataTable(fields, threads, minNumberOfThreadsToFetch, sorter, filter, relations, true, null, null, 0, 0);

				// sort closed threads to the bottom. Do this in-memory as it's a sort operation after projection. Doing it on the server would mean
				// a sort operation before projection.
				return new DataView(threads, string.Empty, ThreadFieldIndex.IsClosed.ToString() + " ASC", DataViewRowState.CurrentRows);
			}
			else
			{
				return threads.DefaultView;
			}
		}


		/// <summary>
		/// Gets all forum data with section name in a typedlist. Sorted on Section.OrderNo, Section.SectionName, Forum.OrderNo, Forum.ForumName.
		/// </summary>
		/// <returns>Filled typedlist with all forum names / forumIDs and their containing section's name, sorted on Sectionname, and then forumname</returns>
		public static ForumsWithSectionNameTypedList GetAllForumsWithSectionNames()
		{
			ForumsWithSectionNameTypedList toReturn = new ForumsWithSectionNameTypedList();
			SortExpression sorter = new SortExpression(SectionFields.OrderNo.Ascending());
			sorter.Add(SectionFields.SectionName.Ascending());
			sorter.Add(ForumFields.OrderNo.Ascending());
			sorter.Add(ForumFields.ForumName.Ascending());
			toReturn.Fill(0, sorter);
			return toReturn;
		}


		/// <summary>
		/// Gets all forum entities which belong to a given section. 
		/// </summary>
		/// <param name="sectionID">The section ID from which forums should be retrieved</param>
		/// <returns>Entity collection with entities for all forums in this section sorted alphabitacally</returns>
		public static ForumCollection GetAllForumsInSection(int sectionID)
		{
			var q = new QueryFactory().Forum
						.Where(ForumFields.SectionID == sectionID)
						.OrderBy(ForumFields.OrderNo.Ascending(), ForumFields.ForumName.Ascending());
			var toReturn = new ForumCollection();
			toReturn.GetMulti(q);
			return toReturn;
		}


		/// <summary>
		/// Retrieves for all available sections all forums with all relevant statistical information. This information is stored per forum in a
		/// DataView which is stored in the returned Dictionary, with the SectionID where the forum is located in as Key.
		/// </summary>
		/// <param name="availableSections">SectionCollection with all available sections</param>
		/// <param name="accessableForums">List of accessable forums IDs.</param>
		/// <param name="forumsWithOnlyOwnThreads">The forums for which the calling user can view other users' threads. Can be null</param>
		/// <param name="userID">The userid of the calling user.</param>
		/// <returns>
		/// Dictionary with per key (sectionID) a dataview with forum information of all the forums in that section.
		/// </returns>
		/// <remarks>Uses dataviews because a dynamic list is executed to retrieve the information for the forums, which include aggregate info about
		/// # of posts.</remarks>
        public static Dictionary<int, DataView> GetAllAvailableForumsDataViews(SectionCollection availableSections, List<int> accessableForums,
				List<int> forumsWithThreadsFromOthers, int userID)
        {
			Dictionary<int, DataView> toReturn = new Dictionary<int, DataView>();

            // return an empty list, if the user does not have a valid list of forums to access
            if (accessableForums == null || accessableForums.Count <= 0)
            {
                return toReturn;
            }

			// fetch all forums with statistics in a dynamic list, while filtering on the list of accessable forums for this user. 
			// Create the filter separate of the query itself, as it's re-used multiple times. 
			IPredicateExpression threadFilter = ThreadGuiHelper.CreateThreadFilter(forumsWithThreadsFromOthers, userID);

			var qf = new QueryFactory();
			var q = qf.Create()
						.Select(ForumFields.ForumID, 
								ForumFields.ForumName, 
								ForumFields.ForumDescription, 
								ForumFields.ForumLastPostingDate,
								// add a scalar query which retrieves the # of threads in the specific forum. 
								// this will result in the query:
								// (
								//		SELECT COUNT(ThreadID) FROM Thread 
								//		WHERE ForumID = Forum.ForumID AND threadfilter. 
								// ) As AmountThreads
								qf.Create()
										.Select(ThreadFields.ThreadID.Count())
										.CorrelatedOver(ThreadFields.ForumID == ForumFields.ForumID)
										.Where(threadFilter)
										.ToScalar().As("AmountThreads"),
								// add a scalar query which retrieves the # of messages in the threads of this forum. 
								// this will result in the query:
								// (
								//		SELECT COUNT(MessageID) FROM Message 
								//		WHERE ThreadID IN
								//		(
								//			SELECT ThreadID FROM Thread WHERE ForumID = Forum.ForumID AND threadfilter
								//		)
								// ) AS AmountMessages
								qf.Create()
										.Select(MessageFields.MessageID.Count())
										.Where(MessageFields.ThreadID.In(
												qf.Create()
													.Select(ThreadFields.ThreadID)
													.CorrelatedOver(ThreadFields.ForumID == ForumFields.ForumID)
													.Where(threadFilter)))
										.ToScalar().As("AmountMessages"),
								ForumFields.HasRSSFeed, 
								ForumFields.SectionID)
						.Where(ForumFields.ForumID == accessableForums)
						.OrderBy(ForumFields.OrderNo.Ascending(), ForumFields.ForumName.Ascending());

			var results = new TypedListDAO().FetchAsDataTable(q);

			// Now per section create a new DataView in memory using in-memory filtering on the DataTable. 
            foreach(SectionEntity section in availableSections)
            {
                // Create view for current section and filter out rows we don't want. Do this with in-memory filtering of the dataview, so we don't
				// have to execute multiple queries. 
                DataView forumsInSection = new DataView(results, "SectionID=" + section.SectionID, string.Empty, DataViewRowState.CurrentRows);
                // add to sorted list with SectionID as key
                toReturn.Add(section.SectionID, forumsInSection);
            }

            // return the dictionary
            return toReturn;
        }


		/// <summary>
		/// Returns a ForumEntity of the given forum
		/// </summary>
		/// <param name="forumID">ForumID of forum which data should be read</param>
		/// <returns>forum entity with the data requested, or null if not found</returns>
		public static ForumEntity GetForum(int forumID)
		{
			ForumEntity toReturn = new ForumEntity(forumID);
			if(toReturn.Fields.State!=EntityState.Fetched)
			{
				return null;
			}
			return toReturn;
		}
	}
}
