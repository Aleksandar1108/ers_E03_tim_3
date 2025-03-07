﻿using Domain.Modeli;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.TimoviServis
{
    public class TimoviServis : ITimoviServis
    {
        public (List<Heroj> PlaviTim, List<Heroj> CrveniTim) KreirajTimove(int maxBrojIgraca, List<Heroj> heroji)
        {
            if (heroji == null || heroji.Count < maxBrojIgraca * 2)
            {
                Console.WriteLine($"Trenutno imate {heroji?.Count ?? 0} heroja, a potrebno je {maxBrojIgraca * 2} heroja za oba tima.");
                throw new ArgumentException("Nedovoljno heroja za kreiranje timova.");
            }

            

            // Nasumično mešanje heroja
            var nasumicnoPromesaniHeroji = heroji.OrderBy(h => Guid.NewGuid()).ToList();
           

            // Deljenje heroja u timove
            var plaviTim = nasumicnoPromesaniHeroji.Take(maxBrojIgraca).ToList();
            var crveniTim = nasumicnoPromesaniHeroji.Skip(maxBrojIgraca).Take(maxBrojIgraca).ToList();

            Console.WriteLine($"Ukupan broj heroja: {plaviTim.Count+crveniTim.Count}");
            Console.WriteLine($"Maksimalni broj igrača po timu: {maxBrojIgraca}");

            Console.WriteLine($"Plavi tim ({plaviTim.Count} heroja): {string.Join(", ", plaviTim.Select(h => h.NazivHeroja))}");
            Console.WriteLine($"Crveni tim ({crveniTim.Count} heroja): {string.Join(", ", crveniTim.Select(h => h.NazivHeroja))}");

            if (plaviTim.Count < maxBrojIgraca || crveniTim.Count < maxBrojIgraca)
            {
                Console.WriteLine("Došlo je do problema pri kreiranju timova. Proverite listu heroja.");
            }

            return (plaviTim, crveniTim);
        }
    }
}
