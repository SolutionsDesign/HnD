<%@ Page language="c#" CodeFile="CloseThread.aspx.cs" AutoEventWireup="false" Inherits="SD.HnD.GUI.CloseThread" ValidateRequest="false" Async="true"%>
<%@ Register TagPrefix="HnD" TagName="PageFooter" Src="Footer.ascx"%>
<%@ Register TagPrefix="HnD" TagName="PageHeader" Src="Header.ascx"%>
<%@ Register TagPrefix="HnD" TagName="MessageEditor" Src="MessageEditor.ascx"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head runat="server">
	<title>HnD::Close the thread: <%=HttpUtility.HtmlEncode(base.ThreadSubject)%></title>
	<meta name="vs_defaultClientScript" content="JavaScript">
	<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">

</head>
<body>
<form id="Form1" method="post" runat="server">
<table width="750" align="center" border="0" cellpadding="0" cellspacing="0">
<hnd:pageheader runat="server" id="PageHeader" />
</table>
<br clear="all"/>
<table width="750" align="center" class="ExplanationBox" cellpadding="2" cellspacing="0">
<tr>
	<td>
		<h3>Close thread</h3>
		<p>
			Below you can edit the text for the close message of the thread <i><b><%=HttpUtility.HtmlEncode(base.ThreadSubject)%></b></i>. When you click
			<i>Post</i>, the close message is added to the thread and the thread is closed so no more messages can be added to the
			thread. 
		</p>
	</td>
</tr>
</table>
<br clear="all">
<hnd:messageeditor runat="server" OnPostMessage="PostMessageHandler" OnCancelAction="CancelActionHandler" id="meMessageEditor" ShowSubscribeToThread="false" />
</form>
<br clear="all">
<!-- footer -->
<hnd:pagefooter runat="server" id="PageFooter" />
</body>
</html>
