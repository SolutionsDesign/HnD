<%@ Page language="c#" CodeFile="ActiveThreads.aspx.cs" AutoEventWireup="false" Inherits="SD.HnD.GUI.ActiveThreads" %>
<%@ Register TagPrefix="HnD" TagName="PageHeader" Src="Header.ascx"%>
<%@ Register TagPrefix="HnD" TagName="PageFooter" Src="Footer.ascx"%>
<%@ Register TagPrefix="HnD" TagName="PageList" Src="PageList.ascx"%>
<%@ Import namespace="System.Web" %>
<%@ Import Namespace="System.Globalization" %>
<%@ Import Namespace="SD.HnD.GUI" %>
<%@ Register TagPrefix="HnD" TagName="PageLegend" Src="PageLegend.ascx"%>
<!doctype html public "-//w3c//dtd html 4.0 transitional//en" >
<html>
  <head runat="server">
	<title>HnD::Active threads</title>
  </head>
<body>
<!-- header, menu and title -->
<form runat="server" id="Form1">
<table width="750" align="center" border="0" cellpadding="0" cellspacing="0">
<hnd:pageheader runat="server" id="PageHeader" />
<tr>
	<td class="SmallFontSmallest">
		<br>
		You are here: <b><a href="Default.aspx">Home</a> &gt; Active threads</b>
		<br><br>
	</td>
</tr>
</table>
<!-- thread list -->
<table width="750" align="center" border="0" cellpadding="0" cellspacing="0">
<tr>
	<td class="TableHeaderTwoLine">
		<span class="TableName">Active threads</span>
		<br />
		<span class="TableDescription">The list of all active threads of the past <%=CacheManager.GetSystemData().HoursThresholdForActiveThreads%> hours.</span>
	</td>
</tr>
<tr>
	<td class="TableContent">
		<asp:repeater id="rpThreads" enableviewstate="False" runat="server">
			<headertemplate>
				<table width="748" align="center" border="0" cellpadding="1" cellspacing="0">
				<tr>
					<td class="TableColumnHeader" width="20" nowrap>&nbsp;</td>
					<td class="TableColumnHeader" width="440">Thread subject</td>
					<td class="TableColumnHeader" width="60" align="center">Replies</td>
					<td class="TableColumnHeader" width="60" align="center">Views</td>
					<td class="TableColumnHeader" width="168">Last post</td>
				</tr>
			</headertemplate>

			<itemtemplate>
				<tr>
					<td class="TableRow LightBackground" align="center" valign="top" width="20" nowrap="nowrap">
						<asp:image id="imgIconNewPostsSticky" SkinID="imgIconNewPostsSticky" Visible="False" RunAt="server"/>
						<asp:image ID="imgIconNoNewPostsSticky" SkinID="imgIconNoNewPostsSticky" Visible="False" RunAt="server"/>
						<asp:image ID="imgIconNewPosts" SkinID="imgIconNewPosts" Visible="False" RunAt="server"/>
						<asp:image ID="imgIconNoNewPosts" SkinID="imgIconNoNewPosts" Visible="False" RunAt="server"/>
						<asp:image ID="imgIconNewPostsClosed" SkinID="imgIconNewPostsClosed" Visible="False" RunAt="server"/>
						<asp:image ID="imgIconNoNewPostsClosed" SkinID="imgIconNoNewPostsClosed" Visible="False" RunAt="server"/>
					</td>
					<td class="TableRow LightBackground" width="440">
						<asp:hyperlink id="lnkThread" navigateurl='<%# "Messages.aspx?ThreadID=" + Eval("ThreadID")%>' runat="server" cssclass="ThreadSubjectLink" title="View thread's messages"><%# HttpUtility.HtmlEncode((string)Eval("Subject"))%></asp:hyperlink>
						&nbsp;&nbsp;&nbsp;<hnd:pagelist runat="server" id="plPageListItem" IsOnThreadsPage="true" UseCommaAsSeparator="true" AmountMessages='<%# Eval("AmountMessages") %>' ThreadID='<%# Eval("ThreadID") %>' Visible='<%# (SessionAdapter.GetUserDefaultNumberOfMessagesPerPage() < (int)Eval("AmountMessages")) %>'/><br />
						<div align="left" class="SmallFontThreadList">Posted in forum: <asp:hyperlink runat="server" enableviewstate="False" id="lnkThreadList" navigateurl='<%# "Threads.aspx?ForumID=" + Eval("ForumID") %>'><%# Eval("ForumName")%></asp:hyperlink>.<br> 
						Started by: <asp:hyperlink id="lnkPoster" navigateurl='<%# "Profile.aspx?UserID=" + Eval("StartedByUserID") %>' target="_blank" cssclass="LinkNoUnderline" runat="server" title="View profile"><%# HttpUtility.HtmlEncode((string)Eval("NickName"))%></asp:hyperlink></div>
					</td>
					<td class="TableRow LightBackground" width="60" align="center" valign="top"><%# (int)Eval("AmountMessages") - 1%></td>
					<td class="TableRow LightBackground" width="60" align="center" valign="top"><%# Eval("NumberOfViews")%></td>
					<td class="TableRow LightBackground" width="168" valign="top">
						<div align="left" class="SmallFontThreadList">By: <b><asp:hyperlink id="lnkPosterLastPosting" navigateurl='<%# "Profile.aspx?UserID=" + Eval("LastPostingByUserID") %>' target="_blank" cssclass="LinkNoUnderline" runat="server" title="View profile"><%# HttpUtility.HtmlEncode((string)Eval("NickNameLastPosting"))%></asp:hyperlink></b><br />
						On: <asp:hyperlink id="lnkGotoLastPosting" navigateurl='<%# string.Format("GotoMessage.aspx?ThreadID={0}&MessageID={1}", Eval("ThreadID"), Eval("LastMessageID")) %>' runat="server" cssclass="LinkNoUnderline" title="Goto last post"><asp:label id="lblThreadLastPostingDate" runat="server" Text='<%# ((DateTime)Eval("ThreadLastPostingDate")).ToString("dd-MMM-yyyy HH:mm", DateTimeFormatInfo.InvariantInfo) %>' /></asp:hyperlink></div>
					</td>
				</tr>
			</itemtemplate>		
		
			<alternatingitemtemplate>
				<tr>
					<td class="TableRow DarkBackground" align="center" valign="top" width="20" nowrap="nowrap">
						<asp:image id="imgIconNewPostsSticky" SkinID="imgIconNewPostsStickyAlt" Visible="False" RunAt="server"/>
						<asp:image ID="imgIconNoNewPostsSticky" SkinID="imgIconNoNewPostsStickyAlt" Visible="False" RunAt="server"/>
						<asp:image ID="imgIconNewPosts" SkinID="imgIconNewPostsAlt" Visible="False" RunAt="server"/>
						<asp:image ID="imgIconNoNewPosts" SkinID="imgIconNoNewPostsAlt" Visible="False" RunAt="server"/>
						<asp:image ID="imgIconNewPostsClosed" SkinID="imgIconNewPostsClosedAlt" Visible="False" RunAt="server"/>
						<asp:image ID="imgIconNoNewPostsClosed" SkinID="imgIconNoNewPostsClosedAlt" Visible="False" RunAt="server"/>
					</td>
					<td class="TableRow DarkBackground" width="440">
						<asp:hyperlink id="lnkThread" navigateurl='<%# "Messages.aspx?ThreadID=" + Eval("ThreadID")%>' runat="server" cssclass="ThreadSubjectLink" title="View thread's messages"><%# HttpUtility.HtmlEncode((string)Eval("Subject"))%></asp:hyperlink>
						&nbsp;&nbsp;&nbsp;<hnd:pagelist runat="server" id="plPageListItem" IsOnThreadsPage="true" UseCommaAsSeparator="true" AmountMessages='<%# Eval("AmountMessages") %>' ThreadID='<%# Eval("ThreadID") %>' Visible='<%# (SessionAdapter.GetUserDefaultNumberOfMessagesPerPage() < (int)Eval("AmountMessages")) %>'/><br />
						<div align="left" class="SmallFontThreadList">Posted in forum: <asp:hyperlink runat="server" enableviewstate="False" id="lnkThreadList" navigateurl='<%# "Threads.aspx?ForumID=" + Eval("ForumID") %>'><%# Eval("ForumName")%></asp:hyperlink>.<br> 
						Started by: <asp:hyperlink id="lnkPoster" navigateurl='<%# "Profile.aspx?UserID=" + Eval("StartedByUserID") %>' target="_blank" cssclass="LinkNoUnderline" runat="server" title="View profile"><%# HttpUtility.HtmlEncode((string)Eval("NickName"))%></asp:hyperlink></div>
					</td>
					<td class="TableRow DarkBackground" width="60" align="center" valign="top"><%# (int)Eval("AmountMessages") - 1%></td>
					<td class="TableRow DarkBackground" width="60" align="center" valign="top"><%# Eval("NumberOfViews")%></td>
					<td class="TableRow DarkBackground" width="168" valign="top">
						<div align="left" class="SmallFontThreadList">By: <b><asp:hyperlink id="lnkPosterLastPosting" navigateurl='<%# "Profile.aspx?UserID=" + Eval("LastPostingByUserID") %>' target="_blank" cssclass="LinkNoUnderline" runat="server" title="View profile"><%# HttpUtility.HtmlEncode((string)Eval("NickNameLastPosting"))%></asp:hyperlink></b><br />
						On:	<asp:hyperlink id="lnkGotoLastPosting" navigateurl='<%# string.Format("GotoMessage.aspx?ThreadID={0}&MessageID={1}", Eval("ThreadID"), Eval("LastMessageID")) %>' runat="server" cssclass="LinkNoUnderline" title="Goto last post"><asp:label id="lblThreadLastPostingDate" runat="server" Text='<%# ((DateTime)Eval("ThreadLastPostingDate")).ToString("dd-MMM-yyyy HH:mm", DateTimeFormatInfo.InvariantInfo) %>' /></asp:hyperlink></div>
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
</TABLE>
</form>
<hnd:pagelegend runat="server" id="PageLegend" />
<br clear="all">
<br clear="all">
<!-- footer -->
<hnd:pagefooter runat="server" id="PageFooter" />
</body>
</html>
