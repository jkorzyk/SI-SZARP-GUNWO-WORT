using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.XPath;
using System.Threading.Tasks;
using System.Xml;

namespace App
{
    class Trasa : XMLReadable 
    {
        private int idpocz;
        public int Idpocz
        {
            get
            {
                return idpocz;
            }
            set
            {
                idpocz = value;
            }
        }
        private int idkonc;
        public int Idkonc
        {
            get
            {
                return idkonc;
            }
            set
            {
                idkonc = value;
            }
        }

        private int lpkt;
        public int Lpkt { get; set; }
        private string nazwapocz;
        public string Nazwapocz { get; set; }
        private string nazwakonc;
        public string Nazwakonc { get; set; }
        public int IDTrasy { get; internal set; }

        public Trasa(int id1, int id2)
        {
            Idpocz = id1;
            Idkonc = id2;
            XmlDocument doc = new XmlDocument(); // odczyt danych z xmla
            try
            {
                doc.Load("ProjektC.xml");
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("Nie znaleziono pliku z danymi!");
                return;

            }
            catch(Exception)
            {
                Console.WriteLine("Wystąpił nieznany błąd!");
                return;
            }
            doc.Load("ProjektC.xml");
            XmlDocument doc2 = new XmlDocument();
            try
            {
                doc2.Load("projekt_c.xml");
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("Nie znaleziono pliku z danymi!");

                return;

            }
            catch (Exception)
            {
                Console.WriteLine("Wystąpił nieznany błąd!");
                return;
            }
            doc2.Load("projekt_c.xml");
            string wezeł;
            try
            {
               wezeł = doc.SelectSingleNode("//trasa[punkt_poczatkowy/id_punktu=" + Idpocz + " and punkt_koncowy/id_punktu=" + Idkonc + " ]/ilosc_punktow").InnerText;
            }
            catch (System.NullReferenceException)
            {
                Console.WriteLine("Nie ma takiej trasy!!");
                
                return;
                
            }
            wezeł = doc.SelectSingleNode("//trasa[punkt_poczatkowy/id_punktu=" + Idpocz + " and punkt_koncowy/id_punktu=" + Idkonc + " ]/ilosc_punktow").InnerText;
            Nazwapocz = doc2.SelectSingleNode("/punkty/punkt[idpunktu=" + Idpocz + "]/nazwa").InnerText;
            Nazwakonc = doc2.SelectSingleNode("/punkty/punkt[idpunktu=" + Idkonc + "]/nazwa").InnerText;
            Lpkt = Int32.Parse(wezeł);

        }
        public Trasa()
        {
            XmlDocument doc = new XmlDocument(); // odczyt danych z xmla
            doc.Load("ProjektC.xml");
            XmlDocument doc2 = new XmlDocument();
            doc2.Load("projekt_c.xml");
            string wezeł = doc.SelectSingleNode("//trasa[punkt_poczatkowy/id_punktu=" + idpocz + " and punkt_koncowy/id_punktu=" + idkonc + " ]/ilosc_punktow").InnerText;
            nazwapocz = doc2.SelectSingleNode("/punkty/punkt[idpunktu=" + idpocz + "]/nazwa").InnerText;
            nazwakonc = doc2.SelectSingleNode("/punkty/punkt[idpunktu=" + idkonc + "]/nazwa").InnerText;
            lpkt = Int32.Parse(wezeł);
            
        }

        public void ToXML()
        {

            using (XmlWriter writer = XmlWriter.Create("output.xml"))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("trasy");

                writer.WriteStartElement("trasa");

                writer.WriteElementString("punkt_poczatkowy", this.nazwapocz);
                writer.WriteElementString("punkt_koncowy", this.nazwakonc);
                writer.WriteElementString("liczba_pkt", this.lpkt.ToString());

                writer.WriteEndElement();

                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();
            }

        }




        public void ReadAll(string x)
        {
            XmlTextReader reader = new XmlTextReader(x);
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: // The node is an element.
                        Console.Write("<" + reader.Name);
                        Console.WriteLine(">");
                        break;
                    case XmlNodeType.Text: //Display the text in each element.
                        Console.WriteLine(reader.Value);
                        break;
                    case XmlNodeType.EndElement: //Display the end of the element.
                        Console.Write("</" + reader.Name);
                        Console.WriteLine(">");
                        break;
                }
            }

        }



    }
}
