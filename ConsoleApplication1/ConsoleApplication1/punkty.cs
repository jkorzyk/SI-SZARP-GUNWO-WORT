
using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
public partial class punkty
{

    private punktyPunkt[] punktField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("punkt")]
    public punktyPunkt[] punkt
    {
        get
        {
            return this.punktField;
        }
        set
        {
            this.punktField = value;
        }
    }
    public void WypiszPunkty()
    {

        foreach (var element in this.punkt)
        {
            Console.Write(element.idpunktu);
            Console.WriteLine(element.nazwa);
        }

    }
  
   

    public string TrasyPolaczone(int id1)
    {
        XmlDocument doc = new XmlDocument();

        doc.Load("ProjektC.xml");
        XmlNodeList l = doc.SelectNodes("/trasy/trasa[punkt_poczatkowy/id_punktu=" + id1 + "]/punkt_koncowy");
        StringBuilder sb = new StringBuilder();
        foreach (XmlNode n in l)
        {
            sb.Append(n.FirstChild.InnerText + " " + n.LastChild.InnerText);
            sb.AppendLine();
        }
        return sb.ToString();
        

    }

}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class punktyPunkt
{

    private byte idpunktuField;

    private string nazwaField;

    /// <remarks/>
    public byte idpunktu
    {
        get
        {
            return this.idpunktuField;
        }
        set
        {
            this.idpunktuField = value;
        }
    }

    /// <remarks/>
    public string nazwa
    {
        get
        {
            return this.nazwaField;
        }
        set
        {
            this.nazwaField = value;
        }
    }



}

