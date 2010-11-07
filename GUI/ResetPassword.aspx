<%@ Page language="c#" CodeFile="ResetPassword.aspx.cs" AutoEventWireup="false" Inherits="SD.HnD.GUI.ResetPassword" %>
<%@ Register TagPrefix="HnD" TagName="PageFooter" Src="Footer.ascx"%>
<%@ Register TagPrefix="HnD" TagName="PageHeader" Src="HeaderRestrictedMenu.ascx"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
  <head runat="server">
	<title>HnD::Reset Password</title>
	<meta name="vs_defaultClientScript" content="JavaScript">
	<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">

	<script LANGUAGE="javascript">
		function SetFocus()
		{
			document.forms[0].elements.tbxNickName.focus();
		}
	</script>
</head>
<body onLoad="SetFocus();">
<table width="750" align="center" border="0" cellpadding="0" cellspacing="0">
<hnd:pageheader runat="server" id="PageHeader" />
</table>
<br clear="all">
<form id="Form1" runat="server" method="post">
<table width="748" align="center" class="ExplanationBox" cellpadding="2" cellspacing="0">
<tr>
	<td>
		<b>Reset your password</b><br><br>
		Please specify your nickname and emailaddress to reset your password. Your new password
		will be mailed to the emailaddress registered with the nickname you specify. The emailaddress you specify
		below has to be the same emailaddress otherwise the system will not reset your password.<br>
		<table width="746" align="center" border="0" cellpadding="1" cellspacing="0">
		<tr><td colspan="2">&nbsp;</td></tr>
		<tr>
			<td align="right" width="100">Nickname&nbsp;</td>
			<td>&nbsp;<input type="text" id="tbxNickName" runat="server" NAME="tbxNickname" class="Inputborder">
			<asp:requiredfieldvalidator id="rfdNickNameValidator" runat="server" ErrorMessage="Nickname is empty" ControlToValidate="tbxNickName" /></td>
		</tr>
		<tr>
			<td align="right">Emailaddress&nbsp;</td>
			<td>&nbsp;<input type="text" size="50" maxlength="200" id="tbxEmailAddress" runat="server" NAME="tbxEmailAddress" class="Inputborder">
				<asp:requiredfieldvalidator id="rfdEmailAddressValidator" runat="server" ErrorMessage="Emailaddress is empty" ControlToValidate="tbxEmailAddress" /></td>
		</tr>
		<tr>
			<td>&nbsp;</td>
			<td>
				<hr align="left" size="1" width="80%">
				<input type="submit" id="btnResetPassword" runat="server" value=" Reset Password " NAME="btnResetPassword" class="FormButtons">
				<br><br>
			</td>
		</tr>
		</table>
	</td>
</tr>
</table>
<table width="450" align="center">
<tr>
	<td>
		<asp:label id="lblErrorMessage" runat="server" forecolor="Red"></asp:label>
	</td>
</tr>
</table>
</form>
<!-- footer -->
<hnd:pagefooter runat="server" id="PageFooter" />
</body>
</html>
