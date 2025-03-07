﻿using Domain.Modeli;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presentations.MeniZaStatistiku;
using Services.PrikazStatistikeUFajl;




namespace Services.ProdavnicaServis
{
    public class SimulacijaBitke : IBorbaServis
    {
        public (List<Heroj> plaviTim, List<Heroj> crveniTim, int brojPobeda) BorbaHeroja(Mape mapa, List<Heroj> plaviTim, List<Heroj> crveniTim, List<PomocniEntitet> pomocniEntiteti, List<Predmet> predmeti)
        {
            Random random = new Random();
            int TrajanjeBitke = random.Next(10,46);
            Prodavnica prodavnica = new Prodavnica();
            Console.WriteLine($"\nBitka pocinje! Trajanje bitke: {TrajanjeBitke} sekundi");

            for(int i = 0; i< TrajanjeBitke; i++)
            {
                //random uzima heroje iz oba tima
                Heroj PlaviHeroj = plaviTim[random.Next(plaviTim.Count)];
                Heroj CrveniHeroj = crveniTim[random.Next(crveniTim.Count)];

                //simuliranje napada 
                int napadNaCrvenog = PlaviHeroj.JacinaNapada;
                int napadNaPlavog = CrveniHeroj.JacinaNapada;

                CrveniHeroj.BrZivotnihPoena -= napadNaCrvenog;
                PlaviHeroj.BrZivotnihPoena -= napadNaPlavog;

                Console.WriteLine($"\n{PlaviHeroj.NazivHeroja} je napao {CrveniHeroj.NazivHeroja} i napravio stetu {napadNaCrvenog}");
                Console.WriteLine($"\n{CrveniHeroj.NazivHeroja} je napao {PlaviHeroj.NazivHeroja} i napravio stetu {napadNaPlavog}"); 

                if(CrveniHeroj.BrZivotnihPoena<0)
                {
                    Console.WriteLine($"\n{CrveniHeroj.NazivHeroja} je porazen! {PlaviHeroj.NazivHeroja} je osvojio 300 zlatnih novcica");
                    PlaviHeroj.StanjeNovcica += 300;
                    crveniTim.Remove(CrveniHeroj);
                }

                if (PlaviHeroj.BrZivotnihPoena < 0)
                {
                    Console.WriteLine($"\n{PlaviHeroj.NazivHeroja} je porazen! {CrveniHeroj.NazivHeroja} je osvojio 300 zlatnih novcica");
                    CrveniHeroj.StanjeNovcica += 300;
                    plaviTim.Remove(PlaviHeroj);
                } 
                if(pomocniEntiteti.Count>0)
                {
                    PomocniEntitet ciljEntitet = pomocniEntiteti[random.Next(pomocniEntiteti.Count)];
                    int stetaNaEntitet = random.Next(10, 50);

                    ciljEntitet.ZivotniPoeni -= stetaNaEntitet;

                    Console.WriteLine($"{PlaviHeroj.NazivHeroja} napada pomocni entitet {ciljEntitet.NazivEntiteta} i nanosi {stetaNaEntitet} stete.");

                    if (ciljEntitet.ZivotniPoeni <= 0)
                    {
                        int nagrada = random.Next(20, 91);
                        PlaviHeroj.StanjeNovcica += nagrada;
                        Console.WriteLine($"Pomocni entitet {ciljEntitet.NazivEntiteta} je eliminisan! {PlaviHeroj.NazivHeroja} osvaja {nagrada} zlatnih novcica.");
                        pomocniEntiteti.Remove(ciljEntitet);
                    }

                }
                if(PlaviHeroj.StanjeNovcica >= 500)
                {
                    // Направите инстанцу продавнице
                    

                    // Филтрирајте доступне предмете (они са доступном количином > 0)
                    List<Predmet> dostupniPredmeti = prodavnica.ListaOiN.Where(p => p.DostupnaKolicina > 0).ToList();

                    if (dostupniPredmeti.Count > 0)
                    {
                        // Изаберите насумични предмет из доступних
                        Random rand = new Random();
                        Predmet predmetZaKupovinu = dostupniPredmeti[rand.Next(dostupniPredmeti.Count)];

                        // Покрените куповину
                        ProdavnicaServis prodavnicaServis = new ProdavnicaServis();
                        bool uspehKupovine = prodavnicaServis.KupiPredmet(PlaviHeroj, prodavnica, predmetZaKupovinu.NazivPredmeta);

                        // Испис резултата куповине
                        if (uspehKupovine)
                        {
                            Console.WriteLine($"{PlaviHeroj.NazivHeroja} je uspesno kupio {predmetZaKupovinu.NazivPredmeta}!");
                        }
                        else
                        {
                            Console.WriteLine($"{PlaviHeroj.NazivHeroja} nije uspeo da kupi {predmetZaKupovinu.NazivPredmeta}.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Nema dostupnih predmeta za kupovinu u prodavnici");
                    }

                } 
                if(CrveniHeroj.StanjeNovcica >= 500)
                {
                    // Направите инстанцу продавнице
                    

                    // Филтрирајте доступне предмете (они са доступном количином > 0)
                    List<Predmet> dostupniPredmeti = prodavnica.ListaOiN.Where(p => p.DostupnaKolicina > 0).ToList();

                    if (dostupniPredmeti.Count > 0)
                    {
                        // Изаберите насумични предмет из доступних
                        Random rand = new Random();
                        Predmet predmetZaKupovinu = dostupniPredmeti[rand.Next(dostupniPredmeti.Count)];

                        // Покрените куповину
                        ProdavnicaServis prodavnicaServis = new ProdavnicaServis();
                        bool uspehKupovine = prodavnicaServis.KupiPredmet(CrveniHeroj, prodavnica, predmetZaKupovinu.NazivPredmeta);

                        // Испис резултата куповине
                        if (uspehKupovine)
                        {
                            Console.WriteLine($"{CrveniHeroj.NazivHeroja} je uspesno kupio {predmetZaKupovinu.NazivPredmeta}!");
                        }
                        else
                        {
                            Console.WriteLine($"{CrveniHeroj.NazivHeroja} nije uspeo da kupi {predmetZaKupovinu.NazivPredmeta}.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Nema dostupnih predmeta za kupovinu u prodavnici");
                    }
                    
                }
                if (crveniTim.Count == 0 || plaviTim.Count == 0)
                {
                    Console.WriteLine("\nBitka je gotova!");
                    if (crveniTim.Count == 0)
                        Console.WriteLine("\nPobedio je plavi tim!");
                    else
                        Console.WriteLine("\nPobedio je crveni tim!");

                    break; // Prekid simulacije čim jedan tim izgubi sve članove
                }

            }
            

            return (plaviTim, crveniTim, TrajanjeBitke);
        }
    }
}
