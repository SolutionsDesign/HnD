<%@ Page language="c#" CodeFile="MyThreads.aspx.cs" AutoEventWireup="true" Inherits="SD.HnD.GUI.MyThreads" ValidateRequest="false" %>
<%@ Register TagPrefix="HnD" TagName="PageHeader" Src="Header.ascx"%>
<%@ Register Src="Footer.ascx" TagName="PageFooter" TagPrefix="HnD" %>
<%@ Register TagPrefix="HnD" TagName="PageList" Src="PageList.ascx"%>
<%@ Register TagPrefix="HnD" TagName="MyThreadsPageList" Src="MyThreadsPageList.ascx"%>
<%@ Register TagPrefix="HnD" TagName="PageLegend" Src="PageLegend.ascx"%>
<%@ Import namespace="System.Web" %>
<%@ Import Namespace="System.Globalization" %>
<%@ Import Namespace="SD.HnD.GUI" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
  <head runat="server">
	<title>HnD::My threads</title>
	<meta name="vs_defaultClientScript" content="JavaScript">
	<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">  </head>
<body>
<table width="750" align="center" border="0" cellpadding="0" cellspacing="0">
<hnd:pageheader runat="server" id="PageHeader" />
</table>
<br clear="all">
<table width="750" align="center" border="0" cellpadding="0" cellspacing="0">
<tr>
	<td>
		<b>Number of threads found:</b> <asp:label id="lblAmountThreads" runat="server" /> <asp:Label ID="lblCappingWarning" runat="server" Visible="false">(Maximum browsable: 500)</asp:Label><br>
		<br>
	</td>
</tr>
<tr>
	<td>
		<hnd:mythreadspagelist runat="server" id="plPageListTop" />
		<br>
		<img src="pics/separator.gif" width="10" height="5" border="0"><br>
	</td>
</tr>
<tr>
	<td class="TableHeaderOneLine">
		<span class="TableName">The threads I participated in</span>
	</td>
</tr>
<tr>
	<td class="TableContent">
		<asp:repeater id="rpThreads" enableviewstate="False" runat="server" OnItemDataBound="rpThreads_ItemDataBound">
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
						<asp:hyperlink id="lnkThread" navigateurl='<%# "Messages.aspx?ThreadID=" + Eval("ThreadID")%>' runat="server" cssclass="ThreadSubjectLink" title="View thread's messages"><%# HttpUtility.HtmlEncode((string)Eval("Subject"))%></asp:hyperlink>
						&nbsp;&nbsp;&nbsp;<hnd:pagelist runat="server" id="plPageListItem" IsOnThreadsPage="true" UseCommaAsSeparator="true" AmountMessages='<%# Convert.ToInt32(Eval("AmountMessages")) %>' ThreadID='<%# Eval("ThreadID") %>' Visible='<%# (SessionAdapter.GetUserDefaultNumberOfMessagesPerPage() < Convert.ToInt32(Eval("AmountMessages"))) %>'/><br />
						<div align="left" class="SmallFontThreadList">
							Started by: <asp:hyperlink id="lnkPoster" navigateurl='<%# "Profile.aspx?UserID=" + Eval("StartedByUserID") %>' target="_blank" cssclass="LinkNoUnderline" runat="server" title="View profile"><%# HttpUtility.HtmlEncode((string)Eval("NickName"))%></asp:hyperlink></div>
					</td>
					<td class="TableRow LightBackground" width="60" align="center" valign="top"><%# Convert.ToInt32(Eval("AmountMessages")) - 1%></td>
					<td class="TableRow LightBackground" width="60" align="center" valign="top"><%# Eval("NumberOfViews")%></td>
					<td class="TableRow LightBackground" width="168" valign="top">
						<div align="left" class="SmallFontThreadList">By: <b><asp:hyperlink id="lnkPosterLastPosting" navigateurl='<%# "Profile.aspx?UserID=" + Eval("LastPostingByUserID") %>' target="_blank" cssclass="LinkNoUnderline" runat="server" title="View profile"><%# HttpUtility.HtmlEncode((string)Eval("NickNameLastPosting"))%></asp:hyperlink></b><br />
						On: <asp:hyperlink id="lnkGotoLastPosting" navigateurl='<%# string.Format("GotoMessage.aspx?ThreadID={0}&MessageID={1}", Eval("ThreadID"), Eval("LastMessageID")) %>' runat="server" cssclass="LinkNoUnderline" title="Goto last post"><asp:label id="lblThreadLastPostingDate" runat="server" Text='<%# ((DateTime)Eval("ThreadLastPostingDate")).ToString("dd-MMM-yyyy HH:mm", DateTimeFormatInfo.InvariantInfo) %>' /></asp:hyperlink></div>
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
						<asp:hyperlink id="lnkThread" navigateurl='<%# "Messages.aspx?ThreadID=" + Eval("ThreadID")%>' runat="server" cssclass="ThreadSubjectLink" title="View thread's messages"><%# HttpUtility.HtmlEncode((string)Eval("Subject"))%></asp:hyperlink>
						&nbsp;&nbsp;&nbsp;<hnd:pagelist runat="server" id="plPageListItem" IsOnThreadsPage="true" UseCommaAsSeparator="true" AmountMessages='<%# Convert.ToInt32(Eval("AmountMessages")) %>' ThreadID='<%# Eval("ThreadID") %>' Visible='<%# (SessionAdapter.GetUserDefaultNumberOfMessagesPerPage() < Convert.ToInt32(Eval("AmountMessages"))) %>'/><br />
						<div align="left" class="SmallFontThreadList">
						Started by: <asp:hyperlink id="lnkPoster" navigateurl='<%# "Profile.aspx?UserID=" + Eval("StartedByUserID") %>' target="_blank" cssclass="LinkNoUnderline" runat="server" title="View profile"><%# HttpUtility.HtmlEncode((string)Eval("NickName"))%></asp:hyperlink></div>
					</td>
					<td class="TableRow DarkBackground" width="60" align="center" valign="top"><%# Convert.ToInt32(Eval("AmountMessages")) - 1%></td>
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
<tr>
	<td>
		<hnd:mythreadspagelist runat="server" id="plPageListBottom" />
	</td>
</tr>
</table>
<hnd:pagelegend runat="server" id="PageLegend" />
<br clear="all">
<br clear="all">
<hnd:pagefooter runat="server" id="PageFooter" />
</body>
</html>
