<%@ Page language="c#" CodeFile="MoveThread.aspx.cs" AutoEventWireup="false" Inherits="SD.HnD.GUI.MoveThread" %>

<%@ Register Assembly="SD.LLBLGen.Pro.ORMSupportClasses.NET20" Namespace="SD.LLBLGen.Pro.ORMSupportClasses" TagPrefix="llblgenpro" %>
<%@ Register TagPrefix="HnD" TagName="PageFooter" Src="Footer.ascx"%>
<%@ Register TagPrefix="HnD" TagName="PageHeader" Src="Header.ascx"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
  <head runat="server">
	<title>HnD::Administrate::Move a thread.</title>
	<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
	<meta content="C#" name="CODE_LANGUAGE">
	<meta content="JavaScript" name="vs_defaultClientScript">
	<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	<link href="stylesheets/layout01282006.css" type="text/css" rel="stylesheet">
  </head>
<body>
<form id="Form1" runat="server" method="post">
<table align="center" border="0" cellpadding="0" cellspacing="0" width="750">
<hnd:pageheader runat="server" id="PageHeader" />
</table>
<br clear="all">
<table  cellSpacing="0" cellPadding="2" width="750" align="center" class="ExplanationBox">
	<tr>
		<td>
			<h3>Move a thread</h3>
			Below you can select the forum whereto you are moving the thread mentioned below. First select the section, then the forum and after that click
			<i>Move</i> if you want to move the thread to the forum selected. 
		</td>
	</tr>
</table>
<br clear="all">
<table cellSpacing="0" cellPadding="0" width="750" align="center" border="0">
	<tr>
		<td class="FormHeaderOneLine">
			<span class="FormName">Select the forum to move the thread to.</span>
		</td>
	</tr>
	<tr>
		<td class="FormContent">
			<table width="748" align="center" border="0" cellpadding="1" cellspacing="0" class="FormWindow">
			<tr><td colspan="2"><br></td></tr>
			<tr>
				<td width="70" align="right" valign="top">Thread&nbsp;</td>
				<td><b><asp:label Runat="server" ID="lblThreadSubject"/></b></td>
			</tr>
			<tr><td colspan="2" height="3"></td></tr>
			<tr>
				<td width="70" align="right">Section&nbsp;</td>
				<td>
					<asp:dropdownlist ID="cbxSections" Runat="server" AutoPostBack="True" DataTextField="SectionName" DataValueField="SectionID" />
				</td>
			</tr>
			<tr><td colspan="2" height="3"></td></tr>
			<tr>
				<td align=right width=70>Forum&nbsp;</td>
				<td>
					<asp:dropdownlist id="cbxForums" Runat="server" DataSourceID="_forumsDS" DataTextField="ForumName" DataValueField="ForumID"></asp:dropdownlist>
				</td>
			</tr>
			<tr>
				<td>&nbsp;</td>
				<td>
					<hr align="left" size="1" width="80%">
					<input class="FormButtons" type="button" name="btnMove" runat="server" value="   Move   " ID="btnMove">&nbsp;&nbsp;&nbsp;
					<input class="FormButtons" type="button" name="btnCancel" runat="server" value="  Cancel  " ID="btnCancel" causesvalidation="false">
				</td>
			</tr>
			<tr><td colspan="2" height="6"></td></tr>
			</table>
		</td>
	</tr>
	<tr>
		<td class="EmptyRowBottom">&nbsp;</td>
	</tr>
</table>
<llblgenpro:llblgenprodatasource id="_forumsDS" runat="server" cachelocation="Session" livepersistence="False" 
	DataContainerType="EntityCollection" EntityCollectionTypeName="SD.HnD.DAL.CollectionClasses.ForumCollection, SD.HnD.DAL" 
	OnPerformSelect="_forumsDS_PerformSelect">
	<SelectParameters>
		<asp:ControlParameter ControlID="cbxSections" Name="SectionID" PropertyName="SelectedValue" />
	</SelectParameters>
</llblgenpro:llblgenprodatasource>
</form>
<!-- footer -->
<hnd:pagefooter runat="server" id="PageFooter" />
</body>
</html>
