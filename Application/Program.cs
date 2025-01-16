﻿using Domain.Repozitorijum.IRepozitorijum;
using Domain.Repozitorijum.RepozitorijumHeroji;
using Domain.Repozitorijum.IRepozitorijum.IHerojRepozitorijum;
using Domain.Enumeracija;
using Domain.Modeli;
using Domain.Repozitorijum;
using Domain.Repozitorijum.RepozitorijumOruzje;
using Domain.Repozitorijum.RepozitorijumNapitci;
//using Presentations.AutentifikacijaPrezentacije;
using Domain.Services;
using Presentations.IpsisMenija;
using Presentations.MeniZaStatistiku;
using Domain.NasumicnaGenerisanja;
using Domain.Repozitorijum.IRepozitorijum.IEntitetRepozitorijum;
using Domain.Repozitorijum.IRepozitorijum.IMapaRepozitorijum;
using Domain.Repozitorijum.IRepozitorijum.IProdavnicaRepozitorijum;
using Domain.Repozitorijum.AutentifikacioniServis;
using Domain.Repozitorijum.RepozitorijumMapa;
using Services.PrikazStatistikeKonzolno;
using Services.PrikazStatistikeUFajl;
using Domain.Repozitorijum.RepozitorijumProdavnica;
using Domain.Repozitorijum.RepozitorijumEntitet;
using Services.BitkaServisi;
using Services.TimoviServis;
using Services.ProdavnicaServis;

namespace Application
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Mape mapa = new Mape("naziv",TipMape.Tip.ZIMSKA, 10,"npt", "nct",4); // Pretpostavimo da ima podrazumevani konstruktor
            //Prodavnica prodavnica = new Prodavnica();
            //List<Heroj> plaviTim = new List<Heroj>();
            //List<Heroj> crveniTim = new List<Heroj>();
            // IHerojiRepozitorijum herojRep = null; // Trebaš konkretan objekat koji implementira ovaj interfejs
            // IPrikazStatistike prikaz; 
            // IPrikazStatistikeDatoteka prikazDa;
            //MeniZaStatistiku meniZaStatistiku = new MeniZaStatistiku(prikaz, prikazDa); // Pretpostavka o konstruktoru

            // Kreiranje instance klase IspisMenia
            //IspisMenia ispisMenia = new IspisMenia(mapa, prodavnica, plaviTim, crveniTim, herojRep, meniZaStatistiku);

            // Poziv metode PrikaziMeni
            //ispisMenia.PrikaziMeni();


                string?  korisnickoIme = "", lozinka = "";
                Korisnik? prijavljen;

                // Servisi
                IServisAutentifikacije autentifikacijaServis = new AutentifikacioniServis();
                //IZapisiServis servis;
                //ILoggerServis logger = new FileLoggerServis();

                Console.WriteLine("\n============== PRIJAVA ==============");



                AutentifikacioniServis autentifikacioniServis = new AutentifikacioniServis();


            (bool uspesnaAutentifikacija, prijavljen) = autentifikacijaServis.Prijava(korisnickoIme.Trim(), lozinka.Trim());

            while (!uspesnaAutentifikacija)
            {
                if (!string.IsNullOrWhiteSpace(korisnickoIme) && !string.IsNullOrWhiteSpace(lozinka))
                {
                    Console.WriteLine("Prijava nije uspela. Proverite korisničko ime i lozinku.");
                }

                Console.Write("Korisničko ime: ");
                korisnickoIme = Console.ReadLine() ?? "";

                Console.Write("Lozinka: ");
                lozinka = Console.ReadLine() ?? "";
            }

            // Kada je prijava uspešna
            Console.WriteLine($"Korisnik '{korisnickoIme}' je uspešno prijavljen!");

            Mape mapa = new Mape();
            Prodavnica prodavnica = new Prodavnica();
            List<Heroj> plaviTim = new List<Heroj>();
            List<Heroj> crveniTim = new List<Heroj>();
            IPrikazStatistike prikazStatistikeKonzolono = new PrikazStatistikeKonzolno();
            IPrikazStatistikeDatoteka prikazStatistikeDatoteke = new PrikazStatistikeDatoteke("statistika.txt");
            IHerojiRepozitorijum herojRepozitorijum = new RepozitorijumHeroji();
            MeniZaStatistiku meniZaStatistiku = new MeniZaStatistiku(prikazStatistikeKonzolono,prikazStatistikeDatoteke);
            NasumicnoGenerisanjeMape nasumicnoGenMape = new NasumicnoGenerisanjeMape();
            //IMapaRepozitorijum mapaRep = new RepozitorijumMapa();
            RepozitorijumMapa mapaRep = new RepozitorijumMapa();
            NasumicnoGenerisanjeProdavnice nasumicnoGenProd = new NasumicnoGenerisanjeProdavnice();
            IProdavnicaRepozitorijum prodavnicaRep = new RepozitorijumProdavnica();
            ITimoviServis timoviServis = new TimoviServis();
            IBorbaServis borbaServis = new BitkaServis();
            IEntitetRepozitorijum pomocniEntitet = new RepozitorijumEntitet();
            IProdavnicaServis prodavnicaServis = new ProdavnicaServis();
            IspisMenia ispis = new IspisMenia(mapa, prodavnica, plaviTim, crveniTim, herojRepozitorijum, meniZaStatistiku, nasumicnoGenMape, mapaRep, nasumicnoGenProd, prodavnicaRep, timoviServis,borbaServis,pomocniEntitet, prodavnicaServis );

            ispis.PrikaziMeni();
        }

    }
    
}
