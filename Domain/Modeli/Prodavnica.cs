using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Modeli
{
    public class Prodavnica
    {
        
        public int IdProdavnice { get; set; } = 0;

      //  public List<Predmet> ListaOiN { get; set; }
        public List<Oruzje> Oruzja { get; set; } = new List<Oruzje>();

        public List<Napitak> Napici { get; set; } = new List<Napitak>();

        public int UkupnaProdataVrednost { get; set; } = 0;

        public Prodavnica() { }

        public Prodavnica(int idProd,List<Oruzje> or,List<Napitak> nap,int ukpVr)
        {
            IdProdavnice = idProd;
            Oruzja = or;
            Napici = nap;
            
        }
        public override string? ToString()
        {
            return "\nId Prodavnice: " + IdProdavnice+
                   "\nLista oruzja: " + Oruzja +
                   "\nLista napitaka: " +Napici+
                   "\nUkupna prodata vrednost: " + UkupnaProdataVrednost;
        }
        public List<Predmet> IspisiDostupneNapitkeIOruzja()
        {
            List<Predmet> dostupniPredmeti = new List<Predmet>();
            
            foreach(Oruzje oruzje in Oruzja)
            {
                dostupniPredmeti.Add(new Predmet
                {
                    NazivPredmeta = oruzje.NazivOruzja,
                    CenaKomada = oruzje.CenaKomada,
                    PojacaniPoeniZaNapad = oruzje.PojacaniPoeniZaNapad
                });
            }

            foreach(Napitak napitak in Napici)
            {
                dostupniPredmeti.Add(new Predmet
                {
                    NazivPredmeta = napitak.NazivNapitka,
                    CenaKomada = napitak.Cena,
                    PojacaniPoeniZaNapad = napitak.PojacaniPoeniZaNapad
                });
            }
            return dostupniPredmeti;
            
        }
    }
}
