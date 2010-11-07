<%@ Page language="c#" CodeFile="Default.aspx.cs" AutoEventWireup="false" Inherits="SD.HnD.GUI.Admin._Default" 
	MasterPageFile="~/Admin/AdminMaster.master" Title="HnD::Administrate your forumsystem"  %>
<%@ Register TagPrefix="HnD" TagName="PageFooter" Src="../Footer.ascx"%>
<%@ Register TagPrefix="HnD" TagName="PageHeader" Src="Header.ascx"%>

<asp:Content runat="server" ContentPlaceHolderID="phMainContent">
<table width="700" align="center" class="ExplanationBox" cellpadding="2" cellspacing="0">
<tr>
	<td>
		<h3>Administrate your forumsystem</h3>
		Below you'll find the menu for the different actions you can perform on this forum system.
		When a menu section is not available to you because you don't have the proper access rights, the
		menu section header is visible, but the options are not.
		All actions performed through this administration menu are
		done on the live database and all your actions are active as soon as you finish your action. 
		Be aware of that fact when you perform actions on your forum system.
	</td>
</tr>
</table>
<br clear="all">
<table width="700" align="center" border="0" cellpadding="0" cellspacing="0">
<tr>
	<td class="TableHeaderTwoLine">
		<span class="TableName">System management</span>
		<br />
		<span class="TableDescription">System management tasks</span>
	</td>
</tr>
<tr>
	<td class="FormContent">
		<table width="698" align="center" border="0" cellpadding="2" cellspacing="0">
		<asp:placeholder ID="phSystem" Runat="server" Visible="False">
		<tr><td class="TableColumnHeader">System parameters</td></tr>
		<tr>
			<td class="TableRow LightBackground">
				<a href="ModifySystemParameters.aspx">Modify system parameters</a><br>
				<span class="SmallFontSmallest">Allows you to modify system parameters such as the default user role assigned to new users.</span>
			</td>
		</tr>
		<tr>
			<td class="TableRow DarkBackground">
				<a href="Reparser.aspx">Re-parse messages</a><br>
				<span class="SmallFontSmallest">Re-parses messages and stores their updated XML into the db.</span>
			</td>
		</tr>
		<tr><td class="EmptyRow" height="1"></td></tr>
		<tr><td class="TableColumnHeader">Support queues</td></tr>
		<tr>
			<td class="TableRow LightBackground">
				<a href="ManageSupportQueues.aspx">Manage support queues</a><br>
				<span class="SmallFontSmallest">Allows you to add, edit and remove a support queue and its details.</span>
			</td>
		</tr>
		</asp:placeholder>
		
		<tr><td class="EmptyRow" height="1"></td></tr>
		<tr><td class="TableColumnHeader">Sections</td></tr>
		
		<asp:placeholder id="phSections" runat="server" visible="False">
			<tr>
				<td class="TableRow LightBackground">
					<a href="AddSection.aspx">Add new section</a><br>
					<span class="SmallFontSmallest">Allows you to add a new section to the forum system wherein you can add new forums.</span>
				</td>
			</tr>
			<tr>
				<td class="TableRow DarkBackground">
					<a href="ModifyDeleteSection.aspx">Modify / Delete section</a><br>
					<span class="SmallFontSmallest">Allows you to modify or delete an existing section in the forum system. 
						You can change name and description of the section and also which forums are in the section. 
						When you delete a section, the forums in that section should first be removed or moved to 
						other sections. You can only delete empty sections.</span>
				</td>
			</tr>
		</asp:placeholder>
		
		<tr><td class="EmptyRow" height="1"></td></tr>
		<tr><td class="TableColumnHeader">Forums</td></tr>
		
		<asp:placeholder ID="phForums" Runat="server" Visible="False">
			<tr>
				<td class="TableRow LightBackground">
					<a href="AddForum.aspx">Add new Forum</a><br>
					<span class="SmallFontSmallest">Allows you to add a new forum to the forum system.</span>
				</td>
			</tr>
			<tr>
				<td class="TableRow DarkBackground">
					<a href="ModifyDeleteForum.aspx">Modify / Delete Forum</a><br>
					<span class="SmallFontSmallest">
						Allows you to modify / delete an existing forum in the forum system. 
						You can change name and description of the forum and also in 
						which section a particular forum is located.
						When you delete a forum, all threads and messages in that forum are removed as well.</span>
				</td>
			</tr>
		</asp:placeholder>
		
		<tr><td class="EmptyRow" height="1"></td></tr>
		<tr><td class="TableColumnHeader">Users</td></tr>
		
		<asp:placeholder ID="phUsers" Runat="server" Visible="False">
			<tr>
				<td class="TableRow LightBackground">
					<a href="BanUnbanUser.aspx">Ban / Unban a user</a><br>
					<span class="SmallFontSmallest">Allows you to ban or unban a user from the forum system, based on a user account ban.</span>
				</td>
			</tr>
			<tr>
				<td class="TableRow DarkBackground">
					<a href="ModifyUserProfile.aspx">Modify user information</a><br>
					<span class="SmallFontSmallest">Allows you to modify a user's profile and reset the user's password etc.</span>
				</td>
			</tr>
			<tr>
				<td class="TableRow LightBackground">
					<a href="DeleteUser.aspx">Delete user</a><br>
					<span class="SmallFontSmallest">Allows you to delete a user. Use this as a last resort, since all the messages
					the user has posted will be assigned to the Anonymous Coward user (UserID 0).</span>
				</td>
			</tr>
			<tr>
				<td class="TableRow DarkBackground">
					<a href="ViewAuditInfo.aspx">View audit information for a user</a><br>
					<span class="SmallFontSmallest">Allows you to view the latest logged audit information for a particular user.</span>
				</td>
			</tr>
			<tr>
				<td class="TableRow LightBackground">
					<a href="SendEmail.aspx">Send email to user(s)</a><br>
					<span class="SmallFontSmallest">Allows you to email one or more users directly from the forum system.</span>
				</td>
			</tr>
			<tr>
				<td class="TableRow DarkBackground">
					<a href="ManageIPBans.aspx">Manage IP bans</a><br>
					<span class="SmallFontSmallest">Allows you add / edit or remove an IP ban. An IP ban is a ban which allows you to ban a range 
						of IP addresses or just one address.</span>
				</td>
			</tr>			
		</asp:placeholder>
		
		<tr><td class="EmptyRow" height="1"></td></tr>
		<tr><td class="TableColumnHeader">Security</td></tr>
		
		<asp:placeholder ID="phSecurity" Runat="server" Visible="False">
			<tr>
				<td class="TableRow LightBackground">
					<a href="AddRole.aspx">Add Role</a><br>
					<span class="SmallFontSmallest">Allows you add a new role to the forum system.</span>
				</td>
			</tr>
			<tr>
				<td class="TableRow DarkBackground">
					<a href="ModifyDeleteRole.aspx">Modify / Delete Role</a><br>
					<span class="SmallFontSmallest">Allows you to modify a role or delete a role alltogether.
					You can change the description and which system rights the role has.</span>
				</td>
			</tr>
			<tr>
				<td class="TableRow LightBackground">
					<a href="ManageUsersInRole.aspx">Manage Users in Role</a><br>
					<span class="SmallFontSmallest">Allows you to modify which users are in the role.</span>
				</td>
			</tr>
			<tr>
				<td class="TableRow DarkBackground">
					<a href="ManageRoleForumRights.aspx">Manage Role rights per Forum</a><br>
					<span class="SmallFontSmallest">Allows you to assign per forum the rights for a role.</span>
				</td>
			</tr>
			<tr>
				<td class="TableRow LightBackground">
					<a href="ManageAuditActionsPerRole.aspx">Manage Audit Actions per Role</a><br>
					<span class="SmallFontSmallest">Allows you to modify which audit actions are set for a specifc role.</span>
				</td>
			</tr>
		</asp:placeholder>
		</table>
	</td>
</tr>
<tr><td class="EmptyRowBottom">&nbsp;</td></tr>
</table>
</asp:Content>