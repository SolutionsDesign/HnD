<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PageLegend.ascx.cs" Inherits="SD.HnD.GUI.PageLegend" %>
<br clear="all"/>
<table width="750" align="center" border="0" cellpadding="1" cellspacing="0" class="LegendBox">
<tr>
	<td colspan="6" class="SmallFontSmallest">
		&nbsp;<b>Legend:</b>
	</td>
</tr>
<tr>
	<td width="25">&nbsp;</td>
	<td width="20" align="center"><asp:Image SkinId="imgIconNoNewPostsLegend" runat="server"/></td>
	<td class="SmallFontSmallest">No new messages since your last visit.</td>
	<td width="25">&nbsp;</td>
	<td width="20" align="center"><asp:Image SkinId="imgIconNewPostsLegend" runat="server"/></td>
	<td class="SmallFontSmallest">New messages since your last visit.</td>
</tr>
<tr>
	<td width="25">&nbsp;</td>
	<td width="20" align="center"><asp:Image SkinId="imgIconNoNewPostsClosedLegend" runat="server"/></td>
	<td class="SmallFontSmallest">No new messages since your last visit, thread is locked / closed.</td>
	<td width="25">&nbsp;</td>
	<td width="20" align="center"><asp:Image SkinId="imgIconNewPostsClosedLegend" runat="server"/></td>
	<td class="SmallFontSmallest">New messages since your last visit, thread is locked / closed.</td>
</tr>
<tr>
	<td width="25">&nbsp;</td>
	<td width="20" align="center"><asp:Image SkinId="imgIconNoNewPostsStickyLegend" runat="server"/></td>
	<td class="SmallFontSmallest">No new messages since your last visit, thread is pinned / sticky.</td>
	<td width="25">&nbsp;</td>
	<td width="20" align="center"><asp:Image SkinId="imgIconNewPostsStickyLegend" runat="server"/></td>
	<td class="SmallFontSmallest">New messages since your last visit, thread is pinned / sticky.</td>
</tr>
<tr>
	<td width="25">&nbsp;</td>
	<td width="20" align="center"><asp:Image SkinID="imgThreadDoneSmall" runat="server"/></td>
	<td class="SmallFontSmallest">Thread is marked 'done' by thread starter or support team.</td>
	<td width="25">&nbsp;</td>
	<td width="20" align="center"><asp:Image SkinID="imgThreadNotDoneSmall" runat="server"/></td>
	<td class="SmallFontSmallest">Thread is active.</td>
</tr>
<tr>
	<td colspan="6">&nbsp;</td>
</tr>
</table>
