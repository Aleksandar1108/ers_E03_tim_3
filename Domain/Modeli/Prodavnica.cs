using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Modeli
{
    public class Prodavnica
    {
        
        public int IdProdavnice { get; set; } = 0;

        public List<Predmet> ListaOiN { get; set; } = new List<Predmet>();
        

        public int UkupnaProdataVrednost { get; set; } = 0;

        public Prodavnica() { }

        public Prodavnica(int idProd,List<Predmet> predmeti,int ukpVr)
        {
            IdProdavnice = idProd;
            ListaOiN = predmeti;
            UkupnaProdataVrednost = ukpVr;
            
        }
        public override string ToString()
        {
            var predmetInfo = string.Join("\n", ListaOiN.Select(p => p.ToString()));
            return $"\nId Prodavnice: {IdProdavnice}\nLista predmeta: {predmetInfo}\nUkupna prodata vrednost: {UkupnaProdataVrednost}";
        }
        public List<Predmet> IspisiDostupneNapitkeIOruzja()
        {
            foreach (var predmet in ListaOiN)
            {
                Console.WriteLine(predmet.ToString());
            } 
            return ListaOiN;

        }
    }
}
