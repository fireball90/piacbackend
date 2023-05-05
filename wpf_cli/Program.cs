using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BalatonCLI
{
    public class Program
    {
        static void Main(string[] args)
        {

            List<Adatok> adatokLista = new List<Adatok>();

            StreamReader reader = new StreamReader("utca.txt");

            reader.ReadLine();
            while (!reader.EndOfStream)
            {
                adatokLista.Add(new Adatok(reader.ReadLine()));
            }
            reader.Close();

            //2. feladat
            Console.WriteLine($"2. feladat. A mintában {adatokLista.Count} telek szerepel.");

            //3. feladat
            
            Console.Write("3. feladat. Egy tulajdonos adószáma: ");
            Console.WriteLine();
            int bekertAdoszam = Convert.ToInt32(Console.ReadLine());

            int temp = 0;
            foreach (var item in adatokLista)
            {
                if (item.adoszam == bekertAdoszam)
                {
                    temp++;
                    Console.WriteLine(item.utcaNev + " utca " + item.hazszam);
                }
            }
            if (temp == 0)
            {
                Console.WriteLine("Nem szerepel az adatállományban.");
            }

            //5. feladat
            Console.WriteLine("5. feladat");

            int osszesA = 0;
            int osszesB = 0;
            int osszesC = 0;
            int osszAdoA = 0;
            int osszAdoB = 0;
            int osszAdoC = 0;

            foreach (var item in adatokLista)
            {
                if (item.adosav == 'A')
                {
                    osszesA += 1;
                    osszAdoA += ado(item.adosav,item.terulet);
                }
                else if (item.adosav == 'B')
                {
                    osszesB += 1;
                    osszAdoB += ado(item.adosav, item.terulet);
                }
                else if (item.adosav == 'C')
                {
                    osszesC += 1;
                    osszAdoC += ado(item.adosav, item.terulet);
                }
            }

            Console.WriteLine($"A sávba {osszesA} telek esik, az adó {osszAdoA} Ft.");
            Console.WriteLine($"A sávba {osszesB} telek esik, az adó {osszAdoB} Ft.");
            Console.WriteLine($"A sávba {osszesC} telek esik, az adó {osszAdoC} Ft.");

            //6.feladat

            StreamWriter writer = new StreamWriter("teljes.txt");

            foreach (var item in adatokLista)
            {
                writer.WriteLine(item.adoszam+" "+item.utcaNev+" "+item.hazszam+" "+item.adosav+" "+item.terulet+" "+ado(item.adosav,item.terulet));
            }
            writer.Close();

            Console.ReadKey();
        }

        public static int ado(char adosav, int terulet)
        {
            int fizetendo = 0;
            
            if (adosav == 'A')
            {
                fizetendo = terulet * 800;
            }
            if (adosav == 'B')
            {
                fizetendo = terulet * 600;
            }
            if (adosav == 'C')
            {
                fizetendo = terulet * 100;
            }

            return fizetendo;
        }
    }
}
