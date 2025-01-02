using Domain.Modeli;
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
        private readonly List<Prodavnica> prodavnicaList=new List<Prodavnica>();

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
