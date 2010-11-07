<%@ Control Language="c#" AutoEventWireup="true" CodeFile="HeaderRestrictedMenu.ascx.cs" Inherits="SD.HnD.GUI.HeaderRestrictedMenu" %>
<tr>
	<td>
		<table width="100%" border="0" cellspacing="0" cellpadding="0">
		<tr class="HeaderTop">
			<td>
				<asp:HyperLink ID="lnkLogoLink" runat="server" SkinID="lnkLogoLink"><asp:Image id="imgLogo" runat="server" SkinID="imgLogo"/></asp:HyperLink>
			</td>
			<td align="right" valign="top">
				<img src="pics/separator.gif" width="10" height="5" border="0"><br>
				<a href="Default.aspx" class="HeaderLinkTop">Home</a><br>
				<a href="Help.aspx" target="_blank" class="HeaderLinkTop">Help</a><br>
				<img src="pics/separator.gif" width="10" height="5" border="0"><br>
			</td>
			<td width="5">&nbsp;</td>
		</tr>		
		<tr class="HeaderBottom " valign="middle" height="25">
			<td colspan="2" class="SmallFontSmaller">
			</td>
			<td width="5">&nbsp;</td>
		</tr>
		</table>
	</td>
</tr>
