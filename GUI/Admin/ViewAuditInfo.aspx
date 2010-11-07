<%@ Page language="c#" CodeFile="ViewAuditInfo.aspx.cs" AutoEventWireup="false" Inherits="SD.HnD.GUI.Admin.ViewAuditInfo" 
	MasterPageFile="~/Admin/AdminMaster.master" Title="HnD::Administrate::View Audit Info for user"%>
<%@ Register TagPrefix="HnD" TagName="FindUser" Src="FindUser.ascx"%>

<asp:Content ContentPlaceHolderID="phMainContent" runat="server">
<table width="700" align="center" class="ExplanationBox" cellpadding="2" cellspacing="0">
<tr>
	<td>
		<h3>View audit info for user.</h3>
		Below you can view the audit info for a user. First select the user using the Find User portion of the form, then show the user's information.
	</td>
</tr>
</table>
<br clear="all">
<hnd:finduser runat="server" id="userFinder" MultiSelect="false" ButtonDescription="View Audit Info" OnSelectClicked="SelectClickedHandler"/>

<br clear="all">
<asp:placeholder id="phAuditInfo" visible="False" runat="server">
<table width="700" align="center" border="0" cellpadding="0" cellspacing="0">
<tr>
	<td class="TableHeaderOneLine">
		<span class="TableName">Audit information for user <asp:label runat="server" id="lblUserName"/></span>
	</td>
</tr>
<tr>
	<td class="TableContent">
		<asp:repeater id="rptAudits" runat="server" enableviewstate="False">
		<headertemplate>
			<table width="698" align="center" border="0" cellpadding="1" cellspacing="0">
			<tr>
				<td class="TableColumnHeader">Action</td>
				<td class="TableColumnHeader">Audited on</td>
				<td class="TableColumnHeader">Additional info</td>
			</tr>
		</headertemplate>

		<itemtemplate>
			<tr>
				<td class="TableRow LightBackground"><asp:label id="lblAuditAction" runat="server" /></td>
				<td class="TableRow LightBackground"><asp:label id="lblAuditDateTime" runat="server" /></td>
				<td class="TableRow LightBackground"><asp:hyperlink id="lnkAdditionalInfoLink" runat="server" visible="False" target="_blank" /></td>
			</tr>
		</itemtemplate>

		<alternatingitemtemplate>
			<tr>
				<td class="TableRow DarkBackground"><asp:label id="lblAuditAction" runat="server" /></td>
				<td class="TableRow DarkBackground"><asp:label id="lblAuditDateTime" runat="server" /></td>
				<td class="TableRow DarkBackground"><asp:hyperlink id="lnkAdditionalInfoLink" runat="server" visible="False" target="_blank" /></td>
			</tr>
		</alternatingitemtemplate>
		
		<footertemplate>
			</table>
		</footertemplate>
		</asp:repeater>
	</td>
</tr>
<tr>
	<td class="EmptyRowBottom" height="5"><img src="../pics/separator.gif" border="0"></td>
</tr>
</table>
</asp:placeholder>
</asp:Content>