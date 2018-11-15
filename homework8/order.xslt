<?xml version="1.0" encoding="utf-8" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
	<xsl:template match="ArrayOfOrder">
		<html>
			<head>
				<title>Orders</title>
			</head>
			<body>
				<ul>
					<xsl:for-each select="Order">
						<li>
							<xsl:value-of select="ONum" />
						</li>
						<li>
							<xsl:value-of select="OName" />
						</li>
						<li>
							<xsl:value-of select="Tel" />
						</li>
						<li>
							<xsl:value-of select="sumPri" />
						</li>
						<li>
							<xsl:value-of select="oDlist" />
						</li>
					</xsl:for-each>
					
				</ul>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
