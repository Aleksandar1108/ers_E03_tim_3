using Domain.Modeli;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.PrikazStatistikeUFajl
{
    public class PrikazStatistikeDatoteke : IPrikazStatistikeDatoteka
    {
        private string nazivDat;

        public PrikazStatistikeDatoteke(string nazivDat)
        {
            this.nazivDat = nazivDat;
        }

        public void Prikazi(Mape mapa, List<Heroj> plaviTim, List<Heroj> crveniTim, decimal ukupnaProdaja, string imeDatoteke)
        {
            using (StreamWriter datoteka = new StreamWriter(nazivDat,true))
            {
                datoteka.WriteLine("*********************************\n");
                datoteka.WriteLine($"Mapa: {mapa}");
                datoteka.WriteLine($"Plavi tim: ");
                foreach(Heroj h in plaviTim)
                {
                    datoteka.WriteLine(h);

                }

                datoteka.WriteLine($"Crveni tim: ");

                foreach (Heroj h in crveniTim)
                {
                    datoteka.WriteLine(h);

                }
                datoteka.WriteLine($"\nUkupna vrednost prodatih itema: {ukupnaProdaja:C}");
                datoteka.WriteLine("*********************************\n");
            }
        }
    }
}
