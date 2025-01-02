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
        public void IspisiDostupneNapitkeIOruzja()
        {

            Console.WriteLine("Dostupni napici:");
            if (Napici.Any())
            {
                foreach (var napitak in Napici)
                {
                    Console.WriteLine(napitak.ToString()); 

                }
            }

            else
            {
                Console.WriteLine("Nema dostupnih napitaka.");
            }

            Console.WriteLine("\nDostupna oruzja:");
            if (Oruzja.Any())
            {

                foreach (var oruzje in Oruzja)

                {

                    Console.WriteLine(oruzje.ToString()); 

                }
            }
            else
            {

                Console.WriteLine("Nema dostupnih oruzja.");

            }
        }
    }
}
