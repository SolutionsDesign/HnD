<%@ Page language="c#" CodeFile="Reparser.aspx.cs" AutoEventWireup="false" Inherits="SD.HnD.GUI.Admin.Reparser" 
	MasterPageFile="~/Admin/AdminMaster.master" title="HnD::Administrate::MessageReparser"%>

<asp:Content ContentPlaceHolderID="phMainContent" runat="server">
<table width="700" align="center" border="0" cellpadding="2" cellspacing="0">
<tr>
	<td>
		<h3>Message reparser</h3>
		Use this form to re-parse the messages. Use with care.<br><br>
		
		<table width="689" border="0">
		<tr class="TableRow LightBackground">
			<td width="20">&nbsp;</td>
			<td valign="top">StartDate</td>
			<td><asp:calendar id="cldStartDate" runat="server" borderstyle="Ridge"/></td>
		</tr>
		<tr class="TableRow DarkBackground">
			<td width="20">&nbsp;</td>
			<td>Amount to re-parse</td>
			<td><asp:textbox runat="server" id="tbxAmountToReparse" /> (empty = parse all from startdate)</td>
		</tr>
		<tr class="TableRow LightBackground">
			<td width="20">&nbsp;</td>
			<td>Generate HTML as well</td>
			<td><asp:checkbox id="chkRegenerateHTML" runat="server" checked="False" /></td>
		</tr>
		<tr class="TableRow DarkBackground">
			<td width="20">&nbsp;</td>
			<td colspan="2">
				<hr align="left" size="1" width="80%">
				<asp:button runat="server" id="btnStart" text="Start Reparse action"/> (can take a while)
			</td>
		</tr>
		<tr class="TableRow LightBackground">
			<td width="20">&nbsp;</td>
			<td colspan="2">
				<br clear="all">
				<asp:panel visible="False" runat="server" id="pnlReparseResults"><asp:label id="lblReparseResults" runat="server"></asp:label>
				</asp:panel>
			</td>
		</tr>
		</table>
	</td>
</tr>
</table>
</asp:Content>