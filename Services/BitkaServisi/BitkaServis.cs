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

            // Filtriraj pomoćne entitete koji su preživeli (da ne napadaju eliminisani)
            List<PomocniEntitet> preostaliPomocniEntiteti = pomocniEntiteti.Where(pe => pe.ZivotniPoeni > 0).ToList();

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

                // Nasumično biraj pomoćni entitet ako ih ima preživelih
                PomocniEntitet? pomocniEntitet = preostaliPomocniEntiteti.Count > 0 ? preostaliPomocniEntiteti[random.Next(preostaliPomocniEntiteti.Count)] : null;

                if (plaviNapadaPrvi)
                {
                    // Plavi tim napada
                    Heroj napadacPlavi = plaviTim[random.Next(plaviTim.Count)];
                    Heroj zrtvaCrveni = crveniTim[random.Next(crveniTim.Count)];

                    // Napad na heroje i pomoćne entitete
                    NapadniHeroja(napadacPlavi, zrtvaCrveni);
                    if (pomocniEntitet != null) NapadniPomocniEntitet(napadacPlavi, pomocniEntitet);

                    // Prikaz napada
                    PrikaziNapad(napadacPlavi, zrtvaCrveni);
                    if (pomocniEntitet != null) PrikaziNapadNaPomocniEntitet(napadacPlavi, pomocniEntitet);

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

                    // Napad na heroje i pomoćne entitete
                    NapadniHeroja(napadacCrveni, zrtvaPlavi);
                    if (pomocniEntitet != null) NapadniPomocniEntitet(napadacCrveni, pomocniEntitet);

                    // Prikaz napada
                    PrikaziNapad(napadacCrveni, zrtvaPlavi);
                    if (pomocniEntitet != null) PrikaziNapadNaPomocniEntitet(napadacCrveni, pomocniEntitet);

                    ukupnaVrednostProdatihPredmeta += KupovinaPredmeta(napadacCrveni, predmeti);
                    if (zrtvaPlavi.BrZivotnihPoena == 0)
                    {
                        plaviTim.Remove(zrtvaPlavi);
                        brojPobedaCrveni++;
                    }
                }

                // Filtriraj preostale pomoćne entitete (ako je neki eliminisan)
                preostaliPomocniEntiteti = pomocniEntiteti.Where(pe => pe.ZivotniPoeni > 0).ToList();
            }

            // Ispis rezultata bitke
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
            Console.WriteLine($"{napadac.NazivHeroja} napada {zrtva.NazivHeroja}. Život žrtve pre napada: {zrtva.BrZivotnihPoena}");
            NapadniHeroja(napadac, zrtva); 
            Console.WriteLine($"{napadac.NazivHeroja} je napao {zrtva.NazivHeroja}. Preostali život žrtve: {zrtva.BrZivotnihPoena}");
            
            if (zrtva.BrZivotnihPoena == 0)
            {
               Console.WriteLine($"{zrtva.NazivHeroja} je eliminisan!");
           

            }
           
        }
        private void PrikaziNapadNaPomocniEntitet(Heroj napadac, PomocniEntitet entitet)
        {
            Console.WriteLine($"{napadac.NazivHeroja} napada pomoćni entitet {entitet.NazivEntiteta}. Život pomoćnog entiteta {entitet.NazivEntiteta}: {entitet.ZivotniPoeni}");
            NapadniPomocniEntitet(napadac, entitet);
            Console.WriteLine($"{napadac.NazivHeroja} je napao pomoćni entitet. Preostali život pomoćnog entiteta: {entitet.ZivotniPoeni}");
            if (entitet.ZivotniPoeni == 0)
            {
                Console.WriteLine($"Pomoćni entitet {entitet.NazivEntiteta} je eliminisan!");
               
                
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
