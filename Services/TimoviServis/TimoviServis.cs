using Domain.Modeli;
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
            if (heroji== null || heroji.Count < maxBrojIgraca * 2)
            {
                throw new ArgumentException("Nedovoljno heroja za kreiranje timova.");
            }

            
            var nasumicnoPromesaniHeroji = heroji.OrderBy(h => Guid.NewGuid()).ToList();

            
            var plaviTim = nasumicnoPromesaniHeroji.Take(maxBrojIgraca).ToList();
            var crveniTim = nasumicnoPromesaniHeroji.Skip(maxBrojIgraca).Take(maxBrojIgraca).ToList();

            return (plaviTim, crveniTim);
        }
    }
}
