using Domain.Modeli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.NasumicnaGenerisanja
{
    public class NasumicnoGenerisanjeProdavnice
    { 
        public static Prodavnica GenerisiProdavnicu(List<Prodavnica> prodavnice)
        {
            if(prodavnice == null || !prodavnice.Any())
            {
                throw new ArgumentException("Lista prodavnica ne sme biti prazna!\n");
            }
            Random random = new Random();
            int index = random.Next(prodavnice.Count);
            return prodavnice[index];   
        }

    }
}
