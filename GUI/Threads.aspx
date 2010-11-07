<%@ Page language="c#" CodeFile="Threads.aspx.cs" AutoEventWireup="false" Inherits="SD.HnD.GUI.Threads" %>
<%@ Import namespace="System.Web" %>
<%@ Import Namespace="System.Globalization" %>
<%@ Import Namespace="SD.HnD.GUI" %>
<%@ Register TagPrefix="HnD" TagName="PageFooter" Src="Footer.ascx"%>
<%@ Register TagPrefix="HnD" TagName="PageHeader" Src="Header.ascx"%>
<%@ Register TagPrefix="HnD" TagName="PageList" Src="PageList.ascx"%>
<%@ Register TagPrefix="HnD" TagName="PageLegend" Src="PageLegend.ascx"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
  <head runat="server">
	<title>HnD::List all threads of forum: <%=base.ForumName%></title>
  </head>
<body>
<!-- header, menu and title -->
<form runat="server" ID="Form1">
<table width="750" align="center" border="0" cellpadding="0" cellspacing="0">
<hnd:pageheader runat="server" id="PageHeader" />
</table>
<table width="750" align="center" border="0" cellpadding="0" cellspacing="0">
<tr>
	<td class="SmallFontSmallest">
		<br><br>
		You are here: <b><a href="Default.aspx">Home</a> &gt; <asp:label ID="lblSectionName" Runat="server" /> &gt; <asp:label ID="lblForumName" Runat="server" /></b>
		<br><br>
	</td>
	<td  align="right" valign="bottom">
		<asp:hyperlink ID="lnkNewThreadTop" NavigateUrl="NewThread.aspx" Runat="server" title="Create a new thread on this forum.">New Thread</asp:hyperlink>&nbsp;
	</td>
</tr>
<tr>
	<td colspan="2"><img src="pics/separator.gif" height="3" border="0"></td>
</tr>
</table>
<!-- thread list -->
<table width="750" align="center" border="0" cellpadding="0" cellspacing="0">
<tr>
	<td class="TableHeaderTwoLine">
		<span class="TableName"><asp:hyperlink ID="lnkForumRSS" Runat="server" NavigateUrl="Rssforum.aspx"><asp:Image runat="server" SkinID="imgButtonRss"/></asp:hyperlink><asp:literal runat="server" id="litRssButtonSpacer" visible="True">&nbsp;&nbsp;</asp:literal><asp:label ID="lblForumName_Header" Runat="server" /></span>
		<br />
		<span class="TableDescription"><asp:label ID="lblForumDescription" Runat="server" /></span>
	</td>
</tr>
<tr>
	<td class="TableContent">
		<asp:repeater ID="rpThreads" EnableViewState="False" Runat="server">
			<headertemplate>
				<table width="748" align="center" border="0" cellpadding="1" cellspacing="0">
				<tr>
					<td class="TableColumnHeader" width="20" nowrap="nowrap">&nbsp;</td>
					<td class="TableColumnHeader" width="435">Thread subject</td>
					<td class="TableColumnHeader" width="60" align="center">Replies</td>
					<td class="TableColumnHeader" width="60" align="center">Views</td>
					<td class="TableColumnHeader" width="168">Last post</td>
				</tr>
			</headertemplate>

			<itemtemplate>
				<tr>
					<td class="TableRow LightBackground" align="center" valign="top" width="20" nowrap>
						<asp:image id="imgIconNewPostsSticky" SkinID="imgIconNewPostsSticky" Visible="False" RunAt="server"/>
						<asp:image ID="imgIconNoNewPostsSticky" SkinID="imgIconNoNewPostsSticky" Visible="False" RunAt="server"/>
						<asp:image ID="imgIconNewPosts" SkinID="imgIconNewPosts" Visible="False" RunAt="server"/>
						<asp:image ID="imgIconNoNewPosts" SkinID="imgIconNoNewPosts" Visible="False" RunAt="server"/>
						<asp:image ID="imgIconNewPostsClosed" SkinID="imgIconNewPostsClosed" Visible="False" RunAt="server"/>
						<asp:image ID="imgIconNoNewPostsClosed" SkinID="imgIconNoNewPostsClosed" Visible="False" RunAt="server"/>
					</td>
					<td class="TableRow LightBackground" width="435">
						<asp:image id="imgThreadDone" Skinid="imgThreadDoneSmall" visible='<%# (bool)Eval("MarkedAsDone") %>' runat="server" />
						<asp:image id="imgThreadNotDone" skinid="imgThreadNotDoneSmall" visible='<%# !(bool)Eval("MarkedAsDone") %>' runat="server" />
						<asp:hyperlink ID="lnkThread" NavigateUrl='<%# "Messages.aspx?ThreadID=" + Eval("ThreadID")%>' Runat="server" cssclass="ThreadSubjectLink" title="View thread's messages"><%# HttpUtility.HtmlEncode((string)Eval("Subject"))%></asp:hyperlink>
						&nbsp;&nbsp;&nbsp;<hnd:pagelist runat="server" id="plPageListItem" IsOnThreadsPage="true" UseCommaAsSeparator="true" AmountMessages='<%# Eval("AmountMessages") %>' ThreadID='<%# Eval("ThreadID") %>' Visible='<%# (SessionAdapter.GetUserDefaultNumberOfMessagesPerPage() < (int)Eval("AmountMessages")) %>'/>
						<div align="left" class="SmallFontThreadList">Started by: <asp:hyperlink id="lnkPoster" navigateurl='<%# "Profile.aspx?UserID=" + Eval("StartedByUserID") %>' target="_blank" cssclass="LinkNoUnderline" runat="server" title="View profile"><%# HttpUtility.HtmlEncode((string)Eval("NickName"))%></asp:hyperlink></div>
					</td>
					<td class="TableRow LightBackground" width="60" align="center" valign="top"><%# ((int)Eval("AmountMessages"))-1%></td>
					<td class="TableRow LightBackground" width="60" align="center" valign="top"><%# Eval("NumberOfViews")%></td>
					<td class="TableRow LightBackground" width="168" valign="top">
						<div align="left" class="SmallFontThreadList">By: <b><asp:hyperlink ID="lnkPosterLastPosting" NavigateUrl='<%# "Profile.aspx?UserID=" + Eval("LastPostingByUserID") %>' Target="_blank" CssClass="LinkNoUnderline" Runat="server" title="View profile"><%# HttpUtility.HtmlEncode((string)Eval("NickNameLastPosting"))%></asp:hyperlink></b><br />
						On: <asp:hyperlink id="lnkGotoLastPosting" navigateurl='<%# string.Format("GotoMessage.aspx?ThreadID={0}&MessageID={1}", Eval("ThreadID"), Eval("LastMessageID")) %>' runat="server" cssclass="LinkNoUnderline" title="Goto last post"><asp:label ID="lblThreadLastPostingDate" Runat="server" Text='<%# ((DateTime)Eval("ThreadLastPostingDate")).ToString("dd-MMM-yyyy HH:mm", DateTimeFormatInfo.InvariantInfo) %>'/></asp:hyperlink></div>
					</td>
				</tr>
			</itemtemplate>		
		
			<alternatingitemtemplate>
				<tr>
					<td class="TableRow DarkBackground" align="center" valign="top" width="20" nowrap>
						<asp:image id="imgIconNewPostsSticky" SkinID="imgIconNewPostsStickyAlt" Visible="False" RunAt="server"/>
						<asp:image ID="imgIconNoNewPostsSticky" SkinID="imgIconNoNewPostsStickyAlt" Visible="False" RunAt="server"/>
						<asp:image ID="imgIconNewPosts" SkinID="imgIconNewPostsAlt" Visible="False" RunAt="server"/>
						<asp:image ID="imgIconNoNewPosts" SkinID="imgIconNoNewPostsAlt" Visible="False" RunAt="server"/>
						<asp:image ID="imgIconNewPostsClosed" SkinID="imgIconNewPostsClosedAlt" Visible="False" RunAt="server"/>
						<asp:image ID="imgIconNoNewPostsClosed" SkinID="imgIconNoNewPostsClosedAlt" Visible="False" RunAt="server"/>
					</td>
					<td class="TableRow DarkBackground" width="435">
						<asp:image id="imgThreadDone" Skinid="imgThreadDoneSmall" visible='<%# (bool)Eval("MarkedAsDone") %>' runat="server" />
						<asp:image id="imgThreadNotDone" skinid="imgThreadNotDoneSmall" visible='<%# !(bool)Eval("MarkedAsDone") %>' runat="server" />
						<asp:hyperlink ID="lnkThread" NavigateUrl='<%# "Messages.aspx?ThreadID=" + Eval("ThreadID")%>' Runat="server" cssclass="ThreadSubjectLink" title="View thread's messages"><%# HttpUtility.HtmlEncode((string)Eval("Subject"))%></asp:hyperlink>
						&nbsp;&nbsp;&nbsp;<hnd:pagelist runat="server" id="plPageListItem" IsOnThreadsPage="true" UseCommaAsSeparator="true" AmountMessages='<%# Eval("AmountMessages") %>' ThreadID='<%# Eval("ThreadID") %>' Visible='<%# (SessionAdapter.GetUserDefaultNumberOfMessagesPerPage() < (int)Eval("AmountMessages")) %>'/>
						<div align="left" class="SmallFontThreadList">Started by: <asp:hyperlink id="lnkPoster" navigateurl='<%# "Profile.aspx?UserID=" + Eval("StartedByUserID") %>' target="_blank" cssclass="LinkNoUnderline" runat="server" title="View profile"><%# HttpUtility.HtmlEncode((string)Eval("NickName"))%></asp:hyperlink></div>
					</td>
					<td class="TableRow DarkBackground" width="60" align="center" valign="top"><%# ((int)Eval("AmountMessages"))-1%></td>
					<td class="TableRow DarkBackground" width="60" align="center" valign="top"><%# Eval("NumberOfViews")%></td>
					<td class="TableRow DarkBackground" width="168" valign="top">
						<div align="left" class="SmallFontThreadList">By: <b><asp:hyperlink ID="lnkPosterLastPosting" NavigateUrl='<%# "Profile.aspx?UserID=" + Eval("LastPostingByUserID") %>' Target="_blank" CssClass="LinkNoUnderline" Runat="server" title="View profile"><%# HttpUtility.HtmlEncode((string)Eval("NickNameLastPosting"))%></asp:hyperlink></b><br />
						On: <asp:hyperlink id="lnkGotoLastPosting" navigateurl='<%# string.Format("GotoMessage.aspx?ThreadID={0}&MessageID={1}", Eval("ThreadID"), Eval("LastMessageID")) %>' runat="server" cssclass="LinkNoUnderline" title="Goto last post"><asp:label ID="lblThreadLastPostingDate" Runat="server" Text='<%# ((DateTime)Eval("ThreadLastPostingDate")).ToString("dd-MMM-yyyy HH:mm", DateTimeFormatInfo.InvariantInfo) %>'/></asp:hyperlink></div>
					</td>
				</tr>
			</alternatingitemtemplate>

			<footertemplate>
				</table>
			</footertemplate>
		</asp:repeater></TD></TR>
<tr>
	<td class="EmptyRowBottom" height="5"><img src="pics/separator.gif" border="0"></td>
</tr>
</table>
<table width="750" align="center" border="0" cellpadding="1" cellspacing="0">
<tr>
	<td width="20">&nbsp;</td>
	<td>
		<asp:hyperlink ID="lnkNewThreadBottom" NavigateUrl="NewThread.aspx" Runat="server" title="Create a new thread on this forum.">New Thread</asp:hyperlink>
	</td>
	<td class="SmallFontSmallest" align="right" valign="middle">
		Show threads of&nbsp;
		<asp:dropdownlist ID="cbxThreadListInterval" Runat="server" AutoPostBack="True">
			<asp:listitem value="1">...last 24 hours</asp:listitem>
			<asp:listitem value="2">...last 48 hours</asp:listitem>
			<asp:listitem value="3">...last week</asp:listitem>
			<asp:listitem value="4">...last month</asp:listitem>
			<asp:listitem value="5">...last year</asp:listitem>
		</asp:dropdownlist>
	</td>
</tr>
</table>
<hnd:pagelegend runat="server" id="PageLegend" />
<br clear="all">
<br clear="all">
<!-- footer -->
<hnd:pagefooter runat="server" id="PageFooter" />
</form>
</body>
</html>
