using Domain.Modeli;
using Domain.Repozitorijum.IRepozitorijum.IPredmetRepozitorijum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repozitorijum.RepozitorijumPredmet
{
    public class RepozitorijumPredmet : IPredmetRepozitorijum
    {
        static List<Predmet> listaPredmeta = [];

        static RepozitorijumPredmet()
        {
            listaPredmeta = [
                new Predmet("Booster",50,20,10),
                new Predmet("Eliksir snage",100,30,8),
                new Predmet("Misticna rosa",70,15,9),
                new Predmet("Gromova krv",50,25,6),
                new Predmet("Zvezdana kap",150,30,10),
                new Predmet("Plameni udah",200,40,5),
                new Predmet("Suze feniksa",300,40,7),
                new Predmet("Carobna esencija",110,25,4),
                new Predmet("Tonik tisine",150,15,3),
                new Predmet("Vesticiji caj",70,30,8),
                new Predmet("Noz", 70, 17, 4),
                new Predmet("Vatreni mac", 120, 25, 3),
                new Predmet("Automatska Puska M-16", 115, 28, 7),
                new Predmet("Sekira", 60, 15, 15),
                new Predmet("Buzdovan", 90, 20, 21),
                new Predmet("Luk i strela", 170, 33, 2),
                new Predmet("Bomba", 165, 36, 12),
                new Predmet("Koplje", 55, 17, 30),
                new Predmet("Samostrel", 99, 29, 4),
                new Predmet("Snajper", 250, 39, 9),
                ];
        }
        public bool DodajPredmet(Predmet predmet)
        {
            foreach (Predmet pred in listaPredmeta)
            {
                if (pred.NazivPredmeta == predmet.NazivPredmeta)
                {
                    return false;
                }
            }
            listaPredmeta.Add(predmet);
            return true;
        }

        public Predmet PronadjiPredmet(string nazivPredmet)
        {
            foreach (Predmet pred in listaPredmeta)
            {
                if (pred.NazivPredmeta == nazivPredmet)
                {
                    return pred;
                }
            }
            return new Predmet();

        }
    }
}
