<%@ Page language="c#" CodeFile="AddRole.aspx.cs" AutoEventWireup="false" Inherits="SD.HnD.GUI.Admin.AddRole" 
	MasterPageFile="~/Admin/AdminMaster.master" Title="HnD::Administrate::Add a new role"%>

<asp:Content ContentPlaceHolderID="phMainContent" runat="server">
<table width="700" align="center" border="0" cellpadding="0" cellspacing="0">
<tr>
	<td class="TableHeaderTwoLine">
		<span class="TableName">Existing roles</span>
		<br>
		<span class="TableDescription">The list of existing roles in the forum system.</span>
	</td>
</tr>
<tr>
	<td class="TableContent">
		<table width="698" align="center" border="0" cellpadding="2" cellspacing="0">
		<asp:repeater ID="rpRoles" Runat="server">
			<itemtemplate>
			<tr>
				<td class="TableRow LightBackground">
					<%#Eval("RoleDescription")%><br>
					<asp:label CssClass="SmallFontSmallest" ID="lblIsAnonymousRole" Runat="server" Visible='<%# (bool)Eval("IsAnonymousRole") %>'>This role is used for anonymous users.</asp:label>
					<asp:label CssClass="SmallFontSmallest" ID="lblIsDefaultNewUserRole" Runat="server" Visible='<%# (bool)Eval("IsDefaultNewUserRole") %>'>This role is assigned to new users.</asp:label>
				</td>
			</tr>
			</itemtemplate>
			
			<alternatingitemtemplate>
			<tr>
				<td class="TableRow DarkBackground">
					<%#Eval("RoleDescription")%><br>
					<asp:label CssClass="SmallFontSmallest" ID="lblIsAnonymousRole" Runat="server" Visible='<%# (bool)Eval("IsAnonymousRole") %>'>This role is used for anonymous users.</asp:label>
					<asp:label CssClass="SmallFontSmallest" ID="lblIsDefaultNewUserRole" Runat="server" Visible='<%# (bool)Eval("IsDefaultNewUserRole") %>'>This role is assigned to new users.</asp:label>
				</td>
			</tr>
			</alternatingitemtemplate>
		</asp:repeater>
		</table>
	</td>
</tr>
<tr><td class="EmptyRowBottom">&nbsp;</td></tr>
</table>
<br clear="all">
<table width="700" align="center" border="0" cellpadding="0" cellspacing="0">
<tr>
	<td class="FormHeaderTwoLine">
		<span class="FormName">Add a new role</span>
		<br>
		<span class="FormDescription">
			Adds a new role to the system immediately. A new role doesn't have any rights assigned to it nor are there any users placed in this role.
		</span>
	</td>
</tr>
<tr>
	<td class="FormContent">
		<table width="698" align="center" border="0" cellpadding="1" cellspacing="0" class="FormWindow">
		<tr><td colspan="2" class="FormWindow"><br></td></tr>
		<tr>
			<td  width="130" align="right">Role description&nbsp;</td>
			<td >
				<asp:textbox class="Inputborder" ID="tbxRoleDescription" Runat="server" Name="tbxRoleDescription" MaxLength="50" Columns="50"/>
			</td>
		</tr>
		<tr><td  colspan="2" height="6"></td></tr>
		<tr>
			<td >&nbsp;</td>
			<td >
				<hr align="left" size="1" width="80%">
				<input class="FormButtons" type="button" name="btnSave" runat="server" value="     Save     " ID="btnSave"><br>
			</td>
		</tr>
		<tr><td  colspan="2" height="6"></td></tr>
		<tr>
			<td >&nbsp;</td>
			<td >
				<asp:requiredfieldvalidator ControlToValidate="tbxRoleDescription" Runat="server" ErrorMessage="Role description is empty" ID="rfvRoleDescription" name="rfvRoleDescription"/><br>
				<asp:label ID="lblDuplicateRoleDescription" Runat="server" Visible="False" ForeColor="red">There was an error saving the role, this can be caused by a role that has the same description.</asp:label>
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