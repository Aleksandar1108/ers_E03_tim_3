using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Modeli;
using Domain.Services;
namespace Services.AutentifikacioniServis
{
    public class AutentifikacioniServis:IServisAutentifikacije    
    {
        private static readonly List<Korisnik> korisnici;

        static AutentifikacioniServis()
        {
            korisnici = [
                   new("Aleksandar", "123455"),
                   new("David","54321")
                ];
        }
        public (bool, Korisnik) Prijava(string korisnickoIme, string lozinka)
        {
            foreach(Korisnik kor in korisnici)
            {
                if(kor.KorisnickoIme.Equals(korisnickoIme) && kor.Lozinka.Equals(lozinka))
                {

                    return (true, kor);


                }
            }

            return (false, new Korisnik());

        }
    }
}
