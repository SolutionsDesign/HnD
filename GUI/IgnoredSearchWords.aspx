<%@ Import namespace="System.Data" %>
<%@ Register TagPrefix="HnD" TagName="PageFooter" Src="Footer.ascx"%>
<%@ Register TagPrefix="HnD" TagName="PageHeader" Src="Header.ascx"%>
<%@ Page language="c#" CodeFile="IgnoredSearchWords.aspx.cs" AutoEventWireup="false" Inherits="SD.HnD.GUI.IgnoredSearchWords" %>
<!doctype html public "-//w3c//dtd html 4.0 transitional//en" >
<html>
  <head runat="server">
	<title>HnD::Ignored Search Words</title>
	<meta name="vs_defaultClientScript" content="JavaScript">
	<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">  </head>
<body ms_positioning="GridLayout" onload="SetFocus();">
<table width="750" align="center" border="0" cellpadding="0" cellspacing="0">
<hnd:pageheader runat="server" id="PageHeader" />
</table>
<br clear="all"/>
<form id="form1" method="post" runat="server">
<table width="750" align="center" class="ExplanationBox" cellpadding="0" cellspacing="0">
<tr>
	<td>
		<h3>Ignored search words.</h3>
		<table width="748" border="0" cellspacing="0" cellpadding="2">
		<tr>
			<td valign="top"><asp:label id="lblWordList1" runat="server" /></td>
			<td valign="top"><asp:label id="lblWordList2" runat="server" /></td>
			<td valign="top"><asp:label id="lblWordList3" runat="server" /></td>
			<td valign="top"><asp:label id="lblWordList4" runat="server" /></td>
			<td valign="top"><asp:label id="lblWordList5" runat="server" /></td>
		</tr>
		</table>
	</td>
</tr>
</table>

</form>
<br clear="all">
<!-- footer -->
<hnd:pagefooter runat="server" id="PageFooter" />
</body>
</html>
