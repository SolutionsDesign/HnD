<%@ Page language="c#" CodeFile="DeleteSection.aspx.cs" AutoEventWireup="false" Inherits="SD.HnD.GUI.Admin.DeleteSection" 
	MasterPageFile="~/Admin/AdminMaster.master" Title="HnD::Administrate::Delete a section"%>

<asp:Content ContentPlaceHolderID="phMainContent" runat="server">
<table cellSpacing="0" cellPadding="2" width="700" align="center" class="ExplanationBox">
	<tr>
		<td>
			<h3>Delete a section</h3>
			Below you'll see the section you selected for deletion. This section can't have 
			any forums. If there are still forums in the section, the form below will 
			notify you on that and you can't delete the section. If the section is empty, 
			you can safely delete the section by clicking on the <b>Delete</b> button. If 
			you don't want to delete this section, click on the <b>Keep</b> button. The delete
			action is irreversable.
		</td>
	</tr>
</table>
<br clear="all">
<table cellSpacing="0" cellPadding="0" width="700" align="center" border="0">
	<tr>
		<td class="FormHeaderOneLine">
			<span class="FormName">Section marked for deletion</span>
		</td>
	</tr>
	<tr>
		<td class="FormContent">
			<table cellSpacing="0" cellPadding="2" width="698" align="center">
			<tr class="LightBackground">
				<td width="40">&nbsp;</td>
				<td>
					<br>
						<b><asp:label id="lblSectionName" Runat="server"></asp:label></b><br>
						<span class="SmallFontSmallest">
							<asp:label id="lblSectionDescription" Runat="server"></asp:label></span>
					<br>
				</td>
			</tr>
			</table>
		</td>
	</tr>
	<tr>
		<td class="FormContent">
			<table class="FormWindow" cellSpacing="0" cellPadding="1" width="698" align="center" border="0">
				<tr>
					<td><br>
						<asp:label id="lblRuleError" Runat="server" Visible="False">
							<b>Note:</b> This section isn't empty, and therefor you're not able to delete this section. Remove / move the existing 
							forum(s) in this section first before deleting this section.
						</asp:label>
						<hr width="80%" SIZE="1">
						<center><input class="FormButtons" id="btnDelete" type="button" value="  Delete  " name="btnDelete" runat="server">
							&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <input class="FormButtons" id="btnKeep" type="button" value="   Keep   " name="btnKeep" runat="server">
						</center>
					</td>
				</tr>
				<tr>
					<td height="6"></td>
				</tr>
			</table>
		</td>
	</tr>
	<tr>
		<td class="EmptyRowBottom">&nbsp;</td>
	</tr>
</table>
</asp:Content>