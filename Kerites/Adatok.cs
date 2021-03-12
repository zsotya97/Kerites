using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kerites
{
    class Adatok
    {
        public string Oldal { get; private set; }
        public int Meret { get; private set; }
        public string Szin { get; private set; }
        public int Sorszam { get; private set; }
        public Adatok(string sor,int sorszam)
        {
            var split = sor.Split();
            Oldal = split[0]=="1"?"Páratlan":"Páros";
            Meret = int.Parse(split[1]);
            Szin = split[2];
            Sorszam = sorszam;
        }
    }
}
