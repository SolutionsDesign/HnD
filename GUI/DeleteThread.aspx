<%@ Register TagPrefix="HnD" TagName="PageHeader" Src="Header.ascx"%>
<%@ Register TagPrefix="HnD" TagName="PageFooter" Src="Footer.ascx"%>
<%@ Page language="c#" CodeFile="DeleteThread.aspx.cs" AutoEventWireup="false" Inherits="SD.HnD.GUI.DeleteThread" %>
<!doctype HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
  <head runat="server">
	<title>HnD::Delete a thread</title>
	<meta name="vs_defaultClientScript" content="JavaScript">
	<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">  </head>
<body>
<form id="DeleteMessage" method="post" runat="server">
<table width="750" align="center" border="0" cellpadding="0" cellspacing="0">
<hnd:pageheader runat="server" id="PageHeader" />
</table>
<br clear="all"><br>
<table width="750" align="center" class="ExplanationBox" cellpadding="2" cellspacing="0">
<tr>
	<td>
		<h3>Delete a thread</h3>
		<p>
			Below you see the thread you're about to delete. If you click <i>Delete</i>, the thread, all its messages and all the complete history log
			for all the messages in this thread are deleted from the database. This is an irreversable action. If you click <i>Keep</i>, 
			nothing happens and you are transfered back to the thread.
		</p>
	</td>
</tr>
</table>
<br clear="all">
<table cellSpacing="0" cellPadding="0" width="750" align="center" border="0">
<tr>
	<td class="FormHeaderOneLine">
		<span class="FormName">Thread marked for deletion</span>
	</td>
</tr>
<tr>
	<td class="FormContent">
		<table cellPadding="2" cellspacing="0" width="748" align="center" class="FormWindow">
			<tr >
				<td width="40">&nbsp;</td>
				<td>
					<br>
					<b>Forum:</b> <asp:label ID="lblForumName" Runat="server" /><br>
					<b>Thread:</b> <asp:label id="lblThreadSubject" Runat="server" /><br>
					<br>
				</td>
			</tr>
			<tr>
				<td colspan="2"><br>
					<hr width="80%" SIZE="1">
					<center><input class="FormButtons" id="btnDelete" type="button" value="  Delete  " name="btnDelete" runat="server">
						&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <input class="FormButtons" id="btnKeep" type="button" value="   Keep   " name="btnKeep" runat="server">
					</center>
				</td>
			</tr>
			<tr>
				<td colspan="2" height="6"></td>
			</tr>
		</table>
	</td>
</tr>
<tr>
	<td class="EmptyRowBottom">&nbsp;</td>
</tr>
</table>
</form>
<br clear="all">
<!-- footer -->
<hnd:pagefooter runat="server" id="PageFooter" />
</body>
</html>
