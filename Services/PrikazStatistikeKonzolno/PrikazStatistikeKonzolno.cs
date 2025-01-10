using Domain.Modeli;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.PrikazStatistikeKonzolno
{
    public class PrikazStatistikeKonzolno : IPrikazStatistike
    {
        public PrikazStatistikeKonzolno() { }
        public void Prikazi(Mape mapa, List<Heroj> plaviTim, List<Heroj> crveniTim, decimal ukupnaProdaja, string nazivPlavogtima, string nazivCrvenogTima)
        {
            Console.WriteLine($"Mapa: {mapa.TipMape}");
            Console.WriteLine($"\nNaziv plavog tima: {nazivPlavogtima}");
            Console.WriteLine($"\nNaziv crvenog tima: {nazivCrvenogTima}"); 

            Console.WriteLine($"\nPlavi tim: ");

            foreach (Heroj h in plaviTim)
            {
                Console.WriteLine(h);
            }

            Console.WriteLine("\nCrveni tim: ");
            foreach (Heroj h in crveniTim)
            {
                Console.WriteLine(h);
            }

            Console.WriteLine($"\nUkupna vrednost prodatih stvari iz prodavnice: {ukupnaProdaja}");
        }
    }
}
