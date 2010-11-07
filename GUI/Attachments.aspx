<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Attachments.aspx.cs" Inherits="SD.HnD.GUI.Attachments" %>
<%@ Register TagPrefix="HnD" TagName="PageFooter" Src="Footer.ascx"%>
<%@ Register TagPrefix="HnD" TagName="PageHeader" Src="Header.ascx"%>
<%@ Register TagPrefix="HnD" TagName="MessageEditor" Src="MessageEditor.ascx"%>
<%@ Import Namespace="System.Globalization" %>
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
		You are here: <b><a href="Default.aspx">Home</a> &gt; <asp:label ID="lblSectionName" Runat="server" /> &gt; 
		<asp:hyperlink id="lnkThreads" NavigateUrl="Threads.aspx" Runat="server" /> &gt; 
		<asp:hyperlink ID="lnkMessages" NavigateURL="Messages.aspx?ThreadID=" Runat="server"/> &gt; Attachments</b>
		<br><br>
	</td>
</tr>
</table>

<table width="750" align="center" class="ExplanationBox" cellpadding="3" cellspacing="0">
<tr>
	<td>
		<h3>Attachments</h3>
		Below you'll find the attachments for the message reachable by the following URL:<br />
		<asp:HyperLink ID="lnkMessage" runat="server" NavigateUrl="GotoMessage.aspx?" >Direct link to message #</asp:HyperLink>
		<asp:PlaceHolder ID="phAttachmentLimits" runat="server" Visible="false">
		<br /><br />
		<b>Max. # of attachments per message:</b> <asp:Label ID="lblMaxNoOfAttachmentsPerMessage" runat="server" /><br />
		<b>Max. file size of attachment:</b> <asp:Label ID="lblMaxFileSize" runat="server" />
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
		<span class="TableDescription">The list of attachments of the selected message.</span>
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
				<td class="TableRow LightBackground" width="20" nowrap="nowrap">
					<asp:Button ID="btnDelete" CommandName="Delete" Text="Delete" runat="server" CssClass="FormButtons" CommandArgument='<%# Eval("AttachmentID") %>'
						visible='<%# base.UserMayManageAttachments %>' OnClientClick='<%# "return confirm(\"Are you sure you want to delete the attachment: " + Eval("Filename") + " ?\");" %>' /><asp:Label runat="server" ID="lblEmptySpace" visible='<%# !base.UserMayManageAttachments %>'>&nbsp;</asp:Label>
				</td>
				<td class="TableRow LightBackground" width="420">
					<asp:HyperLink runat="server" ID="lnkGetAttachment" Visible='<%# (!base.UserCanApproveAttachments && (bool)Eval("Approved")) || base.UserCanApproveAttachments %>' 
						Target="_blank" NavigateUrl='<%# "FileStreamer.aspx?AttachmentID=" + Eval("AttachmentID")%>'><%# Eval("Filename") %></asp:HyperLink>
					<asp:Label runat="server" ID="lblFilename" Visible='<%# !base.UserCanApproveAttachments && !(bool)Eval("Approved") %>'><%# Eval("Filename") %></asp:Label>
				</td>
				<td class="TableRow LightBackground" width="75" align="right"><asp:Label ID="lblFilesize" runat="server"><%# ((int)Eval("Filesize")).ToString("N0") %></asp:Label></td>
				<td class="TableRow LightBackground" width="148" align="right"><asp:Label ID="lblLastModifiedOn" runat="server"><%# ((DateTime)Eval("AddedOn")).ToString("dd-MMM-yyyy HH:mm.ss", DateTimeFormatInfo.InvariantInfo) %></asp:Label></td>
				<td class="TableRow LightBackground" width="85" align="right">
					<asp:Button id="btnApprove" runat="server" CssClass="FormButtons" Text="Approve" CommandName="Approve" 
						CommandArgument='<%# Eval("AttachmentID") %>' Visible='<%# base.UserCanApproveAttachments && !(bool)Eval("Approved") %>' />
					<asp:Button id="btnRevoke" runat="server" CssClass="FormButtons" Text="Revoke" CommandName="Revoke" 
						CommandArgument='<%# Eval("AttachmentID") %>' Visible='<%# base.UserCanApproveAttachments && (bool)Eval("Approved") %>' />
					<asp:label ID="lblApproved" runat="server" Text="Approved" Visible='<%# !base.UserCanApproveAttachments && (bool)Eval("Approved") %>' />
					<asp:label ID="lblPending" runat="server" Text="Pending" Visible='<%# !base.UserCanApproveAttachments && !(bool)Eval("Approved") %>' />
				</td>
			</tr>
		</ItemTemplate>
		
		<AlternatingItemTemplate>
			<tr>
				<td class="TableRow DarkBackground" width="20" nowrap="nowrap">
					<asp:Button ID="btnDelete" CommandName="Delete" Text="Delete" runat="server" CssClass="FormButtons" CommandArgument='<%# Eval("AttachmentID") %>' 
						visible='<%# base.UserMayManageAttachments %>' OnClientClick='<%# "return confirm(\"Are you sure you want to delete the attachment: " + Eval("Filename") + " ?\");" %>' /><asp:Label runat="server" ID="lblEmptySpace" visible='<%# !base.UserMayManageAttachments %>'>&nbsp;</asp:Label>
				</td>
				<td class="TableRow DarkBackground" width="420">
					<asp:HyperLink runat="server" ID="lnkGetAttachment" Visible='<%# (!base.UserCanApproveAttachments && (bool)Eval("Approved")) || base.UserCanApproveAttachments %>' 
						Target="_blank" NavigateUrl='<%# "FileStreamer.aspx?AttachmentID=" + Eval("AttachmentID")%>'><%# Eval("Filename") %></asp:HyperLink>
					<asp:Label runat="server" ID="lblFilename" Visible='<%# !base.UserCanApproveAttachments && !(bool)Eval("Approved") %>'><%# Eval("Filename") %></asp:Label>
				</td>
				<td class="TableRow DarkBackground" width="75" align="right"><asp:Label ID="lblFilesize" runat="server"><%# ((int)Eval("Filesize")).ToString("N0") %></asp:Label></td>
				<td class="TableRow DarkBackground" width="148" align="right"><asp:Label ID="lblLastModifiedOn" runat="server"><%# ((DateTime)Eval("AddedOn")).ToString("dd-MMM-yyyy HH:mm.ss", DateTimeFormatInfo.InvariantInfo)%></asp:Label></td>
				<td class="TableRow DarkBackground" width="85" align="right">
					<asp:Button id="btnApprove" runat="server" CssClass="FormButtons" Text="Approve" CommandName="Approve" 
						CommandArgument='<%# Eval("AttachmentID") %>' Visible='<%# base.UserCanApproveAttachments && !(bool)Eval("Approved") %>' />
					<asp:Button id="btnRevoke" runat="server" CssClass="FormButtons" Text="Revoke" CommandName="Revoke" 
						CommandArgument='<%# Eval("AttachmentID") %>' Visible='<%# base.UserCanApproveAttachments && (bool)Eval("Approved") %>' />
					<asp:label ID="lblApproved" runat="server" Text="Approved" Visible='<%# !base.UserCanApproveAttachments && (bool)Eval("Approved") %>' />
					<asp:label ID="lblPending" runat="server" Text="Pending" Visible='<%# !base.UserCanApproveAttachments && !(bool)Eval("Approved") %>' />
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
<asp:PlaceHolder ID="phAddNewAttachment" runat="server" Visible="true">
<tr>
	<td>
		<br />
		Add a new attachment: <asp:FileUpload ID="fuUploader" size="60" runat="server" />&nbsp;&nbsp;
		<asp:Button ID="btnUploadAttachment" runat="server" Text=" Upload " CssClass="FormButtons" OnClick="btnUploadAttachment_Click" />
	</td>
</tr>
</asp:PlaceHolder>
<asp:PlaceHolder ID="phUploadResult" runat="server" Visible="false">
<tr>
	<td>
		<br />
		<asp:Label ForeColor="Red" ID="lblError" runat="server" Visible="false" />
		<asp:Label ID="lblSuccess" runat="server" Visible="false" />
	</td>
</tr>
</asp:PlaceHolder>
<tr>
	<td>
		<br><br />
		<hr align="left" size="1" width="80%">
		<asp:button cssclass="FormButtons" id="btnContinue" runat="server" text=" Continue " commandname="btnContinue" OnClick="btnContinue_Click" />
	</td>
</tr>
</table>
</form>
<br clear="all">
<!-- footer -->
<hnd:pagefooter runat="server" id="PageFooter" />
</body>
</html>
