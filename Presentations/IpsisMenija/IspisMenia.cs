using Domain.Modeli;
using Domain.NasumicnaGenerisanja;
using Domain.Repozitorijum.IRepozitorijum.IEntitetRepozitorijum;
using Domain.Repozitorijum.IRepozitorijum.IHerojRepozitorijum;
using Domain.Repozitorijum.IRepozitorijum.IMapaRepozitorijum;
using Domain.Repozitorijum.IRepozitorijum.IProdavnicaRepozitorijum;
using Domain.Repozitorijum.RepozitorijumHeroji;
using Domain.Repozitorijum.RepozitorijumMapa;
using Domain.Repozitorijum.RepozitorijumProdavnica;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Domain.Enumeracija;
namespace Presentations.IpsisMenija
{
    public class IspisMenia
    {
        Mape mapa;
        Prodavnica prodavnica;
        private readonly NasumicnoGenerisanjeMape nasumicnoGenerisanjeMape;
        private readonly NasumicnoGenerisanjeProdavnice nasumicnoGenerisanjeProdavnice;
        private readonly IProdavnicaRepozitorijum prodavnicaRepozitorijum;
        private readonly RepozitorijumMapa mapaRepozitorijum;
        
        public List<Heroj> PlaviTim = new List<Heroj>();
        public List<Heroj> CrveniTim = new List<Heroj>();
        private readonly IHerojiRepozitorijum herojRep;
        private readonly ITimoviServis timoviServis;
        IEntitetRepozitorijum pomocniEntitet;
        private readonly IBorbaServis servis;
        //interfejs za tabelrani prikaz 
        private List<Predmet> predmeti = new List<Predmet>();
        private readonly Presentations.MeniZaStatistiku.MeniZaStatistiku meniZaStatistiku;
        bool podaciGenerisani = false;

        public IspisMenia(Mape mapa, Prodavnica prodavnica, List<Heroj> plaviTim, List<Heroj> crveniTim, IHerojiRepozitorijum herojRep, MeniZaStatistiku.MeniZaStatistiku meniZaStatistiku, NasumicnoGenerisanjeMape nasumicnoGenerisanjeMape, RepozitorijumMapa mapaRepozitorijum,NasumicnoGenerisanjeProdavnice nasumicnoGenerisanjeProdavnice,IProdavnicaRepozitorijum prodavnicaRepozitorijum,ITimoviServis timoviServis,IBorbaServis servis,IEntitetRepozitorijum pomocniEntitet)
        { 
            //ovde nam fale za nasumicno generisanje
            //to cemo dodati kad uradimo generisanje bitke, timova...
            this.mapa = mapa;
            this.prodavnica = prodavnica;
            PlaviTim = plaviTim;
            CrveniTim = crveniTim;
            this.herojRep = herojRep;
            this.meniZaStatistiku = meniZaStatistiku;
            this.nasumicnoGenerisanjeMape = nasumicnoGenerisanjeMape;
            this.mapaRepozitorijum = mapaRepozitorijum;
            this.nasumicnoGenerisanjeProdavnice = nasumicnoGenerisanjeProdavnice;
            this.prodavnicaRepozitorijum = prodavnicaRepozitorijum;
            this.timoviServis = timoviServis;
            this.servis = servis;
            this.pomocniEntitet = pomocniEntitet;
        }

        public void PrikaziMeni()
        {
            bool kraj = false;
            int maxBrojIgraca = 0;
            while (!kraj) 
            {
                Console.WriteLine("\n1.Odabir broja igraca");
                Console.WriteLine("\n2.Nasumican unos podataka bitke");
                Console.WriteLine("\n3.Simulacija bitke");
                Console.WriteLine("\nVas odabir: ");

                string? unos = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(unos))
                continue;

                switch (unos[0])
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
                            maxBrojIgraca = int.Parse(brojIgraca);
                        }
                        break;
                    case '2':
                        Console.WriteLine("\nUnesite tip mape (1 za LETNJA, 2 za ZIMSKA):");
                        string? izbor = Console.ReadLine();
                        if(izbor == "1")
                        {
                            mapaRepozitorijum.DodajMapu(TipMape.Tip.LETNJA);
                        }
                        else if(izbor == "2")
                        {
                            mapaRepozitorijum.DodajMapu(TipMape.Tip.ZIMSKA);
                        }
                        else
                        {
                            Console.WriteLine("Nepoznat unos!");
                        }
                        prodavnica = NasumicnoGenerisanjeProdavnice.GenerisiProdavnicu(prodavnicaRepozitorijum.PregledProdavnice().ToList());
                        predmeti = prodavnica.IspisiDostupneNapitkeIOruzja();
                        (PlaviTim, CrveniTim) = timoviServis.KreirajTimove(maxBrojIgraca, herojRep.pregledHeroja().ToList());
                        Console.WriteLine("\nPodaci su uspesno izgenerisani");
                        podaciGenerisani = true;

                       

                        break;
                    case '3':
                        if(!podaciGenerisani)
                        {
                            Console.WriteLine("\nPokrece se simulacija");
                            if (maxBrojIgraca == 0)
                            {
                                Console.WriteLine("Unesite maksimalan broj igrača po timu: ");
                                if (int.TryParse(Console.ReadLine(), out maxBrojIgraca) && maxBrojIgraca > 0)
                                {
                                    Console.WriteLine($"Broj igrača po timu je postavljen na {maxBrojIgraca}.");
                                }
                                else
                                {
                                    Console.WriteLine("Neispravan unos broja igrača. Pokušajte ponovo.");
                                    break;
                                }
                            }

                            // Unos naziva timova
                            Console.WriteLine("Unesite naziv za Plavi tim:");
                            string? nazivPlavogTima = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(nazivPlavogTima))
                            {
                                nazivPlavogTima = "Plavi Tim"; // Podrazumevani naziv
                            }

                            Console.WriteLine("Unesite naziv za Crveni tim:");
                            string? nazivCrvenogTima = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(nazivCrvenogTima))
                            {
                                nazivCrvenogTima = "Crveni Tim"; // Podrazumevani naziv
                            }

                            // Unos naziva igrača za plavi tim
                            PlaviTim.Clear();
                            Console.WriteLine($"Unos naziva igrača za {nazivPlavogTima}:");
                            for (int i = 0; i < maxBrojIgraca; i++)
                            {
                                Console.WriteLine($"Unesite naziv za igrača {i + 1}: ");
                                string? nazivIgraca = Console.ReadLine();
                                if (!string.IsNullOrWhiteSpace(nazivIgraca))
                                {
                                    Console.WriteLine("Unesite broj životnih poena za igrača:");
                                    int brZivotnihPoena = int.Parse(Console.ReadLine() ?? "100"); // Podrazumevano 100 ako nije uneseno

                                    Console.WriteLine("Unesite jačinu napada za igrača:");
                                    int jacinaNapada = int.Parse(Console.ReadLine() ?? "10"); // Podrazumevano 10 ako nije uneseno

                                    // Dodajemo igrača u plavi tim
                                    PlaviTim.Add(new Heroj { NazivHeroja = nazivIgraca, BrZivotnihPoena = brZivotnihPoena, JacinaNapada = jacinaNapada, StanjeNovcica = 0 });
                                }
                                else
                                {
                                    Console.WriteLine("Neispravan unos naziva. Pokušajte ponovo.");
                                    i--;
                                }
                            }

                            // Unos naziva igrača za crveni tim
                            CrveniTim.Clear();
                            Console.WriteLine($"Unos naziva igrača za {nazivCrvenogTima}:");
                            for (int i = 0; i < maxBrojIgraca; i++)
                            {
                                Console.WriteLine($"Unesite naziv za igrača {i + 1}: ");
                                string? nazivIgraca = Console.ReadLine();
                                if (!string.IsNullOrWhiteSpace(nazivIgraca))
                                {
                                    Console.WriteLine("Unesite broj životnih poena za igrača:");
                                    int brZivotnihPoena = int.Parse(Console.ReadLine() ?? "100"); // Podrazumevano 100 ako nije uneseno

                                    Console.WriteLine("Unesite jačinu napada za igrača:");
                                    int jacinaNapada = int.Parse(Console.ReadLine() ?? "10"); // Podrazumevano 10 ako nije uneseno

                                    CrveniTim.Add(new Heroj { NazivHeroja = nazivIgraca, BrZivotnihPoena = brZivotnihPoena, JacinaNapada = jacinaNapada, StanjeNovcica = 0 });
                                }
                                else
                                {
                                    Console.WriteLine("Neispravan unos naziva. Pokušajte ponovo.");
                                    i--;
                                }
                            }

                            // Unos mape
                            Console.WriteLine("Unesite tip mape za bitku (1 za LETNJA, 2 za ZIMSKA):");
                            string? izborMape = Console.ReadLine();
                            if (izborMape == "1")
                            {
                                mapa = new Mape { NazivMape = "Letnja" };
                            }
                            else if (izborMape == "2")
                            {
                                mapa = new Mape { NazivMape = "Zimska" };
                            }
                            else
                            {
                                Console.WriteLine("Nepoznat unos tipa mape. Podrazumevano je postavljena Letnja mapa.");
                                mapa = new Mape { NazivMape = "Letnja" };
                            }

                            // Odabir prodavnice
                            Console.WriteLine("Odaberite prodavnicu za kupovinu:");
                            var prodavnice = prodavnicaRepozitorijum.PregledProdavnice().ToList();
                            for (int i = 0; i < prodavnice.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. Prodavnica ID: {prodavnice[i].IdProdavnice}");
                            }
                            int izborProdavnice;
                            if (int.TryParse(Console.ReadLine(), out izborProdavnice) && izborProdavnice > 0 && izborProdavnice <= prodavnice.Count)
                            {
                                prodavnica = NasumicnoGenerisanjeProdavnice.GenerisiProdavnicu(new List<Domain.Modeli.Prodavnica> { prodavnice[izborProdavnice - 1] });
                            }
                            else
                            {
                                Console.WriteLine("Neispravan izbor prodavnice. Koristi se podrazumevana prodavnica.");
                                prodavnica = NasumicnoGenerisanjeProdavnice.GenerisiProdavnicu(new List<Domain.Modeli.Prodavnica> { prodavnice[0] });
                            }

                            predmeti = prodavnica.IspisiDostupneNapitkeIOruzja();

                            // Pokretanje bitke
                            Console.WriteLine("\nSimulacija bitke je u toku...");
                            // List<Heroj> plaviPosleBitke = new List<Heroj>();
                            //List<Heroj> crveniPosleBitke = new List<Heroj>();
                            List<Heroj> sviHerojiPlavi = new List<Heroj>(PlaviTim);  // Svi heroji iz plavog tima
                            List<Heroj> sviHerojiCrveni = new List<Heroj>(CrveniTim);
                            int rezultatBitke = 0;

                            (PlaviTim, CrveniTim, rezultatBitke) = servis.BorbaHeroja(mapa, PlaviTim, CrveniTim, pomocniEntitet.PregledPomocnihEntiteta().ToList(), predmeti);



                            // Prikaz rezultata kroz meni za statistiku
                            meniZaStatistiku.MeniStatistika(mapa, sviHerojiPlavi, sviHerojiCrveni, rezultatBitke, nazivPlavogTima, nazivCrvenogTima);
                        } 
                        else
                        { 
                            Console.WriteLine("\nPokreće se simulacija bitke!\n");
                            int brojac = 0;
                            List<Heroj> sviHerojiPlavi2 = new List<Heroj>(PlaviTim);
                            List<Heroj> sviHerojiCrveni2 = new List<Heroj>(CrveniTim);
                            (PlaviTim, CrveniTim, brojac) = servis.BorbaHeroja(mapa, PlaviTim, CrveniTim, pomocniEntitet.PregledPomocnihEntiteta().ToList(), predmeti
           );

                            
                            string nazivPT = "plavi";
                            string nazivCT = "crveni";
                            int rez = 0;
                            meniZaStatistiku.MeniStatistika(mapa, sviHerojiPlavi2, sviHerojiCrveni2, rez, nazivPT, nazivCT);

                            // Unos broja igrača po timu ako nije ranije definisan
                        }
                       
                       

                        break;
                    default:
                        Console.WriteLine("\nNeispravan unos, pokusajte ponovo!\n");
                        break;
                        
                }

            }
        }

    }
}
