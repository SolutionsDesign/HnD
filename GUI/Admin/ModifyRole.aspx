<%@ Page language="c#" CodeFile="ModifyRole.aspx.cs" AutoEventWireup="false" Inherits="SD.HnD.GUI.Admin.ModifyRole" 
	MasterPageFile="~/Admin/AdminMaster.master" Title="HnD::Administrate::Modify a role"%>


<asp:Content ContentPlaceHolderID="phMainContent" runat="server">
<table cellSpacing="0" cellPadding="2" width="700" align="center" class="ExplanationBox">
	<tr>
		<td>
			<h3>Modify a role</h3>
			Below you'll be able to modify the description of the role, plus assign the role to several system rights. 
			When you're done and click <b>Save</b>, the changes are made instantly. <b>Cancel</b> will bring you back to the previous screen 
			with the role listing. Be aware that the role rights are cached for every session, so you will have to start a new session with the
			forum system to see the system right changes in effect.
		</td>
	</tr>
</table>
<br clear="all">
<table width="700" align="center" border="0" cellpadding="0" cellspacing="0">
<tr>
	<td class="FormHeaderTwoLine">
		<span class="FormName">Modify role</span>
		<br>
		<span class="FormDescription">Modifies an existing role.</span>
	</td>
</tr>
<tr>
	<td class="FormContent">
		<table width="698" align="center" border="0" cellpadding="1" cellspacing="0" class="FormWindow">
		<tr><td colspan="2" ><br></td></tr>
		<tr>
			<td  width="130" align="right">Role description&nbsp;</td>
			<td >
				<asp:textbox ID="tbxRoleDescription" Runat="server" Name="tbxRoleDescription" MaxLength="50" Columns="50" CssClass="Inputborder"/>
			</td>
		</tr>
		<tr><td  colspan="2" height="6"></td></tr>
		<tr>
			<td  width="130" align="right" valign="top">
				<table cellpadding="2" border="0">
				<tr><td> System rights&nbsp;</td></tr>
				</table>
			</td>
			<td  valign="top">
				<asp:checkboxlist ID="cblSystemRights" Runat="server" RepeatDirection="Vertical" RepeatLayout="Flow" CssClass="input.NoBorder"></asp:checkboxlist>
			</td>
		</tr>
		<tr>
			<td >&nbsp;</td>
			<td >
				<hr align="left" size="1" width="80%">
				<input class="FormButtons" type="button" name="btnSave" runat="server" value="     Save     " ID="btnSave">&nbsp;&nbsp;&nbsp;
				<input class="FormButtons" type="button" name="btnCancel" runat="server" value="  Cancel  " ID="btnCancel" causesvalidation="false">
			</td>
		</tr>
		<tr><td  colspan="2" height="6"></td></tr>
		<tr>
			<td >&nbsp;</td>
			<td >
				<asp:requiredfieldvalidator ControlToValidate="tbxRoleDescription" Runat="server" ErrorMessage="Role description is empty" ID="rfvRoleDescription" name="rfvRoleDescription"/><br>
				<asp:label ID="lblDuplicateRoleDescription" Runat="server" Visible="False" ForeColor="red">There was an error saving the role, this can be caused by a role that has the same description.</asp:label>
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
</asp:Content>