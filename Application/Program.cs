using Domain.Repozitorijum.IRepozitorijum;
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


            string korisnickoIme = "", lozinka = "";
            Korisnik? prijavljen;

            // Servisi
            IServisAutentifikacije autentifikacijaServis = new AutentifikacioniServis();

            Console.WriteLine("\n============== PRIJAVA ==============");

            bool uspesnaAutentifikacija = false;

            while (!uspesnaAutentifikacija)
            {
                Console.Write("Korisničko ime: ");
                korisnickoIme = Console.ReadLine() ?? "";

                Console.Write("Lozinka: ");
                lozinka = Console.ReadLine() ?? "";

                // Pozivamo metodu za proveru prijave
                (uspesnaAutentifikacija, prijavljen) = autentifikacijaServis.Prijava(korisnickoIme.Trim(), lozinka.Trim());

                if (!uspesnaAutentifikacija)
                {
                    Console.WriteLine("Prijava nije uspela. Proverite korisničko ime i lozinku.");
                }
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
