<%@ Page language="c#" CodeFile="ModifySystemParameters.aspx.cs" AutoEventWireup="false" Inherits="SD.HnD.GUI.Admin.ModifySystemParameters" 
	MasterPageFile="~/Admin/AdminMaster.master" Title="HnD::Administrate::Modify system parameters"%>

<asp:Content ContentPlaceHolderID="phMainContent" runat="server">
<table width="700" align="center" class="ExplanationBox" cellpadding="2" cellspacing="0">
<tr>
	<td>
		<h3>Modify system parameters</h3>
		Below you can set several system parameters at once. Once you have saved these parameters, the forum system will reload these values into the
		application cache so new session will use the new settings immediately. Click <i>Cancel</i> to disgard changes and to go back to the main menu.
		Anonymous users are users who are not logged in. The role assigned to them should have only those rights you want anonymous users to have, which
		should be rather slim (f.e. only access rights to a subset of your forums).
	</td>
</tr>
</table>
<br clear="all">
<table width="700" align="center" border="0" cellpadding="0" cellspacing="0">
<tr>
	<td class="FormHeaderTwoLine">
		<span class="FormName">System parameter settings</span>
		<br>
		<span class="FormDescription">The current values for various system parameters.</span>
	</td>
</tr>
<tr>
	<td class="FormContent">
		<table width="698" align="center" border="0" cellpadding="1" cellspacing="0" class="FormWindow">
		<tr><td colspan="2" ><br></td></tr>
		<tr>
			<td  width="250" align="right">Default role for new users&nbsp;</td>
			<td >
				<asp:dropdownlist ID="cbxDefaultRoleNewUsers" Runat="server"/>
			</td>
		</tr>
		<tr><td  colspan="2" height="3"></td></tr>
		<tr>
			<td  align=right width="250">Role for anonymous users&nbsp;</td>
			<td >
				<asp:dropdownlist id="cbxAnonymousUserRole" Runat="server"/>
			</td>
		</tr>
		<tr><td  colspan="2" height="3"></td></tr>
		<tr>
			<td  align=right width="250">Default user title for new users&nbsp;</td>
			<td >
				<asp:dropdownlist id="cbxDefaultUserTitleNewUsers" Runat="server"/>
			</td>
		</tr>
		<tr><td  colspan="2" height="3"></td></tr>
		<tr>
			<td  align=right width="250">Hours threshold for Active Threads&nbsp;</td>
			<td >
				<asp:TextBox Columns="4" ID="tbxActiveThreadsThreshold" runat="server" MaxLength="4" />
			</td>
		</tr>
		<tr><td  colspan="2" height="3"></td></tr>
		<tr>
			<td  align=right width="250">Page size in search results&nbsp;</td>
			<td >
				<asp:TextBox Columns="4" ID="tbxPageSizeInSearchResults" runat="server" MaxLength="4" />
			</td>
		</tr>
		<tr><td  colspan="2" height="3"></td></tr>
		<tr>
			<td  align=right width="250">Min. # of threads to fetch&nbsp;</td>
			<td >
				<asp:TextBox Columns="4" ID="tbxMinNumberOfThreadsToFetch" runat="server" MaxLength="4" />
			</td>
		</tr>
		<tr><td  colspan="2" height="3"></td></tr>
		<tr>
			<td  align=right width="250">Min. # of non-sticky visible threads&nbsp;</td>
			<td >
				<asp:TextBox Columns="4" ID="tbxMinNumberOfNonStickyVisibleThreads" runat="server" MaxLength="4" />
			</td>
		</tr>
		<tr><td  colspan="2" height="3"></td></tr>
		<tr>
			<td  align=right width="250" valign="top">Send reply notifications&nbsp;
			</td>
			<td >
				<asp:CheckBox ID="chkSendReplyNotifications" runat="server"/>
				<span class="SmallFontSmallest">When this option has been enabled, the system will send notification emails to subscribers
				who have subscribed to a thread in which a new message was posted. When this option has been disabled, the system won't send
				notification emails and users aren't able to subscribe/unsubscribe to threads. 
				</span>
			</td>
		</tr>
		<tr>
			<td >&nbsp;</td>
			<td >
				<hr align="left" size="1" width="80%">
				<input class="FormButtons" type="button" name="btnSave" runat="server" value="   Save   " ID="btnSave">&nbsp;&nbsp;&nbsp;
				<input class="FormButtons" type="button" name="btnCancel" runat="server" value="  Cancel  " ID="btnCancel" causesvalidation="false">
			</td>
		</tr>
		<tr><td  colspan="2" height="6"></td></tr>
		</table>
	</td>
</tr>
<tr><td class="EmptyRowBottom">&nbsp;</td></tr>
</table>
</asp:Content>