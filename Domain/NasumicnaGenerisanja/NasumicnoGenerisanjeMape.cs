using Domain.Modeli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.NasumicnaGenerisanja
{
    public class NasumicnoGenerisanjeMape
    {

        public static Mape GenerisiNasumicnuMapu(List<Mape> dostupneMape)
        {
            if (dostupneMape == null || !dostupneMape.Any())
                throw new ArgumentException("Lista mapa ne sme biti prazna.");

            Random random = new Random();
            int index = random.Next(dostupneMape.Count);
            return dostupneMape[index];
        }


    }
}
