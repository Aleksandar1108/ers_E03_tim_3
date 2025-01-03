using Domain.Repozitorijum.IRepozitorijum;
using Domain.Repozitorijum.RepozitorijumHeroji;
using Domain.Repozitorijum.IRepozitorijum.IHerojRepozitorijum;
using Domain.Enumeracija;
using Domain.Modeli;
using Domain.Repozitorijum;
using Domain.Repozitorijum.RepozitorijumOruzje;
using Domain.Repozitorijum.RepozitorijumNapitci;
using Presentations.AutentifikacijaPrezentacije;
using Domain.Services;
using Presentations.IpsisMenija;
using Presentations.MeniZaStatistiku;
using Domain.NasumicnaGenerisanja;
using Domain.Repozitorijum.IRepozitorijum.IEntitetRepozitorijum;
using Domain.Repozitorijum.IRepozitorijum.IMapaRepozitorijum;
using Domain.Repozitorijum.IRepozitorijum.IProdavnicaRepozitorijum;

namespace Application
{
    public class Program
    {
         static void Main(string[] args)
        {
            Mape mapa = new Mape("naziv",TipMape.Tip.ZIMSKA, 10,"npt", "nct",4); // Pretpostavimo da ima podrazumevani konstruktor
            Prodavnica prodavnica = new Prodavnica();
            List<Heroj> plaviTim = new List<Heroj>();
            List<Heroj> crveniTim = new List<Heroj>();
            // IHerojiRepozitorijum herojRep = null; // Trebaš konkretan objekat koji implementira ovaj interfejs
            // IPrikazStatistike prikaz; 
            // IPrikazStatistikeDatoteka prikazDa;
            //MeniZaStatistiku meniZaStatistiku = new MeniZaStatistiku(prikaz, prikazDa); // Pretpostavka o konstruktoru

            // Kreiranje instance klase IspisMenia
            //IspisMenia ispisMenia = new IspisMenia(mapa, prodavnica, plaviTim, crveniTim, herojRep, meniZaStatistiku);

            // Poziv metode PrikaziMeni
            //ispisMenia.PrikaziMeni();




       




        }
    }
}
