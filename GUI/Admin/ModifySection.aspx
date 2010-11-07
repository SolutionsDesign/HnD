<%@ Page language="c#" CodeFile="ModifySection.aspx.cs" AutoEventWireup="false" Inherits="SD.HnD.GUI.Admin.ModifySection" 
	MasterPageFile="~/Admin/AdminMaster.master" Title="HnD::Administrate::Modify a section"%>

<asp:Content ContentPlaceHolderID="phMainContent" runat="server">
<table cellSpacing="0" cellPadding="2" width="700" align="center" class="ExplanationBox">
	<tr>
		<td>
			<h3>Modify a section</h3>
			Below you'll be able to modify the name and description of a section. When you're done and click <b>Save</b>, the
			changes are made instantly and are irreversable. <b>Cancel</b> will bring you back to the previous screen with the
			section listing.
		</td>
	</tr>
</table>
<br clear="all">
<table width="700" align="center" border="0" cellpadding="0" cellspacing="0">
<tr>
	<td class="FormHeaderTwoLine">
		<span class="FormName">Modify section</span>
		<br>
		<span class="FormDescription">Modifies an existing section to the system immediately.</span>
	</td>
</tr>
<tr>
	<td class="FormContent">
		<table width="698" align="center" border="0" cellpadding="1" cellspacing="0" class="FormWindow">
		<tr><td colspan="3" ><br></td></tr>
		<tr>
			<td width="30" >&nbsp;</td>
			<td width="100" align="right" >Section name&nbsp;</td>
			<td ><input type="text" class="Inputborder" id="tbxSectionName" maxlength="50" size="50" runat="server" name="tbxSectionName"></td>
		</tr>
		<tr><td  colspan="3" height="3"></td></tr>
		<tr>
			<td  width="30">&nbsp;</td>
			<td  width="100" align="right" valign="top">Description&nbsp;</td>
			<td >
				<asp:textbox Rows="5" ID="tbxSectionDescription" Runat="server" Name="tbxSectionDescription" TextMode="MultiLine" width="500"/>
			</td>
		</tr>
		<tr><td  colspan="3" height="3"></td></tr>
		<tr>
			<td  width="30">&nbsp;</td>
			<td  width="100" align="right">Sort-order no.&nbsp;</td>
			<td >
				<asp:textbox ID="tbxOrderNo" runat="server" Columns="4" MaxLength="4" />
			</td>
		</tr>
		<tr><td  colspan="3" height="6"></td></tr>
		<tr>
			<td  colspan="2">&nbsp;</td>
			<td >
				<hr align="left" size="1" width="80%">
				<input class="FormButtons" type="button" name="btnSave" runat="server" value="   Save   " ID="btnSave">&nbsp;&nbsp;&nbsp;
				<input class="FormButtons" type="button" name="btnCancel" runat="server" value="  Cancel  " ID="btnCancel" causesvalidation="false">
			</td>
		</tr>
		<tr><td  colspan="3" height="6"></td></tr>
		<tr>
			<td  colspan="2">&nbsp;</td>
			<td >
				<asp:requiredfieldvalidator ControlToValidate="tbxSectionName" Runat="server" ErrorMessage="Section name is empty" ID="rfvSectionName" name="rfvSectionName"/><br>
				<asp:requiredfieldvalidator ControlToValidate="tbxSectionDescription" Runat="server" ErrorMessage="Section description is empty" ID="rfvSectionDescription" name="rfvSectionDescription"/>
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