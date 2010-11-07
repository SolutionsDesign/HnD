<%@ Page language="c#" CodeFile="default.aspx.cs" AutoEventWireup="false" Inherits="SD.HnD.GUI._default" EnableViewState="false" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="SD.HnD.DAL.EntityClasses" %>
<%@ Import Namespace="SD.HnD.GUI" %>
<%@ Register TagPrefix="HnD" TagName="PageFooter" Src="Footer.ascx"%>
<%@ Register TagPrefix="HnD" TagName="PageHeader" Src="Header.ascx"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head runat="server">
		<title>HnD::</title>
	</head>
<body>
<form runat="server" ID="Form1">
<!-- header, menu and title -->
<table width="760" align="center" border="0" cellpadding="0" cellspacing="0">
<hnd:pageheader runat="server" id="PageHeader" />
<tr>
	<td>
		<br clear="all"/>
		<table border="0" width="100%" class="WelcomeBox">
		<tr>
			<td width="10">&nbsp;</td>
			<td>
				<br>
				Welcome	<b><asp:label Runat="server" ID="lblUserName" Visible="True" /></b>!
				<br>
				<asp:label runat="server" ID="lblWelcomeTextNotLoggedIn" Visible="False">
				Below, you'll find several sections and forums where you can discuss all kinds of topics, if
				you're a registered user and if you've <a href="login.aspx">logged in</a>.
				<br>
				If you're not a registered user, you can register <a href="register.aspx">here</a>.
				</asp:label>
				<asp:label runat="server" ID="lblWelcomeTextLoggedIn" Visible="False">
				Below you'll find several sections and forums where you can discuss all kinds of topics.
				</asp:label>
				<br><br>
				<asp:PlaceHolder ID="phLastVisitDate" runat="server" Visible="false">
					Your last session here started on: <b><asp:label Runat="server" ID="lblLastVisitDate"/></b>
					<br><br>
				</asp:PlaceHolder>
				<asp:PlaceHolder id="phAttentionRemarks" runat="server" Visible="false">
					<asp:PlaceHolder ID="phAttachmentsToApprove" runat="server" Visible="false">
						There are attachments <a href="ApproveAttachments.aspx">waiting for approval</a>. <br>
					</asp:PlaceHolder>
					<asp:PlaceHolder ID="phThreadsToSupport" runat="server" Visible="false">
						There are threads <a href="SupportQueues.aspx">waiting in the support queues</a>. <br>
					</asp:PlaceHolder>
					<br>
				</asp:PlaceHolder>
			</td>
		</tr>
		</table>
		<br clear="all"/>
	</td>
</tr>
</table>
<!-- forum sections with forums -->
<asp:repeater ID="rpSections" Runat="server" OnItemDataBound="rpSections_ItemDataBound">
	<headertemplate>
		<table width="760" align="center" border="0" cellpadding="0" cellspacing="0">
	</headertemplate>

	<itemtemplate>
		<tr>
			<td nowrap="nowrap" width="100%">
				<table width="100%" border="0" cellpadding="0" cellspacing="0">
					<tr>
						<td class="TableHeaderTwoLine" align="left" valign="top">
							<span class="TableName"><%#Eval("SectionName")%></span>
							<br />
							<span class="TableDescription"><%#Eval("SectionDescription")%></span>
						</td>
						<td class="TableHeaderTwoLine" nowrap="nowrap" align="right" valign="middle">
							<div id='<%# Eval("SectionName", "Expand{0}") %>' style="display:none;">
								<a href="javascript:stateObject.toggle('<%#Eval("SectionName")%>');"><asp:Image skinid="imgButtonExpand" runat="server"/></a>&nbsp;
							</div>
							<div id='<%# Eval("SectionName", "Collapse{0}") %>'>
								<a href="javascript:stateObject.toggle('<%#Eval("SectionName")%>');"><asp:Image skinid="imgButtonCollapse" runat="server"/></a>&nbsp;
							</div>
						</td>
					</tr>
				</table>
			</td>
		</tr>
		<tr>
			<td class="TableContent">
			<div id="<%#Eval("SectionName")%>">
				<asp:repeater ID="rpForums" Runat="server" OnItemDataBound="rpForums_ItemDataBound">
					<headertemplate>
						<table width="758" align="center" border="0" cellpadding="1" cellspacing="0">
						<tr>
							<td class="TableColumnHeader" width="20">&nbsp;</td>
							<td class="TableColumnHeader" width="448">Forum</td>
							<td class="TableColumnHeader" width="80" align="center">Threads</td>
							<td class="TableColumnHeader" width="80" align="center">Posts</td>
							<td class="TableColumnHeader" width="130">Last post</td>
						</tr>
					</headertemplate>
					
					<footertemplate>
						</table>
					</footertemplate>
					
					<itemtemplate>
						<tr>
							<td class="TableRow LightBackground" align="center" valign="top" width="20">
								<asp:image hspace="3" align="center" SkinId="imgIconNoNewPosts" ID="imgIconNoNewPosts" Runat="server" Visible="False"/>
								<asp:image hspace="3" align="center" SkinId="imgIconNewPosts" ID="imgIconNewPosts" Runat="server" Visible="False"/>
							</td>
							<td class="TableRow LightBackground" width="448">
								&nbsp;<asp:hyperlink ID="lnkForumRSS" Runat="server" Visible='<%# (bool)Eval("HasRSSFeed") %>' NavigateUrl='<%# "RssForum.aspx?ForumID=" + Eval("ForumID") %>'><asp:Image runat="server" SkinID="imgButtonRss"/></asp:hyperlink><asp:literal runat="server" id="litRssButtonSpacer" Visible='<%# (bool)Eval("HasRSSFeed") %>'>&nbsp;&nbsp;</asp:literal><asp:hyperlink Runat="server" ID="lnkThreadList" NavigateUrl='<%# "Threads.aspx?ForumID=" + Eval("ForumID") %>'><%# Eval("ForumName")%></asp:hyperlink><br>
								<span class="SmallFontSmallest"><%# Eval("ForumDescription")%></span>
							</td>
							<td class="TableRow LightBackground" align="center" valign="top"><%# Eval("AmountThreads")%></td>
							<td class="TableRow LightBackground" align="center" valign="top"><%# Eval("AmountMessages")%></td>
							<td class="TableRow LightBackground" valign="top"><asp:label ID="lblForumLastPostingDate" Runat="server" /></td>
						</tr>
					</itemtemplate>
					
					<alternatingitemtemplate>
						<tr>
							<td class="TableRow DarkBackground" align="center" valign="top" width="20">
								<asp:image hspace="3" align="center" SkinId="imgIconNoNewPostsAlt" ID="imgIconNoNewPosts" Runat="server" Visible="False"/>
								<asp:image hspace="3" align="center" SkinId="imgIconNewPostsAlt" ID="imgIconNewPosts" Runat="server" Visible="False"/>							</td>
							<td class="TableRow DarkBackground" width="448">
								&nbsp;<asp:hyperlink ID="lnkForumRSS" Runat="server" Visible='<%# (bool)Eval("HasRSSFeed") %>' NavigateUrl='<%# "RssForum.aspx?ForumID=" + Eval("ForumID") %>'><asp:Image runat="server" SkinID="imgButtonRss"/></asp:hyperlink><asp:literal runat="server" id="litRssButtonSpacer" Visible='<%# (bool)Eval("HasRSSFeed") %>'>&nbsp;&nbsp;</asp:literal><asp:hyperlink Runat="server" NavigateUrl='<%# "Threads.aspx?ForumID=" + Eval("ForumID") %>' ID="lnkThreadList"><%# Eval("ForumName")%></asp:hyperlink><br>
								<span class="SmallFontSmallest"><%# Eval("ForumDescription")%></span>
							</td>
							<td class="TableRow DarkBackground" align="center" valign="top"><%# Eval("AmountThreads")%></td>
							<td class="TableRow DarkBackground" align="center" valign="top"><%# Eval("AmountMessages")%></td>
							<td class="TableRow DarkBackground" valign="top"><asp:label ID="lblForumLastPostingDate" Runat="server" /></td>
						</tr>
					</alternatingitemtemplate>
					
				</asp:repeater>
			</div>
			</td>
		</tr>
	</itemtemplate>
	
	<separatortemplate>
		<tr><td class="EmptyRowOnlyTopBorder">&nbsp;</td></tr>
	</separatortemplate>

	<footertemplate>
		<tr><td class="EmptyRowBottom">&nbsp;</td></tr>
		</table>
	</footertemplate>
</asp:repeater>
<table width="760" align="center" border="0" cellpadding="0" cellspacing="0">
<tr>
	<td class="TableHeaderOneLine">
		<span class="TableName">Easy Access</span>
	</td>
</tr>
<tr>
	<td class="TableContent">
		<table width="758" align="center" border="0" cellpadding="1" cellspacing="0">
		<tr>
			<td class="TableColumnHeader" width="20">&nbsp;</td>
			<td class="TableColumnHeader" width="448">&nbsp;</td>
			<td class="TableColumnHeader" width="80" align="center">Threads</td>
			<td class="TableColumnHeader" width="80" align="center">Posts</td>
			<td class="TableColumnHeader" width="130">Last post</td>
		</tr>
		<tr>
			<td class="TableRow LightBackground" align="center" valign="top" width="20">
				<asp:image hspace="3" align="center" SkinId="imgIconNoNewPosts" ID="imgIconBookmarkNoNewPosts" Runat="server" Visible="False" enableviewstate="False"/>
				<asp:image hspace="3" align="center" SkinId="imgIconNewPosts" ID="imgIconBookmarkNewPosts" Runat="server" Visible="False" enableviewstate="False"/>
			</td>
			<td class="TableRow LightBackground" width="448">
				&nbsp;<asp:hyperlink runat="server" enableviewstate="False" id="lnkBookmarkThreadList" navigateurl="Bookmarks.aspx">View / edit my bookmarks</asp:hyperlink><br>
				&nbsp;<span class="SmallFontSmallest">Enables you to view / edit the list of your bookmarked threads.</span>
			</td>
			<td class="TableRow LightBackground" align="center" valign="top"><asp:label id="lblAmountBookmarks" runat="server" /></td>
			<td class="TableRow LightBackground" align="center" valign="top"><asp:label id="lblAmountPostingsInBookmarks" runat="server" /></td>
			<td class="TableRow LightBackground" valign="top"><asp:label id="lblBookmarksLastPostingDate" runat="server" /></td>
		</tr>
		<tr>
			<td class="TableRow DarkBackground" align="center" valign="top" width="20">
				<asp:image hspace="3" align="center" SkinId="imgIconNoNewPostsAlt" ID="imgIconActiveThreadsNoNewPosts" Runat="server" Visible="False" enableviewstate="False"/>
				<asp:image hspace="3" align="center" SkinId="imgIconNewPostsAlt" ID="imgIconActiveThreadsNewPosts" Runat="server" Visible="False" enableviewstate="False"/>
			</td>
			<td class="TableRow DarkBackground" width="448">
				&nbsp;<asp:hyperlink runat="server" enableviewstate="False" id="lnkActiveThreadsThreadList" navigateurl="ActiveThreads.aspx">View active threads</asp:hyperlink><br>
				&nbsp;<span class="SmallFontSmallest">Enables you to view all active threads of the past <%=CacheManager.GetSystemData().HoursThresholdForActiveThreads%> hours.</span>
			</td>
			<td class="TableRow DarkBackground" align="center" valign="top"><asp:label id="lblAmountActiveThreads" runat="server" /></td>
			<td class="TableRow DarkBackground" align="center" valign="top"><asp:label id="lblAmountPostingsInActiveThreads" runat="server" /></td>
			<td class="TableRow DarkBackground" valign="top"><asp:label id="lblActiveThreadsLastPostingDate" runat="server" /></td>
		</tr>
		</table>
	</td>
</tr>
<tr><td class="EmptyRowBottom">&nbsp;</td></tr>
</table>
<br clear="all"/>
<table width="760" align="center" border="0" cellpadding="1" cellspacing="1" class="LegendBox">
<tr>
	<td colspan="2" class="SmallFontSmallest">
		&nbsp;<b>Legend:</b>
	</td>
</tr>
<tr>
	<td width="25">&nbsp;</td>
	<td width="20" align="center"><asp:Image SkinId="imgIconNoNewPostsLegend" runat="server"/></td>
	<td class="SmallFontSmallest">No new messages since your last visit</td>
</tr>
<tr>
	<td width="25">&nbsp;</td>
	<td width="20" align="center"><asp:Image SkinId="imgIconNewPostsLegend" runat="server"/></td>
	<td class="SmallFontSmallest">New messages since your last visit</td>
</tr>

</table>
<br clear="all">
<br>
<!-- footer -->
<hnd:pagefooter runat="server" id="PageFooter" />
</form>
</body>
</html>
