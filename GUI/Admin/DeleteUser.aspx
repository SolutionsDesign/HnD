<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DeleteUser.aspx.cs" Inherits="SD.HnD.GUI.Admin.DeleteUser" 
	MasterPageFile="~/Admin/AdminMaster.master" Title="HnD::Administrate::Delete a user"%>
<%@ Register TagPrefix="HnD" TagName="FindUser" Src="FindUser.ascx"%>

<asp:Content ContentPlaceHolderID="phMainContent" runat="server">
<table width="700" align="center" class="ExplanationBox" cellpadding="2" cellspacing="0">
<tr>
	<td>
		<h3>Delete a user.</h3>
		Below you can delete a user. First select the user to delete using the Find User portion of the form, then you've to confirm you want to delete the user
		selected. You can't delete yourself nor the Anonymous Coward user (UserID 0).
	</td>
</tr>
</table>
<br clear="all"><br>
<hnd:finduser runat="server" id="userFinder" MultiSelect="false" ButtonDescription="Select for deletion" OnSelectClicked="SelectClickedHandler"/>

<br clear="all">
<asp:placeholder id="phUserInfo" visible="false" runat="server">
<table width="700" align="center" border="0" cellpadding="2" cellspacing="0">
<tr>
	<td align="center">
		Are you sure you want to delete user <b><asp:Label ID="lblNickname" runat="server" /></b> (<asp:Label id="lblUserID" runat="server" />) ?
		<br /><br />
		<asp:Button cssclass="FormButtons" ID="btnYes" runat="server" Text="  Yes  " OnClick="btnYes_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
		<asp:Button cssclass="FormButtons" ID="btnNo" runat="server" Text="  No  " OnClick="btnNo_Click" />
	</td>
</tr>
</table>
</asp:placeholder>

<asp:PlaceHolder ID="phDeleteResult" Visible="false" runat="server">
<table width="700" align="center" border="0" cellpadding="2" cellspacing="0">
<tr>
	<td align="center">
		User deleted succesfully.	
	</td>
</tr>
</table>
</asp:PlaceHolder>
</asp:Content>