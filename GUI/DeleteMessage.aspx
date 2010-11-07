<%@ Register TagPrefix="HnD" TagName="PageHeader" Src="Header.ascx"%>
<%@ Page language="c#" CodeFile="DeleteMessage.aspx.cs" AutoEventWireup="false" Inherits="SD.HnD.GUI.DeleteMessage" %>
<%@ Register TagPrefix="HnD" TagName="PageFooter" Src="Footer.ascx"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
  <head runat="server">
	<title>HnD::Delete a message</title>
	<meta name="vs_defaultClientScript" content="JavaScript">
	<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">  </head>
<body>
<form id="Form1" runat="server" method="post">
<table width="750" align="center" border="0" cellpadding="0" cellspacing="0">
<hnd:pageheader runat="server" id="PageHeader" />
</table>
<br clear="all"><br>
<table width="750" align="center" class="ExplanationBox" cellpadding="2" cellspacing="0">
<tr>
	<td>
		<h3>Delete message</h3>
		<p>
			Below you see the message you're about to delete. If you click <i>Yes</i>, the message and its complete history log is deleted from the
			database. This is an irreversable action. If you click <i>No</i>, nothing happens and you are transfered back to the thread containing
			this message. 
		</p>
	</td>
</tr>
</table>
<br clear="all">
<table width="750" align="center" border="0" cellpadding="0" cellspacing="0">
<tr>
	<td class="FormHeaderTwoLine" colspan="2">
		<span class="FormName"><asp:label ID="lblForumName_Header" Runat="server" /></span>
		<br>
		<span class="FormSubName"><%=HttpUtility.HtmlEncode(base.ThreadSubject)%></span>
	</td>
</tr>
<tr>
	<td class="FormContent" colspan="2">
		<table width="748" align="center" border="0" cellpadding="2" cellspacing="0">
		<tr>
			<td width="100" class="TableRow LightBackground" valign="top" align="right">Message</td>
			<td width="648" class="TableRow LightBackground" valign="top" height="100%">
				<table border="0" width="100%" cellpadding="1" cellspacing="0" height="100%">
				<tr>
					<td width="480" class="MessageHeader"><span class="SmallFontSmaller">Posted on: <asp:label Runat="server" ID="lblPostingDate" /></span></td>
					<td align="right" class="MessageHeader">&nbsp;</td>
				</tr>
				<tr>
					<td colspan="2" class="TableRow LightBackground" valign="top" height="100%">
						<asp:label ID="lblMessageBody" Runat="server" />
						<br><br>
					</td>
				</tr>
				<tr>
					<td colspan="2" class="MessageFooter"><br></td>
				</tr>
				</table>
			</td>
		</tr>
		<tr>
			<td class="TableRow LightBackground">&nbsp;</td>
			<td class="TableRow LightBackground" align="center">
				Are you sure you want to delete this message?<br>
				<br><br>
				<asp:button CssClass="FormButtons" ID="btnYes" Runat="server" Text="  Yes  " CommandName="btnYes" />&nbsp;&nbsp;&nbsp;&nbsp;
				<asp:button CssClass="FormButtons" ID="btnNo" Runat="server" Text="   No   " CommandName="btnNo" />
				<br><br><br>
			</td>
		</tr>
		</table>
	</td>
</tr>
<tr>
	<td class="EmptyRowBottom" height="5" colspan="2"><img src="pics/separator.gif" border="0"></td>
</tr>
</table>
</form>
<br clear="all">
<!-- footer -->
<hnd:pagefooter runat="server" id="PageFooter" />
</body>
</html>
