using Domain.Repozitorijum.IRepozitorijum;
using Domain.Repozitorijum.RepozitorijumHeroji;
using Domain.Repozitorijum.IRepozitorijum.IHerojRepozitorijum;
using Domain.Enumeracija;
using Domain.Modeli;
using Domain.Repozitorijum;
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
        }
    }
}
