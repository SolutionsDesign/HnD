<%@ Page language="c#" CodeFile="AddSection.aspx.cs" AutoEventWireup="false" Inherits="SD.HnD.GUI.Admin.AddSection" 
	MasterPageFile="~/Admin/AdminMaster.master" Title="HnD::Administrate::Add a new section"%>

<asp:Content ContentPlaceHolderID="phMainContent" runat="server">
<table width="700" align="center" border="0" cellpadding="0" cellspacing="0">
<tr>
	<td class="TableHeaderTwoLine">
		<span class="TableName">Existing sections</span>
		<br>
		<span class="TableDescription">The list of existing sections in the forum system.</span>
	</td>
</tr>
<tr>
	<td class="TableContent">
		<table width="698" align="center" border="0" cellpadding="2" cellspacing="0">
		<tr>
			<td class="TableColumnHeader">Section Name</td>
			<td class="TableColumnHeader" nowrap="nowrap">Sort-order no.</td>
		</tr>
		<asp:repeater ID="rpSections" Runat="server">
			<itemtemplate>
			<tr>
				<td class="TableRow LightBackground">
					<b><%#Eval("SectionName") %></b><br>
					<span class="SmallFontSmallest"><%#Eval("SectionDescription")%></span>
				</td>
				<td class="TableRow LightBackground">
					<%# Eval("OrderNo") %>
				</td>
			</tr>
			</itemtemplate>
			
			<alternatingitemtemplate>
			<tr>
				<td class="TableRow DarkBackground">
					<b><%#Eval("SectionName") %></b><br>
					<span class="SmallFontSmallest"><%#Eval("SectionDescription")%></span>
				</td>
				<td class="TableRow DarkBackground">
					<%# Eval("OrderNo") %>
				</td>
			</tr>
			</alternatingitemtemplate>
		</asp:repeater>
		</table>
	</td>
</tr>
<tr><td class="EmptyRowBottom">&nbsp;</td></tr>
</table>
<br clear="all">

<table width="700" align="center" border="0" cellpadding="0" cellspacing="0">
<tr>
	<td class="FormHeaderTwoLine">
		<span class="FormName">Add a new section</span>
		<br>
		<span class="FormDescription">Adds a new section to the system immediately. A new section doesn't have any forums.</span>
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
				<input class="FormButtons" type="button" name="btnSave" runat="server" value="     Save     " ID="btnSave"><br>
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