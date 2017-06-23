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
	
	<xsl:template match="url[@description]">
		<a href="{.}" target="_blank"><xsl:value-of select="@description" /></a>
	</xsl:template>

	<xsl:template match="url">
		<a href="{.}" target="_blank"><xsl:value-of select="." /></a>
	</xsl:template>

	<xsl:template match="color">
		<font color="#{@value}"><xsl:apply-templates select="./*" /></font>
	</xsl:template>
	
	<xsl:template match="list[@type='UL']">
		<ul>
			<xsl:apply-templates select="listitems/*" />
		</ul>
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

	<xsl:template match="smileyregular">:)</xsl:template>

	<xsl:template match="smileyangry">:(</xsl:template>

	<xsl:template match="smileylaugh">:D</xsl:template>

	<xsl:template match="smileywink">;)</xsl:template>

	<xsl:template match="smileycool">8)</xsl:template>

	<xsl:template match="smileytongue">:P</xsl:template>

	<xsl:template match="smileyconfused">:?</xsl:template>

	<xsl:template match="smileyshocked">:o</xsl:template>

	<xsl:template match="smileydissapointed">:/</xsl:template>

	<xsl:template match="smileysad">;(</xsl:template>

	<xsl:template match="smileyembarrassed">:!</xsl:template>
	
	<xsl:template match="br">
		<br />
	</xsl:template>
	
	<xsl:template match="tab">
		<xsl:text>&#09;</xsl:text>
	</xsl:template>
	
	<!-- consume the rest of the tags and thus strip them from the result -->
	<xsl:template match="*">
		<xsl:apply-templates select="./*" />
	</xsl:template>
</xsl:stylesheet>
  