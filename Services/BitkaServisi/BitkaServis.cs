using Domain.Modeli;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Services.BitkaServisi
{
    public class BitkaServis : IBorbaServis
    {
        public (List<Heroj> plaviTim, List<Heroj> crveniTim, int brojPobeda) BorbaHeroja(Mape mapa, List<Heroj> plaviTim, List<Heroj> crveniTim, List<PomocniEntitet> pomocniEntiteti, List<Predmet> predmeti)
        {
            Random random = new Random();
            int brojPobedaPlavi = 0;
            int brojPobedaCrveni = 0;
            PomocniEntitet pomocniEntitet = pomocniEntiteti[random.Next(pomocniEntiteti.Count)];

            int trajanjeBitke = random.Next(10, 45);
            Console.WriteLine($"Bitka traje {trajanjeBitke} sekundi na mapi: {mapa.NazivMape}");
           
            decimal ukupnaVrednostProdatihPredmeta = 0;
            
            for (int i = 0; i < trajanjeBitke; i++)
            {
                Console.WriteLine($"\nRunda {i + 1}:");

                // Provera da li timovi imaju heroje
                if (plaviTim.Count == 0 || crveniTim.Count == 0)
                {
                    Console.WriteLine("Jedan od timova je ostao bez heroja!");
                    break;
                }

                // Nasumično biraj tim koji napada prvi
                bool plaviNapadaPrvi = random.Next(2) == 0;

                if (plaviNapadaPrvi)
                {
                    // Plavi tim napada
                    Heroj napadacPlavi = plaviTim[random.Next(plaviTim.Count)];
                    Heroj zrtvaCrveni = crveniTim[random.Next(crveniTim.Count)];
                    NapadniHeroja(napadacPlavi, zrtvaCrveni);
                    NapadniPomocniEntitet(napadacPlavi, pomocniEntitet);
                    PrikaziNapad(napadacPlavi, zrtvaCrveni);

                    ukupnaVrednostProdatihPredmeta += KupovinaPredmeta(napadacPlavi, predmeti);
                    if (zrtvaCrveni.BrZivotnihPoena == 0)
                    {
                        crveniTim.Remove(zrtvaCrveni);
                        brojPobedaPlavi++;
                    }
                }
                else
                {
                    // Crveni tim napada
                    Heroj napadacCrveni = crveniTim[random.Next(crveniTim.Count)];
                    Heroj zrtvaPlavi = plaviTim[random.Next(plaviTim.Count)];
                    NapadniHeroja(napadacCrveni, zrtvaPlavi);
                    NapadniPomocniEntitet(napadacCrveni, pomocniEntitet);
                    PrikaziNapad(napadacCrveni, zrtvaPlavi);

                    ukupnaVrednostProdatihPredmeta += KupovinaPredmeta(napadacCrveni, predmeti);
                    if (zrtvaPlavi.BrZivotnihPoena == 0)
                    {
                        plaviTim.Remove(zrtvaPlavi);
                        brojPobedaCrveni++;
                    }
                }
            }

           
          

            Console.WriteLine("\nBitka je završena!");
            if (brojPobedaPlavi > brojPobedaCrveni)
            {
                Console.WriteLine("Plavi tim je pobedio!");
            }
            else if (brojPobedaCrveni > brojPobedaPlavi)
            {
                Console.WriteLine("Crveni tim je pobedio!");
            }
            else
            {
                Console.WriteLine("Bitka je završena nerešeno!");
            }
            return (plaviTim, crveniTim, brojPobedaPlavi > brojPobedaCrveni ? 1 : brojPobedaCrveni > brojPobedaPlavi ? 2 : 0);

        }
        /*private void KupovinaPredmeta(List<Heroj> tim, List<Predmet> predmeti)
        {
            Random random = new Random();
            foreach (var heroj in tim)
            {
                if (heroj.StanjeNovcica >= 500)
                {
                    // Random odabir predmeta
                    var dostupniPredmeti = predmeti.Where(p => p.DostupnaKolicina > 0).ToList();
                    if (dostupniPredmeti.Count > 0)
                    {
                        var predmetZaKupovinu = dostupniPredmeti[random.Next(dostupniPredmeti.Count)];

                        // Kupovina predmeta
                        heroj.JacinaNapada += predmetZaKupovinu.PojacaniPoeniZaNapad;
                        heroj.StanjeNovcica -= predmetZaKupovinu.CenaKomada;
                        predmetZaKupovinu.DostupnaKolicina--;
                       int vrednostKupovine = predmetZaKupovinu.CenaKomada;
                        Console.WriteLine($"{heroj.NazivHeroja} je kupio {predmetZaKupovinu.NazivPredmeta} i povećao napad na {heroj.JacinaNapada}.");
                    }
                }
            }
        }*/
        private decimal KupovinaPredmeta(Heroj heroj, List<Predmet> predmeti)
        {
            Random random = new Random();
            decimal vrednostKupovine = 0;

            if (heroj.StanjeNovcica >= 500)
            {
                // Random odabir predmeta
                var dostupniPredmeti = predmeti.Where(p => p.DostupnaKolicina > 0).ToList();
                if (dostupniPredmeti.Count > 0)
                {
                    var predmetZaKupovinu = dostupniPredmeti[random.Next(dostupniPredmeti.Count)];

                    // Kupovina predmeta
                    heroj.JacinaNapada += predmetZaKupovinu.PojacaniPoeniZaNapad;
                    heroj.StanjeNovcica -= predmetZaKupovinu.CenaKomada;
                    predmetZaKupovinu.DostupnaKolicina--;

                    vrednostKupovine = predmetZaKupovinu.CenaKomada;  // Zbir cene kupljenih predmeta
                    Console.WriteLine($"{heroj.NazivHeroja} je kupio {predmetZaKupovinu.NazivPredmeta} i povećao napad na {heroj.JacinaNapada}.");
                }
            }

            return vrednostKupovine;
        }


        private void PrikaziNapad(Heroj napadac, Heroj zrtva)
        {
            Console.WriteLine($"{napadac.NazivHeroja} napada {zrtva.NazivHeroja}. Život žrtve: {zrtva.BrZivotnihPoena}");

            if (zrtva.BrZivotnihPoena == 0)
            {
                Console.WriteLine($"{zrtva.NazivHeroja} je eliminisan!");
                // Logika eliminacije žrtve
            }
            else
            {
                // Ispis nakon napada, kad žrtva još ima život
                Console.WriteLine($"{napadac.NazivHeroja} je napao {zrtva.NazivHeroja}. Preostali život žrtve: {zrtva.BrZivotnihPoena}");
            }
        }

        private void NapadniHeroja(Heroj napadac, Heroj zrtva)
        {
            zrtva.BrZivotnihPoena -= napadac.JacinaNapada;
            if (zrtva.BrZivotnihPoena < 0) zrtva.BrZivotnihPoena = 0;
            if (zrtva.BrZivotnihPoena == 0) napadac.StanjeNovcica += 300;
        }

        private void NapadniPomocniEntitet(Heroj napadac, PomocniEntitet entitet)
        {
            entitet.ZivotniPoeni -= napadac.JacinaNapada;
            if (entitet.ZivotniPoeni < 0) entitet.ZivotniPoeni = 0;
            if (entitet.ZivotniPoeni == 0)
            {
                int vrednost = new Random().Next(20, 91);
                napadac.StanjeNovcica += vrednost;
            }
        }

    }
}
