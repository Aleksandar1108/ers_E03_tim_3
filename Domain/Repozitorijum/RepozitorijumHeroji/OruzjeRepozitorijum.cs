using Domain.Modeli;
using Domain.Repozitorijum.IRepozitorijum.IOruzja;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repozitorijum.RepozitorijumHeroji
{
    public class OruzjeRepozitorijum : IOruzja
    {
        public static List<Oruzje> listaOruzja = [];


        static OruzjeRepozitorijum()
        {
            listaOruzja = [
                            new Oruzje("Noz", 70, 17, 4),
                            new Oruzje("Vatreni mac", 120, 25, 3),
                            new Oruzje("Automatska Puska M-16", 115, 28, 7),
                            new Oruzje("Sekira", 60, 15, 15),
                            new Oruzje("Buzdovan", 90, 20, 21),
                            new Oruzje("Luk i strela", 170, 33, 2),
                            new Oruzje("Bomba", 165, 36, 12),
                            new Oruzje("Koplje", 55, 17, 30),
                            new Oruzje("Samostrel", 99, 29, 4),
                            new Oruzje("Snajper", 250, 39, 9),
                           ];
        }

        public bool DodajOruzje(Oruzje oruzje)
        {
            foreach(Oruzje or in listaOruzja)
            {
                if(or.NazivOruzja == oruzje.NazivOruzja)
                {
                    Console.WriteLine("\nOruzje vec postoji");
                    return false;
                }
            } 
            listaOruzja.Add(oruzje);
            Console.WriteLine("\nOruzje uspesno dodato");
            return true;
        }

        public Oruzje PronadjiOruzje(string NazivOruzja)
        {
            foreach(Oruzje or in listaOruzja)
            {
                if(or.NazivOruzja == NazivOruzja)
                {
                    Console.WriteLine("\nOruzje je uspesno pronadjeno");
                    return or;
                    
                }
            }
            Console.WriteLine("\nTrazeno oruzje nije pronadjeno");
            return null;
        }
    }
}
