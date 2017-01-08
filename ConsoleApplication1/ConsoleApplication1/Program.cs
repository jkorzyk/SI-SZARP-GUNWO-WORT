using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml.XPath;

namespace App
{
    class Program
    {
        public static int PobierzInt()
        {
            string a = Console.ReadLine();
            try
            {
                Int32.Parse(a);
            }
            catch (FormatException)
            {
                Console.WriteLine("Podano nieprawidłową wartość! Podaj wartość z zakresu powyżej!");
                PobierzInt();
            }
            catch(Exception)
            {
                Console.WriteLine("Wystapił nieznany błąd. Spróbuj wprowadzić liczbę jeszcze raz!");
                PobierzInt();
            }
            return Int32.Parse(a);
        }


        static void Main(string[] args)
        {
            FileStream fs = File.OpenRead("projekt_c.xml"); // utworzenie strumienia i wczytanie pliku xml
            punkty obiekt = (punkty)new XmlSerializer(typeof(punkty)).Deserialize(fs);
            ListaTras lista = new ListaTras();

            Console.WriteLine("Ile tras chcesz podać?");
            int a = PobierzInt();
            for (int i=0; i < a; i++)
            {
                obiekt.WypiszPunkty();
                Console.WriteLine("Podaj numer punktu początkowego trasy:");
                int pktpocz = PobierzInt();
                Console.WriteLine(obiekt.TrasyPolaczone(pktpocz));
                Console.WriteLine("Podaj numer punktu końcowego trasy:");
                int pktkon = PobierzInt();
                Trasa t1 = new Trasa(pktpocz, pktkon);

                
                lista.Dodaj(t1); 
             }
            lista.ListaToXML();

           
            
           
        }
      
    }
}