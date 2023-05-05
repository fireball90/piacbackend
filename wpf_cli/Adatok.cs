using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalatonWPF
{
    public class Adatok
    {
        public Adatok(string sor)
        {
            string[] darabok = sor.Split(' ');
            this.adoszam = Convert.ToInt32(darabok[0]);
            this.utcaNev = darabok[1];
            this.hazszam = darabok[2];
            this.adosav = Convert.ToChar(darabok[3]);
            this.terulet = Convert.ToInt32(darabok[4]);
        }

        public int adoszam { get; set; }
        public string utcaNev { get; set; }
        public string hazszam { get; set; }
        public char adosav { get; set; }
        public int terulet { get; set; }


    }
}
