using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2021KozutiEllenorzes9FSchon
{
    class Program
    {
        class Adat
        {
            //public static List<Adat> ooplista = new List<Adat>(); // oop-s stílus: a lista az nem egy adat, hanem az "Adatság"-nak a tulajdonsága (Adat classé)
            public DateTime ido;
            public string rendszam;
            public Adat(string[] sortömb)
            {
                ido = new DateTime(2021,4,4, int.Parse(sortömb[0]), int.Parse(sortömb[1]), int.Parse(sortömb[2]));
                rendszam = sortömb[3];
            //    ooplista.Add(this);
            }
        }

        static void Main(string[] args)
        {
            List<Adat> lista = new List<Adat>();
            using (StreamReader f = new StreamReader("jarmu.txt",Encoding.Default))
            {
                while (!f.EndOfStream)
                {
                    lista.Add(new Adat(f.ReadLine().Split(' ')));
                    //new Adat(f.ReadLine().Split(' ')); // oop-s stílus
                }
            }

            // Console.WriteLine(Adat.ooplista.Count); // oop-s stílus
            Console.WriteLine(lista.Count);



            /*
            StreamReader f = new StreamReader("jarmu.txt", Encoding.Default);
            ....
            f.Close();
            */

            /*
             * foreach (string sor in File.ReadAllLines("jarmu.txt", Encoding.Default))
               {

               }
            */


            // 2. feladat:
            Console.WriteLine($"2. feladat: {lista.Last().ido.Hour+1-lista[0].ido.Hour} óra hosszat dolgoztak az ellenőrök");

            // 3. feladat:
            Console.WriteLine($"3. feladat:");
            Console.WriteLine($"{lista[0].ido.Hour} óra: {lista[0].rendszam}");

            for (int i = 1; i < lista.Count; i++)
            {
                if (lista[i - 1].ido.Hour < lista[i].ido.Hour)
                {
                    Console.WriteLine($"{lista[i].ido.Hour} óra: {lista[i].rendszam}");
                }
            }

            // 4. feladat:

            Dictionary<char, int> szótár = new Dictionary<char, int>();

            szótár['B'] = 0;
            szótár['K'] = 0;
            szótár['M'] = 0;
            szótár[' '] = 0;

            foreach (Adat kocsi in lista)
            {
                //            if (kocsi.rendszam[0]=='B' || kocsi.rendszam[0]='K' ...)
                if ("BKM".Contains(kocsi.rendszam[0]))
                {
                    szótár[kocsi.rendszam[0]]++;
                }
                else// személygépkocsi eset
                {
                    szótár[' ']++;
                }
            }


            Console.WriteLine($" autóbusz: {szótár['B']} db ");
            Console.WriteLine($" kamion: {szótár['K']} db ");
            Console.WriteLine($" motor: {szótár['M']} db ");
            Console.WriteLine($" személygépkocsi: {szótár[' ']} db ");


        }
    }
}
