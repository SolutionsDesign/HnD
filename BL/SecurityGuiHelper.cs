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

using SD.HnD.DAL.CollectionClasses;
using SD.HnD.DAL.HelperClasses;
using SD.HnD.DAL;
using SD.HnD.DAL.EntityClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using SD.HnD.DAL.DaoClasses;
using System.Collections.Generic;
using SD.LLBLGen.Pro.QuerySpec.SelfServicing;
using SD.LLBLGen.Pro.QuerySpec;
using SD.HnD.DAL.FactoryClasses;

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
		public static RoleCollection GetAllRoles()
		{
			RoleCollection toReturn = new RoleCollection();
			toReturn.GetMulti(null, 0, new SortExpression(RoleFields.RoleDescription.Ascending()));
			return toReturn;
		}


		/// <summary>
		/// Gets all audit actions.
		/// </summary>
		/// <returns></returns>
		public static AuditActionCollection GetAllAuditActions()
		{
			AuditActionCollection toReturn = new AuditActionCollection();
			toReturn.GetMulti(null, 0, new SortExpression(AuditActionFields.AuditActionDescription.Ascending()));
			return toReturn;
		}


		/// <summary>
		/// Gets all audit actions for role.
		/// </summary>
		/// <param name="roleID">Role ID.</param>
		/// <returns></returns>
		public static RoleAuditActionCollection GetAllAuditActionsForRole(int roleID)
		{
			RoleAuditActionCollection toReturn = new RoleAuditActionCollection();
			toReturn.GetMulti((RoleAuditActionFields.RoleID == roleID));
			return toReturn;
		}


		/// <summary>
		/// Gets all audits for user.
		/// </summary>
		/// <param name="userID">User ID.</param>
		/// <returns>All audit data objects (polymorphic)</returns>
		public static AuditDataCoreCollection GetAllAuditsForUser(int userID)
		{
			var qf = new QueryFactory();
			var q = qf.AuditDataCore
						.Where(AuditDataCoreFields.UserID==userID)
						.OrderBy(AuditDataCoreFields.AuditedOn.Descending())
						.Limit(50)
						.WithPath(AuditDataMessageRelatedEntity.PrefetchPathMessage.WithSubPath(MessageEntity.PrefetchPathThread),
								  AuditDataThreadRelatedEntity.PrefetchPathThread);
			
			AuditDataCoreCollection toReturn = new AuditDataCoreCollection();
			toReturn.GetMulti(q);
			return toReturn;
		}


		/// <summary>
		/// Gets all IP ban entities, sorted by range for the page specified.
		/// </summary>
		/// <param name="pageNo">The page number for the page to read. Specify 0 to fetch all ip bans.</param>
		/// <param name="pageSize">Size of the page to fetch. Specify 0 to fetch all ip bans.</param>
		/// <param name="prefetchUser">If set to true, it will prefetch the user entity into the ipBan entity, for the user who set the IPBan</param>
		/// <returns>
		/// the collection of ipban entities requested
		/// </returns>
		public static IPBanCollection GetAllIPBans(int pageNo, int pageSize, bool prefetchUser)
		{
			IPBanCollection toReturn = new IPBanCollection();
			PrefetchPath path = null;
			if(prefetchUser)
			{
				// build the Prefetch path to fetch the user as well
				path = new PrefetchPath((int)EntityType.IPBanEntity);
				path.Add(IPBanEntity.PrefetchPathSetByUser);
			}
			toReturn.GetMulti(null, 0, new SortExpression(IPBanFields.Range.Ascending()), null, path, pageNo, pageSize);
			return toReturn;
		}


		/// <summary>
		/// Gets the total IP ban count as they're stored in the DB now.
		/// </summary>
		/// <returns>the # of IPBans stored in the database.</returns>
		public static int GetTotalIPBanCount()
		{
			IPBanCollection toReturn = new IPBanCollection();
			return toReturn.GetDbCount();
		}


		/// <summary>
		/// Constructs a dataview with all the roles available, complete with statistics (#users, if the role is used as anonymous role or default user role)
		/// </summary>
		/// <returns>DataView with all the Roles available, directly bindable to webcontrols</returns>
		public static DataView GetAllRolesWithStatisticsAsDataView()
		{
			// create dynamic list, with all fields of Role and 3 extra fields: one field for the # of users in the role, one field which
			// signals if the role is the defaultnewuserrole and one field which signals if the role is the anonymous role. The # of users field is
			// used in the query, the other two fields are added later for efficiency.
			var qf = new QueryFactory();
			var q = qf.Create()
						.Select(RoleFields.RoleID,
								RoleFields.RoleDescription,
								// now add the # of users subquery to the resultset. This will result in the query:
								// (
								//    SELECT 	COUNT(UserID)
								//    FROM	RoleUser
								//    WHERE RoleUser.RoleID = Role.RoleID
								// ) AS AmountUsersInRole
								qf.Create()
									.Select(RoleUserFields.UserID.Count())
									.CorrelatedOver(RoleUserFields.RoleID == RoleFields.RoleID)
									.ToScalar()
									.As("AmountUsersInRole"))
						.OrderBy(RoleFields.RoleDescription.Ascending());
			var dao = new TypedListDAO();
			var results = dao.FetchAsDataTable(q);

			// we now fetch the system data which contains the two role id's we've to check with in the results to return.
			SystemDataEntity systemData = SystemGuiHelper.GetSystemSettings();
			// now add 2 columns to the datatable, booleans, which are used to store the flags for IsDefaultNewUserRole and IsAnonymousRole, so the complete
			// set of data can be processed in a list form.
			results.Columns.Add(new DataColumn("IsDefaultNewUserRole", typeof(bool)));
			results.Columns.Add(new DataColumn("IsAnonymousRole", typeof(bool)));
			foreach(DataRow row in results.Rows)
			{
				row["IsDefaultNewUserRole"] = ((int)row["RoleID"] == systemData.DefaultRoleNewUser);
				row["IsAnonymousRole"] = ((int)row["RoleID"] == systemData.AnonymousRole);
			}

			// done, return the dataview of this datatable
			return results.DefaultView;
		}


		/// <summary>
		/// Gets the RoleEntity with the id specified.
		/// </summary>
		/// <param name="roleID">Role to retrieve</param>
		/// <returns>Entity with the role data or null if not found</returns>
		public static RoleEntity GetRole(int roleID)
		{
			RoleEntity toReturn = new RoleEntity( roleID );
			if(toReturn.IsNew)
			{
				return null;
			}
			return toReturn;
		}

		
		/// <summary>
		/// Retrieves an entitycollection with all the systemactionright-role combinations currently defined for the role specified
		/// </summary>
		/// <param name="roleID">The role which system action rights should be retrieved.</param>
		/// <returns>filled collection with entities of type RoleSystemActionRightEntity</returns>
		public static RoleSystemActionRightCollection GetSystemActionRightRolesForRole(int roleID)
		{
			RoleSystemActionRightCollection toReturn = new RoleSystemActionRightCollection();
			toReturn.GetMulti((RoleSystemActionRightFields.RoleID == roleID));
			return toReturn;
		}


		/// <summary>
		/// Retrieves an entitycollection with all the forum-actionright-role combinations currently defined for the role specified for the given forum
		/// </summary>
		/// <param name="roleID">The role which forum action rights should be retrieved.</param>
		/// <param name="forumID">The forum ID.</param>
		/// <returns>filled entity collection
		/// </returns>
		public static ForumRoleForumActionRightCollection GetForumActionRightRolesFoForumRole(int roleID, int forumID)
		{
			ForumRoleForumActionRightCollection toReturn = new ForumRoleForumActionRightCollection();
			toReturn.GetMulti((ForumRoleForumActionRightFields.RoleID == roleID).And(ForumRoleForumActionRightFields.ForumID==forumID));
			return toReturn;
		}


		/// <summary>
		/// Retrieves all ActionRight entities which are applyable to a forum.
		/// </summary>
		/// <returns>entitycollection with all the action rights requested</returns>
		public static ActionRightCollection GetAllActionRightsApplybleToAForum()
		{
			ActionRightCollection toReturn = new ActionRightCollection();
			toReturn.GetMulti((ActionRightFields.AppliesToForum == true), 0, new SortExpression( ActionRightFields.ActionRightID.Ascending()) );
			return toReturn;
		}


		/// <summary>
		/// Retrieves all action rights which are system action rights and which aren't applyable to a forum
		/// </summary>
		/// <returns>entitycollection with all the system action rights</returns>
		public static ActionRightCollection GetAllSystemActionRights()
		{
			ActionRightCollection toReturn = new ActionRightCollection();
			toReturn.GetMulti((ActionRightFields.AppliesToSystem == true), 0, new SortExpression(ActionRightFields.ActionRightID | SortOperator.Ascending));
			return toReturn;
		}
		

		/// <summary>
		/// Gets the system action rights for user.
		/// </summary>
		/// <param name="userID">The user ID.</param>
		/// <param name="actionRights">The action rights to be returned.</param>
		/// <returns>filled collection</returns>
		public static ActionRightCollection GetSystemActionRightsForUser(int userID)
		{
			ActionRightCollection actionRights = new ActionRightCollection();

			// the subquery in the filter requires joins as the filter's subquery has to filter on fields in related entities:
			// WHERE ActionRightID IN (SELECT ActionRightID FROM RoleSystemActionRight INNER JOIN Role ... INNER JOIN RoleUser ... WHERE RoleUser.UserID=userID)
			RelationCollection relations = new RelationCollection();
			relations.Add(RoleSystemActionRightEntity.Relations.RoleEntityUsingRoleID);
			relations.Add(RoleEntity.Relations.RoleUserEntityUsingRoleID);

			PredicateExpression filter = new PredicateExpression();
			// retrieve system action rights only.
			filter.Add(ActionRightFields.AppliesToSystem == true);
			filter.Add(new FieldCompareSetPredicate(
						ActionRightFields.ActionRightID,
						RoleSystemActionRightFields.ActionRightID,
						SetOperator.In,
						(RoleUserFields.UserID == userID), relations));

			actionRights.GetMulti(filter);
			return actionRights;
		}


		/// <summary>
		/// Gets the Forum action rights for user.
		/// </summary>
		/// <param name="userID">The user ID.</param>
		/// <returns>fetched collection</returns>
		public static ForumRoleForumActionRightCollection GetForumsActionRightsForUser(int userID)
		{
			ForumRoleForumActionRightCollection forumRoleActionRights = new ForumRoleForumActionRightCollection();

			// the subquery in the filter requires joins as the filter's subquery has to filter on fields in related entities:
			// WHERE RoleID IN (SELECT RoleID FROM Role INNER JOIN RoleUser ... WHERE RoleUser.UserID=userID)
			RelationCollection relations = new RelationCollection();
			relations.Add(RoleEntity.Relations.RoleUserEntityUsingRoleID);

			PredicateExpression filter = new PredicateExpression();
			filter.Add(new FieldCompareSetPredicate(ForumRoleForumActionRightFields.RoleID,
						RoleFields.RoleID, SetOperator.In, (RoleUserFields.UserID == userID), relations));

			forumRoleActionRights.GetMulti(filter);
			return forumRoleActionRights;
		}


		/// <summary>
		/// Gets the audit actions for user.
		/// </summary>
		/// <param name="userID">The user ID.</param>
		/// <returns>fetched collection</returns>
		public static AuditActionCollection GetAuditActionsForUser(int userID)
		{
			var qf = new QueryFactory();
			var q = qf.AuditAction
						.Where(AuditActionFields.AuditActionID
											.In(qf.Create()
														.Select(RoleAuditActionFields.AuditActionID)
														.From(qf.RoleAuditAction
																.InnerJoin(qf.Role).On(RoleAuditActionFields.RoleID==RoleFields.RoleID)
																.InnerJoin(qf.RoleUser).On(RoleFields.RoleID==RoleUserFields.RoleID))
														.Where(RoleUserFields.UserID==userID)));

			AuditActionCollection auditActions = new AuditActionCollection();
			auditActions.GetMulti(q);
			return auditActions;
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

				allCachedIPBans.TryGetValue(8*(i+1), out rangeBans);
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
	}
}
