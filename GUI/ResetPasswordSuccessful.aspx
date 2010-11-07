<%@ Register TagPrefix="HnD" TagName="PageFooter" Src="Footer.ascx"%>
<%@ Register TagPrefix="HnD" TagName="PageHeader" Src="HeaderRestrictedMenu.ascx"%>
<%@ Page language="c#" CodeFile="ResetPasswordSuccessful.aspx.cs" AutoEventWireup="false" Inherits="SD.HnD.GUI.ResetPasswordSuccessful" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
  <head runat="server">
	<title>HnD::Reset of password Successful</title>
	<meta name="vs_defaultClientScript" content="JavaScript">
	<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">  </head>
<body>
<table width="750" align="center" border="0" cellpadding="0" cellspacing="0">
<hnd:pageheader runat="server" id="PageHeader" />
</table>
<br clear="all">
<table width="750" align="center" class="ExplanationBox" cellpadding="2" cellspacing="0">
<tr>
	<td>
		<h3>Reset of your password was successful!</h3>
		You'll receive an email with your new password a.s.a.p. Use that password to login, by clicking 
		<a href="Login.aspx">here</a>. You can then change your new password by editing your profile.
		<br><br>
	</td>
</tr>
</table>
<br clear="all">
<br clear="all">
<!-- footer -->
<hnd:pagefooter runat="server" id="PageFooter" />
</body>
</html>
