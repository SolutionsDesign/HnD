<%@ Page language="c#" CodeFile="EditMessage.aspx.cs" AutoEventWireup="false" Inherits="SD.HnD.GUI.EditMessage" ValidateRequest="false"%>
<%@ Register TagPrefix="HnD" TagName="PageFooter" Src="Footer.ascx"%>
<%@ Register TagPrefix="HnD" TagName="PageHeader" Src="Header.ascx"%>
<%@ Register TagPrefix="HnD" TagName="MessageEditor" Src="MessageEditor.ascx"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
  <head runat="server">
	<title>HnD::Edit a message in thread: <%=HttpUtility.HtmlEncode(base.ThreadSubject)%></title>
	<meta name="vs_defaultClientScript" content="JavaScript">
	<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">

</head>
<body onload="SetFocus();">
<form id="Form1" runat="server" method="post">
<table width="750" align="center" border="0" cellpadding="0" cellspacing="0">
<hnd:pageheader runat="server" id="PageHeader" />
<tr>
	<td class="SmallFontSmallest" colspan="2">
		<br>
		You are here: <b><a href="Default.aspx">Home</a> &gt; <asp:label ID="lblSectionName" Runat="server" /> &gt; 
		<asp:hyperlink id="lnkThreads" NavigateUrl="Threads.aspx" Runat="server" /> &gt; 
		<asp:hyperlink ID="lnkMessages" NavigateURL="Messages.aspx?ThreadID=" Runat="server"/> &gt; Edit message</b>
		<br><br>
	</td>
</tr>
</table>
<hnd:messageeditor runat="server" OnPostMessage="PostMessageHandler" OnCancelAction="CancelActionHandler" id="meMessageEditor" ShowAddAttachment="false" ShowSubscribeToThread="false"/>
</form>
<br clear="all">
<!-- footer -->
<hnd:pagefooter runat="server" id="PageFooter" />
</body>
</html>
