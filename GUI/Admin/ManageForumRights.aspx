<%@ Page language="c#" CodeFile="ManageForumRights.aspx.cs" AutoEventWireup="false" Inherits="SD.HnD.GUI.Admin.ManageForumRights" 
	MasterPageFile="~/Admin/AdminMaster.master" Title="HnD::Administrate::Manage forum rights"%>

<asp:Content ContentPlaceHolderID="phMainContent" runat="server">
<table width="700" align="center" class="ExplanationBox" cellpadding="2" cellspacing="0">
<tr>
	<td>
		<h3>Manage forum rights</h3>
		Below you can configure the forum right definitions for the role <b><%=base.RoleDescription%></b>. You first select a forum, then
		you check / uncheck every action right to set the rights for this role and the forum selected. When you are done, click <b>Save</b> to
		save the definition or click <b>Cancel</b> to go back to the role list. Once you've saved a new setting, it's stored in the database. Pressing
		cancel after that will not undo your save action. 
		<br><br>
		You can only set a subset of all
		the available rights to a role here, since only the action rights for forums are available here. Modify the role itself to set
		system rights. All users in the role will inherit the rights you set when their next session begins. 
	</td>
</tr>
</table>
<br clear="all">
<table width="700" align="center" border="0" cellpadding="0" cellspacing="0">
<tr>
	<td class="FormHeaderTwoLine">
		<span class="FormName">Action rights per forum for role <i><%=base.RoleDescription%></i></span>
		<br>
		<span class="FormDescription">&nbsp;The list of existing action rights set for the given role per forum.</span>
	</td>
</tr>
<tr>
	<td class="FormContent">
		<table width="698" align="center" border="0" cellpadding="1" cellspacing="0" class="FormWindow">
		<tr><td colspan="2" ><br></td></tr>
		<tr>
			<td  width="130" align="right">Section&nbsp;</td>
			<td >
				<asp:dropdownlist ID="cbxSections" Runat="server" AutoPostBack="True" />
			</td>
		</tr>
		<tr><td  colspan="2" height="3"></td></tr>
		<tr>
			<td  align=right width="130">Forum&nbsp;</td>
			<td >
				<asp:dropdownlist id="cbxForums" Runat="server" AutoPostBack="True"></asp:dropdownlist>
			</td>
		</tr>
		<tr><td  colspan="2" height="3"></td></tr>
		<tr>
			<td  width="130" align="right" valign="top">
				<table cellpadding="2" border="0">
				<tr><td>Forum rights&nbsp;</td></tr>
				</table>
			</td>
			<td  valign="top">
				<asp:checkboxlist ID="cblForumRights" Runat="server" RepeatDirection="Vertical" RepeatLayout="Flow"></asp:checkboxlist>
			</td>
		</tr>
		<tr>
			<td >&nbsp;</td>
			<td >
				<hr align="left" size="1" width="80%">
				<input class="FormButtons" type="button" name="btnSave" runat="server" value="   Save   " ID="btnSave">&nbsp;&nbsp;&nbsp;
				<input class="FormButtons" type="button" name="btnCancel" runat="server" value="  Cancel  " ID="btnCancel" causesvalidation="false">
			</td>
		</tr>
		<asp:placeholder ID="phSaveResult" Visible="False" Runat="server">
			<tr><td  colspan="2" height="3"></td></tr>
			<tr>
				<td  width="130">&nbsp;</td>
				<td >Save action was succesful!</td>
			</tr>
		</asp:placeholder>
		<tr><td  colspan="2" height="6"></td></tr>
		</table>
	</td>
</tr>
<tr><td class="EmptyRowBottom">&nbsp;</td></tr>
</table>
</asp:Content>