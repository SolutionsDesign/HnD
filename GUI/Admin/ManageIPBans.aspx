<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManageIPBans.aspx.cs" Inherits="SD.HnD.GUI.Admin.ManageIPBans" 
	MasterPageFile="~/Admin/AdminMaster.master" Title="HnD::Administrate::Manage IP bans"%>
<%@ Register Assembly="SD.LLBLGen.Pro.ORMSupportClasses.NET20" Namespace="SD.LLBLGen.Pro.ORMSupportClasses" TagPrefix="llblgenpro" %>

<asp:Content ContentPlaceHolderID="phMainContent" runat="server">
<asp:HiddenField ID="_userID" runat="server" />
<asp:HiddenField ID="_currentDate" runat="server" />

<table width="700" align="center" class="ExplanationBox" cellpadding="2" cellspacing="0">
<tr>
	<td>
		<h3>Manage IP bans</h3>
		The form below allows you to manage the IP bans currently defined. The form allows you to add, edit and remove IP bans. IP bans are bans on an 
		IP range. An IP number has 4 segments: aaa.bbb.ccc.ddd. By specifying a range, which can be 8, 16, 24 or 32 for the significant bits in the 
		IP segments specified, you are able to specify how IP addresses are matched against the set IP ban. <br /><br />
		Example: you set as IP ban: 1.2.3.4/24, where '24' is the range. When a user with IP address 1.2.3.5 tries to connect to the website, his IP address
		matches with this IP ban, as the range is 24, i.e. the first 3 segments, and thus the IP address matches the IP ban if the first 3 segments are the same, 
		which is the case: 1.2.3. Would the user have the IP address: 2.2.3.4, it wouldn't be a match, as 2.2.3 isn't equal to 1.2.3.
		<br /><br />
		The <b>Switch view</b> button allows you to switch between insert and update view of the formview. When you select a row in the grid, you are able to
		either edit it in the formview below it, which is automatically switched to update view, or you're able to delete the row via the <b>Delete selected</b> button. 
		This button is only visible if a row is selected and the IP ban can be deleted.
	</td>
</tr>
</table>
	<llblgenpro:LLBLGenProDataSource ID="_ipBanDS" runat="server" DataContainerType="EntityCollection" EntityCollectionTypeName="SD.HnD.DAL.CollectionClasses.IPBanCollection, SD.HnD.DAL" EnablePaging="True" LivePersistence="False" OnPerformGetDbCount="_ipBanDS_PerformGetDbCount" OnPerformSelect="_ipBanDS_PerformSelect" OnPerformWork="_ipBanDS_PerformWork">
		<InsertParameters>
			<asp:FormParameter DefaultValue="0" FormField="_userID" Name="IPBanSetByUserID" />
			<asp:FormParameter FormField="_currentDate" Name="IPBanSetOn" />
		</InsertParameters>
		<UpdateParameters>
			<asp:FormParameter FormField="_currentDate" Name="IPBanSetOn" />
		</UpdateParameters>
	</llblgenpro:LLBLGenProDataSource>
<br>
<asp:GridView ID="_ipBansGrid" runat="server" EnableViewState="False" AutoGenerateColumns="False" AllowPaging="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" Caption="Current IP bans" CaptionAlign="Top" CellPadding="4" DataKeyNames="IPBanID" DataSourceID="_ipBanDS" ForeColor="Black" GridLines="Vertical" HorizontalAlign="Center" OnSelectedIndexChanged="_ipBansGrid_SelectedIndexChanged">
	<FooterStyle BackColor="#CCCC99" />
	<Columns>
		<asp:CommandField ButtonType="Button" ShowSelectButton="True" ControlStyle-CssClass="FormButtons" />
		<asp:BoundField DataField="IPSegment1" HeaderText="S1" SortExpression="IPSegment1" />
		<asp:BoundField DataField="IPSegment2" HeaderText="S2" SortExpression="IPSegment2" />
		<asp:BoundField DataField="IPSegment3" HeaderText="S3" SortExpression="IPSegment3" />
		<asp:BoundField DataField="IPSegment4" HeaderText="S4" SortExpression="IPSegment4" />
		<asp:BoundField DataField="Range" HeaderText="Range" SortExpression="Range" />
		<asp:BoundField DataField="IPBanSetOn" HeaderText="Set on" DataFormatString="{0:dd-MMM-yyyy HH:mm.ss}" SortExpression="IPBanSetOn" HtmlEncode="false" />
		<asp:BoundField DataField="SetByUserNickName" HeaderText="Set By" SortExpression="SetByUserNickName" />
	</Columns>
	<RowStyle CssClass="TableRow LightBackground" />
	<SelectedRowStyle CssClass="TableRowSelected" />
	<PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
	<HeaderStyle cssclass="TableColumnHeader " />
	<AlternatingRowStyle CssClass="TableRow DarkBackground"/>
</asp:GridView>

<table border="0" align="center" style="width: 439px">
<tr>
	<td align="left" style="width: 96px; height: 26px" valign="bottom">
		<asp:Button ID="_switchViewButton" CssClass="FormButtons" runat="server" OnClick="_switchViewButton_Click" Text="Switch view" />
	</td>
	<td align="right" style="width: 488px; height: 26px" valign="bottom">
		<asp:Button ID="_deleteSelectedButton" CssClass="FormButtons" runat="server" Text="Delete selected" UseSubmitBehavior="False" Visible="False" OnClick="_deleteSelectedButton_Click" />
	</td>
</tr>
</table>
	<br />
<asp:FormView ID="_ipBanFormView" CssClass="ExplanationBox" runat="server" DefaultMode="edit" DataKeyNames="IPBanID" DataSourceID="_ipBanDS" HorizontalAlign="Center" Width="436px">
	<EditItemTemplate>
		<b>Edit selected item</b><br clear="all" />
		<table width="100%" id="TABLE1">
			<tr>
				<td nowrap="nowrap">
					IP Address</td>
				<td>
					<asp:TextBox ID="IPSegment1TextBox" runat="server" Text='<%# Bind("IPSegment1") %>' maxlength="3" Width="32px"/>.
					<asp:TextBox ID="IPSegment2TextBox" runat="server" Text='<%# Bind("IPSegment2") %>' maxlength="3" Width="32px"/>.
					<asp:TextBox ID="IPSegment3TextBox" runat="server" Text='<%# Bind("IPSegment3") %>' maxlength="3" Width="32px"/>.
					<asp:TextBox ID="IPSegment4TextBox" runat="server" Text='<%# Bind("IPSegment4") %>' maxlength="3" Width="32px"/>
				</td>
			</tr>
			<tr>
				<td>
					Range</td>
				<td>
					<asp:DropDownList ID="rangeComboBox" runat="server" SelectedValue='<%# Bind("Range") %>' >
						<asp:ListItem Value="8" Text="8 (First segment)" />
						<asp:ListItem Value="16" Text="16 (First 2 segments)" />
						<asp:ListItem Value="24" Text="24 (First 3 segments)" Selected="true"/>
						<asp:ListItem Value="32" Text="32 (All segments)" />
					</asp:DropDownList>
				</td>
			</tr>
			<tr>
				<td valign="top">
					Reason</td>
				<td>
					<asp:TextBox ID="ReasonTextBox" runat="server" Height="80px" Text='<%# Bind("Reason") %>' TextMode="MultiLine" Width="300px"></asp:TextBox>
				</td>
			</tr>
		</table>
		<hr class="FooterHR" />
		<asp:Button ID="UpdateButton" CssClass="FormButtons" runat="server" CausesValidation="True" CommandName="Update" Text="Update">
		</asp:Button>
		<asp:Button ID="UpdateCancelButton" CssClass="FormButtons" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel">
		</asp:Button>
	</EditItemTemplate>
	<InsertItemTemplate>
		<b>Insert new IP ban</b><br clear="all" />
		<table width="100%" id="TABLE1">
			<tr>
				<td nowrap="nowrap">
					IP Address</td>
				<td>
					<asp:TextBox ID="IPSegment1TextBox" runat="server" Text='<%# Bind("IPSegment1") %>' maxlength="3" Width="32px"/>.
					<asp:TextBox ID="IPSegment2TextBox" runat="server" Text='<%# Bind("IPSegment2") %>' maxlength="3" Width="32px"/>.
					<asp:TextBox ID="IPSegment3TextBox" runat="server" Text='<%# Bind("IPSegment3") %>' maxlength="3" Width="32px"/>.
					<asp:TextBox ID="IPSegment4TextBox" runat="server" Text='<%# Bind("IPSegment4") %>' maxlength="3" Width="32px"/>
				</td>
			</tr>
			<tr>
				<td>
					Range</td>
				<td>
					<asp:DropDownList ID="rangeComboBox" runat="server" SelectedValue='<%# Bind("Range") %>' >
						<asp:ListItem Value="8" Text="8 (First segment)" />
						<asp:ListItem Value="16" Text="16 (First 2 segments)" />
						<asp:ListItem Value="24" Text="24 (First 3 segments)" Selected="true"/>
						<asp:ListItem Value="32" Text="32 (All segments)" />
					</asp:DropDownList>
				</td>
			</tr>
			<tr>
				<td valign="top">
					Reason</td>
				<td>
					<asp:TextBox ID="ReasonTextBox" runat="server" Height="80px" Text='<%# Bind("Reason") %>' TextMode="MultiLine" Width="300px"></asp:TextBox>
				</td>
			</tr>
		</table>
		<hr class="FooterHR" />
		<asp:Button ID="InsertButton" CssClass="FormButtons" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert">
		</asp:Button>
		<asp:Button ID="InsertCancelButton" CssClass="FormButtons" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel">
		</asp:Button>
	</InsertItemTemplate>
	<ItemTemplate>
		Selected Item:<br /><br />
		IPSegment1:
		<asp:Label ID="IPSegment1Label" runat="server" Text='<%# Bind("IPSegment1") %>'></asp:Label><br />
		IPSegment2:
		<asp:Label ID="IPSegment2Label" runat="server" Text='<%# Bind("IPSegment2") %>'></asp:Label><br />
		IPSegment3:
		<asp:Label ID="IPSegment3Label" runat="server" Text='<%# Bind("IPSegment3") %>'></asp:Label><br />
		IPSegment4:
		<asp:Label ID="IPSegment4Label" runat="server" Text='<%# Bind("IPSegment4") %>'></asp:Label><br />
		Range:
		<asp:Label ID="RangeLabel" runat="server" Text='<%# Bind("Range") %>'></asp:Label><br />
		<asp:Button ID="EditButton" CssClass="FormButtons" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit">
		</asp:Button>
		<asp:Button ID="DeleteButton" CssClass="FormButtons" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete">
		</asp:Button>
		<asp:Button ID="NewButton" runat="server" CausesValidation="False" CommandName="New" Text="New">
		</asp:Button>
	</ItemTemplate>
</asp:FormView>
</asp:Content>