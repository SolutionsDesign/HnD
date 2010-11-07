<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ApproveAttachments.aspx.cs" Inherits="SD.HnD.GUI.ApproveAttachments" %>
<%@ Register TagPrefix="HnD" TagName="PageFooter" Src="Footer.ascx"%>
<%@ Register TagPrefix="HnD" TagName="PageHeader" Src="Header.ascx"%>
<%@ Register TagPrefix="HnD" TagName="MessageEditor" Src="MessageEditor.ascx"%>
<%@ Import Namespace="System.Globalization" %>
<%@ Import Namespace="SD.HnD.GUI" %>
<%@ Import Namespace="SD.HnD.BL" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
  <head runat="server">
	<title>HnD::Manage attachments</title>
	<meta name="vs_defaultClientScript" content="JavaScript">
	<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">

</head>
<body>
<form id="form1" runat="server" EncType="Multipart/Form-Data">
<table width="750" align="center" border="0" cellpadding="0" cellspacing="0">
<hnd:pageheader runat="server" id="PageHeader" />
<tr>
	<td class="SmallFontSmallest" colspan="2">
		<br>
		You are here: <b><a href="Default.aspx">Home</a> &gt; Approve Attachments</b>
		<br><br>
	</td>
</tr>
</table>

<table width="750" align="center" class="ExplanationBox" cellpadding="3" cellspacing="0">
<tr>
	<td>
		<h3>Approve attachments</h3>
		Below you'll find the all the attachments which need approval. The messages to which they're attached are reachable as well. Be sure you've
		checked the attachment's contents to see if it can be approved or not when you click the Approve button for a given attachment. Only approve attachments 
		which you find OK for visitors to download. 
		<asp:PlaceHolder ID="phAttachmentDelete" runat="server" Visible="false">
		<br /><br />
		You're allowed to delete attachments as well. It's best to delete an attachment if the attachment will never get approval, as it will otherwise
		stick around forever in this list. An attachment which violates certain forum rules will likely fall into this category.
		</asp:PlaceHolder>
	</td>
</tr>
</table>
<br clear="all">
<table width="750" align="center" border="0" cellpadding="0" cellspacing="0">
<tr>
	<td class="TableHeaderTwoLine">
		<span class="TableName">Message Attachments</span>
		<br />
		<span class="TableDescription">The list of attachments which need approval.</span>
	</td>
</tr>
<tr>
	<td class="TableContent">
		<asp:Repeater ID="rpAttachments" runat="server" OnItemCommand="rpAttachments_ItemCommand">
		<HeaderTemplate>
			<table width="748" align="center" border="0" cellpadding="3" cellspacing="0">
			<tr>
				<td class="TableColumnHeader" width="20">&nbsp;</td>
				<td class="TableColumnHeader" width="420">Filename</td>
				<td class="TableColumnHeader" nowrap="nowrap" width="75" align="right">File size</td>
				<td class="TableColumnHeader" nowrap="nowrap" width="148" align="right">Added on</td>
				<td class="TableColumnHeader" width="85" align="right">Approval</td>
			</tr>
		</HeaderTemplate>
		
		<ItemTemplate>
			<tr>
				<td class="TableRow LightBackground" width="20" nowrap="nowrap" valign="top">
					<asp:Button ID="btnDelete" CommandName="Delete" Text="Delete" runat="server" CssClass="FormButtons" CommandArgument='<%# Eval("AttachmentID") %>'
						visible='<%# (SessionAdapter.GetUserID()==(int)Eval("PostedByUserID")) || SessionAdapter.CanPerformForumActionRight((int)Eval("ForumID"), ActionRights.ManageOtherUsersAttachments) %>' />
					<asp:Label runat="server" ID="lblEmptySpace" 
						visible='<%# !((SessionAdapter.GetUserID()==(int)Eval("PostedByUserID")) || SessionAdapter.CanPerformForumActionRight((int)Eval("ForumID"), ActionRights.ManageOtherUsersAttachments)) %>'>&nbsp;</asp:Label>
				</td>
				<td class="TableRow LightBackground" width="420" valign="top">
					<asp:HyperLink runat="server" ID="lnkGetAttachment" 
						Target="_blank" NavigateUrl='<%# "FileStreamer.aspx?AttachmentID=" + Eval("AttachmentID")%>'><%# Eval("Filename") %></asp:HyperLink>
					<br />
					<div class="SmallFontThreadList" align="left">
						Attached to message: <asp:HyperLink Target="_blank" ID="lnkMessage" runat="server" NavigateUrl='<%# String.Format("GotoMessage.aspx?MessageID={0}&ThreadID={1}", Eval("MessageID"), Eval("ThreadID")) %>'>#<%# Eval("MessageID") %></asp:HyperLink>
					</div>
				</td>
				<td class="TableRow LightBackground" width="75" align="right" valign="top"><asp:Label ID="lblFilesize" runat="server"><%# ((int)Eval("Filesize")).ToString("N0") %></asp:Label></td>
				<td class="TableRow LightBackground" width="148" align="right" valign="top"><asp:Label ID="lblLastModifiedOn" runat="server"><%# ((DateTime)Eval("AddedOn")).ToString("dd-MMM-yyyy HH:mm.ss", DateTimeFormatInfo.InvariantInfo) %></asp:Label></td>
				<td class="TableRow LightBackground" width="85" align="right" valign="top">
					<asp:Button id="btnApprove" runat="server" CssClass="FormButtons" Text="Approve" CommandName="Approve" 
						CommandArgument='<%# Eval("AttachmentID") %>' />
				</td>
			</tr>
		</ItemTemplate>
		
		<AlternatingItemTemplate>
			<tr>
				<td class="TableRow DarkBackground" width="20" nowrap="nowrap" valign="top">
					<asp:Button ID="btnDelete" CommandName="Delete" Text="Delete" runat="server" CssClass="FormButtons" CommandArgument='<%# Eval("AttachmentID") %>'
						visible='<%# (SessionAdapter.GetUserID()==(int)Eval("PostedByUserID")) || SessionAdapter.CanPerformForumActionRight((int)Eval("ForumID"), ActionRights.ManageOtherUsersAttachments) %>' />
					<asp:Label runat="server" ID="lblEmptySpace" 
						visible='<%# !((SessionAdapter.GetUserID()==(int)Eval("PostedByUserID")) || SessionAdapter.CanPerformForumActionRight((int)Eval("ForumID"), ActionRights.ManageOtherUsersAttachments)) %>'>&nbsp;</asp:Label>
				</td>
				<td class="TableRow DarkBackground" width="420" valign="top">
					<asp:HyperLink runat="server" ID="lnkGetAttachment" 
						Target="_blank" NavigateUrl='<%# "FileStreamer.aspx?AttachmentID=" + Eval("AttachmentID")%>'><%# Eval("Filename") %></asp:HyperLink>
					<br />
					<div class="SmallFontThreadList" align="left">
						Attached to message: <asp:HyperLink Target="_blank" ID="lnkMessage" runat="server" NavigateUrl='<%# String.Format("GotoMessage.aspx?MessageID={0}&ThreadID={1}", Eval("MessageID"), Eval("ThreadID")) %>'>#<%# Eval("MessageID") %></asp:HyperLink>
					</div>
				</td>
				<td class="TableRow DarkBackground" width="75" align="right" valign="top"><asp:Label ID="lblFilesize" runat="server"><%# ((int)Eval("Filesize")).ToString("N0") %></asp:Label></td>
				<td class="TableRow DarkBackground" width="148" align="right" valign="top"><asp:Label ID="lblLastModifiedOn" runat="server"><%# ((DateTime)Eval("AddedOn")).ToString("dd-MMM-yyyy HH:mm.ss", DateTimeFormatInfo.InvariantInfo) %></asp:Label></td>
				<td class="TableRow DarkBackground" width="85" align="right" valign="top">
					<asp:Button id="btnApprove" runat="server" CssClass="FormButtons" Text="Approve" CommandName="Approve" 
						CommandArgument='<%# Eval("AttachmentID") %>' />
				</td>
			</tr>
		</AlternatingItemTemplate>
		<FooterTemplate>
			</table>
		</FooterTemplate>
		</asp:Repeater>
	</td>
</tr>
<tr>
	<td class="EmptyRowBottom" height="5"><img src="pics/separator.gif" border="0"></td>
</tr>
</table>
</form>
<br clear="all">
<!-- footer -->
<hnd:pagefooter runat="server" id="PageFooter" />
</body>
</html>
