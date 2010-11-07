<%@ Page language="c#" CodeFile="SendEmail.aspx.cs" AutoEventWireup="false" Inherits="SD.HnD.GUI.Admin.SendEmail" 
	MasterPageFile="~/Admin/AdminMaster.master" title="HnD::Administrate::Send email to user(s)" ValidateRequest="false"%>
<%@ Register TagPrefix="HnD" TagName="FindUser" Src="FindUser.ascx"%>

<asp:Content ContentPlaceHolderID="phMainContent" runat="server">
<table width="700" align="center" class="ExplanationBox" cellpadding="2" cellspacing="0">
<tr>
	<td>
		<h3>Send an email to user(s).</h3>
		Below you can an email to one or more users. First select the user using the Find Users portion of the form, then 
		specify the email contents and click Send. The email is send using support AT llblgen.com as from address, is always in plain text and is send
		as stated in the textbox.
	</td>
</tr>
</table>
<br clear="all">
<hnd:finduser runat="server" id="userFinder" multiselect="true" buttondescription="Select users" onselectclicked="SelectClickedHandler"/>
<br clear="all">
<asp:placeholder id="phEmailConstruction" visible="False" runat="server">
<table width="700" align="center" border="0" cellpadding="0" cellspacing="0">
<tr>
	<td class="FormHeaderOneLine">
		<span class="FormName">Send email to users</span>
	</td>
</tr>
<tr>
	<td class="FormContent">
		<table width="698" align="center" border="0" cellpadding="1" cellspacing="0" class="FormWindow">
		<tr><td  colspan="2" height="3"></td></tr>
		<tr>
			<td width="80" align="right"  valign="top">To&nbsp;</td>
			<td >
				<asp:label id="lblToNames" runat="server" />
			</td>
		</tr>
		<tr><td  colspan="2" height="3"></td></tr>
		<tr>
			<td width="80" align="right" >From&nbsp;</td>
			<td >
				<input type="text" id="tbxFrom" maxlength="250" size="50" class="Inputborder" runat="server" name="tbxFrom">
			</td>
		</tr>
		<tr><td  colspan="2" height="3"></td></tr>
		<tr>
			<td width="80" align="right" >Subject&nbsp;</td>
			<td >
				<input type="text" id="tbxSubject" maxlength="250" size="50" class="Inputborder" runat="server" name="tbxSubject">
			</td>
		</tr>
		<tr><td  colspan="2" height="6"></td></tr>
		<tr>
			<td  width="80" align="right" valign="top">Message&nbsp;</td>
			<td  rowspan="2">
				<asp:textbox rows="23" id="tbxMessage" runat="server" textmode="MultiLine" style="width:600px;"/>
			</td>
		</tr>
		<tr><td  colspan="2" height="6"></td></tr>
		<tr>
			<td >&nbsp;</td>
			<td >
				<hr align="left" size="1" width="80%">
				<asp:button cssclass="FormButtons" id="btnPost" runat="server" text="     Send     " />&nbsp;&nbsp;&nbsp;
				<asp:button cssclass="FormButtons" causesvalidation="False" id="btnCancel" runat="server" text="   Cancel  " />
				<br>
			</td>
		</tr>
		<tr><td  colspan="2" height="6"></td></tr>
		<tr>
			<td >&nbsp;</td>
			<td >
				<asp:requiredfieldvalidator controltovalidate="tbxFrom" runat="server" errormessage="From address is empty" id="rfvFrom"/><br>
				<asp:requiredfieldvalidator controltovalidate="tbxSubject" runat="server" errormessage="Subject is empty" id="rfvSubject"/><br>
				<asp:requiredfieldvalidator controltovalidate="tbxMessage" runat="server" errormessage="Message is empty" id="rfvMessage" />
			</td>
		</tr>
		<tr><td  colspan="2" height="6"></td></tr>
		</table>
	</td>
</tr>
<tr>
	<td class="EmptyRowBottom" height="5"><img src="../pics/separator.gif" border="0"></td>
</tr>
</table>
</asp:placeholder>

<asp:placeholder id="phResult" runat="server" visible="False">
<table cellspacing="0" cellpadding="2" width="700" align=center class="ExplanationBox">
  <tr>
    <td>Email sent! </td>
  </tr>
</table>
</asp:placeholder>
</asp:Content>