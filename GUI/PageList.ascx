<%@ Control Language="c#" AutoEventWireup="false" CodeFile="PageList.ascx.cs" Inherits="SD.HnD.GUI.PageList" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<asp:repeater ID="rptPageListMessages" Runat="server" Visible="false">
	<headertemplate>Pages: </headertemplate>
	<separatortemplate> </separatortemplate>
	<itemtemplate>
		<asp:label ID="lblMessagesPage" Runat="server" Visible="False"><%# (int)(Container.DataItem)%></asp:label>
		<asp:hyperlink NavigateUrl="Messages.aspx" ID="lnkMessagesPage" Visible="False" Runat="server"><%# (int)(Container.DataItem)%></asp:hyperlink>
	</itemtemplate>
</asp:repeater>
<asp:repeater ID="rptPageListThreads" Runat="server" Visible="false">
	<separatortemplate>, </separatortemplate>
	<itemtemplate>
		<asp:hyperlink NavigateUrl="Messages.aspx" ID="lnkMessagesPage" Runat="server"><%# (int)(Container.DataItem)%></asp:hyperlink>
	</itemtemplate>
</asp:repeater>
