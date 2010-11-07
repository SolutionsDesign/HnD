<%@ Control Language="c#" AutoEventWireup="false" CodeFile="FindUser.ascx.cs" Inherits="SD.HnD.GUI.Admin.FindUser" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<table width="700" align="center" border="0" cellpadding="0" cellspacing="0">
<tr>
	<td class="FormHeaderTwoLine">
		<span class="FormName">Find <%=_description%></span>
		<br />
		<span class="FormSubName">Find <%=_description%> by Role, Nickname or email address.</span>
	</td>
</tr>
<tr>
    <td class="FormContent">
		<table cellspacing="0" cellpadding="2" width="698" align=center border=0 class="FormWindow">
		<tr>
			<td  width="150">&nbsp;Filter on role</td>
			<td  width="20"><asp:checkbox runat="server" id="chkFilterOnRole"/></td>
			<td ><asp:dropdownlist runat="server" id="cbxRoles"/></td>
		</tr>
		<tr>
			<td  width="150">&nbsp;Filter on nickname</td>
			<td  width="20"><asp:checkbox runat="server" id="chkFilterOnNickName"/></td>
			<td ><asp:textbox runat="server" id="tbxNickName" size="20"/></td>
		</tr>
		<tr>
			<td  width="150">&nbsp;Filter on emailaddress</td>
			<td  width="20"><asp:checkbox runat="server" id="chkFilterOnEmailAddress"/></td>
			<td ><asp:textbox runat="server" id="tbxEmailAddress" size="75"/></td>
		</tr>
		<tr>
			<td widtd="150" >&nbsp;</td>
			<td colspan="2" >
				<hr align="left" size="1" width="80%">
				<asp:button cssclass="FormButtons" id="btnFindUsers" runat="server" text="  Find  " commandname="btnFindUsers" />
				<br><br>
			</td>
		</tr>
		</table>
	</td>
</tr>
<asp:placeholder runat="server" id="phSearchResults" visible="false">
<tr>
    <td class="FormHeaderOneLine">
    	<span class="FormName">Users matching the filter</span>
		<table cellspacing="0" cellpadding="3" width="698" align=center border=0>
		<tr>
			<td class="FormWindow">
				<asp:listbox selectionmode="Single" rows="10" Width="400" runat="server" id="lbxMatchingUsers" name="lbxMatchingUsers"/>
				<hr align="left" size="1" width="80%">
				<asp:button cssclass="FormButtons" id="btnSelect" runat="server" text="Perform select" commandname="btnSelect" />
			</td>
		</tr>
		</table>		
	</td>
</tr>
</asp:placeholder>
<tr>
	<td class="EmptyRowBottom" height="5"><img src="../pics/separator.gif" border="0"></td>
</tr>
</table>