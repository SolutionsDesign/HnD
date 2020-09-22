using System.Linq;
using SD.HnD.BL;
using SD.HnD.DALAdapter.EntityClasses;
using SD.HnD.DALAdapter.HelperClasses;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using SD.HnD.Gui.Classes;

namespace SD.HnD.Gui
{
	/// <summary>
	/// Set of extension methods on ISession related to auditing information
	/// </summary>
	public static class AuditingAdapter
	{
		/// <summary>
		/// Adds the audit action IDs collection to the session.
		/// If the object already exists, it is overwritten with the new value.
		/// </summary>
		/// <param name="session">The session the method works on</param>
		/// <param name="auditActions">The audit actions to store.</param>
		internal static void AddAuditActions(this ISession session, EntityCollection<AuditActionEntity> auditActions)
		{
			var valuesToStore = auditActions.Select(e => e.AuditActionID).ToArray();
			session.SetString(SessionKeys.AuditActions, JsonConvert.SerializeObject(valuesToStore));
		}


		/// <summary>
		/// Gets the audit action ids from the session.
		/// </summary>
		/// <param name="session">The session the method works on</param>
		/// <returns>array with audit action id's if available otherwise returns null.</returns>
		internal static int[] GetAuditActions(this ISession session)
		{
			var auditValues = session.GetString(SessionKeys.AuditActions);
			return string.IsNullOrEmpty(auditValues) ? null : JsonConvert.DeserializeObject<int[]>(auditValues);
		}


		/// <summary>
		/// Checks if the current user needs auditing for the action specified
		/// </summary>
		/// <param name="session">The session the method works on</param>
		/// <param name="auditActionID">the id of the audit action to take</param>
		/// <returns>true if the user needs auditing, otherwise false</returns>
		public static bool CheckIfNeedsAuditing(this ISession session, AuditActions auditActionID)
		{
			var auditActions = session.GetAuditActions();
			return auditActions != null && auditActions.Length > 0 && auditActions.Contains((int)auditActionID);
		}
	}
}