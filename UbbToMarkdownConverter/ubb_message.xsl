<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:output method="html" version="1.0" omit-xml-declaration="yes" />
	<xsl:template match="/"><xsl:apply-templates select="./*" /></xsl:template>
	<xsl:template match="generaltext"><xsl:apply-templates select="./*" /></xsl:template>
	<xsl:template match="formattedtext"><xsl:apply-templates select="./*" /></xsl:template>
	<xsl:template match="literaltext"><xsl:apply-templates select="./*" /></xsl:template>
	<xsl:template match="literaltextelement"><xsl:value-of select="." /></xsl:template>
	<xsl:template match="bold">**<xsl:apply-templates select="./*" />**</xsl:template>
	<xsl:template match="italic">_<xsl:apply-templates select="./*" />_</xsl:template>
	<xsl:template match="code">
```cs
<xsl:apply-templates select="./*" />
```
</xsl:template>
	<xsl:template match="quote[@nick]">
@quote <xsl:value-of select="@nick" /><xsl:text>&#10;</xsl:text>
<xsl:apply-templates select="./*" />
@end
</xsl:template>
	<xsl:template match="quote">
@quote<xsl:text>&#10;</xsl:text>
<xsl:apply-templates select="./*" />
@end
</xsl:template>
	<xsl:template match="url[@description]">[<xsl:value-of select="@description" />](<xsl:value-of select="." />)</xsl:template>
	<xsl:template match="url">[<xsl:value-of select="." />](<xsl:value-of select="." />)</xsl:template>
	<xsl:template match="image[@alt]">![<xsl:value-of select="@alt" />](<xsl:value-of select="." />)</xsl:template>
	<xsl:template match="image">![](<xsl:value-of select="." />)</xsl:template>
	<xsl:template match="color"><xsl:apply-templates select="./*" /></xsl:template>
	<xsl:template match="list[@type='UL']">
<xsl:apply-templates select="listitems/*" />
	</xsl:template>
	<xsl:template match="list[@type='OL']">
<xsl:apply-templates select="listitems/*" />
	</xsl:template>
	<xsl:template match="list">
<xsl:apply-templates select="listitems/*" />
	</xsl:template>
	<xsl:template match="listitem">
* <xsl:apply-templates select="./*" />
	</xsl:template>
	<xsl:template match="size"><xsl:apply-templates select="./*" /></xsl:template>
	<xsl:template match="offtopic">
@offtopic
<xsl:apply-templates select="./*" />
@end
</xsl:template>
	<xsl:template match="underlined"><xsl:apply-templates select="./*" /></xsl:template>
	<xsl:template match="striked">~~<xsl:apply-templates select="./*" />~~</xsl:template>
	<xsl:template match="emailaddress"><xsl:text disable-output-escaping="yes">&#60;</xsl:text><xsl:value-of select="." /><xsl:text disable-output-escaping="yes">&#62;</xsl:text></xsl:template>
	<xsl:template match="smileyregular">:) </xsl:template>
	<xsl:template match="smileyangry">:( </xsl:template>
	<xsl:template match="smileylaugh">:D </xsl:template>
	<xsl:template match="smileywink">;) </xsl:template>
	<xsl:template match="smileycool">8) </xsl:template>
	<xsl:template match="smileytongue">:P </xsl:template>
	<xsl:template match="smileyconfused">:? </xsl:template>
	<xsl:template match="smileyshocked">:o </xsl:template>
	<xsl:template match="smileydissapointed">:/ </xsl:template>
	<xsl:template match="smileysad">;( </xsl:template>
	<xsl:template match="smileyembarrassed">:! </xsl:template>
	<xsl:template match="br">
		<xsl:text>&#10;</xsl:text>
	</xsl:template>
	<xsl:template match="tab">
		<xsl:text>&#09;</xsl:text>
	</xsl:template>

	<!-- consume the rest of the tags and thus strip them from the result -->
	<xsl:template match="*">
	</xsl:template>
</xsl:stylesheet>