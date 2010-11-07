<%@ Register TagPrefix="HnD" TagName="PageFooter" Src="Footer.ascx"%>
<%@ Register TagPrefix="HnD" TagName="PageHeader" Src="Header.ascx"%>
<%@ Register TagPrefix="HnD" TagName="MessageEditor" Src="MessageEditor.ascx"%>
<%@ Page language="c#" CodeFile="NewThread.aspx.cs" AutoEventWireup="false" Inherits="SD.HnD.GUI.NewThread" ValidateRequest="false"
	Async="true"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head runat="server">
	<title>HnD::Create a new thread in Forum: <%=HttpUtility.HtmlEncode(base.ForumName)%></title>
	<meta name="vs_defaultClientScript" content="JavaScript">
	<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">

	<script LANGUAGE="javascript">
		function SetFocus()
		{
			document.forms[0].elements.tbxSubject.focus();
		}
	</script>
</head>
<body onload="SetFocus();">
<form id="Form1" runat="server" method="post">
<table width="750" align="center" border="0" cellpadding="0" cellspacing="0">
<hnd:pageheader runat="server" id="PageHeader" />
<tr>
	<td class="SmallFontSmallest" colspan="2">
		<br>
		You are here: <b><a href="Default.aspx">Home</a> &gt; <asp:label ID="lblSectionName" Runat="server" /> &gt; <asp:hyperlink id="lnkThreads" NavigateUrl="Threads.aspx" Runat="server" /> &gt; Add New Thread</b>
		<br><br>
	</td>
</tr>
</table>
<asp:PlaceHolder ID="phWelcomeText" runat="server" Visible="false">
<table width="750" align="center" class="ExplanationBox" cellpadding="3" cellspacing="0">
<tr>
	<td>
		<asp:Literal ID="litWelcomeText" runat="server" />
	</td>
</tr>
</table>
<br clear="all">
</asp:PlaceHolder>
<hnd:messageeditor runat="server" OnPostMessage="PostMessageHandler" OnCancelAction="CancelActionHandler" id="meMessageEditor" ShowAddAttachment="true"/>
</form>
<br clear="all">
<!-- footer -->
<hnd:pagefooter runat="server" id="PageFooter" />
</body>
</html>
