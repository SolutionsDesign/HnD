<%@ Page language="c#" CodeFile="ModifyUserProfile.aspx.cs" AutoEventWireup="true" Inherits="SD.HnD.GUI.Admin.ModifyUserProfile" ValidateRequest="false" 
	MasterPageFile="~/Admin/AdminMaster.master" title="HnD::Administrate::Modify a user profile"%>
<%@ Register TagPrefix="HnD" TagName="FindUser" Src="FindUser.ascx"%>

<asp:Content ContentPlaceHolderID="phMainContent" runat="server">
<asp:PlaceHolder ID="phFindUserArea" runat="server" Visible="true">
<table width="700" align="center" class="ExplanationBox" cellpadding="2" cellspacing="0">
<tr>
	<td>
		<b>Modify a user profile.</b>
		<p> Below you can change the profile information of a user currently known by the forumsystem. First you've to select the user of whom you want to
			modify the profile, and then click <b>Manage profile</b> to manage the profile data. 
		</p>
	</td>
</tr>
</table>
<br clear="all">
<hnd:finduser runat="server" id="userFinder" MultiSelect="false" ButtonDescription="Select for profile editing" OnSelectClicked="SelectClickedHandler"/>
</asp:PlaceHolder>

<asp:PlaceHolder ID="phProfileEditArea" runat="server" Visible="false">
<table width="700" align="center" class="ExplanationBox" cellpadding="2" cellspacing="0">
<tr>
	<td>
		<b>Modify a user profile.</b>
		<p>Below you can change the profile information of a user currently known by the forumsystem. When you're done, click the Update button to make the
		changes take effect. If you want to set the password to a new value, specify a new password in the two textboxes for new password, otherwise leave them
		empty and the current password will be kept.
		</p>
	</td>
</tr>
</table>
<br clear="all">
<table align="center" cellpadding="0" cellspacing="0" width="700">
<tr>
	<td>
		<asp:validationsummary id="vsErrors" runat="server" headertext="The following errors occured / you have to provide a value for the following fields:"/>
	</td>
</tr>
</table>
<table align="center" class="ExplanationBox" cellpadding="0" cellspacing="0" width="700">
<tr>
	<td>
		<table width="698" border="0" cellpadding="1" cellspacing="1" align="center">
		<tr>
			<td colspan="2" class="TableColumnHeader">User profile</td>
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
		<tr class="NormalBackground"><td colspan="2" class="SmallFontSmaller"><br><b>Personal information, which should tell something about the user.</b></td></tr>
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
			<td width="170" class="LightBackground">Date of birth <br>
				<span class="SmallFontSmallest">Format: mm/dd/yyyy</span></td>
			<td class="LightBackground">
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
			<td><textarea id="tbxSignature" runat="server" rows="3" style="WIDTH: 360px" NAME="tbxSignature" class="Inputborder"></textarea></td>
		</tr>
		<tr class="DarkBackground">
			<td width="170">User title</td>
			<td valign="top">
				<asp:DropDownList ID="cmbUserTitle" runat="server" />
			</td>
		</tr>
		<tr class="NormalBackground">
			<td width="170">&nbsp;</td>
			<td>
				<hr align="left" size="1" width="80%">
				<asp:Button ID="btnUpdate" runat="server" Text="   Update   " CssClass="FormButtons" OnClick="btnUpdate_Click" />
			</td>
		</tr>
		</table>
	</td>
</tr>
</table>
<asp:HiddenField ID="_emailAddressIsVisible" runat="server"  />
<asp:HiddenField ID="_autoSubscribeToThread" runat="server"  />
<asp:HiddenField ID="_defaultNumberOfMessagesPerPage" runat="server"  />
</asp:PlaceHolder>
<asp:PlaceHolder ID="phModifyResult" Visible="false" runat="server">
<table width="700" align="center" cellpadding="2" cellspacing="0" class="ExplanationBox">
<tr>
	<td align="center">
		User profile modified succesfully.
	</td>
</tr>
</table>
 </asp:PlaceHolder>
</asp:Content>