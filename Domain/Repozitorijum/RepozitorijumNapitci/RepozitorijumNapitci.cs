using Domain.Modeli;
using Domain.Repozitorijum.IRepozitorijum.INapitciRepozitorijum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repozitorijum.RepozitorijumNapitci
{
    public class RepozitorijumNapitci : INapitciRepozitorijum
    {
        static List<Napitak> listaNapitaka = [];

        static RepozitorijumNapitci()
        {
            listaNapitaka = [
                new Napitak("Booster",50,20,10),
                new Napitak("Eliksir snage",100,30,8),
                new Napitak("Misticna rosa",70,15,9),
                new Napitak("Gromova krv",50,25,6),
                new Napitak("Zvezdana kap",150,30,10),
                new Napitak("Plameni udah",200,40,5),
                new Napitak("Suze feniksa",300,40,7),
                new Napitak("Carobna esencija",110,25,4),
                new Napitak("Tonik tisine",150,15,3),
                new Napitak("Vesticiji caj",70,30,8),
                ];
        }
        public bool DodajNapitak(Napitak napitak)
        {
            foreach(Napitak nap in listaNapitaka)
            {
                if(nap.NazivNapitka == napitak.NazivNapitka)
                {
                    return false;
                }
            }
            listaNapitaka.Add(napitak);
            return true;
            
        }

        public Napitak PronadjiNapitak(string nazivNapitka)
        {
            foreach(Napitak nap in listaNapitaka)
            {
                if(nap.NazivNapitka == nazivNapitka)
                {
                    return nap;
                }
            }

          
            return new Napitak();

        }
    }
}
