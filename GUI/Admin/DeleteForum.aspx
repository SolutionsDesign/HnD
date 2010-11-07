<%@ Page language="c#" CodeFile="DeleteForum.aspx.cs" AutoEventWireup="false" Inherits="SD.HnD.GUI.Admin.DeleteForum" 
	MasterPageFile="~/Admin/AdminMaster.master" Title="HnD::Administrate::Delete a forum"%>

<asp:Content ContentPlaceHolderID="phMainContent" runat="server">
<table cellSpacing="0" cellPadding="2" width="700" align="center" class="ExplanationBox">
	<tr>
		<td>
			<h3>Delete a forum</h3>
			Below you'll see the forum you selected for deletion. When you proceed with deleting this forum, <i>all</i> messages posted in this forum
			are deleted with the threads they're in plus all message history logs are also removed. Only remove a forum if you really want to get rid of
			all the discussions posted in the forum.
			<br><br>	
			You can proceed with the deletion of the forum by clicking on the <b>Delete</b> button. If 
			you don't want to delete this forum, click on the <b>Keep</b> button. The delete action is irreversable.
		</td>
	</tr>
</table>
<br clear="all">
<table cellSpacing="0" cellPadding="0" width="700" align="center" border="0">
	<tr>
		<td class="TableHeaderOneLine">
			<span class="TableName">Forum marked for deletion</span>
		</td>
	</tr>
	<tr>
		<td class="FormContent">
			<table cellSpacing="0" cellPadding="2" width="698" align="center">
				<tr class="LightBackground">
					<td width="40">&nbsp;</td>
					<td>
						<br>
						<b><asp:label id="lblForumName" Runat="server"></asp:label></b><br>
						<span class="SmallFontSmallest"><asp:label id="lblForumDescription" Runat="server"/></span>
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