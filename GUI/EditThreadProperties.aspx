<%@ Register TagPrefix="HnD" TagName="PageHeader" Src="Header.ascx"%>
<%@ Page language="c#" CodeFile="EditThreadProperties.aspx.cs" AutoEventWireup="false" Inherits="SD.HnD.GUI.EditThreadProperties" %>
<%@ Register TagPrefix="HnD" TagName="PageFooter" Src="Footer.ascx"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head runat="server">
	<title>HnD::Edit thread properties of thread: <%=HttpUtility.HtmlEncode(base.ThreadSubject)%></title>
	<meta name="vs_defaultClientScript" content="JavaScript">
	<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">

</head>
<body>
<form id="Form1" runat="server" method="post">
<table align="center" border="0" cellpadding="0" cellspacing="0" width="750">
<hnd:pageheader runat="server" id="PageHeader" />
</table>
<br clear="all">
<table width="750" align="center" class="ExplanationBox" cellpadding="2" cellspacing="0">
<tr>
	<td>
		<b>Edit Thread Properties</b>
		<p>
			Below you can change the properties of the thread <i><b><%=HttpUtility.HtmlEncode(base.ThreadSubject)%></b></i>. 
			When you enable the <i>Closed</i> checkbox, the thread is closed but there will be no close message at the end
			of the thread. If you want that, use the <i>close thread</i> option in the message view. 
		</p>
	</td>
</tr>
</table>
<br clear="all">
<table align="center" class="ExplanationBox" cellpadding="0" cellspacing="0" width="750">
<tr>
	<td>
		<asp:validationsummary id="vsErrors" runat="server" headertext="The following errors occured / you have to provide a value for the following fields:"/>
	</td>
</tr>
</table>
<table align="center" class="ExplanationBox" cellpadding="0" cellspacing="0" width="750">
<tr>
	<td>
		<table width="748" border="0" cellpadding="1" cellspacing="1" align="center">
		<tr><td colspan="2" class="TableColumnHeader">Thread Properties of thread: <i><%=HttpUtility.HtmlEncode(base.ThreadSubject)%></i></td></tr>
		<tr><td colspan="2" class="SmallFontSmaller">Fields marked with a '*' are mandatory.</td></tr>
		<tr class="LightBackground">
			<td width="170">Subject *</td>
			<td>
				<input type="text" id="tbxSubject" maxlength="250" size="50" runat="server" NAME="tbxSubject" class="Inputborder">
				<asp:requiredfieldvalidator display="None" controlToValidate="tbxSubject" Runat="server" ErrorMessage="Subject is empty" ID="rfvSubject" name="rfvSubject"/>
			</td>
		</tr>
		<tr class="DarkBackground">
			<td width="170">Is closed</td>
			<td valign="top"><input type="checkbox" runat="server" id="chkIsClosed" name="chkIsClosed"></td>
		</tr>
		<tr class="LightBackground">
			<td width="170">Is pinned / sticky</td>
			<td valign="top"><input type="checkbox" runat="server" id="chkIsSticky" name="chkIsSticky"></td>
		</tr>
		<tr class="NormalBackground">
			<td width="170">&nbsp;</td>
			<td>
				<hr align="left" size="1" width="80%">
				<input type="submit" id="btnUpdate" runat="server" name="btnUpdate" value="   Update   " class="FormButtons">&nbsp;&nbsp;
				<input type="submit" id="btnCancel" runat="server" name="btnCancel" value="   Cancel   " class="FormButtons" causesvalidation="false">
			</td>
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
