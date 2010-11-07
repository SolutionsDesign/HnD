<%@ Register TagPrefix="HnD" TagName="PageFooter" Src="Footer.ascx"%>
<%@ Register TagPrefix="HnD" TagName="PageHeader" Src="Header.ascx"%>
<%@ Page language="c#" CodeFile="EditProfile.aspx.cs" AutoEventWireup="false" Inherits="SD.HnD.GUI.EditProfile" ValidateRequest="false" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
  <head runat="server">
	<title>HnD::Edit your profile</title>
	<meta name="vs_defaultClientScript" content="JavaScript">
	<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">

	<script LANGUAGE="javascript">
		function SetFocus()
		{
			document.forms[0].elements.tbxPassword1.focus();
		}
	</script>
</head>
<body onload="SetFocus();">
<table width="750" align="center" border="0" cellpadding="0" cellspacing="0">
<hnd:pageheader runat="server" id="PageHeader" />
</table>
<form id="form1" method="post" runat="server">
<br clear="all"/>
<table width="750" align="center" class="ExplanationBox" cellpadding="2" cellspacing="0">
<tr>
	<td>
		<b>Edit your profile.</b>
		<p> Below you can change your information currently known by the forumsystem. If you want to change your password,
			enter a value in the two password boxes, otherwise leave these boxes blank. When no password is filled in, your
			current password is kept.
		</p>
		<p>
			No information will be disclosed to other parties than the forumsystem itself. You decide which information you
			want to enter in the non-mandatory fields. The email-address you enter is used to send you a new password if you
			request it from the system again in the case you forgot your password. It can be made hidden for visitors of the forums. 
		</p>
	</td>
</tr>
</table>
<br clear="all">
<table align="center" cellpadding="0" cellspacing="0" width="750">
<tr>
	<td>
		<asp:validationsummary id="vsErrors" runat="server" headertext="The following errors occured / you have to provide a value for the following fields:"/>
	</td>
</tr>
</table>
<table align="center" class="ExplanationBox" cellpadding="0" cellspacing="0" width="602">
<tr>
	<td>
		<table width="748" border="0" cellpadding="1" cellspacing="1" align="center">
		<tr>
			<td colspan="2" class="TableColumnHeader">Your profile</td>
		</tr>
		<tr class="NormalBackground"><td colspan="2" class="SmallFontSmaller"><b>Registration information.</b> Fields marked with a '*' are mandatory.</td></tr>
		<tr class="LightBackground">
			<td width="170">Nickname</td>
			<td>
				<asp:label ID="lblNickname" Runat="server" />
			</td>
		</tr>
		<tr class="DarkBackground">
			<td width="170">New password</td>
			<td>
				<input type="password" id="tbxPassword1" runat="server" size="20" maxlength="20" name="tbxPassword1" class="Inputborder"> 
			</td>
		</tr>
		<tr class="LightBackground">
			<td width="170">New Password<br>
				<span class="SmallFontSmallest">For confirmation</span>
			</td>
			<td>
				<input type="password" id="tbxPassword2" runat="server" size="20" maxlength="20" name="tbxPassword2" class="Inputborder"> 
				<asp:CompareValidator id="cvPasswordConfirm" runat="server" ControlToValidate="tbxPassword1" ErrorMessage="Passwords are not identical" Display="Dynamic" ControlToCompare="tbxPassword2"></asp:CompareValidator>
			</td>
		</tr>
		<tr class="DarkBackground">
			<td width="170">Emailaddress *</td>
			<td>
				<input type="text" id="tbxEmailAddress" runat="server" name="tbxEmailAddress" maxlength="200" size="40" class="Inputborder">&nbsp;
				<asp:regularexpressionvalidator id="revEmailAddress" runat="server" ErrorMessage="Not a valid address" ControlToValidate="tbxEmailAddress" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" display="Dynamic"/>
				<asp:requiredfieldvalidator id="rfvEmailAddress" runat="server" ErrorMessage="Email address" ControlToValidate="tbxEmailAddress" display="None" width="31px"/>
			</td>
		</tr>
		<tr class="NormalBackground"><td colspan="2" class="SmallFontSmaller"><br><b>Personal information, which should tell something about you.</b></td></tr>
		<tr class="DarkBackground">
			<td width="170">User icon URL<br>
				<span class="SmallFontSmallest">(Only 60x60 .jpg and .gif are accepted)</span>
				</td>
			<td valign="top">
				http:// <input type="text" id="tbxIconURL" runat="server" name="tbxIconURL" maxlength="250" size="50" class="Inputborder"><br>
				<asp:regularexpressionvalidator id="revIconURL" runat="server" ErrorMessage="Not a valid user icon URL" 
					ControlToValidate="tbxIconURL" ValidationExpression="([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;~=]*)?/[\w-]+\.(jpg|gif)" display="Dynamic"/>
			</td>
		</tr>
		<tr class="LightBackground">
			<td width="170">Date of birth <br>
				<span class="SmallFontSmallest">Format: mm/dd/yyyy</span></td>
			<td>
				<input type="text" id="tbxDateOfBirth" runat="server" name="tbxDateOfBirth" maxlength="10" size="11" class="Inputborder">
				<asp:regularexpressionvalidator id="revDateOfBirth" runat="server" ErrorMessage="Wrong date format" ValidationExpression="\d{1,2}/\d{1,2}/\d{4}" controltovalidate="tbxDateOfBirth"/>
			</td>
		</tr>
		<tr class="DarkBackground">
			<td width="170">Occupation</td>
			<td><input type="text" id="tbxOccupation" style="WIDTH: 360px" runat="server" name="tbxOccupation" maxlength="100" size="50" class="Inputborder"></td>
		</tr>
		<tr class="LightBackground">
			<td width="170">Location<br>
				<span class="SmallFontSmallest">e.g.: city, country</span></td>
			<td><input type="text" id="tbxLocation" style="WIDTH: 360px" runat="server" name="tbxLocation" maxlength="100" size="50" class="Inputborder"></td>
		</tr>
		<tr class="DarkBackground">
			<td width="170">Website</td>
			<td valign="top">http:// <input type="text" id="tbxWebsite" runat="server" name="tbxWebsite" maxlength="200" size="50" class="Inputborder"><br>
				<asp:regularexpressionvalidator id="revWebsite" runat="server" ErrorMessage="Not a valid URL" ControlToValidate="tbxWebsite" ValidationExpression="([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?" Display="Dynamic"/>
			</td>
		</tr>
		<tr class="LightBackground">
			<td width="170" valign="top">Signature<br>
				<span class="SmallFontSmallest">You can use several <a href="Help.aspx#UBBTags" target="_blank">UBB Tags</a> in your signature. Maximum length is 250 characters.</span></td>
			<td ><textarea id="tbxSignature" runat="server" rows="3" style="WIDTH: 360px" NAME="tbxSignature" class="Inputborder"></textarea></td>
		</tr>
		<tr><td colspan="2" height="6"></td></tr>
		<tr><td colspan="2" class="SmallFontSmaller"><br><b>Preferences.</b></td></tr>
		<tr class="DarkBackground">
			<td width="170">Email address is hidden</td>
			<td valign="top"><input type="checkbox" class="NoBorder" runat="server" id="chkEmailAddressIsHidden" name="chkEmailAddressIsHidden" checked></td>
		</tr>
		<tr class="LightBackground">
			<td width="170">Notify me of thread replies<br />
				<span class="SmallFontSmallest">Overridable per-thread</span>
			</td>
			<td valign="top"><input type="checkbox" class="NoBorder" runat="server" id="chkAutoSubscribeToThread" name="chkAutoSubscribeToThread" checked></td>
		</tr>
		<tr class="DarkBackground">
			<td width="170">Messages per page<br />
				<span class="SmallFontSmallest">Takes effect the next time you login/visit the site.</span>
			</td>
			<td valign="top"><input type="text" class="Inputborder" runat="server" id="tbxDefaultNumberOfMessagesPerPage" name="tbxDefaultNumberOfMessagesPerPage" maxlength="4" size="4">
                <asp:RangeValidator ID="rvDefaultNumberOfMessagesPerPage" runat="server" ControlToValidate="tbxDefaultNumberOfMessagesPerPage" MinimumValue="1" MaximumValue="1000" ErrorMessage="Messages per page must be between 1 and 1000." Display="Dynamic" Type="Integer"></asp:RangeValidator>
			</td>
		</tr>
		<tr class="NormalBackground">
			<td width="170">&nbsp;</td>
			<td>
				<hr align="left" size="1" width="80%">
				<input type="submit" id="btnUpdate" runat="server" name="btnUpdate" value="   Update   " class="FormButtons">
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
