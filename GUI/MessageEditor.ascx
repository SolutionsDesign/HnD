<%@ Control Language="c#" AutoEventWireup="false" CodeFile="MessageEditor.ascx.cs" Inherits="SD.HnD.GUI.MessageEditor" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<script language="javascript">
	// browser checkers
	var iClientVersion = parseInt(navigator.appVersion); 
	var sClientPCUA = navigator.userAgent.toLowerCase(); 
	var bIsIE = ((sClientPCUA.indexOf("msie") != -1) && (sClientPCUA.indexOf("opera") == -1));
	var bIsNetscape = ((sClientPCUA.indexOf('mozilla')!=-1) && (sClientPCUA.indexOf('spoofer')==-1)
					&& (sClientPCUA.indexOf('compatible') == -1) && (sClientPCUA.indexOf('opera')==-1)
					&& (sClientPCUA.indexOf('webtv')==-1) && (sClientPCUA.indexOf('hotjava')==-1));
	var bIsWindows = ((sClientPCUA.indexOf("win")!=-1) || (sClientPCUA.indexOf("16bit") != -1));
	var bIsApple = (sClientPCUA.indexOf("mac")!=-1);
	var bCaretPosInitialized = false;
	var tbxMessage = null;

	function InitMessageBox()
	{
		if(!tbxMessage)
		{
			tbxMessage = document.getElementById("meMessageEditor_tbxMessage");
		}
		if(tbxMessage)
		{
			tbxMessage.focus();
			if (typeof tbxMessage.createTextRange != 'undefined')
			{
				// IE
				tbxMessage.onkeyup = StoreCaretPosition;
				tbxMessage.onclick = StoreCaretPosition;
				tbxMessage.onselect = StoreCaretPosition;
				tbxMessage.onselect();
			}
			else
			{
				// Other browsers. Do nothing for now.
			}
		}
	}
	

	// Inserts the given string sTagToInsert at the caret position in tbxMessage.
	// Adds spaces when appropriate.
	function InsertTagAtCarretPos(sTagToInsert) 
	{
		sTextToInsert = ' ' + sTagToInsert + ' ';
		return InsertTagAroundSelection(sTagToInsert, '');
	}


	// Inserts the given begintag sStartTagToInsert in front of the selected text and sEndTagToInsert behind the
	// selected text. If no text is selected, or the user uses a browser which doesn't support decent javascripting
	// the tags are inserted at the end of the text in tbxMessage.
	function InsertTagAroundSelection(sStartTagToInsert, sEndTagToInsert)
	{
		var sSelectedText;
		if (tbxMessage)
		{
			if (typeof tbxMessage.cursorPos != 'undefined')
			{
				var cursorPos = tbxMessage.cursorPos;
				sSelectedText = cursorPos.text;
				cursorPos.text = sStartTagToInsert + sSelectedText + sEndTagToInsert;
			}
			else 
			{
				if (typeof tbxMessage.selectionStart != 'undefined')
				{
					// remember scrollposition
					var scrollTop = tbxMessage.scrollTop;

					var sStart = tbxMessage.selectionStart;
					var sEnd = tbxMessage.selectionEnd;
					sSelectedText = tbxMessage.value.substring(sStart, sEnd);
					var newText = sStartTagToInsert + sSelectedText + sEndTagToInsert;
					tbxMessage.value = tbxMessage.value.substr(0, sStart) + newText + tbxMessage.value.substr(sEnd);
					var nStart = sStart == sEnd ? sStart + newText.length : sStart;
					var nEnd = sStart + newText.length;
					tbxMessage.setSelectionRange(nStart, nEnd);

					// reset scrollposition
					tbxMessage.scrollTop = scrollTop;
				}
				else
				{
					tbxMessage.value += sStartTagToInsert + sEndTagToInsert;
				}
			}

			tbxMessage.focus();
			if (typeof tbxMessage.cursorPos != 'undefined') 
			{
				tbxMessage.onselect();
			}
		}
		return false;
	}
	
	
	// Stores the current caret position in a variable of tbxMessage. 
	function StoreCaretPosition() 
	{
		if (tbxMessage.createTextRange)
		{
			this.cursorPos = document.selection.createRange().duplicate();
		}
	}
	
	// Sets initial focus to the textbox. Is called from the body tag of host pages which host this control.
	function SetFocus()
	{
		InitMessageBox();
		
		<%
			if(base.IsThreadStart)
			{
				%>
					document.forms[0].elements["meMessageEditor$tbxSubject"].focus();
				<%	
			}
			else
			{
				%>
					document.forms[0].elements["meMessageEditor$tbxMessage"].focus();
				<%
			}
		%>
	}
</script>
<table width="750" align="center" border="0" cellpadding="0" cellspacing="0">
<tr>
	<td class="FormHeaderTwoLine">
		<span class="FormName"><asp:label ID="lblForumName" Runat="server" /></span>
		<asp:placeholder ID="phHeaderNormal" Runat="server" Visible="False">
			<br />
			<span class="FormSubName"><asp:label ID="lblThreadSubject" Runat="server" /></span>
		</asp:placeholder>
		<asp:placeholder ID="phHeaderNewThread" Runat="server" Visible="False">
			<br>
			<span class="FormDescription"><asp:label ID="lblForumDescription" Runat="server" /></span>
		</asp:placeholder>
	</td>
</tr>
<asp:placeholder ID="phPreviewRow" Runat="server" Visible="False">
<tr>
    <td class="FormContent">
		<table cellspacing="0" cellpadding="1" width="748" align=center border=0>
		<tr>
			<td class="TableRow LightBackground" valign="top" align=right width=100>Preview&nbsp;</td>
			<td class="TableRow LightBackground" valign="top" width="638" height="100%">
				<table height="100%" cellspacing="0" cellpadding="1" width="100%" border="0">
				<tr>
					<td class="MessageHeader">
						<span class="SmallFontSmaller">Posted on: <asp:label id="lblPreviewPostedOn" Runat="server"></asp:label></span>
					</td>
				</tr>
				<tr>
					<td class="TableRow LightBackground" valign="top" height="100%">
						<asp:label id="lblPreviewBody" Runat="server"></asp:label><br><br>
					</td>
				</tr>
				</table>
			</td>
		</tr>
		<tr>
			<td class="EmptyRowBottom" heigth="2"></td>
		</tr>
		</table>
	</td>
</tr>
</asp:placeholder>
<tr>
	<td class="FormContent">
		<table width="748" align="center" border="0" cellpadding="1" cellspacing="0" class="FormWindow">
		<asp:placeholder ID="phSubjectRow" Runat="server" Visible="False">
		<tr><td  colspan="2" height="3"></td></tr>
		<tr>
			<td width="100" align="right" >Subject&nbsp;</td>
			<td >
				<input type="text" id="tbxSubject" maxlength="250" size="50" class="Inputborder" runat="server" NAME="tbxSubject">
				<asp:placeholder ID="phCanBeSticky" Runat="server" Visible="False">
					&nbsp;&nbsp;<asp:CheckBox id="chkIsSticky" runat="server" Visible="true" Text="Sticky / Pinned" TextAlign="right"/>
				</asp:placeholder>
			</td>
		</tr>
		</asp:placeholder>
		<tr><td  colspan="2" height="6"></td></tr>
		<tr>
			<td  width="100" align="right" valign="top"><asp:label runat="server" id="lblTextType"/>&nbsp;</td>
			<td  rowspan="2">
				<asp:textbox Rows="23" ID="tbxMessage" Runat="server" TextMode="MultiLine" style="width:600px;" onfocus="StoreCaretPosition();"/>
			</td>
		</tr>
		<tr>
			<td  width="100" align="right" valign="bottom">
				<br clear="all"><br><br>
				<table width="95%" border="0" cellpadding="2" cellspacing="0">
				<tr>
					<td colspan="2" class="GeneralSmallBorderTable" align="center">Smileys</td>
				</tr>
				<tr>
					<td valign="middle"><img onclick="InsertTagAtCarretPos(':(');" src="pics/smileyangry.gif" border="0" alt="Angry" align="absmiddle"> :(</td>
					<td valign="middle"><img onclick="InsertTagAtCarretPos(':?');" src="pics/smileyconfused.gif" border="0" alt="Confused" align="absmiddle"> :?</td>
				</tr>
				<tr>
					<td valign="middle"><img onclick="InsertTagAtCarretPos('8)');" src="pics/smileycool.gif" border="0" alt="Cool" align="absmiddle"> 8)</td>
					<td valign="middle"><img onclick="InsertTagAtCarretPos(':/');" src="pics/smileydissapointed.gif" border="0" alt="Dissapointed" align="absmiddle"> :/</td>
				</tr>
				<tr>
					<td valign="middle"><img onclick="InsertTagAtCarretPos(':!');" src="pics/smileyembarrassed.gif" border="0" alt="Embarrassed" align="absmiddle"> :!</td>
					<td valign="middle"><img onclick="InsertTagAtCarretPos(':D');" src="pics/smileylaugh.gif" border="0" alt="Laugh" align="absmiddle"> :D</td>
				</tr>
				<tr>
					<td valign="middle"><img onclick="InsertTagAtCarretPos(':)');" src="pics/smileyregular.gif" border="0" alt="Regular" align="absmiddle"> :)</td>
					<td valign="middle"><img onclick="InsertTagAtCarretPos(';(');" src="pics/smileysad.gif" border="0" alt="Sad" align="absmiddle"> ;(</td>
				</tr>
				<tr>
					<td valign="middle"><img onclick="InsertTagAtCarretPos(':o');" src="pics/smileyshocked.gif" border="0" alt="Shocked" align="absmiddle"> :o</td>
					<td valign="middle"><img onclick="InsertTagAtCarretPos(':P');" src="pics/smileytongue.gif" border="0" alt="Tongue" align="absmiddle"> :P</td>
				</tr>
				<tr>
					<td valign="middle"><img onclick="InsertTagAtCarretPos(';)');" src="pics/smileywink.gif" border="0" alt="Wink" align="absmiddle"> ;)</td>
					<td valign="middle">&nbsp;</td>
				</tr>
				</table>
			</td>
		</tr>
		<tr><td  colspan="3" height="3"></td></tr>
		<tr>
			<td  width="100">&nbsp;</td>
			<td>
				<input type="button" class="FormButtonsFlat_Light" value="B" onclick="InsertTagAroundSelection('[b]','[/b]');" name="btnBold" style="font-weight:bold; width: 25px">&nbsp;
				<input type="button" class="FormButtonsFlat_Light" value="I" onclick="InsertTagAroundSelection('[i]','[/i]');" name="btnItalic" style="font-style:italic; width: 25px">&nbsp;
				<input type="button" class="FormButtonsFlat_Light" value="S" onclick="InsertTagAroundSelection('[s]','[/s]');" name="btnStriked" style="text-decoration:line-through; width: 25px">&nbsp;
				<input type="button" class="FormButtonsFlat_Light" value="U" onclick="InsertTagAroundSelection('[u]','[/u]');" name="btnUnderlined" style="text-decoration:underline; width: 25px">&nbsp;
				<input type="button" class="FormButtonsFlat_Light" value="Code" onclick="InsertTagAroundSelection('[code]','[/code]');" name="btnCode" >&nbsp;
				<input type="button" class="FormButtonsFlat_Light" value="Quote" onclick="InsertTagAroundSelection('[quote]','[/quote]');" name="btnQuote" >&nbsp;
				<input type="button" class="FormButtonsFlat_Light" value="List" onclick="InsertTagAroundSelection('[list][*]','[/*][/list]');" name="btnList" >&nbsp;
				Color <select name="cbxFontColor" onChange="InsertTagAroundSelection('[color value=' + String.fromCharCode(34) + document.forms[0].cbxFontColor.options[document.forms[0].cbxFontColor.selectedIndex].value + String.fromCharCode(34) + ']', '[/color]');this.selectedIndex=0;">
					<option  style="color:#000000; background-color: #EDEDED" value="000000" selected="selected">Black</option>
					<option  style="color:#662200; background-color: #EDEDED" value="662200">Brown</option>
					<option  style="color:#800000; background-color: #EDEDED" value="800000">Dark Red</option>
					<option  style="color:#ff0000; background-color: #EDEDED" value="FF0000">Red</option>
					<option  style="color:#ff6600; background-color: #EDEDED" value="FF6600">Orange</option>
					<option  style="color:#ffff00; background-color: #EDEDED" value="FFFF00">Yellow</option>
					<option  style="color:#00CC00; background-color: #EDEDED" value="00CC00">Green</option>
					<option  style="color:#008822; background-color: #EDEDED" value="008822">Olive</option>
					<option  style="color:#9900bb; background-color: #EDEDED" value="9900bb">Violet</option>
					<option  style="color:#ee33ff; background-color: #EDEDED" value="EE22FF">Pink</option>
					<option  style="color:#00ccff; background-color: #EDEDED" value="00ccFF">Cyan</option>
					<option  style="color:#0011ff; background-color: #EDEDED" value="0011FF">Blue</option>
					<option  style="color:#0000aa; background-color: #EDEDED" value="0000AA">Dark Blue</option>
					<option  style="color:#4000aa; background-color: #EDEDED" value="4000aa">Indigo</option>
					<option  style="color:#ffffff; background-color: #EDEDED" value="FFFFFF">White</option>
				</select> &nbsp;
				Size <select name="cbxFontSize" onChange="InsertTagAroundSelection('[size value=' + String.fromCharCode(39) + document.forms[0].cbxFontSize.options[document.forms[0].cbxFontSize.selectedIndex].value + String.fromCharCode(39) + ']', '[/size]');this.selectedIndex=0;">
					<option value="1">Tiny</option>
					<option value="2">Small</option>
					<option value="3" selected>Normal</option>
					<option value="4">Large</option>
					<option value="5">Huge</option>
					<option value="6">Real Huge(tm)</option>
				</select>
			</td>
		</tr>
		<tr><td  colspan="2" height="6"></td></tr>
		<tr>
			<td >&nbsp;</td>
			<td >
				<asp:CheckBox runat="server" ID="chkAddAttachment" TextAlign="right" Text="Add attachment" visible="false"/><br />
			    <asp:CheckBox id="chkSubscribeToThread" runat="server" Visible="true" Text="Notify me of thread replies" TextAlign="right"/>
				<hr align="left" size="1" width="80%">
				<asp:button CssClass="FormButtons" ID="btnPreview" Runat="server" Text="  Preview  " CommandName="btnPreview" />&nbsp;
				<asp:button CssClass="FormButtons" ID="btnPost" Runat="server" Text="     Post     " CommandName="btnPost" />&nbsp;&nbsp;&nbsp;
				<asp:button CssClass="FormButtons" CausesValidation="False" ID="btnCancel" Runat="server" Text="   Cancel  " CommandName="btnCancel" />
				<br>
			</td>
		</tr>
		<tr><td  colspan="2" height="6"></td></tr>
		<tr>
			<td >&nbsp;</td>
			<td >
				<asp:requiredfieldvalidator ControlToValidate="tbxSubject" Enabled="False" Runat="server" ErrorMessage="Subject is empty" ID="rfvSubject" name="rfvSubject"/><br>
				<asp:requiredfieldvalidator ControlToValidate="tbxMessage" Runat="server" ErrorMessage="Message is empty" ID="rfvMessage" NAME="rfvMessage"/>
			</td>
		</tr>
		<tr><td  colspan="2" height="6"></td></tr>
		</table>
	</td>
</tr>
<tr>
	<td class="EmptyRowBottom" height="5"><img src="pics/separator.gif" border="0"></td>
</tr>
</table>
