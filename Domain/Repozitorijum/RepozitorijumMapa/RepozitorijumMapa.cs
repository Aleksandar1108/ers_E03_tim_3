using Domain.Modeli;
using Domain.Repozitorijum.IRepozitorijum.IMapaRepozitorijum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repozitorijum.RepozitorijumMapa
{
    public class RepozitorijumMapa : IMapaRepozitorijum
    {
        private readonly List<Mape> mape = new List<Mape>();
        public IEnumerable<Mape> PregledMapa()
        {
            foreach (var mapa in mape)
            {
                Console.WriteLine(mapa.ToString());
            }

            return mape;
           
        }
    }
}
