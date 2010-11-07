<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:output method="html" version="1.0" omit-xml-declaration="yes" />
	<xsl:template match="/">
		<span><xsl:apply-templates select="./*" /></span>
	</xsl:template>

	<xsl:template match="generaltext">
		<xsl:apply-templates select="./*" />
	</xsl:template>

	<xsl:template match="formattedtext">
		<xsl:apply-templates select="./*" />
	</xsl:template>

	<xsl:template match="literaltext">
		<xsl:apply-templates select="./*" />
	</xsl:template>

	<xsl:template match="literaltextelement">
		<xsl:value-of select="." />
	</xsl:template>

	<xsl:template match="bold">
		<b>
			<xsl:apply-templates select="./*" />
		</b>
	</xsl:template>

	<xsl:template match="italic">
		<i>
			<xsl:apply-templates select="./*" />
		</i>
	</xsl:template>
	
	<xsl:template match="code">
		<table width="95%" align="center" border="0" cellspacing="1" cellpadding="2">
			<tr>
				<td align="left"><b>Code:</b></td>
			</tr>
			<tr>
				<td class="CodeText"><code><xsl:apply-templates select="./*" /></code></td>
			</tr>
		</table>
	</xsl:template>
	
	<xsl:template match="quote[@nick]">
		<table width="95%" align="center" border="0" cellspacing="1" cellpadding="2">
			<tr>
				<td align="left"><b><xsl:value-of select="@nick" /> wrote:</b></td>
			</tr>
			<tr>
				<td class="QuoteText">
					<xsl:apply-templates select="./*" />
				</td>
			</tr>
		</table>
	</xsl:template>
	
	<xsl:template match="quote">
		<table width="95%" align="center" border="0" cellspacing="1" cellpadding="2">
			<tr>
				<td align="left"><b>Quote:</b></td>
			</tr>
			<tr>
				<td class="QuoteText">
					<xsl:apply-templates select="./*" />
				</td>
			</tr>
		</table>
	</xsl:template>
	
	<xsl:template match="url[@description]">
		<a href="{.}" target="_blank"><xsl:value-of select="@description" /></a>
	</xsl:template>

	<xsl:template match="url">
		<a href="{.}" target="_blank"><xsl:value-of select="." /></a>
	</xsl:template>

	<xsl:template match="image[@alt]">
		<img src="{.}" border="0" alt="{@alt}" /><br />
	</xsl:template>

	<xsl:template match="image">
		<img src="{.}" border="0" /><br />
	</xsl:template>
	
	<xsl:template match="color">
		<font color="#{@value}"><xsl:apply-templates select="./*" /></font>
	</xsl:template>
	
	<xsl:template match="list[@type='UL']">
		<ul>
			<xsl:apply-templates select="listitems/*" />
		</ul>
	</xsl:template>

	<xsl:template match="list[@type='OL']">
		<ol>
			<xsl:apply-templates select="listitems/*" />
		</ol>
	</xsl:template>

	<xsl:template match="list">
		<ul>
			<xsl:apply-templates select="listitems/*" />
		</ul>
	</xsl:template>

	<xsl:template match="listitem">
		<li>
			<xsl:apply-templates select="./*" />
		</li>
	</xsl:template>

	<xsl:template match="size">
		<span class="MessageFontSize_{@value}"><xsl:apply-templates select="./*" /></span>
	</xsl:template>

	<xsl:template match="offtopic">
		<span class="OfftopicText"><p>Offtopic:<br /><xsl:apply-templates select="./*" /></p></span>
	</xsl:template>

	<xsl:template match="underlined">
		<u><xsl:apply-templates select="./*" /></u>
	</xsl:template>

	<xsl:template match="striked">
		<s><xsl:apply-templates select="./*" /></s>
	</xsl:template>

	<xsl:template match="emailaddress">
		<a href="mailto:{.}"><xsl:value-of select="." /></a>
	</xsl:template>
	
	<xsl:template match="smileyregular">
		<img src="pics/smileyregular.gif" border="0" alt="Regular Smiley"/>
	</xsl:template>

	<xsl:template match="smileyangry">
		<img src="pics/smileyangry.gif" border="0" alt="Angry"/>
	</xsl:template>

	<xsl:template match="smileylaugh">
		<img src="pics/smileylaugh.gif" border="0" alt="Laugh"/>
	</xsl:template>

	<xsl:template match="smileywink">
		<img src="pics/smileywink.gif" border="0" alt="Wink"/>
	</xsl:template>

	<xsl:template match="smileycool">
		<img src="pics/smileycool.gif" border="0" alt="Cool"/>
	</xsl:template>

	<xsl:template match="smileytongue">
		<img src="pics/smileytongue.gif" border="0" alt="Tongue"/>
	</xsl:template>

	<xsl:template match="smileyconfused">
		<img src="pics/smileyconfused.gif" border="0" alt="Confused"/>
	</xsl:template>

	<xsl:template match="smileyshocked">
		<img src="pics/smileyshocked.gif" border="0" alt="Shocked"/>
	</xsl:template>

	<xsl:template match="smileydissapointed">
		<img src="pics/smileydissapointed.gif" border="0" alt="Dissapointed"/>
	</xsl:template>

	<xsl:template match="smileysad">
		<img src="pics/smileysad.gif" border="0" alt="Sad"/>
	</xsl:template>

	<xsl:template match="smileyembarrassed">
		<img src="pics/smileyembarrassed.gif" border="0" alt="Embarrassed"/>
	</xsl:template>
	
	<xsl:template match="br">
		<br />
	</xsl:template>

	<xsl:template match="tab">
		<xsl:text>&#09;</xsl:text>
	</xsl:template>
	
	<!-- consume the rest of the tags and thus strip them from the result -->
	<xsl:template match="*">
	</xsl:template>
</xsl:stylesheet>