<%@ Register TagPrefix="HnD" TagName="PageHeader" Src="Header.ascx"%>
<%@ Page language="c#" CodeFile="SearchResults.aspx.cs" AutoEventWireup="false" Inherits="SD.HnD.GUI.SearchResults" EnableViewState="false" %>
<%@ Register TagPrefix="HnD" TagName="PageFooter" Src="Footer.ascx"%>
<%@ Import namespace="System.Data" %>
<%@ Register TagPrefix="HnD" TagName="SearchResultPageList" Src="SearchResultPageList.ascx"%>
<!doctype html public "-//w3c//dtd html 4.0 transitional//en" >
<html>
  <head runat="server">
	<title>HnD::Search</title>
	<meta name="vs_defaultClientScript" content="JavaScript">
	<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">  </head>
<body ms_positioning="GridLayout">
<table width="90%" align="center" border="0" cellpadding="0" cellspacing="0">
<hnd:pageheader runat="server" id="PageHeader" />
</table>
<br clear="all"><br>
<form id="Form1" method="post" runat="server">
<table width="90%" align="center" border="0" cellpadding="2" cellspacing="0">
<tr>
	<td>
		<b>Search results for search on:</b> <asp:label id="lblSearchTerms" runat="server" />
<asp:panel runat="server" id="pnlSkippedWords" visible="False">
		The following words were skipped from your query, as they're <a href="IgnoredSearchWords.aspx" target="_blank">ignored words</a>: 
		<b><asp:label id="lblSkippedWords" runat="server"></asp:label></b>
</asp:panel>
	</td>
</tr>
</table>
<table align="center" border="0" width="90%">
<tr>
	<td colspan="2">
		<b>Number of threads found:</b> <asp:label id="lblAmountThreads" runat="server" /><br>
		<br>
	</td>
</tr>
<tr>
	<td>
		<hnd:searchresultpagelist runat="server" id="plPageListTop" />
	</td>
	<td align="right">
		<a href="Search.aspx">New search</a>
	</td>
</tr>
<tr>
	<td class="TableContent" colspan="2">
		<table align="center" border="0" cellpadding="2" cellspacing="0" width="100%">
		<tr>
			<td class="TableColumnHeader"><b>Thread</b></td>
			<td class="TableColumnHeader"><b>Forum</b></td>
			<td class="TableColumnHeader"><b>Last post</b></td>
		</tr>
		<asp:repeater id="rptResults" runat="server">
			<itemtemplate>
			<tr>
				<td class="TableRow LightBackground"><asp:hyperlink navigateurl='<%# "Messages.aspx?ThreadID=" + Eval("ThreadID") + "&HighLight=1" %>' target="_blank" id="lnkThread" runat="server"/></td>
				<td class="TableRow LightBackground" style="font-size:7pt;"><%#Eval("SectionName") %> - <%#Eval("ForumName") %></td>
				<td class="TableRow LightBackground"><asp:label id="lblThreadLastPostingDate" runat="server" ><%# ((DateTime)Eval("ThreadLastPostingDate")).ToString("dd-MMM-yyyy HH:mm")%></asp:label></td>
			</tr>
			</itemtemplate>
			
			<alternatingitemtemplate>
			<tr>
				<td class="TableRow DarkBackground"><asp:hyperlink navigateurl='<%# "Messages.aspx?ThreadID=" + Eval("ThreadID") + "&HighLight=1" %>' target="_blank" id="lnkThread" runat="server"/></td>
				<td class="TableRow DarkBackground" style="font-size:7pt;"><%#Eval("SectionName") %> - <%#Eval("ForumName") %></td>
				<td class="TableRow DarkBackground"><asp:label id="lblThreadLastPostingDate" runat="server"  ><%# ((DateTime)Eval("ThreadLastPostingDate")).ToString("dd-MMM-yyyy HH:mm")%></asp:label></td>
			</tr>
			</alternatingitemtemplate>
		</asp:repeater>
		</table>
	</td>
</tr>
<tr>
	<td>
		<hnd:searchresultpagelist runat="server" id="plPageListBottom" />
	</td>
	<td align="right">
		<a href="Search.aspx">New search</a>
	</td>
</tr>
</table>
</form>
<br clear="all">
<!-- footer -->
<hnd:pagefooter runat="server" id="PageFooter" />
</body>
</html>
