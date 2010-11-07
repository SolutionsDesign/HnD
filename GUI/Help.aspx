<%@ Register TagPrefix="HnD" TagName="PageFooter" Src="Footer.ascx"%>
<%@ Register TagPrefix="HnD" TagName="PageHeader" Src="HeaderRestrictedMenu.ascx"%>
<%@ Page language="c#" CodeFile="Help.aspx.cs" AutoEventWireup="false" Inherits="SD.HnD.GUI.Help" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
  <head runat="server">
	<title>HnD::Manual</title>
	<meta name="vs_defaultClientScript" content="JavaScript">
	<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">  </head>
<body>
<table width="750" align="center" border="0" cellpadding="0" cellspacing="0">
<hnd:pageheader runat="server" id="PageHeader" />
</table>
<br clear="all">
<table width="750" align="center" class="ExplanationBox" cellpadding="2" cellspacing="0">
<tr>
	<td>
		<center>
		<h3>Manual</h3>
		</center>
		<b>Contents</b><br>
		The following sections are available:<br>
		<ul>
			<li><a href="#UBBTags">UBB Tags</a></li>
		</ul>
		<hr align="center" width="80%" size="1">
		<a name="UBBTags"></a>
		<b>UBB Tags</b><br>
		When adding or editing messages, you can insert special <i>tags</i> to make your texts more alive. Also in your
		signature you can use several of the UBB tags mentioned below, to create special formatting of the text or to include
		a link for example. Tags marked with a '*' in the column 'Sig' are also available for usage in your signature.
		<br clear="all"><br>
		<table width="99%" border="0" cellpadding="2" cellspacing="0" align="center">
		<tr>
			<td class="TableColumnHeader">Tag</td>
			<td class="TableColumnHeader">Sig</td>
		</tr>
		<tr>
			<td class="QuoteText" valign="top">
				<b>Tag: </b> [br]<br>
				Inserts a hard CRLF into the text. Equivalent of HTML's &lt;br&gt;<br><br>
			</td>
			<td class="QuoteText" valign="top" align="center">*</td>
		</tr>
		<tr>
			<td class="QuoteText" valign="top">
				<b>Tag: </b> [b]text[/b]<br>
				Makes <i>text</i> become bold<br><br>
				<b>Example:</b><br>
				[b]this is a test[/b] will result in: <b>this is a test</b>
			</td>
			<td class="QuoteText" valign="top" align="center">*</td>
		</tr>
		<tr>
			<td class="QuoteText" valign="top">
				<b>Tag: </b> [i]text[/i]<br>
				Makes <i>text</i> become italic<br><br>
				<b>Example:</b><br>
				[i]this is a test[/i] will result in: <i>this is a test</i>
			</td>
			<td class="QuoteText" valign="top" align="center">*</td>
		</tr>
		<tr>
			<td class="QuoteText" valign="top">
				<b>Tag: </b> [s]text[/s]<br>
				Makes <i>text</i> become striked through<br><br>
				<b>Example:</b><br>
				[s]this is a test[/s] will result in: <s>this is a test</s>
			</td>
			<td class="QuoteText" valign="top" align="center">*</td>
		</tr>
		<tr>
			<td class="QuoteText" valign="top">
				<b>Tag: </b> [u]text[/u]<br>
				Makes <i>text</i> become underlined<br><br>
				<b>Example:</b><br>
				[u]this is a test[/u] will result in: <u>this is a test</u>
			</td>
			<td class="QuoteText" align="center">*</td>
		</tr>
		<tr>
			<td class="QuoteText" valign="top">
				<b>Tag: </b> [img]ImageURI[/img]<br>
				Will show the image located by ImageURI in the message. ImageURI has to end on '.gif', '.jpg' or '.png'.
				ImageURI's are matched using the following Regular Expression:<br>
				(http://www.|http://)([\w-]+\.)+[\w-]+(/[\w-./?%&amp+,#;~=]*)?/[\w-]+\.(jpg|gif|png)
				<br><br>
				<b>Example:</b><br>
				[img]http://www.llblgen.com/pics/llblgen.gif[/img]. will result in:<br>
				<img src="http://www.llblgen.com/pics/llblgen.gif" border="0">
			</td>
			<td class="QuoteText" valign="top" align="center">&nbsp;</td>
		</tr>
		<tr>
			<td class="QuoteText" valign="top">
				<b>Tag: </b> [img alt="Alt text"]ImageURI[/img]<br>
				As '[img]ImageURI[/img]', but now also the alt attribute of the image is specified.<br><br>
				<b>Example:</b><br>
				[img alt="LLBLGen Pro logo"]http://www.llblgen.com/pics/llblgen.gif[/img] will result in:<br>
				<img src="http://www.llblgen.com/pics/llblgen.gif" border="0" alt="LLBLGen Pro Logo">
			</td>
			<td class="QuoteText" valign="top" align="center">&nbsp;</td>
		</tr>
		<tr>
			<td class="QuoteText" valign="top">
				<b>Tag: </b> [url]URI[/url]<br>
				Will result in a clickable link of URI, with the description the same as the URI itself. The
				link will open in a new window. URI's are matched using the following Regular Expression: <br>
				(http://www.|http://|www.)([\w-]+\.)+[\w-]+(/[\w-./?%&amp;~=]*)?
				<br><br>
				<b>Example:</b><br>
				[url]http://www.llblgen.com/HnD[/url] will result in:<br>
				<a href="http://www.llblgen.com/HnD" target="_blank">http://www.llblgen.com/Hnd</a>
			</td>
			<td class="QuoteText" valign="top" align="center">*</td>
		</tr>
		<tr>
			<td class="QuoteText" valign="top">
				<b>Tag: </b> [url description="Link description"]URI[/url]<br>
				Will result in a clickable link of URI, with the description set to the text specified as the description. The
				link will open in a new window.<br><br>
				<b>Example:</b><br>
				[url description="HnD homepage"]http://www.llblgen.com/HnD[/url] will result in:<br>
				<a href="http://www.llblgen.com/HnD" target="_blank">HnD homepage</a>
			</td>
			<td class="QuoteText" valign="top" align="center">*</td>
		</tr>
		<tr>
			<td class="QuoteText" valign="top">
				<b>Tag: </b> [quote]text[/quote]<br>
				<i>text</i> will show up as a quoted block of text in the message.
				<br><br>
				<b>Example:</b><br>
				[quote]This is a test[/quote] will result in:<br>
				<table width="95%" align="center" border="0" cellspacing="1" cellpadding="2">
					<tr>
						<td align="left"><b>Quote:</b></td>
					</tr>
					<tr>
						<td class="QuoteText">This is a test</td>
					</tr>
				</table>
			</td>
			<td class="QuoteText" valign="top" align="center">&nbsp;</td>
		</tr>
		<tr>
			<td class="QuoteText" valign="top">
				<b>Tag: </b> [quote nick="NickName"]text[/quote]<br>
				<i>text</i> will show up as a quoted block of text in the message, and will add a line with the nickname provided so readers
				can see that person actually wrote the quoted text.
				<br><br>
				<b>Example:</b><br>
				[quote nick="Admin"]This is a test[/quote] will result in:<br>
				<table width="95%" align="center" border="0" cellspacing="1" cellpadding="2">
					<tr>
						<td align="left"><b>Admin wrote:</b></td>
					</tr>
					<tr>
						<td class="QuoteText">This is a test</td>
					</tr>
				</table>
			</td>
			<td class="QuoteText" valign="top" align="center">&nbsp;</td>
		</tr>
		<tr>
			<td class="QuoteText" valign="top">
				<b>Tag: </b> [code]text[/code]<br>
				<i>text</i> will show up as if it was a piece of code posted. It will keep its formatting, thus tabs and hard CRLF's are kept. The
				font used is a proportional font, and wrapping will occur when a line is too big. 
				<br><br>
				<b>Example:</b><br>
				[code]<br>
				void main()<br>
				{<br>
				&nbsp; &nbsp; printf("this is a test");<br>
				}<br>
				[/code]<br><br>
				 will result in:<br>
				<table width="95%" align="center" border="0" cellspacing="1" cellpadding="2">
					<tr>
						<td align="left"><b>Code:</b></td>
					</tr>
					<tr>
						<td class="CodeText">
							void main()<br>
							{<br>
							&nbsp; &nbsp; printf("this is a test");<br>
							}<br>
						</td>
					</tr>
				</table>
			</td>
			<td class="QuoteText" valign="top" align="center">&nbsp;</td>
		</tr>
		<tr>
			<td class="QuoteText" valign="top">
				<b>Tag: </b> [offtopic]text[/offtopic]<br>
				Makes <i>text</i> become displayed smaller and in a different color so it is separated from the main text.<br><br>
				<b>Example:</b><br>
				[offtopic]this is a test[/offtopic] will result in: 
				<br><br>
				<span class="OfftopicText">Offtopic:<br>this is a test</span>
			</td>
			<td class="QuoteText" align="center">&nbsp;</td>
		</tr>
		<tr>
			<td class="QuoteText" valign="top">
				<b>Tag: </b> [list][*]item1[/*]...[/list]<br>
				Will format the list of items which are formatted between [*] and [/*] into a list with dots (An 'UL') list.
				You can use formatting inside an item. 
				<br><br>
				<b>Example:</b><br>
				[list]<br>
				[*]This is item 1[/*]<br>
				[*]This is item 2[/*]<br>
				[/list]<br><br>
				 will result in: 
				<ul>
					<li>This is item 1</li>
					<li>This is item 2</li>
				</ul>
			</td>
			<td class="QuoteText" align="center">&nbsp;</td>
		</tr>
		<tr>
			<td class="QuoteText" valign="top">
				<b>Tag: </b> [list type="UL|OL"][*]item1[/*]...[/list]<br>
				Will format the list of items which are formatted between [*] and [/*] into a list with dots when type = "UL", or
				in a list of numbers when the type = "OL". You can use formatting inside an item. 
				<br><br>
				<b>Example:</b><br>
				[list type="OL"]<br>
				[*]This is item 1[/*]<br>
				[*]This is item 2[/*]<br>
				[/list]<br><br>
				 will result in: 
				<ol>
					<li>This is item 1</li>
					<li>This is item 2</li>
				</ol>
			</td>
			<td class="QuoteText" align="center">&nbsp;</td>
		</tr>
		<tr>
			<td class="QuoteText" valign="top">
				<b>Tag: </b> [size value='1|2|3|4|5|6]text[/size]<br>
				Makes <i>text</i> become displayed in the size specified, 1 being very small, 6 being very large.
				<br><br>
				<b>Example:</b><br>
				[size value='5']this is a test[/size] will result in: 
				<br><br>
				<font size="5">this is a test</font>
			</td>
			<td class="QuoteText" align="center">&nbsp;</td>
		</tr>
		<tr>
			<td class="QuoteText" valign="top">
				<b>Tag: </b> [color value="Hexvalue"]text[/color]<br>
				Makes <i>text</i> become displayed in the color specified. The color has to be in hexadecimal: RRGGBB, without the '#'. 
				<br><br>
				<b>Example:</b><br>
				[color value="FF0000"]this is a test[/color] will result in: 
				<br><br>
				<font color="#FF0000">this is a test</font>
			</td>
			<td class="QuoteText" align="center">*</td>
		</tr>
		<tr>
			<td class="QuoteText" valign="top">
				<b>Tag: </b> any valid email-address<br>
				The email-address is transformed into a clickable link which open a mail construction window using the default mail program.
				Email-addresses are found using the following regular expression:<br>
				\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*
				<br><br>
				<b>Example:</b><br>
				My email address is: foobar@example.com<br><br>
				will result in:
				<br><br>
				My email address is: <a href="mailto:foobar@example.com">foobar@example.com</a>
			</td>
			<td class="QuoteText" align="center">*</td>
		</tr>
		<tr>
			<td class="QuoteText" valign="top">
				<b>Tag: </b> any valid URL<br>
				The URL is transformed into a clickable link which opens a new browser window with the URL specified. Please do include 'http://' or
				'https://' because otherwise the link will end up as being a relative link to the forum and people will not be able to use it. 
				URL's are found using the following regular expression:<br>
				(http://www.|http://|https://www.|https://)([\w-]+\.)+[\w-]+(/[\w-./?%&amp;+,~=#]*)?
				<br><br>
				<b>Example:</b><br>
				My homepage is: http://www.example.com/foldername<br><br>
				will result in:
				<br><br>
				My homepage is: <a href="http://www.example.com/foldername">http://www.example.com/foldername</a>
			</td>
			<td class="QuoteText" align="center">*</td>
		</tr>
		<tr>
			<td class="QuoteText" valign="top">
				<b>Tag: </b> several smileys<br>
				HnD supports a nice collection of smileys to use in your texts to illustrate the meaning of the texts. These smileys are custom
				designed for HnD so they fit in the layout. Use smileys with care, since misinterpretation of your texts based on the smileys can
				occur plus some users might find all those happy faces annoying. You can't use smileys inside code-blocks.<br><br>
				The following collection is currently supported:
				<br><br>
				<pre>
:D <img src="pics/smileylaugh.gif" border="0" alt="Laugh">	:( <img src="pics/smileyangry.gif" border="0" alt="Angry">	:) <img src="pics/smileyregular.gif" border="0" alt="Regular">
;) <img src="pics/smileywink.gif" border="0" alt="Wink">	8) <img src="pics/smileycool.gif" border="0" alt="Cool">	:P <img src="pics/smileytongue.gif" border="0" alt="Tongue">
:? <img src="pics/smileyconfused.gif" border="0" alt="Confused">	:o <img src="pics/smileyshocked.gif" border="0" alt="Shocked">	:/ <img src="pics/smileydissapointed.gif" border="0" alt="Dissapointed">
;( <img src="pics/smileysad.gif" border="0" alt="Sad">	:! <img src="pics/smileyembarassed.gif" border="0" alt="Embarassed">
				</pre>
			</td>
			<td class="QuoteText" align="center">&nbsp;</td>
		</tr>
		</table>
		<br clear="all">
		All HTML code is transfered into XML readable code first and then back to readable text, which will result in having your HTML
		code being readable as plain text and it won't get embedded into the resulting page. The same goes for script. All TAB characters are
		transformed into 4 spaces, thus 4 &amp;nbsp; characters.
		<br><br>	
		<center>
			<a href="javascript://" onclick="window.close();">Close window</a>
		</center>
		<br>
	</td>
</tr>
</table>
<br clear="all">
<!-- footer -->
<hnd:pagefooter runat="server" id="PageFooter" />
</body>
</html>
