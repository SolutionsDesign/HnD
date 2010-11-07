<%@ Page language="c#" CodeFile="PrintMessages.aspx.cs" AutoEventWireup="true" Inherits="SD.HnD.GUI.PrintMessages"%>
<%@ Import namespace="System.Web" %>
<%@ Import namespace="System.Data" %>
<%@ Import Namespace="SD.HnD.GUI" %>
<html>
  <head runat="server">
	<title>HnD::List all messages of thread: <%=HttpUtility.HtmlEncode(base.ThreadSubject)%></title>
</head>
<body style="font-family:Arial;background-image:none;background-color:White;">
<!-- header, menu and title -->
<form runat="server" ID="Form1">
<h3>Forum: &nbsp;<asp:label ID="lblForumName_Header" Runat="server" /></h3>
<h4>Thread: &nbsp;<%=HttpUtility.HtmlEncode(base.ThreadSubject)%></h4>
<br />
<!-- Messages table -->
<table width="100%" align="center" border="0" cellpadding="0" cellspacing="0">
<tr>
	<td style="border-top: #1f87aa 1px solid;">
		<asp:repeater ID="rptMessages" Runat="server" EnableViewState="False">
			<headertemplate>
				<table width="100%" border="0" cellpadding="0" cellspacing="1">
			</headertemplate>
	
			<itemtemplate>
				<tr>
					<td>
						<table width="100%" border="0" cellpadding="2" cellspacing="0">
							<tr>
								<td valign="top" height="100%" style="border-bottom: #1f87aa 1px solid; ">
									<table border="0" width="100%" cellpadding="1" cellspacing="0" height="100%">
									<tr>
										<td nowrap="nowrap" style="border-bottom: #A5D6E6 1px solid; ">
											<b><%# Eval("NickName")%></b> (<span><%# Eval("UserTitleDescription")%></span>)&nbsp;&nbsp;
											<span>Posted on: <%# ((DateTime)Eval("PostingDate")).ToString(@"dd-MMM-yyyy HH:mm:ss")%>. <asp:PlaceHolder ID="phIPAddress" runat="server" Visible='<%#base.ShowIPAddresses %>'>Posted from IP: <asp:Label ID="lblIPAddress" runat="server" Text='<%# Eval("PostedFromIP") %>' /></asp:PlaceHolder></span>										
										</td>
									</tr>
									<tr>
										<td valign="top" height="100%">
											<%# Eval("MessageTextAsHTML")%>
										</td>
									</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</itemtemplate>
			
			<alternatingitemtemplate>
				<tr>
					<td>
						<table width="100%" border="0" cellpadding="2" cellspacing="0">
							<tr>
								<td valign="top" height="100%" style="border-bottom: #1f87aa 1px solid; ">
									<table border="0" width="100%" cellpadding="1" cellspacing="0" height="100%">
									<tr>
										<td nowrap="nowrap" style="border-bottom: #A5D6E6 1px solid; ">
											<b><%# Eval("NickName")%></b> (<span><%# Eval("UserTitleDescription")%></span>)&nbsp;&nbsp;
											<span>Posted on: <%# ((DateTime)Eval("PostingDate")).ToString(@"dd-MMM-yyyy HH:mm:ss")%>. <asp:PlaceHolder ID="phIPAddress" runat="server" Visible='<%#base.ShowIPAddresses %>'>Posted from IP: <asp:Label ID="lblIPAddress" runat="server" Text='<%# Eval("PostedFromIP") %>' /></asp:PlaceHolder></span>
										</td>
									</tr>
									<tr>
										<td valign="top" height="100%">
											<%# Eval("MessageTextAsHTML")%>
											<br><br>
										</td>
									</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</alternatingitemtemplate>
			<footertemplate>
				</table>
			</footertemplate>
		</asp:repeater>
	</td>
</tr>
</table>
</form>
</body>
</html>
