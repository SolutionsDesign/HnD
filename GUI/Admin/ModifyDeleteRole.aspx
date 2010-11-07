<%@ Page language="c#" CodeFile="ModifyDeleteRole.aspx.cs" AutoEventWireup="false" Inherits="SD.HnD.GUI.Admin.ModifyDeleteRole" 
	MasterPageFile="~/Admin/AdminMaster.master" Title="HnD::Administrate::Modify / Delete a role"%>

<asp:Content ContentPlaceHolderID="phMainContent" runat="server">
<table width="700" align="center" class="ExplanationBox" cellpadding="2" cellspacing="0">
<tr>
	<td>
		<h3>Modify / delete a role</h3>
		Below you'll find all existing roles in the system. Modifying a role means that you can change the description of the role plus change 
		all system rights assigned to that role. Deleting a role means you delete that role, all user-role assignments and all rights assigned to
		the role from the system. Be aware of the fact that if you remove all the roles which have one or more system administration rights, you can not
		administrate the system when you re-login. You can't delete the role for anonymous users (users who visit the forum system but are not logged in)
		or the role which is default assigned to new users. <br><br>
		You can change which roles are used for anonymous users or for new users in 
		<a href="ModifySystemParameters.aspx">Modify system parameters</a>, if you have the proper access rights for that.
	</td>
</tr>
</table>
<br clear="all"><br>
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
		<tr>
			<td class="TableColumnHeader"><b>Role description</b></td>
			<td class="TableColumnHeader"><b># Users</b></td>
			<td class="TableColumnHeader"><b>Action</b></td>
		</tr>
		<asp:repeater ID="rpRoles" Runat="server" EnableViewState="True">
			<itemtemplate>
			<tr>
				<td class="TableRow LightBackground">
					<%# Eval("RoleDescription")%><br>
					<asp:label CssClass="SmallFontSmallest" ID="lblIsAnonymousRole" Runat="server" Visible='<%# (bool)Eval("IsAnonymousRole") %>'>This role is used for anonymous users.</asp:label>
					<asp:label CssClass="SmallFontSmallest" ID="lblIsDefaultNewUserRole" Runat="server" Visible='<%# (bool)Eval("IsDefaultNewUserRole") %>'>This role is assigned to new users.</asp:label>
				</td>
				<td class="TableRow LightBackground" align="center" width="60">
					<asp:label ID="lblAmountUsersInRole" Runat="server" Text='<%# Eval("AmountUsersInRole") %>'/>
				</td>
				<td width="150" class="TableRow LightBackground">
					<asp:button CssClass="FormButtons" ID="btnModify" CommandName="Modify" Text="Modify" runat="server" 
						CommandArgument='<%# Eval("RoleID") %>'/>&nbsp;&nbsp;
					<asp:button CssClass="FormButtons" ID="btnDelete" CommandName="Delete" Text="Delete" runat="server" 
						Visible='<%# !((bool)Eval("IsAnonymousRole") || (bool)Eval("IsDefaultNewUserRole")) %>' CommandArgument='<%# Eval("RoleID") %>'/>
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
				<td class="TableRow DarkBackground" align="center" width="60">
					<asp:label ID="lblAmountUsersInRole" Runat="server" Text='<%# Eval("AmountUsersInRole") %>' />
				</td>
				<td width="150" class="TableRow DarkBackground">
					<asp:button CssClass="FormButtons" ID="btnModify" CommandName="Modify" Text="Modify" runat="server"
						CommandArgument='<%# Eval("RoleID") %>'/>&nbsp;&nbsp;
					<asp:button CssClass="FormButtons" ID="btnDelete" CommandName="Delete" Text="Delete" runat="server"
						Visible='<%# !((bool)Eval("IsAnonymousRole") || (bool)Eval("IsDefaultNewUserRole")) %>' CommandArgument='<%# Eval("RoleID") %>'/>
				</td>
			</tr>
			</alternatingitemtemplate>
		</asp:repeater>
		</table>
	</td>
</tr>
<tr><td class="EmptyRowBottom">&nbsp;</td></tr>
</table>
</asp:Content>