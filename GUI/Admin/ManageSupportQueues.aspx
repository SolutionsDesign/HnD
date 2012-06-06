<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManageSupportQueues.aspx.cs" Inherits="SD.HnD.GUI.Admin.ManageSupportQueues" 
	MasterPageFile="~/Admin/AdminMaster.master" Title="HnD::Administrate::Manage Support Queues"%>
<%@ Register Assembly="SD.LLBLGen.Pro.ORMSupportClasses.Web" Namespace="SD.LLBLGen.Pro.ORMSupportClasses" TagPrefix="llblgenpro" %>

<asp:Content ContentPlaceHolderID="phMainContent" runat="server">
<table width="700" align="center" class="ExplanationBox" cellpadding="2" cellspacing="0">
<tr>
	<td>
		<h3>Manage support queues</h3>
		The form below allows you to manage support queues in the forum system: you can add new ones and edit and delete existing queues. You can only 
		manage the support queue definitions, not their contents. If you delete a support queue, all threads inside that queue will be made queue-less.
		<br /><br />
		The <b>Switch view</b> button allows you to switch between insert and update view of the formview. When you select a row in the grid, you are able to
		either edit it in the formview below it, which is automatically switched to update view, or you're able to delete the row via the <b>Delete selected</b> button. 
		This button is only visible if a row is selected and the IP ban can be deleted.
	</td>
</tr>
</table>
	<llblgenpro:LLBLGenProDataSource ID="_supportQueueDS" runat="server" DataContainerType="EntityCollection" 
		EntityCollectionTypeName="SD.HnD.DAL.CollectionClasses.SupportQueueCollection, SD.HnD.DAL" 
		EnablePaging="True" LivePersistence="False" OnPerformSelect="_supportQueueDS_PerformSelect" OnPerformWork="_supportQueueDS_PerformWork">
	</llblgenpro:LLBLGenProDataSource>
<br>
<asp:GridView ID="_supportQueuesGrid" runat="server" EnableViewState="False" AutoGenerateColumns="False" BackColor="White" 
	BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" Caption="Current Support Queues" CaptionAlign="Top" CellPadding="4" 
	DataKeyNames="QueueID" DataSourceID="_supportQueueDS" ForeColor="Black" GridLines="Vertical" HorizontalAlign="Center" Width="700px" 
	OnSelectedIndexChanged="_supportQueuesGrid_SelectedIndexChanged">
	<FooterStyle BackColor="#CCCC99" />
	<Columns>
		<asp:CommandField ButtonType="Button" ShowSelectButton="True" >
			<ControlStyle CssClass="FormButtons" />
			<ItemStyle VerticalAlign="Top" />
		</asp:CommandField>
		<asp:BoundField DataField="QueueName" HeaderText="Queue name" SortExpression="QueueName" >
			<HeaderStyle Wrap="False" />
			<ItemStyle VerticalAlign="Top" />
		</asp:BoundField>
		<asp:BoundField DataField="QueueDescription" HeaderText="Description" SortExpression="QueueDescription" >
			<ItemStyle VerticalAlign="Top" />
		</asp:BoundField>
		<asp:BoundField DataField="OrderNo" HeaderText="Order No" SortExpression="OrderNo" >
			<HeaderStyle Wrap="False" />
			<ItemStyle VerticalAlign="Top" />
		</asp:BoundField>
	</Columns>
	<RowStyle CssClass="TableRow LightBackground" />
	<SelectedRowStyle CssClass="TableRowSelected" />
	<PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
	<HeaderStyle cssclass="TableColumnHeader " />
	<AlternatingRowStyle CssClass="TableRow DarkBackground"/>
</asp:GridView>
	<br />

<table border="0" align="center" style="width: 437px">
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
<asp:FormView ID="_supportQueueFormView" runat="server" DefaultMode="Edit" DataKeyNames="QueueID" DataSourceID="_supportQueueDS"
	CssClass="ExplanationBox" HorizontalAlign="Center" Width="436px">
	<EditItemTemplate>
		<b>Edit selected item</b><br clear="all" />
		<table width="100%" id="TABLE1">
			<tr>
				<td nowrap="nowrap">
					Queue name</td>
				<td>
					<asp:TextBox ID="tbxQueueName" runat="server" Text='<%# Bind("QueueName") %>' Columns="50"/>
				</td>
			</tr>
			<tr>
				<td valign="top">
					Description</td>
				<td>
					<asp:TextBox ID="DescriptionTextBox" runat="server" Height="80px" Text='<%# Bind("QueueDescription") %>' TextMode="MultiLine" Width="300px"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td nowrap="nowrap">
					Order no</td>
				<td>
					<asp:TextBox ID="tbxOrderNo" runat="server" Text='<%# Bind("OrderNo") %>' MaxLength="5" Columns="5"/>
                    <asp:CompareValidator ID="CompareValidator1" ControlToValidate="tbxOrderNo" Operator="DataTypeCheck" Type="Integer" runat="server" ErrorMessage="Please insert a numeric value." Display="Dynamic"></asp:CompareValidator>                
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbxOrderNo"
                        Display="Dynamic" ErrorMessage="Please insert an Order no."></asp:RequiredFieldValidator></td>
			</tr>
		</table>
		<hr class="FooterHR" />
		<asp:Button ID="UpdateButton" CssClass="FormButtons" runat="server" CausesValidation="True" CommandName="Update" Text="Update">
		</asp:Button>
		<asp:Button ID="UpdateCancelButton" CssClass="FormButtons" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel">
		</asp:Button>
	</EditItemTemplate>
	<InsertItemTemplate>
		<b>Insert new support queue</b><br clear="all" />
		<table width="100%" id="TABLE1">
			<tr>
				<td nowrap="nowrap">
					Queue name</td>
				<td>
					<asp:TextBox ID="tbxQueueName" runat="server" Text='<%# Bind("QueueName") %>' Columns="50"/>
				</td>
			</tr>
			<tr>
				<td valign="top">
					Description</td>
				<td>
					<asp:TextBox ID="DescriptionTextBox" runat="server" Height="80px" Text='<%# Bind("QueueDescription") %>' TextMode="MultiLine" Width="300px"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td nowrap="nowrap">
					Order no</td>
				<td>
					<asp:TextBox ID="tbxOrderNo" runat="server" Text='<%# Bind("OrderNo") %>' MaxLength="5" Columns="5"/>
					<asp:CompareValidator ID="CompareValidator1" ControlToValidate="tbxOrderNo" Operator="DataTypeCheck" Type="Integer" runat="server" ErrorMessage="Please insert a numeric value." Display="Dynamic"></asp:CompareValidator>                
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbxOrderNo"
                        Display="Dynamic" ErrorMessage="Please insert an Order no."></asp:RequiredFieldValidator>
                </td>
			</tr>
		</table>
		<hr class="FooterHR" />
		<asp:Button ID="InsertButton" CssClass="FormButtons" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert">
		</asp:Button>
		<asp:Button ID="InsertCancelButton" CssClass="FormButtons" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel">
		</asp:Button>
	</InsertItemTemplate>
</asp:FormView>

</asp:Content>