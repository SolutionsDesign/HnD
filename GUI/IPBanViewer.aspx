<%@ Register TagPrefix="HnD" TagName="PageFooter" Src="Footer.ascx"%>
<%@ Page language="c#" CodeFile="IPBanViewer.aspx.cs" AutoEventWireup="false" Inherits="SD.HnD.GUI.IPBanViewer" %>
<%@ Import namespace="System.Data" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head runat="server">
	<title>HnD::IP-ban viewer.</title>
</head>
<body>
<form id="IPBanViewerForm" method="post" runat="server">
<table width="600" align="center" border="0" cellpadding="0" cellspacing="0">
<tr>
	<td colspan="2">
		<br>
		<h3>You are banned.</h3>
		Your IP-address, <%=Request.UserHostAddress%>, matches an IP-ban and therefor the forum system
		will not let you access its contents. The IP-ban information which matches your IP-address
		is stated below. If you are an innocent victim of the IP-ban mentioned below, you can
	    email to <asp:hyperlink ID="lnkBanComplaintEmailAddress" Runat="server" NavigateUrl="mailto:"/> and explain what
	    happened and perhaps the IP-ban is lifted or changed (in the case of the ban of a range of
	    IP-addresses). 
	    <br><br>
	    The IP-ban is for this forum system only. 
	</td>
</tr>
<tr>
	<td>
		<br>
		<table border="0" width="500" align="center" cellpadding="2" cellspacing="0">
		<tr>
			<td colspan="2" class="TableColumnHeader"><b>Matching IP-ban</b></td>
		</tr>
		<tr>
			<td class="GeneralSmallBorderTable" width="120"><b>IP range</b></td>
			<td class="GeneralSmallBorderTable">
				<asp:Label ID="lblIPBanRange" runat="server" />
			</td>
		</tr>
		<tr>
			<td class="GeneralSmallBorderTable" width="120"><b>IP ban set on</b></td>
			<td class="GeneralSmallBorderTable"><asp:Label ID="lblIPBanDate" runat="server" /></td>
		</tr>
		<tr>
			<td class="GeneralSmallBorderTable" width="120" valign="top"><b>Reason</b></td>
			<td class="GeneralSmallBorderTable"><asp:Label ID="lblIPBanReason" runat="server" /></td>
		</tr>
		</table>
	</td>
</tr>
</table>
</form>
<!-- footer -->
<hnd:pagefooter runat="server" id="PageFooter" />
</body>
</html>
