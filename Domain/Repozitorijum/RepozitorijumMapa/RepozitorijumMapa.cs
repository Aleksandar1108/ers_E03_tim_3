using Domain.Enumeracija;
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
        private readonly List<TipMape.Tip> mape = new List<TipMape.Tip>();

        public void DodajMapu(TipMape.Tip tipMape)
        {
            mape.Add(tipMape);
            Console.WriteLine("Mapa dodata: " + tipMape.ToString());
        }

        public void InicijalizujMape()
        {
            mape.Add(TipMape.Tip.LETNJA);
            mape.Add(TipMape.Tip.ZIMSKA);
            Console.WriteLine("Mape inicijalizovane.");
        }

        public IEnumerable<TipMape.Tip> PregledMapa()
        {
            if (mape.Count == 0)
            {
                Console.WriteLine("Nema dostupnih mapa.");
            }
            else
            {
                foreach (var mapa in mape)
                {
                    Console.WriteLine(mapa.ToString());
                }
            }

            return mape;
        }
    }
}
