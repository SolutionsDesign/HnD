<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BanUnBanUser.aspx.cs" Inherits="SD.HnD.GUI.Admin.BanUnbanUser" 
	MasterPageFile="~/Admin/AdminMaster.master" Title="HnD::Administrate::Ban/unban a user"%>
<%@ Register TagPrefix="HnD" TagName="FindUser" Src="FindUser.ascx"%>

<asp:Content ContentPlaceHolderID="phMainContent" runat="server">
<table width="700" align="center" class="ExplanationBox" cellpadding="2" cellspacing="0">
<tr>
	<td>
		<h3>Ban/unban a user.</h3>
		Below you can ban or unban a user. First select the user to ban/unban using the Find User portion of the form, then you've to confirm you want to 
		ban / unban the user selected. 
		You can't ban yourself nor the Anonymous Coward user (UserID 0). The ban is set on the user account and the user will be logged out by force
		the next time the user requests a forum page. 
	</td>
</tr>
</table>
<br clear="all"><br>
<hnd:finduser runat="server" id="userFinder" MultiSelect="false" ButtonDescription="Select a user to ban/unban" OnSelectClicked="SelectClickedHandler"/>

<br clear="all">
<asp:placeholder id="phUserInfo" visible="false" runat="server">
<table width="700" align="center" border="0" cellpadding="2" cellspacing="0">
<tr>
	<td align="center">
		Current ban status for user <b><asp:Label ID="lblNickname" runat="server" /></b> (<asp:Label id="lblUserID" runat="server" />):
		<b><asp:Label ID="lblBanStatus" runat="server" /></b>
		<br /><br />
		Are you sure you want to toggle the ban flag for this user?
		<br /><br />
		<asp:Button cssclass="FormButtons" ID="btnYes" runat="server" Text="  Yes  " OnClick="btnYes_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
		<asp:Button cssclass="FormButtons" ID="btnNo" runat="server" Text="  No  " OnClick="btnNo_Click" />
	</td>
</tr>
</table>
</asp:placeholder>

<asp:PlaceHolder ID="phToggleResult" Visible="false" runat="server">
<table width="700" align="center" border="0" cellpadding="2" cellspacing="0">
<tr>
	<td align="center">
		Toggle of banflag value was successful.
	</td>
</tr>
</table>
</asp:PlaceHolder>
</asp:Content>