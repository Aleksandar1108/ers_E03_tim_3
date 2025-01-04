using Domain.Modeli;
using Domain.Repozitorijum.IRepozitorijum.IPredmetRepozitorijum;
using Domain.Repozitorijum.IRepozitorijum.IProdavnicaRepozitorijum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repozitorijum.RepozitorijumProdavnica
{
    public class RepozitorijumProdavnica : IProdavnicaRepozitorijum
    {
        private static readonly List<Prodavnica> prodavnicaList = [];
        private static readonly IPredmetRepozitorijum PredmetRepozitorijum; 


        static RepozitorijumProdavnica()
        {
            PredmetRepozitorijum = new Domain.Repozitorijum.RepozitorijumPredmet.RepozitorijumPredmet();
            prodavnicaList = new List<Prodavnica>
            {
                new Prodavnica (1,PredmetRepozitorijum.PregledPredmeta().ToList(),0),
                new Prodavnica (2,PredmetRepozitorijum.PregledPredmeta().ToList(),0),
                new Prodavnica (3,PredmetRepozitorijum.PregledPredmeta().ToList(),0)
            };
        }

        public IEnumerable<Prodavnica> PregledProdavnice()
        {
            foreach (var prodavnica in prodavnicaList)
            {
                Console.WriteLine(prodavnica.ToString());
            }
            return prodavnicaList;  
        }
    }
}
