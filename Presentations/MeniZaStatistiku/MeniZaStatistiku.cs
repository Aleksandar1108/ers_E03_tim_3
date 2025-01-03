using Domain.Modeli;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentations.MeniZaStatistiku
{
    public class MeniZaStatistiku
    {
        IPrikazStatistike prikazStatistike;
        IPrikazStatistikeDatoteka prikazDat;

        public MeniZaStatistiku(IPrikazStatistike prikaziStatistiku, IPrikazStatistikeDatoteka prikazDat)
        {
            this.prikazStatistike = prikaziStatistiku;
            this.prikazDat = prikazDat;
        }
        public void MeniStatistika(Mape mapa, List<Heroj> plavi, List<Heroj>crveni, int ukupno)
        {
           

            bool kraj = false; 

            while (!kraj) 
            { 
                 Console.WriteLine("\nOdaberite nacin za ispisivanje statistike: ");
                 Console.WriteLine("\n1.Ispis statitistike na ekran");
                 Console.WriteLine("\n2.Ispis statististike u datoteku");

                string? unos = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(unos))
                    continue;

                switch(unos[0])
                {
                    case '1':
                        {
                            prikazStatistike.Prikazi(mapa,plavi,crveni,ukupno);
                             break;   
                        }
                    case '2':
                        {
                            Console.WriteLine("Unesite naziv fajla u koji zelite da sacuvate statistiku");
                            string nazivDatoteke = Console.ReadLine() ?? "statistikaBtike";
                            prikazDat.Prikazi(mapa, plavi, crveni, ukupno, nazivDatoteke);
                            break;
                        }
                                     
                }


            }  

        }
    }
}
