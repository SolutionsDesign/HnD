<%@ Page language="c#" CodeFile="NewMessage.aspx.cs" AutoEventWireup="false" Inherits="SD.HnD.GUI.NewMessage" ValidateRequest="false"
	Async="true"%>
<%@ Import namespace="SD.HnD.DAL.EntityClasses" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="System.Web" %>
<%@ Register TagPrefix="HnD" TagName="MessageEditor" Src="MessageEditor.ascx"%>
<%@ Register TagPrefix="HnD" TagName="PageHeader" Src="Header.ascx"%>
<%@ Register TagPrefix="HnD" TagName="PageFooter" Src="Footer.ascx"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
  <head runat="server">
	<title>HnD::Add a new message to thread: <%=HttpUtility.HtmlEncode(base.ThreadSubject)%></title>
	<meta name="vs_defaultClientScript" content="JavaScript">
	<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">  </head>
<body onload="SetFocus();">
<form id="Form1" runat="server" method="post">
<table width="750" align="center" border="0" cellpadding="0" cellspacing="0">
<hnd:pageheader runat="server" id="PageHeader" />
<tr>
	<td class="SmallFontSmallest" colspan="2">
		<br>
		You are here: <b><a href="Default.aspx">Home</a> &gt; <asp:label ID="lblSectionName" Runat="server" /> &gt; 
		<asp:hyperlink id="lnkThreads" NavigateUrl="Threads.aspx" Runat="server" /> &gt; 
		<asp:hyperlink ID="lnkMessages" NavigateURL="Messages.aspx?ThreadID=" Runat="server"/> &gt; Add new message</b>
		<br><br>
	</td>
</tr>
<asp:placeholder runat="server" id="phMemo" visible="False">
<tr><td>&nbsp;<br /></td></tr>
<tr>
	<td class="supportarea">
		<table width="100%" align="center" border="0" cellpadding="2" cellspacing="0">
		<tr>
			<td class="SupportAreaHeader">Memo</td>
		</tr>
		<tr>
			<td>
				<asp:label runat="server" id="lblMemo"/>
			</td>
		</tr>
		</table>
	</td>
</tr>
<tr><td>&nbsp;<br /></td></tr>
</asp:placeholder>
</table>

<hnd:messageeditor runat="server" OnPostMessage="PostMessageHandler" OnCancelAction="CancelActionHandler" id="meMessageEditor" ShowAddAttachment="true" />
<asp:placeholder id="phLastPostingInThread" runat="server">
<!-- last message in thread -->
<br clear="all"><br>
<table width="750" align="center" border="0" cellpadding="0" cellspacing="0">
<tr>
	<td class="TableHeaderOneLine">
		<span class="TableName">Last posting in thread</span>
	</td>
</tr>
<tr>
	<td class="TableContent" colspan="2">
		<table width="100%" align="center" border="0" cellpadding="0" cellspacing="1">
		<tr>
			<td>
				<table width="100%" align="center" border="0" cellpadding="2" cellspacing="0">
				<tr>
					<td class="TableColumnHeader" width="100">Poster</td>
					<td class="TableColumnHeader">Message</td>
				</tr>
				</table>
			</td>
		</tr>
		<tr>
			<td>
				<table width="100%" align="center" border="0" cellpadding="2" cellspacing="0">
				<tr>
					<td width="100" valign="top" class="TableRow LightBackground">
						<b><asp:label id="lblNickname" runat="server"/></b><br>
						<span class="SmallFontAuthorSmaller"><asp:label id="lblUserTitleDescription" runat="server"/></span>
						<br><br>
						<span class="SmallFontAuthorSmallest">
							<b>Location:</b> <br><asp:label id="lblLocation" runat="server"/><br>
							<b>Joined on:</b> <br><asp:label id="lblJoinDate" runat="server"/><br>
							<b>Posted:</b> <br><asp:label id="lblAmountOfPostings" runat="server"/> posts<br>
						</span>
					</td>
					<td class="TableRow LightBackground" valign="top" height="100%">
						<table border="0" width="100%" cellpadding="1" cellspacing="0" height="100%">
						<tr>
							<td width="65%" class="MessageHeader LightBackground"><span class="SmallFontSmaller">Posted on: <asp:label id="lblPostingDate" runat="server"/></span></td>
							<td align="right" class="MessageHeader LightBackground">&nbsp;</td>
						</tr>
						<tr>
							<td colspan="2" class="TableRow LightBackground" valign="top" height="100%">
								<asp:literal id="litMessageBody" runat="server"/>
							</td>
						</tr>
						<tr>
							<td class="MessageFooter LightBackground" valign="top">
								<asp:literal id="litSignature" runat="server"/>
							</td>
							<td class="MessageFooter LightBackground" valign="top" align="right">
								<b><a href="#top">Top</a></b>
							</td>
						</tr>
						</table>
					</td>
				</tr>
				</table>
			</td>
		</tr>
		</table>
	</td>
</tr>
</table>
</asp:placeholder>
</form>
<br clear="all">
<!-- footer -->
<hnd:pagefooter runat="server" id="PageFooter" />
</body>
</html>
