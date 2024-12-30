using Domain.Modeli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Presentations.IpsisMenija
{
    public class IspisMenia
    { 
        public void PrikaziMeni()
        {
            bool kraj = false; 

            while(!kraj) 
            {
                Console.WriteLine("\n1.Odabir broja igraca");
                Console.WriteLine("\n2.Nasumican unos podataka bitke");
                Console.WriteLine("\n3.Simulacija bitke");
                Console.WriteLine("\nVas odabir: ");

                string? unos = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(unos))
                continue;

                switch(unos[0])
                {
                    case '1':
                        Console.WriteLine("\nUnesite maksimalan broj igraca u jednom timu");
                        string? brojIgraca = Console.ReadLine();

                        if (brojIgraca == null)
                        {
                            Console.WriteLine("\nNeispravno unet broj igraca");
                            return;
                        }
                        else
                        { 
                            int MaxBrojIgraca = int.Parse(brojIgraca);
                        }
                        break;
                    case '2':
                        //mapa = NasumicnoGenerisanjeMape.GenerisiMapu(mapaRepozitorijum.PregledMapa().ToList()); 
                        //prodavnica = nasumicnoGenerisanjeProdavnice.GenerisiProdavnicu(prodavnicaRepozitorijum.pregledProdavnica.toList());
                        //prodati = prodavnica. 
                        //(PlaviTim, CrveniTim) = timoviServis.KreirajTimove(MaxBrojIgraca, herojRepozitorijum,pregledHeroja().ToList());
                        //Console.Writeline("\nPodaci su uspesno izgenerisani");
                        break;
                    case '3':
                        List<Heroj> plavi = new List<Heroj>();
                        List<Heroj> crveni= new List<Heroj>();
                        //int q = 0;
                        Console.WriteLine("\nBitka pocinje!");
                        //(plavi,crveni,q) = servis.BorbaHeroja(PlaviTim, CrveniTim, pomocniEntitet.PregledPomocnihEntiteta().ToList(), predmeti);
                        //statistikaMeni.IspisStatistikeMeni(plavi, crveni, mapa, q);
                        break;
                        
                }


            }



        }



    }
}
