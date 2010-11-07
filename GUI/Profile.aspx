<%@ Page language="c#" CodeFile="Profile.aspx.cs" AutoEventWireup="true" Inherits="SD.HnD.GUI._Profile" ValidateRequest="false" %>
<%@ Register TagPrefix="HnD" TagName="PageHeader" Src="Header.ascx"%>
<%@ Register Src="Footer.ascx" TagName="PageFooter" TagPrefix="HnD" %>
<%@ Register TagPrefix="HnD" TagName="PageList" Src="PageList.ascx"%>
<%@ Import namespace="System.Web" %>
<%@ Import Namespace="System.Globalization" %>
<%@ Import Namespace="SD.HnD.GUI" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
  <head runat="server">
	<title>HnD::Show User Profile</title>
	<meta name="vs_defaultClientScript" content="JavaScript">
	<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">  </head>
<body>
<table width="750" align="center" border="0" cellpadding="0" cellspacing="0">
<hnd:pageheader runat="server" id="PageHeader" />
</table>
<br clear="all">
<table align="center" class="ExplanationBox" cellpadding="2" cellspacing="0" width="750">
<tr>
	<td>
		<h3>User profile</h3>
		The user profile below contains information which is filled in by the user. It is against the law to 
		collect any information from this page in any form whatsoever without prior written permission of the 
		user who owns this account. 
	</td>
</tr>
</table>
<br clear="all">
<table align="center" class="ExplanationBox" cellpadding="0" cellspacing="0">
<tr>
	<td>
		<table width="750" cellpadding="3" cellspacing="0" align="center">
		<tr class="LightBackground">
			
			<td width="170"><b>Nickname</b></td>
			<td class="LightBackground"><asp:label ID="lblNickName" Runat="server" /></td>
		</tr>
		<tr class="DarkBackground">
			<td width="170"><b>Email address</b></td>
			<td>
				<asp:label ID="lblEmailAddressNotPublicTxt" Runat="server" Visible="False">Not visible.</asp:label>
				<asp:hyperlink ID="lnkEmailAddress" Runat="server" Visible="False" />
			</td>
		</tr>
		<tr class="LightBackground">
			<td width="170" valign="top"><b>User icon</b></td>
			<td>
				<asp:image ID="imgIcon" Visible="False" Runat="server" border="1" width="60" Height="60" /><br>
				<span class="SmallFontSmallest"><asp:label ID="lblIconURL" Runat="server"/></span>
			</td>
		</tr>
		<tr class="DarkBackground">
			<td width="170"><b>Date of birth</b></td>
			<td ><asp:label ID="lblDateOfBirth" Runat="server" /></td>
		</tr>
		<tr class="LightBackground">
			<td width="170"><b>Occupation</b></td>
			<td><asp:label ID="lblOccupation" Runat="server" /></td>
		</tr>
		<tr class="DarkBackground">
			<td width="170"><b>Location</b></td>
			<td><asp:label ID="lblLocation" Runat="server" /></td>
		</tr>
		<tr class="LightBackground">
			<td width="170"><b>Website</b></td>
			<td>
				<asp:hyperlink ID="lnkWebsite" Visible="False" Target="_blank" Runat="server" />
			</td>
		</tr>
		<tr class="DarkBackground">
			<td width="170" valign="top"><b>Signature</b></td>
			<td><asp:label ID="lblSignature" Runat="server" /></td>
		</tr>
		<tr class="LightBackground">
			<td width="170"><b>User title</b></td>
			<td><asp:label ID="lblUserTitle" Runat="server" /></td>
		</tr>
		<tr class="DarkBackground">
			<td width="170" valign="top"><b>Registered on</b></td>
			<td><asp:label ID="lblRegisteredOn" Runat="server" /></td>
		</tr>
		<tr class="LightBackground">
			<td width="170"><b>Number of posts</b></td>
			<td><asp:label ID="lblAmountOfPosts" Runat="server" /></td>
		</tr>
<asp:PlaceHolder ID="phAdminSection" runat="server">
		<tr class="DarkBackground">
			<td width="170" valign="top"><b>IP Address</b></td>
			<td><asp:label ID="lblIpAddress" Runat="server" /></td>
		</tr>
		<tr class="LightBackground">
			<td width="170"><b>Last visit date</b></td>
			<td><asp:label ID="lblLastVisitDate" Runat="server" /></td>
		</tr>
</asp:PlaceHolder>
		<tr class="NormalBackground">
			<td colspan="2">
				<br>
				<center>
					<a href="javascript://" onclick="window.close();">Close window</a>
				</center>
				<br>
			</td>
		</tr>
		</table>
	</td>
</tr>
</table>
<br clear="all">
<table width="750" align="center" border="0" cellpadding="0" cellspacing="0">
<tr>
	<td class="TableHeaderOneLine">
		<span class="TableName">Last 25 threads this user participated in</span>
	</td>
</tr>
<tr>
	<td class="TableContent">
		<asp:repeater id="rpThreads" enableviewstate="False" runat="server" OnItemDataBound="rpThreads_ItemDataBound">
			<headertemplate>
				<table width="748" align="center" border="0" cellpadding="1" cellspacing="0">
				<tr>
					<td class="TableColumnHeader" width="20" nowrap>&nbsp;</td>
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
						<asp:hyperlink id="lnkThread" navigateurl='<%# "Messages.aspx?ThreadID=" + Eval("ThreadID")%>' runat="server" cssclass="ThreadSubjectLink" title="View thread's messages"><%# HttpUtility.HtmlEncode((string)Eval("Subject"))%></asp:hyperlink>
						&nbsp;&nbsp;&nbsp;<hnd:pagelist runat="server" id="plPageListItem" IsOnThreadsPage="true" UseCommaAsSeparator="true" AmountMessages='<%# Eval("AmountMessages") %>' ThreadID='<%# Eval("ThreadID") %>' Visible='<%# (SessionAdapter.GetUserDefaultNumberOfMessagesPerPage() < (int)Eval("AmountMessages")) %>'/><br />
						<div align="left" class="SmallFontThreadList">
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
					<td class="TableRow DarkBackground" align="center" valign="top" width="20" nowrap>
						<asp:image id="imgIconNewPostsSticky" SkinID="imgIconNewPostsStickyAlt" Visible="False" RunAt="server"/>
						<asp:image ID="imgIconNoNewPostsSticky" SkinID="imgIconNoNewPostsStickyAlt" Visible="False" RunAt="server"/>
						<asp:image ID="imgIconNewPosts" SkinID="imgIconNewPostsAlt" Visible="False" RunAt="server"/>
						<asp:image ID="imgIconNoNewPosts" SkinID="imgIconNoNewPostsAlt" Visible="False" RunAt="server"/>
						<asp:image ID="imgIconNewPostsClosed" SkinID="imgIconNewPostsClosedAlt" Visible="False" RunAt="server"/>
						<asp:image ID="imgIconNoNewPostsClosed" SkinID="imgIconNoNewPostsClosedAlt" Visible="False" RunAt="server"/>
					</td>
					<td class="TableRow DarkBackground" width="435">
						<asp:hyperlink id="lnkThread" navigateurl='<%# "Messages.aspx?ThreadID=" + Eval("ThreadID")%>' runat="server" cssclass="ThreadSubjectLink" title="View thread's messages"><%# HttpUtility.HtmlEncode((string)Eval("Subject"))%></asp:hyperlink>
						&nbsp;&nbsp;&nbsp;<hnd:pagelist runat="server" id="plPageListItem" IsOnThreadsPage="true" UseCommaAsSeparator="true" AmountMessages='<%# Eval("AmountMessages") %>' ThreadID='<%# Eval("ThreadID") %>' Visible='<%# (SessionAdapter.GetUserDefaultNumberOfMessagesPerPage() < (int)Eval("AmountMessages")) %>'/><br />
						<div align="left" class="SmallFontThreadList">
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


<!-- footer -->
<hnd:pagefooter runat="server" id="PageFooter" />
</body>
</html>
