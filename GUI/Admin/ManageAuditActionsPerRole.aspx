<%@ Page language="c#" CodeFile="ManageAuditActionsPerRole.aspx.cs" AutoEventWireup="false" Inherits="SD.HnD.GUI.Admin.ManageAuditActionsPerRole" 
	MasterPageFile="~/Admin/AdminMaster.master" Title="HnD::Administrate::Manage Audit Actions per role"%>

<asp:Content ContentPlaceHolderID="phMainContent" runat="server">
<table width="700" align="center" class="ExplanationBox" cellpadding="2" cellspacing="0">
<tr>
	<td>
		<h3>Manage Audit Actions per Role</h3>
		Below you can configure the audit action definitions per role. You first select the role you want to define the audit actions for, then
		you check / uncheck every audit action to set the audit actions for the role selected. When you are done, click <b>Save</b> to
		save the definition or click <b>Cancel</b> to go back to the main menu. Once you've saved a new setting, it's stored in the database. Pressing
		cancel after that will not undo your save action. 
	</td>
</tr>
</table>
<br clear="all">
<table width="700" align="center" border="0" cellpadding="0" cellspacing="0">
<tr>
	<td class="FormHeaderTwoLine">
		<span class="FormName">Audit Actions per role</span>
		<br>
		<span class="FormDescription">The list of existing audit actions set for the select role.</span>
	</td>
</tr>
<tr>
	<td class="FormContent">
		<table width="698" align="center" border="0" cellpadding="1" cellspacing="0" class="FormWindow">
		<tr><td colspan="2" ><br></td></tr>
		<tr>
			<td  width="130" align="right">Role&nbsp;</td>
			<td >
				<asp:dropdownlist id="cbxRoles" runat="server" autopostback="True" />
			</td>
		</tr>
		<tr><td  colspan="2" height="3"></td></tr>
		<tr>
			<td  width="130" align="right" valign="top">
				<table cellpadding="2" border="0">
				<tr><td>Audit actions&nbsp;</td></tr>
				</table>
			</td>
			<td  valign="top">
				<asp:checkboxlist id="cblAuditActions" runat="server" repeatdirection="Vertical" repeatlayout="Flow" cssclass="input.NoBorder"></asp:checkboxlist>
			</td>
		</tr>
		<tr>
			<td >&nbsp;</td>
			<td >
				<hr align="left" size="1" width="80%">
				<input class="FormButtons" type="button" name="btnSave" runat="server" value="   Save   " id="btnSave">&nbsp;&nbsp;&nbsp;
				<input class="FormButtons" type="button" name="btnCancel" runat="server" value="  Cancel  " id="btnCancel" causesvalidation="false">
			</td>
		</tr>
		<asp:placeholder id="phSaveResult" visible="False" runat="server">
        <tr>
          <td  colspan="2" height="3"></td></tr>
        <tr>
          <td  width="130">&nbsp;</td>
          <td >Save action was 
        succesful!</td></tr>
		</asp:placeholder>
		<tr><td  colspan="2" height="6"></td></tr>
		</table>
	</td>
</tr>
<tr><td class="EmptyRowBottom">&nbsp;</td></tr>
</table>
</asp:Content>