using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Modeli
{
    public class Napitak
    {
        private int bppn;
        private int cena;
        private int kolicina;
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

        public int Cena
        {
            get { return cena; }
            set
            {
                if(value < 0)
                {
                    throw new ArgumentException(nameof(value), "Cena napitaka ne sme biti negativna vrednost!");


                }
                cena = value;
            }
        }
        public int Kolicina
        {
            get { return kolicina; }
            set
            {
                if(value < 0)
                {
                    throw new ArgumentException(nameof(value), "Kolicina napitaka ne sme biti negativna vrednost!");
                }

                kolicina = value;
            }

        }

        public int Bppn
        {
            get { return bppn; }
            set
            {
                if(value<15 || value > 40)
                {
                    throw new ArgumentException(nameof(value), "Broj pojacanih poena za napad mora biti izmedju 15 i 40");
                }
                bppn = value;
            }
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
