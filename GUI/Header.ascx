<%@ Control Language="c#" AutoEventWireup="true" CodeFile="Header.ascx.cs" Inherits="SD.HnD.GUI.Header" %>
<tr>
	<td>
		<table width="100%" border="0" cellspacing="0" cellpadding="0">
		<tr class="HeaderTop">
			<td>
				<asp:HyperLink ID="lnkLogoLink" runat="server" SkinID="lnkLogoLink"><asp:Image id="imgLogo" runat="server" SkinID="imgLogo"/></asp:HyperLink>
			</td>
			<td align="right">
				<img src="pics/separator.gif" width="10" height="5" border="0"><br>
				<a href="Default.aspx" class="HeaderLinkTop">Home</a><br>
				<a href="Help.aspx" class="HeaderLinkTop">Help</a><br>
				<asp:PlaceHolder ID="phNotLoggedIn" runat="server" Visible="false">
					<asp:hyperlink id="lnkRegister" runat="server" NavigateUrl="Register.aspx" CssClass="HeaderLinkTop">Register</asp:hyperlink><br>
					<asp:hyperlink id="lnkLogIn" runat="server" NavigateUrl="Login.aspx" CssClass="HeaderLinkTop">Log in</asp:hyperlink><br>
				</asp:PlaceHolder>
				<asp:PlaceHolder ID="phLoggedIn" runat="server" Visible="false">
					<asp:hyperlink CssClass="HeaderLinkTop" id="lnkLogOut" runat="server" NavigateUrl="Logout.aspx">Log out</asp:hyperlink><br>
					<asp:hyperlink id="lnkProfile" runat="server" NavigateUrl="EditProfile.aspx" CssClass="HeaderLinkTop">Profile</asp:hyperlink><br>
				</asp:PlaceHolder>
				<br>
				<a href="Search.aspx" class="HeaderLinkTop">Search</a><br>
				<img src="pics/separator.gif" width="10" height="5" border="0"><br>
			</td>
			<td width="5">&nbsp;</td>
		</tr>		
		<tr class="HeaderBottom " valign="middle" height="25">
			<td colspan="2" class="SmallFontSmaller">
				&nbsp;&nbsp;
				<a href="ActiveThreads.aspx" class="HeaderLinkBottom">Active Threads</a>
				<asp:PlaceHolder ID="phLoggedInBottom" runat="server">
					<span class="HeaderSeparator">&nbsp;|&nbsp;</span>
					<a href="Bookmarks.aspx" class="HeaderLinkBottom">My Bookmarks</a>
					<span class="HeaderSeparator">&nbsp;|&nbsp;</span>
					<a href="MyThreads.aspx" class="HeaderLinkBottom">My Threads</a>
				</asp:PlaceHolder>
				<asp:PlaceHolder ID="phAdministrate" runat="server" Visible="false">
					<span class="HeaderSeparator">&nbsp;|&nbsp;</span>
					<asp:hyperlink cssclass="HeaderLinkBottom" id="lnkAdministrate" runat="server" NavigateUrl="Admin/Default.aspx" Target="_blank">Administrate</asp:hyperlink>
				</asp:PlaceHolder>
				<asp:PlaceHolder ID="phAttachmentApproval" runat="server" Visible="false">
					<span class="HeaderSeparator">&nbsp;|&nbsp;</span>
					<asp:HyperLink cssclass="HeaderLinkBottom" ID="lnkAttachmentApproval" runat="server" NavigateUrl="ApproveAttachments.aspx">Approve Attachments</asp:HyperLink>
				</asp:PlaceHolder>
				<asp:PlaceHolder ID="phSupportQueues" runat="server" Visible="false">
					<span class="HeaderSeparator">&nbsp;|&nbsp;</span>
					<asp:HyperLink cssclass="HeaderLinkBottom" ID="lnkSupportQueues" runat="server" NavigateUrl="SupportQueues.aspx">Support Queues</asp:HyperLink>
				</asp:PlaceHolder>
			</td>
			<td width="5">&nbsp;</td>
		</tr>
		</table>
	</td>
</tr>
