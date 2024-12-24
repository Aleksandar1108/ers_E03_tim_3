using Domain.Repozitorijum.IRepozitorijum;
using Domain.Repozitorijum.RepozitorijumHeroji;
using Domain.Repozitorijum.IRepozitorijum.IHerojRepozitorijum;
using Domain.Enumeracija;
using Domain.Modeli;
using Domain.Repozitorijum;
using Domain.Repozitorijum.RepozitorijumOruzje;
using Domain.Repozitorijum.RepozitorijumNapitci;
namespace Application
{
    public class Program
    {
         static void Main(string[] args)
        {
            RepozitorijumHeroji repo = new RepozitorijumHeroji();

            //dodavanje novog heroja
            Heroj noviHero = new Heroj("Thor",750,210, 0);

            bool jeDodato = repo.DodajHeroja(noviHero);

            repo.IspisiHeroje();

            repo.PronadjiHeroja("Rajko");
            repo.PronadjiHeroja("Thor");

            OruzjeRepozitorijum or = new OruzjeRepozitorijum();
            Oruzje novo = new Oruzje("NovoOruzje", 25,15,1);

            bool jeDod = or.DodajOruzje(novo);
            or.PronadjiOruzje("Bomba");
            

            //dodavanje napitka
            RepozitorijumNapitci nap = new RepozitorijumNapitci();

            Napitak napitak = new Napitak("Napitak1",100,20,3);

            bool dodat = nap.DodajNapitak(napitak);


            nap.PronadjiNapitak("Napitak1");
        }
    }
}
