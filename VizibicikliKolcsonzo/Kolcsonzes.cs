using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VizibicikliKolcsonzo
{
    internal class Kolcsonzes
    {
        string nev;
        string jazon;
        int eora;
        int eperc;
        int vora;
        int vperc;

        public Kolcsonzes(string nev, string jazon, int eora, int eperc, int vora, int vperc)
        {
            this.nev = nev;
            this.jazon = jazon;
            this.eora = eora;
            this.eperc = eperc;
            this.vora = vora;
            this.vperc = vperc;
        }

        public string Nev { get => nev; set => nev = value; }
        public string Jazon { get => jazon; set => jazon = value; }
        public int Eora { get => eora; set => eora = value; }
        public int Eperc { get => eperc; set => eperc = value; }
        public int Vora { get => vora; set => vora = value; }
        public int Vperc { get => vperc; set => vperc = value; }
    }
}
