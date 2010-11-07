<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Header.ascx.cs" Inherits="SD.HnD.GUI.Admin.Header" ClassName="Header" %>
<table width="700" align="center" border="0" cellpadding="0" cellspacing="0">
<tr>
	<td>
		<table width="100%" border="0" cellspacing="0" cellpadding="0">
		<tr class="HeaderTop">
			<td>
				<asp:HyperLink ID="lnkLogoLink" runat="server" SkinID="lnkLogoLink"><asp:Image id="imgLogo" runat="server" SkinID="imgLogo"/></asp:HyperLink>
			</td>
			<td align="right">
				<img src="../pics/separator.gif" width="10" height="5" border="0"><br>
				<asp:PlaceHolder runat="server" ID="phMenuLink">
					<a href="Default.aspx" class="HeaderLinkTop">Administrate home</a>
				</asp:PlaceHolder>
			</td>
			<td width="5">&nbsp;</td>
		</tr>		
		</table>
	</td>
</tr>
</table>
<br clear="all" />
