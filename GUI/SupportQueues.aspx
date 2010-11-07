<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SupportQueues.aspx.cs" Inherits="SD.HnD.GUI.SupportQueues" %>
<%@ Register TagPrefix="HnD" TagName="PageHeader" Src="Header.ascx"%>
<%@ Register TagPrefix="HnD" TagName="PageFooter" Src="Footer.ascx"%>
<%@ Register TagPrefix="HnD" TagName="PageList" Src="PageList.ascx"%>
<%@ Register TagPrefix="HnD" TagName="PageLegend" Src="PageLegend.ascx"%>
<%@ Import Namespace="SD.HnD.GUI" %>
<%@ Import namespace="System.Web" %>
<%@ Import Namespace="System.Globalization" %>
<!doctype html public "-//w3c//dtd html 4.0 transitional//en" >
<html>
  <head runat="server">
	<title>HnD::Support Queues</title>
  </head>
<body>
<!-- header, menu and title -->
<form runat="server" id="Form1">
<table width="750" align="center" border="0" cellpadding="0" cellspacing="0">
<hnd:pageheader runat="server" id="PageHeader" />
<tr>
	<td class="SmallFontSmallest">
		<br>
		You are here: <b><a href="Default.aspx">Home</a> &gt; Support queues</b>
		<br><br>
	</td>
</tr>
</table>
<table width="750" align="center" class="ExplanationBox" cellpadding="3" cellspacing="0">
<tr>
	<td>
		<h3>Support queues</h3>
		Below you'll find the support queues defined in the forum system, ordered by their defined order no, ascending, as well as their containing threads.
		Use the queues below to access threads which need attention. Be sure to <i>claim</i> a thread when you want to work on the thread and release the claim
		of the thread when you're done. You can do that in this overview, however you can also do that in the message view of the thread. 
		<br /><br />
		The list of threads in a queue is filtered by the forums you can access: threads located in forums you don't have access to aren't displayed.
	</td>
</tr>
</table>
<br clear="all">
<asp:Repeater ID="rpQueues" runat="server" OnItemDataBound="rpQueues_ItemDataBound">
	<ItemTemplate>
		<table width="750" align="center" border="0" cellpadding="0" cellspacing="0">
		<tr>
			<td class="TableHeaderTwoLine">
				<span class="TableName"><%# Eval("QueueName") %></span>
				<br />
				<span class="TableDescription"><%# Eval("QueueDescription") %></span>
			</td>
		</tr>
		<tr>
			<td class="TableContent">
				<asp:PlaceHolder ID="phNoDataText" runat="server" Visible="false">
					<table width="748" align="center" border="0" cellpadding="1" cellspacing="0">
					<tr>
						<td class="TableRow LightBackground">
							There are no threads in this queue.
						</td>
					</tr>
					</table>
				</asp:PlaceHolder>
				
				<asp:repeater id="rpThreads" runat="server" OnItemDataBound="rpThreads_ItemDataBound" OnItemCommand="rpThreads_ItemCommand">
					<headertemplate>
						<table width="748" align="center" border="0" cellpadding="1" cellspacing="0">
						<tr>
							<td class="TableColumnHeader" width="20" nowrap="nowrap">&nbsp;</td>
							<td class="TableColumnHeader" width="400">Thread subject</td>
							<td class="TableColumnHeader" width="164">Last post</td>
							<td class="TableColumnHeader" width="164">Claim</td>
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
							<td class="TableRow LightBackground" width="400">
								<asp:hyperlink id="lnkThread" navigateurl='<%# "Messages.aspx?ThreadID=" + Eval("ThreadID")%>' runat="server" cssclass="ThreadSubjectLink" title="View thread's messages"><%# HttpUtility.HtmlEncode((string)Eval("Subject"))%></asp:hyperlink>
								&nbsp;&nbsp;&nbsp;<hnd:pagelist runat="server" id="plPageListItem" IsOnThreadsPage="true" UseCommaAsSeparator="true" AmountMessages='<%# Eval("AmountMessages") %>' ThreadID='<%# Eval("ThreadID") %>' Visible='<%# (SessionAdapter.GetUserDefaultNumberOfMessagesPerPage() < (int)Eval("AmountMessages")) %>'/><br />
								<div align="left" class="SmallFontThreadList">Posted in forum: <asp:hyperlink runat="server" id="lnkThreadList" navigateurl='<%# "Threads.aspx?ForumID=" + Eval("ForumID") %>'><%# Eval("ForumName")%></asp:hyperlink>.<br> 
								Started by: <asp:hyperlink id="lnkPoster" navigateurl='<%# "Profile.aspx?UserID=" + Eval("StartedByUserID") %>' target="_blank" cssclass="LinkNoUnderline" runat="server" title="View profile"><%# HttpUtility.HtmlEncode((string)Eval("NickName"))%></asp:hyperlink><br />
								Placed in queue by: <asp:hyperlink id="lnkQueuePlacer" navigateurl='<%# "Profile.aspx?UserID=" + Eval("PlacedInQueueByUserID") %>' target="_blank" cssclass="LinkNoUnderline" runat="server" title="View profile"><%# HttpUtility.HtmlEncode((string)Eval("NickNamePlacedInQueue"))%></asp:hyperlink><br />
								Placed in queue on: <%# ((DateTime)Eval("PlacedInQueueOn")).ToString("dd-MMM-yyyy HH:mm.ss", DateTimeFormatInfo.InvariantInfo) %>
								</div>
							</td>
							<td class="TableRow LightBackground" width="164" valign="top">
								<div align="left" class="SmallFontThreadList">By: <b><asp:hyperlink id="lnkPosterLastPosting" navigateurl='<%# "Profile.aspx?UserID=" + Eval("LastPostingByUserID") %>' target="_blank" cssclass="LinkNoUnderline" runat="server" title="View profile"><%# HttpUtility.HtmlEncode((string)Eval("NickNameLastPosting"))%></asp:hyperlink></b><br />
								On: <asp:hyperlink id="lnkGotoLastPosting" navigateurl='<%# string.Format("GotoMessage.aspx?ThreadID={0}&MessageID={1}", Eval("ThreadID"), Eval("LastMessageID")) %>' runat="server" cssclass="LinkNoUnderline" title="Goto last post"><asp:label id="lblThreadLastPostingDate" runat="server" Text='<%# ((DateTime)Eval("ThreadLastPostingDate")).ToString("dd-MMM-yyyy HH:mm", DateTimeFormatInfo.InvariantInfo) %>' /></asp:hyperlink>
								<br /><br />
								# replies: <%# ((int)Eval("AmountMessages")-1)%><br />
								# views: <%# Eval("NumberOfViews")%>
								</div>
							</td>
							<td class="TableRow LightBackground" width="164" valign="top">
								<div align="left" class="SmallFontThreadList">
								<asp:PlaceHolder ID="phClaimed" runat="server" Visible='<%# (Eval("ClaimedByUserID") != DBNull.Value) %>'>
								by: <b><asp:hyperlink id="lnkClaimerThread" navigateurl="Profile.aspx?UserID=" target="_blank" cssclass="LinkNoUnderline" runat="server" title="View profile"></asp:hyperlink></b> <br />
								on: <asp:Label ID="lblClaimDate" runat="server" />
								</asp:PlaceHolder>
								
								<asp:Button ID="btnRelease" style="margin:10px 0px 0px 3px;" runat="server" CommandName="ReleaseClaim" CommandArgument='<%# (int)Eval("ThreadID") %>' Text="Release" CssClass="FormButtons" Visible='<%# (Eval("ClaimedByUserID") != DBNull.Value) %>'/>

								<asp:Button ID="btnClaim" style="margin:3px 0px 0px 3px;" runat="server" CommandName="Claim" Text="Claim" CommandArgument='<%# (int)Eval("ThreadID") %>' CssClass="FormButtons" Visible='<%# (Eval("ClaimedByUserID") == DBNull.Value) %>' />
								</div>
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
							<td class="TableRow DarkBackground" width="400">
								<asp:hyperlink id="lnkThread" navigateurl='<%# "Messages.aspx?ThreadID=" + Eval("ThreadID")%>' runat="server" cssclass="ThreadSubjectLink" title="View thread's messages"><%# HttpUtility.HtmlEncode((string)Eval("Subject"))%></asp:hyperlink>
								&nbsp;&nbsp;&nbsp;<hnd:pagelist runat="server" id="plPageListItem" IsOnThreadsPage="true" UseCommaAsSeparator="true" AmountMessages='<%# Eval("AmountMessages") %>' ThreadID='<%# Eval("ThreadID") %>' Visible='<%# (SessionAdapter.GetUserDefaultNumberOfMessagesPerPage() < (int)Eval("AmountMessages")) %>'/><br />
								<div align="left" class="SmallFontThreadList">Posted in forum: <asp:hyperlink runat="server" id="lnkThreadList" navigateurl='<%# "Threads.aspx?ForumID=" + Eval("ForumID") %>'><%# Eval("ForumName")%></asp:hyperlink>.<br> 
								Started by: <asp:hyperlink id="lnkPoster" navigateurl='<%# "Profile.aspx?UserID=" + Eval("StartedByUserID") %>' target="_blank" cssclass="LinkNoUnderline" runat="server" title="View profile"><%# HttpUtility.HtmlEncode((string)Eval("NickName"))%></asp:hyperlink><br />
								Placed in queue by: <asp:hyperlink id="lnkQueuePlacer" navigateurl='<%# "Profile.aspx?UserID=" + Eval("PlacedInQueueByUserID") %>' target="_blank" cssclass="LinkNoUnderline" runat="server" title="View profile"><%# HttpUtility.HtmlEncode((string)Eval("NickNamePlacedInQueue"))%></asp:hyperlink><br />
								Placed in queue on: <%# ((DateTime)Eval("PlacedInQueueOn")).ToString("dd-MMM-yyyy HH:mm.ss", DateTimeFormatInfo.InvariantInfo) %>
								</div>
							</td>
							<td class="TableRow DarkBackground" width="164" valign="top">
								<div align="left" class="SmallFontThreadList">By: <b><asp:hyperlink id="lnkPosterLastPosting" navigateurl='<%# "Profile.aspx?UserID=" + Eval("LastPostingByUserID") %>' target="_blank" cssclass="LinkNoUnderline" runat="server" title="View profile"><%# HttpUtility.HtmlEncode((string)Eval("NickNameLastPosting"))%></asp:hyperlink></b><br />
								On:	<asp:hyperlink id="lnkGotoLastPosting" navigateurl='<%# string.Format("GotoMessage.aspx?ThreadID={0}&MessageID={1}", Eval("ThreadID"), Eval("LastMessageID")) %>' runat="server" cssclass="LinkNoUnderline" title="Goto last post"><asp:label id="lblThreadLastPostingDate" runat="server" Text='<%# ((DateTime)Eval("ThreadLastPostingDate")).ToString("dd-MMM-yyyy HH:mm", DateTimeFormatInfo.InvariantInfo) %>' /></asp:hyperlink>
								<br /><br />
								# replies: <%# ((int)Eval("AmountMessages")-1)%><br />
								# views: <%# Eval("NumberOfViews")%>
								</div>
							</td>
							<td class="TableRow DarkBackground" width="164" valign="top">
								<div align="left" class="SmallFontThreadList">
								<asp:PlaceHolder ID="phClaimed" runat="server" Visible='<%# (Eval("ClaimedByUserID") != DBNull.Value) %>'>
								by: <b><asp:hyperlink id="lnkClaimerThread" navigateurl="Profile.aspx?UserID=" target="_blank" cssclass="LinkNoUnderline" runat="server" title="View profile"></asp:hyperlink></b> <br />
								on: <asp:Label ID="lblClaimDate" runat="server" />
								</asp:PlaceHolder>
								
								<asp:Button ID="btnRelease" style="margin:10px 0px 0px 3px;" runat="server" Text="Release" CommandName="ReleaseClaim" CommandArgument='<%# (int)Eval("ThreadID") %>' CssClass="FormButtons" Visible='<%# (Eval("ClaimedByUserID") != DBNull.Value) %>'/>

								<asp:Button ID="btnClaim" style="margin:3px 0px 0px 3px;" runat="server" Text="Claim" CommandName="Claim" CommandArgument='<%# (int)Eval("ThreadID") %>' CssClass="FormButtons" Visible='<%# (Eval("ClaimedByUserID") == DBNull.Value) %>' />
								</div>
							</td>
						</tr>
					</alternatingitemtemplate>

					<footertemplate>
						</table>
					</footertemplate>
				</asp:repeater>
			</td>
		</tr>
		<tr>
			<td class="EmptyRowBottom" height="5"><img src="pics/separator.gif" border="0"></td>
		</tr>
		</table>
	</ItemTemplate>
	<SeparatorTemplate>
		<br clear="all" /><br />
	</SeparatorTemplate>
</asp:Repeater>
</form>
<hnd:pagelegend runat="server" id="PageLegend" />
<br clear="all">
<br clear="all">
<!-- footer -->
<hnd:pagefooter runat="server" id="PageFooter" />
</body>
</html>
