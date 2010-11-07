<%@ Page language="c#" CodeFile="ModifyDeleteSection.aspx.cs" AutoEventWireup="false" Inherits="SD.HnD.GUI.Admin.ModifyDeleteSection" 
	MasterPageFile="~/Admin/AdminMaster.master" Title="HnD::Administrate::Modify / Delete a section"%>

<asp:Content ContentPlaceHolderID="phMainContent" runat="server">
<table width="700" align="center" class="ExplanationBox" cellpadding="2" cellspacing="0">
<tr>
	<td>
		<h3>Modify / delete a section</h3>
		Below you'll find all existing sections in the system. Modifying a section means you can change the name and the
		description. You can only delete a section if there are no forums in that section. The sections you can delete have a delete-button, others lack that
		button.
	</td>
</tr>
</table>
<br clear="all"><br>
<table width="700" align="center" border="0" cellpadding="0" cellspacing="0">
<tr>
	<td class="TableHeaderTwoLine">
		<span class="TableName">Existing sections</span>
		<br>
		<span class="TableDescription">The list of existing sections in the forum system.</span>
	</td>
</tr>
<tr>
	<td class="TableContent">
		<asp:repeater ID="rpSections" Runat="server">
			<HeaderTemplate>
				<table width="698" align="center" border="0" cellpadding="2" cellspacing="0">
				<tr>
					<td class="TableColumnHeader">Section Name</td>
					<td class="TableColumnHeader" nowrap="nowrap">Sort-order no.</td>
					<td class="TableColumnHeader">&nbsp;</td>
				</tr>
			</HeaderTemplate>
			<itemtemplate>
			<tr>
				<td class="TableRow LightBackground">
					<b><%#Eval("SectionName") %></b><br>
					<span class="SmallFontSmallest"><%#Eval("SectionDescription")%></span>
				</td>
				<td class="TableRow LightBackground" valign="top">
					<%#Eval("OrderNo") %><br>
				</td>
				<td width="150" class="TableRow LightBackground" valign="top">
					<asp:button CssClass="FormButtons" ID="btnModify" CommandName="Modify" Text="Modify" runat="server" CommandArgument='<%# Eval("SectionID") %>'/>&nbsp;&nbsp;
					<asp:button CssClass="FormButtons" ID="btnDelete" CommandName="Delete" Text="Delete" runat="server" 
						CommandArgument='<%# Eval("SectionID") %>' Visible='<%# ((int)Eval("AmountForums") <= 0) %>'/>
				</td>
			</tr>
			</itemtemplate>
			
			<alternatingitemtemplate>
			<tr>
				<td class="TableRow DarkBackground">
					<b><%#Eval("SectionName") %></b><br>
					<span class="SmallFontSmallest"><%#Eval("SectionDescription")%></span>
				</td>
				<td class="TableRow DarkBackground" valign="top">
					<%#Eval("OrderNo") %><br>
				</td>
				<td width="150" class="TableRow DarkBackground" valign="top">
					<asp:button CssClass="FormButtons" ID="btnModify" CommandName="Modify" Text="Modify" runat="server" CommandArgument='<%# Eval("SectionID") %>'/>&nbsp;&nbsp;
					<asp:button CssClass="FormButtons" ID="btnDelete" CommandName="Delete" Text="Delete" runat="server" 
						CommandArgument='<%# Eval("SectionID") %>' Visible='<%# ((int)Eval("AmountForums") <= 0) %>'/>
				</td>
			</tr>
			</alternatingitemtemplate>
			<FooterTemplate>
				</table>
			</FooterTemplate>
		</asp:repeater>
	</td>
</tr>
<tr><td class="EmptyRowBottom">&nbsp;</td></tr>
</table>
</asp:Content>