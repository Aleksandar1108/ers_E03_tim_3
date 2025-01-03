using Domain.Modeli;
using Domain.NasumicnaGenerisanja;
using Domain.Repozitorijum.IRepozitorijum.IEntitetRepozitorijum;
using Domain.Repozitorijum.IRepozitorijum.IHerojRepozitorijum;
using Domain.Repozitorijum.IRepozitorijum.IMapaRepozitorijum;
using Domain.Repozitorijum.IRepozitorijum.IProdavnicaRepozitorijum;
using Domain.Repozitorijum.RepozitorijumHeroji;
using Domain.Repozitorijum.RepozitorijumProdavnica;
using Domain.Services;
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
        Mape mapa;
        Prodavnica prodavnica;
        private readonly NasumicnoGenerisanjeMape nasumicnoGenerisanjeMape;
        private readonly NasumicnoGenerisanjeProdavnice nasumicnoGenerisanjeProdavnice;
        private readonly IProdavnicaRepozitorijum prodavnicaRepozitorijum;
        private readonly IMapaRepozitorijum mapaRepozitorijum;
        public List<Heroj> PlaviTim = new List<Heroj>();
        public List<Heroj> CrveniTim = new List<Heroj>();
        private readonly IHerojiRepozitorijum herojRep;
        private readonly ITimoviServis timoviServis;
        IEntitetRepozitorijum pomocniEntitet;
        private readonly IBorbaServis servis;
        //interfejs za tabelrani prikaz 
        private List<Predmet> predmeti = new List<Predmet>();
        private readonly Presentations.MeniZaStatistiku.MeniZaStatistiku meniZaStatistiku;

        public IspisMenia(Mape mapa, Prodavnica prodavnica, List<Heroj> plaviTim, List<Heroj> crveniTim, IHerojiRepozitorijum herojRep, MeniZaStatistiku.MeniZaStatistiku meniZaStatistiku, NasumicnoGenerisanjeMape nasumicnoGenerisanjeMape, IMapaRepozitorijum mapaRepozitorijum,NasumicnoGenerisanjeProdavnice nasumicnoGenerisanjeProdavnice,IProdavnicaRepozitorijum prodavnicaRepozitorijum,ITimoviServis timoviServis,IBorbaServis servis,IEntitetRepozitorijum pomocniEntitet)
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
                        mapa = NasumicnoGenerisanjeMape.GenerisiNasumicnuMapu(mapaRepozitorijum.PregledMapa().ToList());
                        prodavnica = NasumicnoGenerisanjeProdavnice.GenerisiProdavnicu(prodavnicaRepozitorijum.PregledProdavnice().ToList());
                        predmeti = prodavnica.IspisiDostupneNapitkeIOruzja();
                        (PlaviTim, CrveniTim) = timoviServis.KreirajTimove(maxBrojIgraca, herojRep.pregledHeroja().ToList());
                        Console.WriteLine("\nPodaci su uspesno izgenerisani");
                        break;
                    case '3':
                        List<Heroj> plavi = new List<Heroj>();
                        List<Heroj> crveni = new List<Heroj>();
                        int q = 0;
                        Console.WriteLine("\nBitka pocinje!");
                        (plavi,crveni,q) = servis.BorbaHeroja(mapa,PlaviTim, CrveniTim, pomocniEntitet.PregledPomocnihEntiteta().ToList(), predmeti);

                        meniZaStatistiku.MeniStatistika(mapa, plavi, crveni, q);

                        break;
                    default:
                        Console.WriteLine("\nNeispravan unos, pokusajte ponovo!\n");
                        break;
                        
                }

            }
        }

    }
}
