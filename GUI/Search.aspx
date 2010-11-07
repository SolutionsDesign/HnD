<%@ Register TagPrefix="HnD" TagName="PageHeader" Src="Header.ascx"%>
<%@ Page language="c#" CodeFile="Search.aspx.cs" AutoEventWireup="false" Inherits="SD.HnD.GUI.Search"  ValidateRequest="false"%>
<%@ Register TagPrefix="HnD" TagName="PageFooter" Src="Footer.ascx"%>
<%@ Import namespace="System.Data" %>
<!doctype HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
  <head runat="server">
	<title>HnD::Search</title>
	<meta name="vs_defaultClientScript" content="JavaScript">
	<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">

	<script LANGUAGE="javascript">
		function SetFocus()
		{
			document.forms[0].elements.tbxSearchString.focus();
		}
	</script>
</head>
<body onload="SetFocus();">
<form id="EditProfile" method="post" runat="server">
<table align="center" border="0" cellpadding="0" cellspacing="0" width="750">
<hnd:pageheader runat="server" id="PageHeader" />
</table>
<br clear="all"><br>
<table align="center" cellpadding="0" cellspacing="0" width="750">
<tr>
	<td>
		<asp:validationsummary EnableClientScript="False" id="vsErrors" runat="server" headertext="The following errors occured / you have to provide a value for the following fields:"/>
	</td>
</tr>
</table>
<table align="center" class="ExplanationBox" cellpadding="0" cellspacing="0" width="750">
<tr>
	<td>
		<table width="748" border="0" cellpadding="1" cellspacing="1" align="center">
		<tr>
			<td colspan="2" class="TableColumnHeader">Your search query</td>
		</tr>
		<tr>
			<td width="170" align="right">Search string&nbsp;</td>
			<td>
				<input type="text" id="tbxSearchString" runat="server" name="tbxSearchString" maxlength="200" size="50" class="Inputborder">&nbsp;
				<asp:requiredfieldvalidator id="rfvSearchString" runat="server" ErrorMessage="Search string" ControlToValidate="tbxSearchString" display="None" width="31px"/>
			</td>
		</tr>
		<tr>
			<td width="170" align="right">Element to search&nbsp;</td>
			<td>
				<asp:dropdownlist ID="cbxElementToSearch" runat="server">
					<asp:ListItem Value="MessageText" Selected="true">Message text</asp:ListItem>
					<asp:ListItem Value="ThreadSubject">Thread subject</asp:ListItem>
					<asp:ListItem Value="MessageTextAndThreadSubject">Message text and thread subject</asp:ListItem>
				</asp:dropdownlist>
			</td>
		</tr>
		<tr>
			<td width="170" valign="top" align="right">Forums to search in&nbsp;<br>
			(Hold Ctrl to select more)&nbsp;</td>
			<td valign="top">
				<asp:listbox Runat="server" ID="lbxForums" Rows="11" CssClass="Inputborder" SelectionMode="Multiple"/>
			</td>
		</tr>
		<tr>
			<td width="170" valign="top" align="right">Sort by&nbsp;</td>
			<td>
				<asp:dropdownlist id="cbxSortByFirstElement" runat="server">
					<asp:listitem value="LastPostDateDescending">Last post date, descending</asp:listitem>
					<asp:listitem value="LastPostDateAscending">Last post date, ascending</asp:listitem>
					<asp:listitem selected="True" value="ForumAscending">Forum, ascending</asp:listitem>
					<asp:listitem value="ForumDescending">Forum, descending</asp:listitem>
					<asp:listitem value="ThreadSubjectAscending">Thread subject, ascending</asp:listitem>
					<asp:listitem value="ThreadSubjectDescending">Thread subject, descending</asp:listitem>
				</asp:dropdownlist><br>
				And<br>
				<asp:dropdownlist id="cbxSortBySecondElement" runat="server">
					<asp:listitem selected="True" value="LastPostDateDescending">Last post date, descending</asp:listitem>
					<asp:listitem value="LastPostDateAscending">Last post date, ascending</asp:listitem>
					<asp:listitem value="ForumAscending">Forum, ascending</asp:listitem>
					<asp:listitem value="ForumDescending">Forum, descending</asp:listitem>
					<asp:listitem value="ThreadSubjectAscending">Thread subject, ascending</asp:listitem>
					<asp:listitem value="ThreadSubjectDescending">Thread subject, descending</asp:listitem>
				</asp:dropdownlist>
			</td>
		</tr>
		<tr>
			<td width="170">&nbsp;</td>
			<td>
				<hr align="left" size="1" width="80%">
				<input type="submit" id="btnSearch" runat="server" name="btnSearch" value="   Search!   " class="FormButtons">
			</td>
		</tr>
		</table>
	</td>
</tr>
</table>
<br clear="all"><br>
<table width="750" align="center" class="ExplanationBox" cellpadding="2" cellspacing="0">
<tr>
	<td>
		<b>Search.</b>
		<p>
			Above you can specify your search query, which element to search and in which forums you want to search. If you do not select a 
			forum, all forums are searched.	You can specify 'AND', 'OR', 'AND NOT' and 'OR NOT' to specify your query arguments. 
			If no operator is specified, AND is assumed, so you don't have to 
			specify it explicitly. Specifying 'OR' will search for either of the two terms it's placed in between.<br>
			This searchengine uses SqlServer full text search together with LLBLGen Pro code to search through the 
			<asp:label id="lblNumberOfPosts" runat="server"/> posts on this forum, using CONTAINS queries. The forum search engine therefore accepts
			queries which are valid CONTAINS queries. Below is a brief help on the basic syntaxis of CONTAINS queries. You can also consult the CONTAINS
			reference documentation in SqlServer Books Online, if you have access to that documentation, for the more advanced elements of the
			syntaxis of CONTAINS queries.
			<br><br>
			The search engine will at most return 500 hits. If you receive 500 hits, please refine your query. A search in both message text and thread subject
			will likely result in more results and this search is also slower. 
			<br><br>
			<b>Query syntaxis</b><br>
			You can use exact index searching by specifying the terms you're looking for, like <i>Entity</i> or <i>Prefetch</i>, which will exactly match with 
			<i>Entity</i> and <i>Prefetch</i>. If you want to use wild-cards, you can. For example <i>Entity*</i> will match with <i>Entity</i> but also with
			EntityClass, EntityMethod but not with MyEntity. To find <i>MyEntity</i> as well, specify <i>*Entity*</i>. <br>
			You can also use <i>phrases</i>, to search for "Entity Collection" for example. Simply enclose any text that you want to search for which contains
			spaces with double quotes. To search for a word near another word, you can use the keyword 'NEAR': Entity NEAR collection, which search for 'Entity' 
			and 'Collection', and will favor messages which contain these words closer together over messages which have these words far apart from eachother. 
			<br><br>
			The search results consists of links to threads with messages matching the search query. All threads open in a new window. At most 500 threads
			are made available to you in the search result page. In the case of a lot of search results, you're adviced to specify more search terms to narrow 
			down the resultset. The search is case-insensitive.
			<br><br>
			<b>Examples:</b><br>
			<i>Prefetch AND Path</i> (which results in all messages with 'Prefetch' and 'Path') Equals to: <i>Prefetch Path</i><br>
			<i>Prefetch OR Path</i> (which results in all messages with 'Prefetch' or 'Path' or both)<br>
			<i>Prefetch Path*</i> (which results in all messages with 'Prefetch' and all known words starting with 'Path')<br>
			<i>Entity Prefetch OR Path</i> (which results in all messages with 'Entity', and either 'Prefetch' or 'Path' or both)<br>
			<i>"Entity Collection"</i> (which results in all messages with 'Entity Collection', including the space)<br>
			<br>
			<b>Note:</b> The search engine uses a list of words which are ignored. Please click 
			<a href="IgnoredSearchWords.aspx" target="_blank">here</a> to check this list. If you perform a search with a reserved word and the AND operator,
			no rows are returned, as it will not return in any hits. 			
		</p>
	</td>
</tr>
</table>
</form>
<br clear="all">
<!-- footer -->
<hnd:pagefooter runat="server" id="PageFooter" />
</body>
</html>
