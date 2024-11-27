using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Modeli
{
    public class Oruzje
    {
        public string NazivOruzja {  get; set; } = string.Empty;

        public int CenaKomada { get; set; } = 0;

        public int PojacaniPoeniZaNapad {  get; set; } = 0;

        public int DostupnaKolicina { get; set; } = 0;

        public Oruzje() { }

        public Oruzje(string nazOr,int cKom,int pojacaniPoeni,int dostupnaKol)
        {
            NazivOruzja = nazOr;
            CenaKomada = cKom;
            PojacaniPoeniZaNapad = pojacaniPoeni;
            DostupnaKolicina = dostupnaKol;
        }

        public override string? ToString()
        {
            return "\nNaziv oruzja: "+ NazivOruzja + 
                   "\nCena komada: " + CenaKomada +
                   "\nBroj pojacanih poena za napad: " +PojacaniPoeniZaNapad+
                   "\nDostupna kolicina za kupovinu: " +DostupnaKolicina;
        }
    }
}
