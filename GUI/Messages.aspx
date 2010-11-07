<%@ Register TagPrefix="HnD" TagName="PageHeader" Src="Header.ascx"%>
<%@ Page language="c#" CodeFile="Messages.aspx.cs" AutoEventWireup="true" Inherits="SD.HnD.GUI.Messages"%>
<%@ Register TagPrefix="HnD" TagName="PageList" Src="PageList.ascx"%>
<%@ Register TagPrefix="HnD" TagName="PageFooter" Src="Footer.ascx"%>
<%@ Import namespace="System.Web" %>
<%@ Import namespace="System.Data" %>
<%@ Import Namespace="SD.HnD.GUI" %>
<html>
  <head runat="server">
	<title>HnD::List all messages of thread: <%=HttpUtility.HtmlEncode(base.ThreadSubject)%></title>
	<meta name="vs_defaultClientScript" content="JavaScript">
	<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">


<asp:literal id="litHighLightLogic" runat="server" visible="false">
	<style>
		SPAN.searchword { background-color:#ffeeb3; }
	</style>
	<script src="js/searchhi.js" language="javascript" type="text/javascript"></script>
</asp:literal>
</head>
<body onload="SearchHighlight();">
<a name="top"></a>
<!-- header, menu and title -->
<form runat="server" ID="Form1">
<table width="90%" align="center" border="0" cellpadding="0" cellspacing="0">
<hnd:pageheader runat="server" id="PageHeader" />
</table>
<table width="90%" align="center" border="0" cellpadding="0" cellspacing="0">
<tr>
	<td class="SmallFontSmallest" colspan="2">
		<br>
		You are here: <b><a href="Default.aspx">Home</a> &gt; <asp:label ID="lblSectionName" Runat="server" /> 
		&gt; <asp:hyperlink id="lnkThreads" NavigateUrl="Threads.aspx" Runat="server" />&gt; <%=HttpUtility.HtmlEncode(base.ThreadSubject)%></b>
	</td>
</tr>

<asp:PlaceHolder ID="phSupportQueueManagement" runat="server">
<tr><td colspan="2">&nbsp;<br /></td></tr>
<tr>
	<td colspan="2">
		<table width="100%" align="left" border="0" cellpadding="2" cellspacing="0" class="SupportArea">
			<tr>
				<td colspan="4" class="SupportAreaHeader">Support Queue Management</td>
			</tr>
			<tr>
				<td width="80" class="SupportAreaRow" nowrap="nowrap" valign="middle">Claimed by</td>
				<td class="SupportAreaRow">
					<asp:Label ID="lblNotClaimed" runat="server" Visible="true" Text="Not claimed" />
					<asp:hyperlink id="lnkClaimerThread" navigateurl="Profile.aspx?UserID=" target="_blank" cssclass="LinkNoUnderline" runat="server" title="View profile" Visible="false"/>
					&nbsp;&nbsp;
					<asp:Button ID="btnRelease" runat="server"  Text="Release" CssClass="FormButtons" Visible="false" OnClick="btnRelease_Click"/>
					<asp:Button ID="btnClaim" runat="server" Text="Claim" CssClass="FormButtons" Visible="false" OnClick="btnClaim_Click"/>
				</td>
				<td width="70">In Queue</td>
				<td>			
					<asp:DropDownList ID="cbxSupportQueues" DataTextField="QueueName" DataValueField="QueueID" runat="server" AppendDataBoundItems="true">
						<asp:ListItem value="-1" Text="None"/>
					</asp:DropDownList>
					&nbsp;<asp:Button ID="btnSetSupportQueue" runat="server" Text="Set" CssClass="FormButtons" OnClick="btnSet_Click" />
				</td>
			</tr>
			<tr>
				<td width="80" class="SupportAreaRow" nowrap="nowrap">Claimed on</td>
				<td class="SupportAreaRow"><asp:Label ID="lblClaimDate" runat="server" />&nbsp;</td>
				<td colspan="2">
				</td>
			</tr>
		</table>
	</td>
</tr>
</asp:PlaceHolder>

<asp:placeholder runat="server" id="phMemo" visible="False">
<tr><td colspan="2">&nbsp;<br /></td></tr>
<tr>
	<td colspan="2" class="supportarea">
		<table width="100%" align="center" border="0" cellpadding="2" cellspacing="0">
		<tr>
			<td class="SupportAreaHeader">Memo&nbsp;&nbsp;(<asp:hyperlink id="lnkEditMemo" visible="false" navigateurl="EditMemoForThread.aspx" runat="server" title="Edit the memo information for this thread">Edit</asp:hyperlink>)</td>
		</tr>
		<tr>
			<td>
				<asp:label runat="server" id="lblMemo"/>
			</td>
		</tr>
		</table>
	</td>
</tr>
</asp:placeholder>
</table>

<!-- Messages table -->
<table width="90%" align="center" border="0" cellpadding="0" cellspacing="0">
<tr><td>&nbsp;<br /><br /></td></tr>
<tr>
	<td valign="bottom" width="40%">
	<div style="width:100%">
		<div style="float:left;" class="SmallFontSmallest">
			<hnd:pagelist runat="server" id="plPageListTop" />
		</div>
		<div style="float:right;">
			<asp:hyperlink ID="lnkNewThreadTop" NavigateUrl="NewThread.aspx" Runat="server" title="Create a new thread on this forum.">New Thread</asp:hyperlink>
			<asp:Label runat="server" ID="lblSeparatorTop">&nbsp;|&nbsp;</asp:Label>
			<asp:hyperlink ID="lnkNewMessageTop" NavigateUrl="NewMessage.aspx" Runat="server" title="Add a new message to this thread.">New Message</asp:hyperlink>
		</div>
	</div>
	</td>
</tr>
<tr>
	<td><img src="pics/separator.gif" height="3" border="0"></td>
</tr>
<tr>
	<td nowrap="nowrap" width="100%">
		<table width="100%" border="0" cellpadding="0" cellspacing="0">
			<tr>
				<td class="TableHeaderTwoLine" align="left" valign="top">
					<span class="TableName"><asp:label ID="lblForumName_Header" Runat="server" /></span>
					<br />
					<span class="TableSubName"><%=HttpUtility.HtmlEncode(base.ThreadSubject)%></span>
					
				</td>
				<td class="TableHeaderTwoLine" nowrap="nowrap" align="right" valign="top">
					<span class="TableName"><b>Page:<asp:label ID="lblCurrentPage" Runat="server" />/<asp:label ID="lblTotalPages" Runat="server" /></b>&nbsp;</span>
					<br />
					<img src="pics/separator.gif" border="0" height="8" align="top" valign="top"/><br />
					<asp:imagebutton id="btnThreadNotDone" skinid="btnThreadNotDone" visible="false" runat="server"  OnClick="btnThreadNotDone_Click"/>
					<asp:imagebutton id="btnThreadDone" skinid="btnThreadDone" visible="false" runat="server" OnClick="btnThreadDone_Click" />
					&nbsp;
					<asp:imagebutton id="btnSubscribeToThread" skinid="btnSubscribeToThread" visible="false" runat="server" OnClick="btnSubscribeToThread_Click"/>
					<asp:imagebutton id="btnUnsubscribeFromThread" skinid="btnUnsubscribeFromThread" visible="false" runat="server" OnClick="btnUnSubscribeFromThread_Click"/>
					<asp:imagebutton id="btnBookmarkThread" skinid="btnBookmarkThread" visible="false" runat="server" OnClick="btnBookmarkThread_Click"/>
					<asp:imagebutton id="btnUnbookmarkThread" Skinid="btnUnbookmarkThread" visible="false" runat="server"  OnClick="btnUnbookmarkThread_Click" />
				
					
					<asp:hyperlink ID="lnkPrintThread" Target="_blank" NavigateUrl="PrintMessages.aspx" Runat="server" title="Print messages in thread"><asp:Image runat="server" SkinID="imgButtonPrint" /></asp:hyperlink>
					<asp:hyperlink ID="lnkMoveThread" Visible="false" NavigateUrl="MoveThread.aspx" Runat="server" title="Move this thread to another forum"><asp:Image runat="server" SkinID="imgButtonMove" /></asp:hyperlink>
					<asp:hyperlink ID="lnkDeleteThread" Visible="false" NavigateUrl="DeleteThread.aspx" Runat="server" title="Delete this thread"><asp:Image runat="server" SkinID="imgButtonDelete" /></asp:hyperlink>
					<asp:hyperlink ID="lnkCloseThread" Visible="false" NavigateUrl="CloseThread.aspx" Runat="server" title="Close this thread"><asp:Image runat="server" SkinID="imgButtonClose" /></asp:hyperlink>
					<asp:hyperlink ID="lnkEditThreadProperties" Visible="false" NavigateUrl="EditThreadProperties.aspx" Runat="server" title="Edit this thread's properties"><asp:Image runat="server" SkinID="imgButtonProperties" /></asp:hyperlink>&nbsp;
				</td>
			</tr>
		</table>
	</td>
</tr>
<tr>
	<td class="TableContent" colspan="2">
		<asp:repeater ID="rptMessages" Runat="server" EnableViewState="False" OnItemDataBound="rptMessages_ItemDataBound">
			<headertemplate>
				<table width="100%" align="center" border="0" cellpadding="0" cellspacing="1">
					<tr><td>
						<table width="100%" align="center" border="0" cellpadding="2" cellspacing="0">
							<tr>
								<td class="TableColumnHeader" width="100">Poster</td>
								<td class="TableColumnHeader">Message</td>
							</tr>
						</table>
					</td></tr>
			</headertemplate>
	
			<itemtemplate>
				<tr>
					<td>
						<table width="100%" align="center" border="0" cellpadding="2" cellspacing="0">
							<tr>
								<td width="100" valign="top" class="TableRow LightBackground" >
									<a name='<%# Eval("MessageID") %>' />
									<b><asp:hyperlink ID="lnkPosterProfile" NavigateUrl='<%# "Profile.aspx?UserID=" + Eval("UserID")%>' Runat="server" Target="_blank"><%# Eval("NickName")%></asp:hyperlink></b><br>
									<span class="SmallFontAuthorSmaller"><%# Eval("UserTitleDescription")%></span>
									<br><br>
									<center>
										<asp:image Visible='<%# (Eval("IconURL").ToString().Length > 0) %>' ID="imgIcon" align="middle" 
											borderwidth="1" Runat="server" width="60" height="60" ImageUrl='<%# "http://" + Eval("IconURL").ToString() %>'/>
										<br>
									</center>
									<br>
									<span class="SmallFontAuthorSmallest">
										<b>Location:</b> <br><%# Eval("Location")%><br>
										<b>Joined on:</b> <br><%# ((DateTime)Eval("JoinDate")).ToString("dd-MMM-yyyy HH:mm:ss")%><br>
										<b>Posted:</b> <br><%# Eval("AmountOfPostings")%> posts<br>
									</span>
								</td>
								<td class="TableRow LightBackground" valign="top" height="100%">
									<table border="0" width="100%" cellpadding="1" cellspacing="0" height="100%">
									<tr>
										<td width="65%" class="MessageHeader LightBackground" nowrap="nowrap">
											<asp:HyperLink Title="Direct Message URL" ToolTip="Direct Message URL" CssClass="LinkNoUnderline" ID="lnkDirectMessageURL" runat="server" NavigateUrl='<%# "GotoMessage.aspx?MessageID=" + Eval("MessageID") + "&ThreadID=" + Eval("ThreadID") %>'>#</asp:HyperLink>
											<span class="SmallFontSmaller">Posted on: <%# ((DateTime)Eval("PostingDate")).ToString(@"dd-MMM-yyyy HH:mm:ss")%>. <asp:PlaceHolder ID="phIPAddress" runat="server" Visible='<%# base.ShowIPAddresses %>'>Posted from IP: <asp:Label ID="lblIPAddress" runat="server" Text='<%# Eval("PostedFromIP") %>' /></asp:PlaceHolder></span> 
											<asp:HyperLink ID="lnkAttachments" runat="server" NavigateUrl='<%# "Attachments.aspx?SourceType=1&MessageID=" + Eval("MessageID")%>'
												visible='<%# ((int)Eval("AmountOfAttachments") >0) || ( ((int)Eval("AmountOfAttachments")<=0) && (SessionAdapter.GetUserID()==(int)Eval("UserID")) && base.ForumAllowsAttachments && base.UserMayAddAttachments)%>'>
												<asp:Image runat="server" ID="imgAttachment" ImageUrl="pics/attachment.gif" BorderWidth="0" ImageAlign="absmiddle" 
													Visible='<%# ((int)Eval("AmountOfAttachments") > 0) %>' AlternateText="Goto attachments" />
												<asp:Image runat="server" ID="imgAttachmentAdd" ImageUrl="pics/attachmentadd.gif" BorderWidth="0" ImageAlign="absmiddle" 
													Visible='<%# ((int)Eval("AmountOfAttachments") <= 0) %>' AlternateText="Add an attachment" />
											</asp:HyperLink>
										</td>
										<td align="right" class="MessageHeader LightBackground" valign="top">&nbsp;
											<span class="SmallFontSmaller">
												<b><asp:hyperlink NavigateUrl='<%# "DeleteMessage.aspx?MessageID=" + Eval("MessageID") + "&THreadID=" + base.ThreadID%>' ID="lnkDeleteMessage" Visible="False" Title="Delete this message" Runat="server">Delete</asp:hyperlink></b>
												<asp:label ID="lblMessageCmdSepDeleteEdit" Runat="server" Visible="False">|</asp:label>
												<b><asp:hyperlink NavigateUrl='<%# "EditMessage.aspx?MessageID=" + Eval("MessageID") + "&THreadID=" + base.ThreadID%>' ID="lnkEditMessage" Visible="False" Title="Edit this message" Runat="server">Edit</asp:hyperlink></b>
												<asp:label ID="lblMessageCmdSepEditQuote" Runat="server" Visible="False">|</asp:label>
												<b><asp:hyperlink NavigateUrl='<%# "NewMessage.aspx?QuoteMessageID=" + Eval("MessageID") + "&THreadID=" + base.ThreadID %>' ID="lnkNewMessageWQuote" Visible="False" Title="Add new message quoting this message" Runat="server">Quote</asp:hyperlink></b>
											</span>
										</td>
									</tr>
									<tr>
										<td colspan="2" class="TableRow LightBackground" valign="top" height="100%">
											<%# Eval("MessageTextAsHTML")%>
										</td>
									</tr>
									<tr>
										<td class="MessageFooter LightBackground" valign="top">
											<%# Eval("SignatureAsHTML")%>&nbsp;
										</td>
										<td class="MessageFooter LightBackground" valign="top" align="right">
											<b><a href="#top">Top</a></b>
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
						<table width="100%" align="center" border="0" cellpadding="2" cellspacing="0">
							<tr>

								<td width="100" valign="top" class="TableRow DarkBackground">
									<a name='<%# Eval("MessageID") %>' />
									<b><asp:hyperlink ID="lnkPosterProfile" NavigateUrl='<%# "Profile.aspx?UserID=" + Eval("UserID")%>' Runat="server" Target="_blank"><%# Eval("NickName")%></asp:hyperlink></b><br>
									<span class="SmallFontAuthorSmaller"><%# Eval("UserTitleDescription")%></span>
									<br><br>
									<center>
										<asp:image Visible='<%# (Eval("IconURL").ToString().Length > 0) %>' ID="imgIcon" align="middle" 
											borderwidth="1" Runat="server" width="60" height="60" ImageUrl='<%# "http://" + Eval("IconURL").ToString() %>'/>
										<br>
									</center>
									<br>
									<span class="SmallFontAuthorSmallest">
										<b>Location:</b> <br><%# Eval("Location")%><br>
										<b>Joined on:</b> <br><%# ((DateTime)Eval("JoinDate")).ToString("dd-MMM-yyyy HH:mm:ss")%><br>
										<b>Posted:</b> <br><%# Eval("AmountOfPostings")%> posts<br>
									</span>
								</td>
								<td class="TableRow DarkBackground" valign="top" height="100%">
									<table border="0" width="100%" cellpadding="1" cellspacing="0" height="100%">
									<tr>
										<td width="65%" class="MessageHeader DarkBackground" nowrap="nowrap"><span class="SmallFontSmaller">
											<asp:HyperLink Title="Direct Message URL" ToolTip="Direct Message URL" CssClass="LinkNoUnderline" ID="lnkDirectMessageURL" runat="server" NavigateUrl='<%# "GotoMessage.aspx?MessageID=" + Eval("MessageID") + "&ThreadID=" + Eval("ThreadID") %>'>#</asp:HyperLink>
											Posted on: <%# ((DateTime)Eval("PostingDate")).ToString(@"dd-MMM-yyyy HH:mm:ss")%>. <asp:PlaceHolder ID="phIPAddress" runat="server" Visible='<%#base.ShowIPAddresses %>'>Posted from IP: <asp:Label ID="lblIPAddress" runat="server" Text='<%# Eval("PostedFromIP") %>' /></asp:PlaceHolder></span>
											<asp:HyperLink ID="lnkAttachments" runat="server" NavigateUrl='<%# "Attachments.aspx?SourceType=1&MessageID=" + Eval("MessageID")%>'
												visible='<%# ((int)Eval("AmountOfAttachments") >0) || ( ((int)Eval("AmountOfAttachments")<=0) && (SessionAdapter.GetUserID()==(int)Eval("UserID")) && base.ForumAllowsAttachments && base.UserMayAddAttachments)%>'>
												<asp:Image runat="server" ID="imgAttachment" ImageUrl="pics/attachment.gif" BorderWidth="0" ImageAlign="absmiddle" 
													Visible='<%# ((int)Eval("AmountOfAttachments") > 0) %>' AlternateText="Goto attachments" />
												<asp:Image runat="server" ID="imgAttachmentAdd" ImageUrl="pics/attachmentadd.gif" BorderWidth="0" ImageAlign="absmiddle" 
													Visible='<%# ((int)Eval("AmountOfAttachments") <= 0) %>' AlternateText="Add an attachment" />
											</asp:HyperLink>
										</td>
										<td align="right" class="MessageHeader DarkBackground">&nbsp;
											<span class="SmallFontSmaller">
												<b><asp:hyperlink NavigateUrl='<%# "DeleteMessage.aspx?MessageID=" + Eval("MessageID") + "&THreadID=" + base.ThreadID%>' ID="lnkDeleteMessage" Visible="False" Title="Delete this message" Runat="server">Delete</asp:hyperlink></b>
												<asp:label ID="lblMessageCmdSepDeleteEdit" Runat="server" Visible="False">|</asp:label>
												<b><asp:hyperlink NavigateUrl='<%# "EditMessage.aspx?MessageID=" + Eval("MessageID") + "&THreadID=" + base.ThreadID%>' ID="lnkEditMessage" Visible="False" Title="Edit this message" Runat="server">Edit</asp:hyperlink></b>
												<asp:label ID="lblMessageCmdSepEditQuote" Runat="server" Visible="False">|</asp:label>
												<b><asp:hyperlink NavigateUrl='<%# "NewMessage.aspx?QuoteMessageID=" + Eval("MessageID") + "&THreadID=" + base.ThreadID %>' ID="lnkNewMessageWQuote" Visible="False" Title="Add new message quoting this message" Runat="server">Quote</asp:hyperlink></b>
											</span>
										</td>
									</tr>
									<tr>
										<td colspan="2" class="TableRow DarkBackground" valign="top" height="100%">
											<%# Eval("MessageTextAsHTML")%>
											<br><br>
										</td>
									</tr>
									<tr>
										<td class="MessageFooter DarkBackground" valign="top">
											<%# Eval("SignatureAsHTML")%>&nbsp;
										</td>
										<td align="right" valign="top" class="MessageFooter DarkBackground">
											<b><a href="#top">Top</a></b>
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

<table width="90%" align="center" border="0" cellpadding="1" cellspacing="0">
<tr>
	<td class="SmallFontSmallest" valign="top" width="40%"><b><hnd:pagelist runat="server" id="plPageListBottom" /></b>&nbsp;</td>
	<td width="60%" valign="top" align="right">
		<asp:hyperlink ID="lnkNewThreadBottom" NavigateUrl="NewThread.aspx" Runat="server" title="Create a new thread on this forum.">New Thread</asp:hyperlink>
		<asp:Label runat="server" ID="lblSeparatorBottom">&nbsp;|&nbsp;</asp:Label>
		<asp:hyperlink ID="lnkNewMessageBottom" NavigateUrl="NewMessage.aspx" Runat="server" title="Add a new message to this thread.">New Message</asp:hyperlink>
	</td>
</tr>
</table>
</form>
<br clear="all">
<!-- footer -->
<hnd:pagefooter runat="server" id="PageFooter" />
</body>
</html>
