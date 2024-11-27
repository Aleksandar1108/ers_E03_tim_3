using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Modeli
{
    public class Napitak
    {
        public string NazivNapitka { get; set; } = string.Empty;

        public int CenaKomada { get; set; } = 0;

        public int PojacaniPoeniZaNapad { get; set; } = 0;

        public int DostupnaKolicina { get; set; } = 0;

        public Napitak() { }

        public Napitak(string nazNap,int cKom,int pojPoeni,int dKol)
        {
            NazivNapitka = nazNap;
            CenaKomada = cKom;
            PojacaniPoeniZaNapad = pojPoeni;
            DostupnaKolicina = dKol;
        }
        public override string? ToString()
        {
            return "\nNaziv napitka: " + NazivNapitka +
                   "\nCena komada: " + CenaKomada +
                   "\nBroj pojacanih poena za napad: " + PojacaniPoeniZaNapad +
                   "\nDostupna kolicina za kupovinu: " + DostupnaKolicina;
        }
    }
}
