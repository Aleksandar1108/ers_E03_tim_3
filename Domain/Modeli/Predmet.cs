using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Modeli
{
    public class Predmet
    {
        public string NazivPredmeta { get; set; } = string.Empty;

        public int CenaKomada { get; set; } = 0;

        public int PojacaniPoeniZaNapad { get; set; } = 0;

        public int DostupnaKolicina { get; set; } = 0;

        public Predmet() { }

        public Predmet(string nazivPredmeta, int cenaKomada, int pojacaniPoeniZaNapad, int dostupnaKolicina)
        {
            NazivPredmeta = nazivPredmeta;
            CenaKomada = cenaKomada;
            PojacaniPoeniZaNapad = pojacaniPoeniZaNapad;
            DostupnaKolicina = dostupnaKolicina;
        }

        //Da li treba dodati i funkcije za ogranicenja

        public override string? ToString()
        {
            return "\nNaziv predmeta: " + NazivPredmeta +
                   "\nCena komada: " + CenaKomada +
                   "\nBroj pojacanih poena za napad: " + PojacaniPoeniZaNapad +
                   "\nDostupna kolicina za kupovinu: " + DostupnaKolicina;
        }
    }
}
