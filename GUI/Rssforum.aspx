<%@ Page language="c#" CodeFile="Rssforum.aspx.cs" ContentType="text/xml" AutoEventWireup="true" Inherits="SD.HnD.GUI.Rssforum" %>
<rss version="2.0">
<channel>
    <title><%=HttpUtility.HtmlEncode(base.SiteName)%> <%=HttpUtility.HtmlEncode(base.ForumName)%> feed</title>
    <link><%=HttpUtility.HtmlEncode(base.ForumURL)%></link>
    <description>This is the RSS feed for the forum <%=HttpUtility.HtmlEncode(base.ForumName)%> on the <%=HttpUtility.HtmlEncode(base.SiteName)%> forum system.</description>
    <ttl>30</ttl>
    <language>en-us</language>

	<asp:repeater id="rptRSS" runat="server" OnItemDataBound="rptRSS_ItemDataBound">
	<itemtemplate>
		<item>
			<title><asp:literal Runat="server" ID="title" /></title>
			<description><asp:literal Runat="server" ID="description" /></description>
			<author><asp:literal Runat="server" ID="author" /></author>
			<link><asp:literal Runat="server" ID="itemLink" /></link>
			<pubDate><asp:literal Runat="server" ID="pubDate" /></pubDate>
			<category><asp:literal Runat="server" ID="threadName" /></category>
			<guid isPermaLink="true"><asp:literal Runat="server" ID="permaLink" /></guid>
		</item>
	</itemtemplate>
	</asp:repeater>
</channel>
</rss>  
