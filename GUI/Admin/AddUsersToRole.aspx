<%@ Page language="c#" CodeFile="AddUsersToRole.aspx.cs" AutoEventWireup="false" Inherits="SD.HnD.GUI.Admin.AddUsersToRole" 
	MasterPageFile="~/Admin/AdminMaster.master" Title="HnD::Administrate::Add users to role"%>

<asp:Content ContentPlaceHolderID="phMainContent" runat="server">
<table width="700" align="center" class="ExplanationBox" cellpadding="2" cellspacing="0">
<tr>
	<td>
		<h3>Add users to role.</h3>
		Below you'll find all existing users in the system who are <i>not</i> currently part of the role <b><%=base.RoleDescription%></b>. 
		All users are shown, also the users who are banned. This way you can create additional ban functionality based on role security.
		<br><br>
		You can select multiple users by holding down <i>control</i> and left clicking nicknames. When you're done, click <b>Add user(s)</b> to add the
		selected users to the role or click <b>Cancel</b> to go back to the role list.
	</td>
</tr>
</table>
<br clear="all">
<table width="700" align="center" border="0" cellpadding="0" cellspacing="0">
<tr>
	<td class="TableHeaderTwoLine">
		<span class="TableName">Select users to add to the role <i><%=base.RoleDescription%></i></span>
		<br>
		<span class="TableDescription">Adds all selected users to the given role. Hold down the control (ctrl) key while left-clicking the 
			names to multi-select users.</span>
	</td>
</tr>
<tr>
	<td class="FormContent">
		<table width="698" align="center" border="0" cellpadding="1" cellspacing="0" class="FormWindow">
		<tr><td colspan="2" ><br></td></tr>
		<tr>
			<td  width="130" align="right" valign="top">Users not in role&nbsp;</td>
			<td >
				<asp:listbox Runat="server" ID="lbxUsers" SelectionMode="Multiple" Rows="10" Width="450px"   />
			</td>
		</tr>
		<tr><td  colspan="2" height="6"></td></tr>
		<tr>
			<td >&nbsp;</td>
			<td >
				<hr align="left" size="1" width="80%">
				<input class="FormButtons" type="button" name="btnAddUsers" runat="server" value="Add user(s)" ID="btnAddUsers">&nbsp;&nbsp;&nbsp;
				<input class="FormButtons" type="button" name="btnCancel" runat="server" value="    Cancel    " ID="btnCancel">
			</td>
		</tr>
		<tr><td  colspan="2" height="6"></td></tr>
		</table>
	</td>
</tr>
<tr>
	<td class="EmptyRowBottom" height="5"><img src="../pics/separator.gif" border="0"></td>
</tr>
</table>
</asp:Content>