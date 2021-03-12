using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Kerites
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<string> beolvas = File.ReadAllLines("kerites.txt");
            List<Adatok> adatok = new List<Adatok>();
            int paros = 0, paratlan = 0;
            foreach (var item in beolvas)
            {
                if(item.Split()[0]=="1")
                {
                    if(paratlan==0)
                    {
                        paratlan = 1;
                        adatok.Add(new Adatok(item, paratlan));
                    }
                    else
                    {
                        paratlan +=2;
                        adatok.Add(new Adatok(item, paratlan));
                    }

                }
                else
                {
                    if (paros == 0)
                    {
                        paros = 2;
                        adatok.Add(new Adatok(item, paros));
                    }
                    else
                    {
                        paros += 2;
                        adatok.Add(new Adatok(item, paros));
                    }
                }
                
            }
            Console.WriteLine($"2. feladat:\nAz eladott telkek száma: {adatok.Count}");
            Console.WriteLine($"\n3. feladat:\nA {adatok.Last().Oldal} oldalon adták el az utolsó telket.\nAz utolsó telek házszáma: {adatok.Last().Sorszam}");
            Console.WriteLine($"\n4. feladat:");
            foreach (var item in adatok.Where(x=>x.Oldal=="Páratlan"&&x.Szin!=":"&&x.Szin!="#"))
            {
                Adatok temp1 = adatok.Where(x => x.Sorszam - 2 == item.Sorszam || x.Sorszam + 2 == item.Sorszam).First();
                if(temp1.Szin==item.Szin)
                {
                    Console.WriteLine($"A szomszéddal egyezik a kerítés színe: {temp1.Sorszam}");
                    break;
                }
                
            }
            Console.Write($"\n5. feladat: \nAdjon meg egy házszámot: ");
            var hazszam = int.Parse(Console.ReadLine());
            Adatok Kivalasztott = adatok.Where(x => x.Sorszam == hazszam).FirstOrDefault();
            Console.WriteLine($"A kerítés színe/állapota: {Kivalasztott.Szin}");
            for (var i = 'A'; i < 'Z'; i++)
            {
                Adatok temp1 = adatok.Where(x => x.Sorszam - 2 == Kivalasztott.Sorszam).FirstOrDefault();
                Adatok temp2 = adatok.Where(x => x.Sorszam + 2 == Kivalasztott.Sorszam).FirstOrDefault();
                if(Kivalasztott.Szin!=i.ToString()&&temp1.Szin!=i.ToString()&&temp2.Szin!=i.ToString())
                {
                    Console.WriteLine($"Egy lehetséges festési szín: {i}");
                    break;
                }
            }


            Console.WriteLine($"\n6. feladat: Kiírás");
            StreamWriter kiir = new StreamWriter("utcakep.txt",false);
            var lista = adatok.Where(x => x.Oldal == "Páratlan");

            foreach (var item in lista)
            {
                for (int i = 0; i < item.Meret; i++)
                {
                    kiir.Write(item.Szin);
                }
            }
            kiir.WriteLine();
            foreach (var item in lista)
            {
                kiir.Write(item.Sorszam);
                for (int i = 0; i < item.Meret-item.Sorszam.ToString().Length; i++)
                {
                    kiir.Write(" ");
                }
            }
            kiir.Close();
        }
    }
}
