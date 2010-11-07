<%@ Register TagPrefix="HnD" TagName="PageFooter" Src="Footer.ascx"%>
<%@ Register TagPrefix="HnD" TagName="PageHeader" Src="HeaderRestrictedMenu.ascx"%>
<%@ Page language="c#" CodeFile="login.aspx.cs" AutoEventWireup="false" Inherits="SD.HnD.GUI.Login" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head runat="server">
	<title>HnD::Log in</title>
	<meta name="vs_defaultClientScript" content="JavaScript">
	<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">

	<script LANGUAGE="javascript">
		function SetFocus()
		{
			document.forms[0].elements.tbxUserName.focus();
		}
	</script>
</head>
<body onLoad="SetFocus();">
<table width="750" align="center" border="0" cellpadding="0" cellspacing="0">
<hnd:pageheader runat="server" id="PageHeader" />
</table>
<br clear="all"><br>
<form id="login" method="post" runat="server" >
<table width="750" align="center" class="ExplanationBox" cellspacing="0">
<tr>
	<td>
		<table width="748" align="center" border="0" cellpadding="1" cellspacing="0">
		<tr>
			<td nowrap="nowrap" width="300" align="right">
				<b>Please specify your login credentials</b><br>
			</td>
			<td>&nbsp;</td>
		</tr>
		<tr><td colspan="2">&nbsp;</td></tr>
		<tr>
			<td align="right">Nickname&nbsp;</td>
			<td>&nbsp;<input type="text" id="tbxUserName" runat="server" NAME="UserName" class="Inputborder">
				<asp:requiredfieldvalidator id="rfdNickNameValidator" runat="server" ErrorMessage="Nickname is empty" ControlToValidate="tbxUserName" />
			</td>
		</tr>
		<tr>
			<td align="right">Password&nbsp;</td>
			<td>&nbsp;<input type="password" id="tbxPassword" runat="server" NAME="Password" class="Inputborder">
				<asp:requiredfieldvalidator id="rfdPasswordValidator" runat="server" ErrorMessage="Password is empty" ControlToValidate="tbxPassword" /></td>
		</tr>
		<tr>
			<td align="right">Log in automatically</td>
			<td><input type="checkbox" class="NoBorder" name="PersistentLogin" id="chkPersistentLogin" runat="server"></td>
		</tr>
		<tr>
			<td>&nbsp;</td>
			<td>
				<hr align="left" size="1" width="80%">
				<input type="submit" id="btnLogin" runat="server" value="   Login   " NAME="btnLogin" class="FormButtons"><br><br>
				<a href="ResetPassword.aspx">Forgot your password?</a>
			</td>
		</tr>
		</table>
	</td>
</tr>
</table>
<br clear="all">
<table width="750" align="center">
<tr>
	<td>
		<asp:label id="lblErrorMessage" runat="server" style="color:Red;"></asp:label>
	</td>
</tr>
</table>
</form>
<br clear="all">
<!-- footer -->
<hnd:pagefooter runat="server" id="PageFooter" />
</body>
</html>
