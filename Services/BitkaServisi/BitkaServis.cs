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

            // Симулација битке
            int trajanjeBitke = random.Next(10, 45); // Трајање битке у секундама
            Console.WriteLine($"Битка траје {trajanjeBitke} секунди на мапи: {mapa.NazivMape}");

            for (int i = 0; i < trajanjeBitke; i++)
            {
                // Одабирање насумичног нападача и жртве у тиму
                if (plaviTim.Count > 0 && crveniTim.Count > 0)
                {
                    Heroj napadacPlavi = plaviTim[random.Next(plaviTim.Count)];
                    Heroj zrtvaCrveni = crveniTim[random.Next(crveniTim.Count)];
                    NapadniHeroja(napadacPlavi, zrtvaCrveni);
                    if (zrtvaCrveni.BrZivotnihPoena == 0)
                    {
                        crveniTim.Remove(zrtvaCrveni);
                        brojPobedaPlavi++;
                    }

                    if (plaviTim.Count == 0 || crveniTim.Count == 0) break;

                    Heroj napadacCrveni = crveniTim[random.Next(crveniTim.Count)];
                    Heroj zrtvaPlavi = plaviTim[random.Next(plaviTim.Count)];
                    NapadniHeroja(napadacCrveni, zrtvaPlavi);
                    if (zrtvaPlavi.BrZivotnihPoena == 0)
                    {
                        plaviTim.Remove(zrtvaPlavi);
                        brojPobedaCrveni++;
                    }
                }

                // Напад на помоћне ентитете
                foreach (var heroj in plaviTim.Concat(crveniTim))
                {
                    if (pomocniEntiteti.Count > 0)
                    {
                        PomocniEntitet entitet = pomocniEntiteti[random.Next(pomocniEntiteti.Count)];
                        NapadniPomocniEntitet(heroj, entitet);
                        if (entitet.ZivotniPoeni == 0)
                        {
                            pomocniEntiteti.Remove(entitet);
                        }
                    }

                    // Провера да ли херој може да купи предмет
                    if (heroj.StanjeNovcica >= 500)
                    {
                        Predmet predmet = predmeti.FirstOrDefault(p => p.DostupnaKolicina > 0) ?? new Predmet
                        {
                            NazivPredmeta = "Default",
                            CenaKomada = 0,
                            PojacaniPoeniZaNapad = 0,
                            DostupnaKolicina = 0
                        };
                        if (predmet != null)
                        {
                            heroj.JacinaNapada += predmet.PojacaniPoeniZaNapad;
                            heroj.StanjeNovcica -= predmet.CenaKomada;
                            predmet.DostupnaKolicina--;
                        }
                    }
                }
            }

            // Резултат битке
            return (plaviTim, crveniTim, brojPobedaPlavi > brojPobedaCrveni ? 1 : brojPobedaCrveni > brojPobedaPlavi ? 2 : 0);
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
