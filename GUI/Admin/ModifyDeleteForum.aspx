<%@ Page language="c#" CodeFile="ModifyDeleteForum.aspx.cs" AutoEventWireup="false" Inherits="SD.HnD.GUI.Admin.ModifyDeleteForum" 
	MasterPageFile="~/Admin/AdminMaster.master" Title="HnD::Administrate::Modify / Delete a forum"%>

<asp:Content ContentPlaceHolderID="phMainContent" runat="server">
<table width="700" align="center" class="ExplanationBox" cellpadding="2" cellspacing="0">
<tr>
	<td>
		<h3>Modify / delete a forum</h3>
		Below you'll find all existing forums in the system, including the section's they're in. Modifying a forum means you can change the name, the
		description and the section location of the forum. Deleting a forum means that the forum, all its threads and all the messages in those threads,
		including the history records are deleted from the database. This action is irreversable and most of the time unnecessary. If you want to hide
		a forum, you can simply remove the Access Forum right for all roles on the particular forum and the forum is hidden automatically. If you hide a forum
		it's often wise to remove all rights for all roles from the forum, so no-one can take actions on the forum through the system. 
	</td>
</tr>
</table>
<br clear="all"><br>
<table width="700" align="center" border="0" cellpadding="0" cellspacing="0">
<tr>
	<td class="TableHeaderTwoLine">
		<span class="TableName">Existing forums</span>
		<br>
		<span class="TableDescription">The list of existing forums in the forum system, including the sections they're in.</span>
	</td>
</tr>
<tr>
	<td class="TableContent">
		<table width="698" align="center" border="0" cellpadding="2" cellspacing="0">
		<tr>
			<td class="TableColumnHeader"><b>Forum name</b></td>
			<td class="TableColumnHeader" nowrap="nowrap"><b>Located in section</b></td>
			<td class="TableColumnHeader" nowrap="nowrap">Order no.</td>
			<td class="TableColumnHeader">&nbsp;</td>
		</tr>
		
		<asp:repeater ID="rpForums" Runat="server">
			<itemtemplate>
			<tr>
				<td class="TableRow LightBackground">
					<b><%#Eval("ForumName") %></b><br>
					<span class="SmallFontSmallest"><%#Eval("ForumDescription")%></span>
				</td>
				<td class="TableRow LightBackground" valign="top">
					<%#Eval("SectionName") %><br>
				</td>
				<td class="TableRow LightBackground" valign="top">
					<%#Eval("ForumOrderNo") %><br>
				</td>
				<td width="150" class="TableRow LightBackground" valign="top">
					<asp:button CssClass="FormButtons" ID="btnModify" CommandName="Modify" Text="Modify" runat="server" CommandArgument='<%# Eval("ForumID") %>'/>&nbsp;&nbsp;
					<asp:button CssClass="FormButtons" ID="btnDelete" CommandName="Delete" Text="Delete" runat="server" CommandArgument='<%# Eval("ForumID") %>'/>
				</td>
			</tr>
			</itemtemplate>
			
			<alternatingitemtemplate>
			<tr>
				<td class="TableRow DarkBackground">
					<b><%#Eval("ForumName") %></b><br>
					<span class="SmallFontSmallest"><%#Eval("ForumDescription")%></span>
				</td>
				<td class="TableRow DarkBackground" valign="top">
					<%#Eval("SectionName") %><br>
				</td>
				<td class="TableRow DarkBackground" valign="top">
					<%#Eval("ForumOrderNo") %><br>
				</td>
				<td width="150" class="TableRow DarkBackground" valign="top">
					<asp:button CssClass="FormButtons" ID="btnModify" CommandName="Modify" Text="Modify" runat="server" CommandArgument='<%# Eval("ForumID") %>'/>&nbsp;&nbsp;
					<asp:button CssClass="FormButtons" ID="btnDelete" CommandName="Delete" Text="Delete" runat="server" CommandArgument='<%# Eval("ForumID") %>'/>
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