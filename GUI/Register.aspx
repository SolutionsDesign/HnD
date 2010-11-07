<%@ Page language="c#" CodeFile="Register.aspx.cs" AutoEventWireup="false" Inherits="SD.HnD.GUI.Register" %>
<%@ Register TagPrefix="HnD" TagName="PageFooter" Src="Footer.ascx"%>
<%@ Register TagPrefix="HnD" TagName="PageHeader" Src="HeaderRestrictedMenu.ascx"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
  <head runat="server">
	<title>HnD::Register as new user</title>
	<meta name="vs_defaultClientScript" content="JavaScript">
	<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">

	<script LANGUAGE="javascript">
		function SetFocus()
		{
			document.forms[0].elements.tbxNickName.focus();
		}
	</script>
</head>
<body onload="SetFocus();">
<form id="RegisterForm" method="post" runat="server">
<table width="750" align="center" border="0" cellpadding="0" cellspacing="0">
<hnd:pageheader runat="server" id="PageHeader" />
</table>
<br clear="all">
<!-- Register block -->
<table width="750" align="center" class="ExplanationBox" cellpadding="2" cellspacing="0">
<tr>
	<td>
		<h3>Register as a new user.</h3>
		<p>
			Below you can enter your information to register so you will be allowed to participate in the 
			discussions helt in the various forums. When registering, you agree to be bound to the registration terms of this site and
			which apply to all forums. These terms can be found <a href="RegistrationRules.aspx" target="_blank">here</a>. If you do not
			agree with these rules, you should not register.
		</p>
		<p>
			No information will be disclosed to other parties than the forumsystem itself. You decide which information you
			want to enter in the non-mandatory fields. The email-address you enter is used to send you a new password, when
			you might forget it and can be made hidden for visitors of the forums. The email address is also used for sending you
			notifications if you subscribe to thread notifications.
		</p>
		<p>
			Please, don't forget to read the <a href="RegistrationRules.aspx" target="_blank">registration terms</a>.
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
		<tr>
			<td colspan="2" class="TableColumnHeader">Your profile</td>
		</tr>
		<tr class="NormalBackground"><td colspan="2" class="SmallFontSmaller"><b>Registration information.</b> Fields marked with a '*' are mandatory.</td></tr>
		<tr class="LightBackground">
			<td width="170">Nickname *</td>
			<td>
				<input type="text" id="tbxNickName" runat="server" name="tbxNickName" maxlength="20" size="20" class="Inputborder">
				<asp:RequiredFieldValidator id="rfvNickName" runat="server" ErrorMessage="Nickname" ControlToValidate="tbxNickName" display="None"/>
				<asp:label ID="lblNickNameError" Runat="server" Visible="False" ForeColor="Red">Nickname already exists.</asp:label>
				</td>
		</tr>
		<tr class="DarkBackground">
			<td width="170">Password</td>
			<td>Your initial password will be randomly generated and mailed to the address you specify at
				<i>Email address</i> below.
			</td>
		</tr>
		<tr class="LightBackground">
			<td width="170">Your IP number</td>
			<td><asp:label ID="lblIPNumber" Runat="server" /></td>
		</tr>
		<tr class="DarkBackground">
			<td width="170">Emailaddress *</td>
			<td>
				<input type="text" id="tbxEmailAddress" runat="server" name="tbxEmailAddress" maxlength="200" size="40" class="Inputborder">&nbsp;
				<asp:RegularExpressionValidator id="revEmailAddress" runat="server" ErrorMessage="Not a valid address" ControlToValidate="tbxEmailAddress" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" display="Dynamic"/>
				<asp:RequiredFieldValidator id="rfvEmailAddress" runat="server" ErrorMessage="Email address" ControlToValidate="tbxEmailAddress" display="None" width="31px"/>
			</td>
		</tr>
		<tr class="NormalBackground"><td colspan="2" class="SmallFontSmaller"><br><b>Personal information, which should tell something about you.</b></td></tr>
		<tr>
			<td width="170">User icon URL<br>
				<span class="SmallFontSmallest">(Only 60x60 .jpg and .gif are accepted)</span>
				</td>
			<td valign="top">
				http://<input type="text" id="tbxIconURL" runat="server" name="tbxIconURL" maxlength="250" size="50" class="Inputborder"><br>
				<asp:RegularExpressionValidator id="revIconURL" runat="server" ErrorMessage="Not a valid user icon URL" 
					ControlToValidate="tbxIconURL" ValidationExpression="([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;~=]*)?/[\w-]+\.(jpg|gif)" display="Dynamic"/>
			</td>
		</tr>
		<tr class="DarkBackground">
			<td width="170">Date of birth <br>
				<span class="SmallFontSmallest">Format: mm/dd/yyyy</span></td>
			<td>
				<input type="text" id="tbxDateOfBirth" runat="server" name="tbxDateOfBirth" maxlength="10" size="11" class="Inputborder">
				<asp:RegularExpressionValidator id="revDateOfBirth" runat="server" ErrorMessage="Wrong date format" ValidationExpression="\d{1,2}/\d{1,2}/\d{4}" controltovalidate="tbxDateOfBirth"/>
			</td>
		</tr>
		<tr class="LightBackground">
			<td width="170">Occupation</td>
			<td><input type="text" id="tbxOccupation" style="WIDTH: 360px" runat="server" name="tbxOccupation" maxlength="100" size="50" class="Inputborder"></td>
		</tr>
		<tr class="DarkBackground">
			<td width="170">Location<br>
				<span class="SmallFontSmallest">f.e.: city, country</span></td>
			<td><input type="text" id="tbxLocation" style="WIDTH: 360px" runat="server" name="tbxLocation" maxlength="100" size="50" class="Inputborder"></td>
		</tr>
		<tr class="LightBackground">
			<td width="170">Website</td>
			<td valign="top">http://<input type="text" id="tbxWebsite" runat="server" name="tbxWebsite" maxlength="200" size="50" class="Inputborder"><br>
				<asp:RegularExpressionValidator id="revWebsite" runat="server" ErrorMessage="Not a valid URL" ControlToValidate="tbxWebsite" ValidationExpression="([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?" Display="Dynamic"/>
			</td>
		</tr>
		<tr class="DarkBackground">
			<td width="170" valign="top">Signature<br>
				<span class="SmallFontSmallest">You can use several <a href="Help.aspx#UBBTags" target="_blank">UBB Tags</a> in your signature. Maximum length is 250 characters.</span></td>
			<td><textarea id="tbxSignature" runat="server" rows="3" style="WIDTH: 360px" class="Inputborder"></textarea></td>
		</tr>
		<tr class="NormalBackground"><td colspan="2" class="SmallFontSmaller"><br><b>Preferences.</b></td></tr>
		<tr class="LightBackground">
			<td width="170">Email address is hidden</td>
			<td valign="top"><input type="checkbox" class="NoBorder" runat="server" id="chkEmailAddressIsHidden" name="chkEmailAddressIsHidden" checked="checked"></td>
		</tr>
		<tr class="DarkBackground">
			<td width="170">Notify me of thread replies<br />
				<span class="SmallFontSmallest">Overridable per-thread</span>
			</td>
			<td valign="top"><input type="checkbox" class="NoBorder" runat="server" id="chkAutoSubscribeToThread" name="chkAutoSubscribeToThread"></td>
		</tr>
		<tr class="LightBackground">
			<td width="170">Messages per page</td>
			<td valign="top"><input type="text" class="Inputborder" runat="server" id="tbxDefaultNumberOfMessagesPerPage" name="tbxDefaultNumberOfMessagesPerPage" maxlength="4" size="4" value="25">
                <asp:RangeValidator ID="rvDefaultNumberOfMessagesPerPage" runat="server" ControlToValidate="tbxDefaultNumberOfMessagesPerPage" MinimumValue="1" MaximumValue="1000" ErrorMessage="Must be between 1 and 1000." Display="Dynamic" Type="Integer"></asp:RangeValidator>
			</td>
		</tr>
		<tr class="NormalBackground">
			<td width="170">&nbsp;</td>
			<td>
				<hr align="left" size="1" width="80%">
				<input type="submit" id="btnRegister" runat="server" name="btnRegister" value="   Register   " class="FormButtons">
			</td>
		</tr>
		</table>
	</td>
</tr>
</table>
</form>
<br clear="all">
<br clear="all">
<!-- footer -->
<hnd:pagefooter runat="server" id="PageFooter" />
</body>
</html>
