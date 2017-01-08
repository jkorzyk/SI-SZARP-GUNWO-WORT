
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:output method="html" encoding="utf-8"/>

  <xsl:template match="/punkty">
 <html>
      <head>
        <title>Trasa</title>
      </head>
      <body>
        <h1><center>Trasy</center></h1>
        <center>
<table border="1">
<tr>
<th><font size="4">Nazwa Trasy</font></th>
<th><font size="4">ID Trasy</font></th>


</tr>
        <xsl:for-each select="punkt">
        <xsl:sort select="idpunktu" data-type="number" lang="pl"/>
          <tr>
          <td><xsl:value-of select="nazwa"/></td>
          <td><xsl:value-of select="idpunktu"/></td>

          </tr>
        </xsl:for-each>
        </table>
        </center>
      </body>
    </html>  
    </xsl:template>
    </xsl:stylesheet>
    
  
  
  
  
  
  
  
  
  
  
  
  

