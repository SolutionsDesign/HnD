<%@ Control Language="c#" AutoEventWireup="false" CodeFile="MyThreadsPageList.ascx.cs" Inherits="SD.HnD.GUI.MyThreadsPageList" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<asp:repeater id="rptPageList" runat="server">
	<headertemplate>Pages: </headertemplate>
	<separatortemplate> </separatortemplate>
	<itemtemplate>
		<asp:label id="lblMessagesPage" runat="server" visible="False"><%# (int)(Container.DataItem)%></asp:label>
		<asp:hyperlink navigateurl="MyThreads.aspx?Page=" id="lnkResultPage" visible="False" runat="server"><%# (int)(Container.DataItem)%></asp:hyperlink>
	</itemtemplate>
</asp:repeater>
