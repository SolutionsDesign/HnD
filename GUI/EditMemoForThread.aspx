<%@ Register TagPrefix="HnD" TagName="MessageEditor" Src="MessageEditor.ascx"%>
<%@ Register TagPrefix="HnD" TagName="PageFooter" Src="Footer.ascx"%>
<%@ Register TagPrefix="HnD" TagName="PageHeader" Src="Header.ascx"%>
<%@ Page language="c#" CodeFile="EditMemoForThread.aspx.cs" AutoEventWireup="false" ValidateRequest="false" Inherits="SD.HnD.GUI.EditMemoForThread" %>
<!doctype html public "-//w3c//dtd html 4.0 transitional//en" >
<html>
  <head runat="server">
	<title>HnD::Edit Memo information for thread thread: <%=HttpUtility.HtmlEncode(base.ThreadSubject)%></title>
	<meta name="vs_defaultClientScript" content="JavaScript">
	<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">  </head>
<body onload="SetFocus();">
<form id="EditMemo" method="post" runat="server">
<table width="750" align="center" border="0" cellpadding="0" cellspacing="0">
<hnd:pageheader runat="server" id="PageHeader" />
<tr>
	<td class="SmallFontSmallest" colspan="2">
		<br>
		You are here: <b><a href="Default.aspx">Home</a> &gt; <asp:label id="lblSectionName" runat="server" /> &gt; 
		<asp:hyperlink id="lnkThreads" navigateurl="Threads.aspx" runat="server" /> &gt; 
		<asp:hyperlink id="lnkMessages" navigateurl="Messages.aspx?ThreadID=" runat="server"/> &gt; Edit memo</b>
		<br><br>
	</td>
</tr>
</table>
<hnd:messageeditor runat="server" onpostmessage="PostMessageHandler" oncancelaction="CancelActionHandler" id="meMessageEditor" AllowEmptyMessage="true" ButtonText="   Save   " MessageType="Memo Text" ShowAddAttachment="false" ShowSubscribeToThread="false"/>
</form>
<br clear="all">
<!-- footer -->
<hnd:pagefooter runat="server" id="PageFooter" />
</body>
</html>
