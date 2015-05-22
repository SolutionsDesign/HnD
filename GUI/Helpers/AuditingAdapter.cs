using System.Linq;
using System.Web;
using SD.HnD.BL;
using SD.HnD.DAL.CollectionClasses;

namespace SD.HnD.Gui
{
	public static class AuditingAdapter
	{
		/// <summary>
		/// Adds the audit actions collection to the session.
		/// If the object already exists, it is overwritten with the new value.
		/// </summary>
		/// <param name="auditActions">The audit actions to store.</param>
		internal static void AddAuditActions(AuditActionCollection auditActions)
		{
			HttpContext.Current.Session.Add("auditActions", auditActions);
		}


		/// <summary>
		/// Gets the audit actions from the session.
		/// </summary>
		/// <returns>AuditActionCollection if available otherwise returns null.</returns>
		internal static AuditActionCollection GetAuditActions()
		{
			return HttpContext.Current.Session["auditActions"] as AuditActionCollection;
		}


		/// <summary>
		/// Checks if the current user needs auditing for the action specified
		/// </summary>
		/// <param name="auditActionID">the id of the audit action to take</param>
		/// <returns>true if the user needs auditing, otherwise false</returns>
		public static bool CheckIfNeedsAuditing(AuditActions auditActionID)
		{
			AuditActionCollection auditActions = GetAuditActions();
			if (auditActions != null && auditActions.Count > 0)
			{
				return auditActions.Any(a=>a.AuditActionID==(int)auditActionID);
			}
			return false;
		}
	}
}