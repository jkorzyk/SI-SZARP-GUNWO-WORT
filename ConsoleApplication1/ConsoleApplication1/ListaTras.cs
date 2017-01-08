using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace App
{
    class ListaTras
    {
        public List<Trasa> listatras;
        public int liczbatras;
        

        public ListaTras()
        {
            listatras = new List<Trasa>();
            liczbatras = 0;
        }

        public void Dodaj(Trasa t)
        {
            listatras.Add(t);
        }

        public void ListaToXML()
        {
            using (XmlWriter writer = XmlWriter.Create("output.xml"))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("trasy");

                foreach (Trasa trasa in this.listatras)
                {
                    writer.WriteStartElement("trasa");

                    writer.WriteElementString("punkt_poczatkowy", trasa.Nazwapocz);
                    writer.WriteElementString("punkt_koncowy", trasa.Nazwakonc);
                    writer.WriteElementString("ilosc_punktow", trasa.Lpkt.ToString());

                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }
    }
}