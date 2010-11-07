<%@ Page language="c#" CodeFile="ModifyForum.aspx.cs" AutoEventWireup="false" Inherits="SD.HnD.GUI.Admin.ModifyForum" 
	MasterPageFile="~/Admin/AdminMaster.master" Title="HnD::Administrate::Modify a forum"%>

<asp:Content ContentPlaceHolderID="phMainContent" runat="server">
<table  cellSpacing="0" cellPadding="2" width="700" align="center" class="ExplanationBox">
<tr>
	<td>
		<h3>Modify a forum</h3>
		Below you'll be able to modify the name, description and location of a forum. When you're done and click <b>Save</b>, the
		changes are made instantly and are irreversable. <b>Cancel</b> will bring you back to the previous screen with the
		forum listing.
		<br /><br />
		The default support queue is the queue to which threads in the forum are added to if the thread is new, or gets a new message.
		Assign only a support queue to a forum if messages in the forum require attention from a special group of users who have queue contents management
		access rights.
	</td>
</tr>
</table>
<br clear="all">
<table width="700" align="center" border="0" cellpadding="0" cellspacing="0">
<tr>
	<td class="FormHeaderOneLine">
		<span class="FormName">Modify a forum</span>
	</td>
</tr>
<tr>
	<td class="FormContent">
		<table width="698" align="center" border="0" cellpadding="1" cellspacing="0" class="FormWindow">
		<tr><td colspan="2" ><br></td></tr>
		<tr>
			<td align="right"  width="228">Forum name&nbsp;</td>
			<td ><input type="text" class="Inputborder" id="tbxForumName" maxlength="50" size="50" runat="server" name="tbxForumName"></td>
		</tr>
		<tr><td  colspan="2" height="3"></td></tr>
		<tr>
			<td  align="right" valign="top" width="228">Description&nbsp;</td>
			<td >
				<asp:textbox Rows="5" ID="tbxForumDescription" Runat="server" Name="tbxForumDescription" TextMode="MultiLine" width="442px"/>
			</td>
		</tr>
		<tr><td  colspan="2" height="3"></td></tr>
		<tr>
			<td  align="right" width="228">Place in section&nbsp;</td>
			<td >
				<asp:dropdownlist ID="cbxSections" Runat="server" DataTextField="SectionName" DataValueField="SectionID" />
			</td>
		</tr>
		<tr><td  colspan="2" height="3"></td></tr>
		<tr>
			<td  align="right" width="228">Has RSS Feed&nbsp;</td>
			<td >
				<asp:checkbox runat="server" id="chkHasRSSFeed" checked="True" style="vertical-align:middle"/>
				<span class="SmallFontSmallest"><b>Warning:</b> Be aware that everyone can see messages posted in this forum via an RSS feed. If you don't want that, don't
				enable an RSS feed on this forum</span>
			</td>
		</tr>
		<tr><td  colspan="2" height="3"></td></tr>
		<tr>
			<td  align="right" width="228">Default support queue&nbsp;</td>
			<td >
				<asp:DropDownList ID="cbxSupportQueues" DataTextField="QueueName" DataValueField="QueueID" runat="server" AppendDataBoundItems="true">
					<asp:ListItem value="-1" Text="None"/>
				</asp:DropDownList>
			</td>
		</tr>
		<tr><td  colspan="2" height="3"></td></tr>
		<tr>
			<td  align="right" width="228">
				Default thread interval&nbsp;</td>
			<td >
				<asp:DropDownList ID="cbxThreadListInterval" runat="server">
					<asp:ListItem value="1" Text="Last 24 hours"/>
					<asp:ListItem value="2" Text="Last 48 hours"/>
					<asp:ListItem value="3" Text="Last week"/>
					<asp:ListItem value="4" Text="Last month"/>
					<asp:ListItem value="5" Text="Last year"/>
				</asp:DropDownList>
			</td>
		</tr>
		<tr><td  colspan="2" height="3"></td></tr>
		<tr>
			<td  align="right" >Sort-order no.&nbsp;</td>
			<td >
				<asp:textbox ID="tbxOrderNo" runat="server" Columns="4" MaxLength="4" />
			</td>
		</tr>
		<tr><td  colspan="2" height="2" align="right"></td></tr>
		<tr>
			<td  align="right" width="228">Max. # attachments per message&nbsp;</td>
			<td>
				<asp:textbox ID="tbxMaxNoOfAttachmentsPerMessage" runat="server" Columns="4" MaxLength="4" />
			</td>
		</tr>
		<tr><td  colspan="2" height="2" align="right"></td></tr>
		<tr>
			<td  align="right" width="228">Max. attachment size&nbsp;</td>
			<td>
				<asp:textbox ID="tbxMaxAttachmentSize" runat="server" Columns="7" MaxLength="7" /> KB
			</td>
		</tr>
		<tr><td  colspan="2" height="2" align="right"></td></tr>
		<tr>
			<td  align="right" width="228" valign="top">New thread welcome text&nbsp;<br />(optional)&nbsp;</td>
			<td>
				<asp:textbox ID="tbxNewThreadWelcomeText" runat="server" width="363px" TextMode="MultiLine" Rows="6" />
				<br />
				<span class="SmallFontSmallest">You can use all normal message UBB tags in this text. All line breaks will be line breaks when the text is shown and 
					all URLs are automatically converted, please prefix any URL with http:// or https://. The New thread welcome text is shown
					when a new thread is started, above the message box.</span>
			</td>
		</tr>
		<tr><td  colspan="2" height="6"></td></tr>
		<tr>
			<td  width="228">&nbsp;</td>
			<td >
				<hr align="left" size="1" width="80%">
				<input class="FormButtons" type="button" name="btnSave" runat="server" value="   Save   " ID="btnSave">&nbsp;&nbsp;&nbsp;
				<input class="FormButtons" type="button" name="btnCancel" runat="server" value="  Cancel  " ID="btnCancel" causesvalidation="false">
			</td>
		</tr>
		<tr><td  colspan="2" height="6"></td></tr>
		<tr>
			<td  width="228">&nbsp;</td>
			<td >
				<asp:requiredfieldvalidator ControlToValidate="tbxForumName" Runat="server" ErrorMessage="Forum name is empty" ID="rfvSectionName"/><br>
				<asp:requiredfieldvalidator ControlToValidate="tbxForumDescription" Runat="server" ErrorMessage="Forum description is empty" ID="rfvForumDescription"/>
			</td>
		</tr>
		<tr><td  colspan="3" height="6"></td></tr>
		</table>
	</td>
</tr>
<tr>
	<td class="EmptyRowBottom" height="5"><img src="../pics/separator.gif" border="0"></td>
</tr>
</table>
</asp:Content>