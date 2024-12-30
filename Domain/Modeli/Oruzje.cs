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

        public int Cena
        {
            get { return CenaKomada;}
            set
            {
                if(value < 0)
                {
                    throw new ArgumentException(nameof(value), "Cena oruzja mora biti pozitivna vrednost!");
                }
                CenaKomada = value;
            }
        }

        public int Bppzn
        {
            get { return PojacaniPoeniZaNapad; }
            set
            {
                if(value <15 || value > 40)
                {
                    throw new ArgumentException(nameof(value), "Broj poena za napad mora biti izmedju 15 i 40!");

                }
                PojacaniPoeniZaNapad = value;
            }
        }

        public int Kolicina
        {
            get { return DostupnaKolicina; }
            set
            {
                if(value < 0)
                {
                    throw new ArgumentException(nameof(value), "Kolicina za kupovinu mora biti pozitivna!");

                }
                DostupnaKolicina= value;
            }
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
