<%@ Page language="c#" CodeFile="DeleteRole.aspx.cs" AutoEventWireup="false" Inherits="SD.HnD.GUI.Admin.DeleteRole" 
	MasterPageFile="~/Admin/AdminMaster.master" Title="HnD::Administrate::Delete a role"%>

<asp:Content ContentPlaceHolderID="phMainContent" runat="server">
<table cellSpacing="0" cellPadding="2" width="700" align="center" class="ExplanationBox">
	<tr>
		<td>
			<h3>Delete a role</h3>
			Below you'll see the role you selected for deletion. Together with this role, all rights assigned to this role are
			removed. You can't delete the role for anonymous users (users who visit the forum system but are not logged in)
			or the role which is default assigned to new users. 
			You can change which roles are used for anonymous users or for new users in 
			<a href="ModifySystemParameters.aspx">Modify system parameters</a>, if you have the proper access rights for that. Delete roles
			only if you do not need them and they are empty; most of the time you do not need to delete roles, you can simply remove the users
			from the role or remove the rights from the role. 
			<br><br>
			If you want to proceed with the deletion, click the <b>Delete</b> button. If 
			you don't want to delete this role, click on the <b>Keep</b> button. The delete	action is irreversable.
		</td>
	</tr>
</table>
<br clear="all">
<table cellSpacing="0" cellPadding="0" width="700" align="center" border="0">
	<tr>
		<td class="FormHeaderOneLine">
			<span class="FormName">Role marked for deletion</span>
		</td>
	</tr>
	<tr>
		<td class="FormContent">
			<table cellSpacing="0" cellPadding="2" width="698" align="center">
			<tr class="LightBackground">
				<td width="40">&nbsp;</td>
				<td>
					<br>
						<b><asp:label id="lblRoleDescription" Runat="server"></asp:label></b>
					<br>
				</td>
			</tr>
			</table>
		</td>
	</tr>
	<tr>
		<td class="FormContent">
			<table class="FormWindow" cellSpacing="0" cellPadding="1" width="698" align="center" border="0">
				<tr>
					<td><br>
						<hr width="80%" SIZE="1">
						<center><input class="FormButtons" id="btnDelete" type="button" value="  Delete  " name="btnDelete" runat="server">
							&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <input class="FormButtons" id="btnKeep" type="button" value="   Keep   " name="btnKeep" runat="server">
						</center>
					</td>
				</tr>
				<tr>
					<td height="6"></td>
				</tr>
			</table>
		</td>
	</tr>
	<tr>
		<td class="EmptyRowBottom">&nbsp;</td>
	</tr>
</table>
</asp:Content>