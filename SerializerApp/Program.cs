using Microsoft.Win32.SafeHandles;
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace SerializerApp
{
    public class Program
    {

        public static void Main(string[] args)
        {
            //serializer

            XmlSerializer serializer = new XmlSerializer(typeof(osoba));

            //serializacja
            osobaAdres osAdres = new osobaAdres();
            osAdres.nrDomu = "10";
            osAdres.nrLokalu = "6";
            osAdres.ulica = "Szmaragodwa";
            osAdres.miejscowosc = "Gdańsk";

            osobaAdres[] adresLista = new osobaAdres[] {osAdres};

            osoba os = new osoba();
            os.nazwisko = "Filipski";
            os.imie = "Jacek";
            os.pesel = 12345678912;
            os.adresy = adresLista;

            //TextWriter StrumienPliku = new StreamWriter("osoba.xml");
            //serializer.Serialize(StrumienPliku, os);

            //deserializacja
            Stream StrumienPliku2 = File.OpenRead("osoba.xml");
            var osobaOdczytanaXML = serializer.Deserialize(StrumienPliku2);

            osoba os2 = new osoba();
            osobaAdres osobaXMLAdres = new osobaAdres();
            os2 = (osoba)osobaOdczytanaXML;

            osobaAdres[] adres = os2.adresy;
            osobaXMLAdres = adres[0];

            string ulica = osobaXMLAdres.ulica;
            string nrDomu = osobaXMLAdres.nrDomu;
            string nrLokalu = osobaXMLAdres.nrLokalu;
            string miejscowosc = osobaXMLAdres.miejscowosc;

            Console.WriteLine($"Imię: {os2.imie}");
            Console.WriteLine($"Nazwisko: {os2.nazwisko}");
            Console.WriteLine($"Pesel: {os2.pesel}");
            Console.WriteLine($"Miejscowość: {miejscowosc}");
            Console.WriteLine($"Ulica: {ulica}");
            Console.WriteLine($"Nr domu: {nrDomu}");
            Console.WriteLine($"Nr lokalu: {nrLokalu}");




        }
    }
}






