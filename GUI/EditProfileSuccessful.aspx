<%@ Page language="c#" CodeFile="EditProfileSuccessful.aspx.cs" AutoEventWireup="false" Inherits="SD.HnD.GUI.EditProfileSuccessful" %>
<%@ Register TagPrefix="HnD" TagName="PageFooter" Src="Footer.ascx"%>
<%@ Register TagPrefix="HnD" TagName="PageHeader" Src="HeaderRestrictedMenu.ascx"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head runat="server">
	<title>HnD::Edit profile Successful</title>
	<meta name="vs_defaultClientScript" content="JavaScript">
	<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">  </head>
<body>
<table width="750" align="center" border="0" cellpadding="0" cellspacing="0">
<hnd:pageheader runat="server" id="PageHeader" />
</table>
<br clear="all"><br>
<table width="750" align="center" class="ExplanationBox" cellpadding="2" cellspacing="0">
<tr>
	<td>
		<h3>Profile has been updated successfully!</h3>
		Your profile has been updated successfully. You can now close this window. 
		<br><br>
		<center>
			<a href="javascript://" onclick="window.close();">Close window</a>
		</center>
	</td>
</tr>
</table>
<br clear="all">
<br clear="all">
<!-- footer -->
<hnd:pagefooter runat="server" id="PageFooter" />
</body>
</html>
