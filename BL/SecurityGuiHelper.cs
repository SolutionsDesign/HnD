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

using SD.HnD.DALAdapter.HelperClasses;
using SD.HnD.DALAdapter;
using SD.HnD.DALAdapter.EntityClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System.Collections.Generic;
using SD.HnD.DALAdapter.DatabaseSpecific;
using SD.LLBLGen.Pro.QuerySpec;
using SD.HnD.DALAdapter.FactoryClasses;
using SD.HnD.DALAdapter.Linq;
using SD.HnD.DTOs.DtoClasses;
using SD.HnD.DTOs.Persistence;
using SD.LLBLGen.Pro.QuerySpec.Adapter;
using System.Linq;
using System.Threading.Tasks;
using SD.LLBLGen.Pro.LinqSupportClasses;

namespace SD.HnD.BL
{
	/// <summary>
	/// Class to provide essential data for the Security Gui. 
	/// </summary>
	public static class SecurityGuiHelper
	{
		/// <summary>
		/// Gets all role objects.
		/// </summary>
		/// <returns></returns>
		public static async Task<List<RoleDto>> GetAllRoleDtosAsync()
		{
			using(var adapter = new DataAccessAdapter())
			{
				var metaData = new LinqMetaData(adapter);
				var q = metaData.Role.OrderBy(r => r.RoleDescription).ProjectToRoleDto();
				return await q.ToListAsync().ConfigureAwait(false);
			}
		}

		
		/// <summary>
		/// Gets all role objects.
		/// </summary>
		/// <returns></returns>
		public static async Task<EntityCollection<RoleEntity>> GetAllRolesAsync()
		{
			using(var adapter = new DataAccessAdapter())
			{
				return await adapter.FetchQueryAsync(new QueryFactory().Role.OrderBy(RoleFields.RoleDescription.Ascending()), new EntityCollection<RoleEntity>())
									.ConfigureAwait(false);
			}
		}


		/// <summary>
		/// Gets all audit actions.
		/// </summary>
		/// <returns></returns>
		public static async Task<EntityCollection<AuditActionEntity>> GetAllAuditActionsAsync()
		{
			using(var adapter = new DataAccessAdapter())
			{
				return await adapter.FetchQueryAsync(new QueryFactory().AuditAction.OrderBy(AuditActionFields.AuditActionDescription.Ascending()), 
													 new EntityCollection<AuditActionEntity>())
									.ConfigureAwait(false);
			}
		}



		/// <summary>
		/// Gets all auditaction ids associated to the role with the id specified.
		/// </summary>
		/// <param name="roleID"></param>
		/// <returns></returns>
		public static List<int> GetAllAuditActionIDsForRole(int roleID)
		{
			using(var adapter = new DataAccessAdapter())
			{
				var qf = new QueryFactory();
				var q = qf.RoleAuditAction
						  .Where(RoleAuditActionFields.RoleID.Equal(roleID))
						  .Select(()=>RoleAuditActionFields.AuditActionID.ToValue<int>());
				return adapter.FetchQuery(q);
			}
		}


		/// <summary>
		/// Gets all audits for user.
		/// </summary>
		/// <param name="userID">User ID.</param>
		/// <returns>All audit data objects (polymorphic)</returns>
		public static async Task<EntityCollection<AuditDataCoreEntity>> GetAllAuditsForUserAsync(int userID)
		{
			var qf = new QueryFactory();
			var q = qf.AuditDataCore
						.Where(AuditDataCoreFields.UserID==userID)
						.OrderBy(AuditDataCoreFields.AuditedOn.Descending())
						.Limit(50)
						.WithPath(AuditDataMessageRelatedEntity.PrefetchPathMessage.WithSubPath(MessageEntity.PrefetchPathThread),
								  AuditDataThreadRelatedEntity.PrefetchPathThread);
			using(var adapter = new DataAccessAdapter())
			{
				return await adapter.FetchQueryAsync(q, new EntityCollection<AuditDataCoreEntity>()).ConfigureAwait(false);
			}
		}


		/// <summary>
		/// Gets all IP ban DTOs, sorted by IP segments ascending
		/// </summary>
		/// <returns>
		/// the collection of ipban DTOs requested
		/// </returns>
		public static async Task<List<IPBanDto>> GetAllIPBanDtosAsync()
		{
			using(var adapter = new DataAccessAdapter())
			{
				var metaData = new LinqMetaData(adapter);
				var q = (from i in metaData.IPBan
						 orderby i.IPSegment1, i.IPSegment2, i.IPSegment3, i.IPSegment4
						 select i)
					.ProjectToIPBanDto();
				return await q.ToListAsync().ConfigureAwait(false);
			}
		}


		/// <summary>
		/// Gets all IP ban entities, sorted by IP segments ascending
		/// </summary>
		/// <returns>
		/// the collection of ipban entities requested
		/// </returns>
		public static EntityCollection<IPBanEntity> GetAllIPBans()
		{
			var qf = new QueryFactory();
			var q = qf.IPBan
					  .OrderBy(IPBanFields.IPSegment1.Ascending(), IPBanFields.IPSegment2.Ascending(), IPBanFields.IPSegment3.Ascending(), IPBanFields.IPSegment4.Ascending());
			using(var adapter = new DataAccessAdapter())
			{
				return adapter.FetchQuery(q, new EntityCollection<IPBanEntity>());
			}
		}


		/// <summary>
		/// Gets the IPBan entity with the ID specified or null if not found
		/// </summary>
		/// <param name="ipBanId"></param>
		/// <returns></returns>
		public static async Task<IPBanEntity> GetIPBanAsync(int ipBanId)
		{
			using(var adapter = new DataAccessAdapter())
			{
				var q = new QueryFactory().IPBan.Where(IPBanFields.IPBanID.Equal(ipBanId));
				return await adapter.FetchFirstAsync(q).ConfigureAwait(false);
			}
		}


		/// <summary>
		/// Gets the RoleEntity with the id specified.
		/// </summary>
		/// <param name="roleID">Role to retrieve</param>
		/// <returns>Entity with the role data or null if not found</returns>
		public static async Task<RoleEntity> GetRoleAsync(int roleID)
		{
			using(var adapter = new DataAccessAdapter())
			{
				var q = new QueryFactory().Role.Where(RoleFields.RoleID.Equal(roleID));
				return await adapter.FetchFirstAsync(q).ConfigureAwait(false);
			}
		}

		
		/// <summary>
		/// Gets all ids for the system action rights associated to the role with id specified
		/// </summary>
		/// <param name="roleID"></param>
		/// <returns></returns>
		public static List<int> GetAllSystemActionRightIDsForRole(int roleID)
		{
			using(var adapter = new DataAccessAdapter())
			{
				var qf = new QueryFactory();
				var q = qf.RoleSystemActionRight
						  .Where(RoleSystemActionRightFields.RoleID.Equal(roleID))
						  .Select(()=>RoleSystemActionRightFields.ActionRightID.ToValue<int>());
				return adapter.FetchQuery(q);
			}
		}
		

		/// <summary>
		/// Retrieves an entitycollection with all the forum-actionright-role combinations currently defined for the role specified for the given forum
		/// </summary>
		/// <param name="roleID">The role which forum action rights should be retrieved.</param>
		/// <param name="forumID">The forum ID.</param>
		/// <returns>filled entity collection
		/// </returns>
		public static async Task<EntityCollection<ForumRoleForumActionRightEntity>> GetForumActionRightRolesForForumRoleAsync(int roleID, int forumID)
		{
			using(var adapter = new DataAccessAdapter())
			{
				return await adapter.FetchQueryAsync(new QueryFactory().ForumRoleForumActionRight
																	.Where(ForumRoleForumActionRightFields.RoleID.Equal(roleID)
																		  .And(ForumRoleForumActionRightFields.ForumID.Equal(forumID))),
										  new EntityCollection<ForumRoleForumActionRightEntity>())
									.ConfigureAwait(false);
			}
		}


		/// <summary>
		/// Retrieves all ActionRight entities which are applyable to a forum.
		/// </summary>
		/// <returns>entitycollection with all the action rights requested</returns>
		public static async Task<EntityCollection<ActionRightEntity>> GetAllActionRightsApplybleToAForumAsync()
		{
			using(var adapter = new DataAccessAdapter())
			{
				return await adapter.FetchQueryAsync(new QueryFactory().ActionRight.Where(ActionRightFields.AppliesToForum.Equal(true))
																	   .OrderBy(ActionRightFields.ActionRightID.Ascending()),
													 new EntityCollection<ActionRightEntity>()).ConfigureAwait(false);
			}
		}


		/// <summary>
		/// Retrieves all action rights which are system action rights and which aren't applyable to a forum
		/// </summary>
		/// <returns>entitycollection with all the system action rights</returns>
		public static async Task<EntityCollection<ActionRightEntity>> GetAllSystemActionRightsAsync()
		{
			using(var adapter = new DataAccessAdapter())
			{
				return await adapter.FetchQueryAsync(new QueryFactory().ActionRight.Where(ActionRightFields.AppliesToSystem.Equal(true))
																	   .OrderBy(ActionRightFields.ActionRightID.Ascending()),
													 new EntityCollection<ActionRightEntity>()).ConfigureAwait(false);
			}
		}
		

		/// <summary>
		/// Gets the system action rights for user.
		/// </summary>
		/// <param name="userID">The user ID.</param>
		/// <param name="actionRights">The action rights to be returned.</param>
		/// <returns>filled collection</returns>
		public static async Task<EntityCollection<ActionRightEntity>> GetSystemActionRightsForUserAsync(int userID)
		{
			var qf = new QueryFactory();
			// the subquery in the filter requires joins as the filter's subquery has to filter on fields in related entities:
			// WHERE ActionRightID IN (SELECT ActionRightID FROM RoleSystemActionRight INNER JOIN Role ... INNER JOIN RoleUser ... WHERE RoleUser.UserID=userID)
			var q = qf.ActionRight
					  .Where(ActionRightFields.ActionRightID.In(
															    qf.Create()
																  .Select(RoleSystemActionRightFields.ActionRightID)
																  .From(qf.RoleSystemActionRight.InnerJoin(qf.Role).On(RoleSystemActionRightFields.RoleID.Equal(RoleFields.RoleID))
																		  .InnerJoin(qf.RoleUser).On(RoleFields.RoleID.Equal(RoleUserFields.RoleID)))
																  .Where(RoleUserFields.UserID.Equal(userID)))
											  .And(ActionRightFields.AppliesToSystem.Equal(true)));
			using(var adapter = new DataAccessAdapter())
			{
				var toReturn = await adapter.FetchQueryAsync(q, new EntityCollection<ActionRightEntity>()).ConfigureAwait(false);
				return toReturn;
			}
		}


		/// <summary>
		/// Gets the Forum action rights for user.
		/// </summary>
		/// <param name="userID">The user ID.</param>
		/// <returns>fetched collection</returns>
		public static async Task<EntityCollection<ForumRoleForumActionRightEntity>> GetForumsActionRightsForUserAsync(int userID)
		{
			var qf = new QueryFactory();
			// the subquery in the filter requires joins as the filter's subquery has to filter on fields in related entities:
			// WHERE RoleID IN (SELECT RoleID FROM Role INNER JOIN RoleUser ... WHERE RoleUser.UserID=userID)
			var q = qf.ForumRoleForumActionRight
					  .Where(ForumRoleForumActionRightFields.RoleID.In(qf.Create()
																		 .Select(RoleFields.RoleID)
																		 .From(qf.Role.InnerJoin(qf.RoleUser).On(RoleFields.RoleID.Equal(RoleUserFields.RoleID)))
																		 .Where(RoleUserFields.UserID.Equal(userID))));
			using(var adapter = new DataAccessAdapter())
			{
				var toReturn = await adapter.FetchQueryAsync(q, new EntityCollection<ForumRoleForumActionRightEntity>()).ConfigureAwait(false);
				return toReturn;
			}
		}


		/// <summary>
		/// Gets the audit actions for user.
		/// </summary>
		/// <param name="userID">The user ID.</param>
		/// <returns>fetched collection</returns>
		public static async Task<EntityCollection<AuditActionEntity>> GetAuditActionsForUserAsync(int userID)
		{
			var qf = new QueryFactory();
			var q = qf.AuditAction
					  .Where(AuditActionFields.AuditActionID.In(qf.Create()
																  .Select(RoleAuditActionFields.AuditActionID)
																  .From(qf.RoleAuditAction
																		  .InnerJoin(qf.Role).On(RoleAuditActionFields.RoleID == RoleFields.RoleID)
																		  .InnerJoin(qf.RoleUser).On(RoleFields.RoleID == RoleUserFields.RoleID))
																  .Where(RoleUserFields.UserID == userID)));
			using(var adapter = new DataAccessAdapter())
			{
				var toReturn = await adapter.FetchQueryAsync(q, new EntityCollection<AuditActionEntity>()).ConfigureAwait(false);
				return toReturn;
			}
		}


		/// <summary>
		/// Checks if passed in IP address, in string format matches an IP ban. If the ip address matches an ip ban, the matching IP ban is returned
		/// </summary>
		/// <param name="allCachedIPBans">All cached IP bans from the cache.</param>
		/// <param name="ipAddressUser">The ip address of the user, in string format.</param>
		/// <returns>null if the user doesn't match any IP ban, or the first IPBan entity it matches</returns>
		public static IPBanEntity GetIPBanMatchingUserIPAddress(Dictionary<int, Dictionary<string, IPBanEntity>> allCachedIPBans, string ipAddressUser)
		{
			string[] ipAddressSegments = ipAddressUser.Split('.');
			if(ipAddressSegments.Length != 4)
			{
				// can't do matching as the ip address has less or more segments
				return null;
			}
			
			Dictionary<string, IPBanEntity> rangeBans = null;
			StringBuilder ipTemp = new StringBuilder();
			IPBanEntity toReturn = null;

			// for each segment we'll check if it, combined with the previous segments, results in a match. If not, the next segment will be tried.
			for(int i=0;i<4;i++)
			{
				// check range ban. Build ip address segments from ip address passed in and check that with the segments in the range ban dictionary
				if(i > 0)
				{
					ipTemp.Append(".");
				}
				ipTemp.Append(ipAddressSegments[i]);
				rangeBans = allCachedIPBans.GetValue(8*(i+1));
				if(rangeBans==null)
				{
					// no range bans with this range, continue
					continue;
				}
				if(rangeBans.TryGetValue(ipTemp.ToString(), out toReturn))
				{
					// we have a match!
					break;
				}
			}

			return toReturn;
		}


		/// <summary>
		/// Gets a list of all the RoleIDs of the roles the user with the userid specified is in
		/// </summary>
		/// <param name="userId"></param>
		/// <returns></returns>
		public static async Task<List<int>> GetAllRoleIDsForUserAsync(int userId)
		{
			using(var adapter = new DataAccessAdapter())
			{
				var q = new QueryFactory().RoleUser.Where(RoleUserFields.UserID.Equal(userId)).Select(()=>RoleUserFields.RoleID.ToValue<int>());
				return await adapter.FetchQueryAsync(q).ConfigureAwait(false);
			}
		}
	}
}
