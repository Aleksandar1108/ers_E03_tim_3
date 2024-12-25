using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Modeli;
using Domain.Services; 

namespace Presentation.AutentifikacijaPrezentacija
{
    public class AutentifikacijaPrezentacija
    {
        private readonly IServisAutentifikacije autentifikacioni_servis; 

        public AutentifikacijaPrezentacija(IServisAutentifikacije autentifikacioniServis)
        {
            autentifikacioni_servis = autentifikacioniServis;
        } 

        public void Prijava()
        {
            bool prijava = true;
            string KorisnickoIme;
            string Lozinka;
            do
            {
                Console.WriteLine("\nUnesite korisnicko ime: ");
                KorisnickoIme = Console.ReadLine();
                Console.WriteLine("\nUnesite lozinku: "); 
                Lozinka = Console.ReadLine();

                bool uspesno; 
                Korisnik k = new Korisnik(); 

                (uspesno, k) = autentifikacioni_servis.Prijava(KorisnickoIme, Lozinka);  
                if(uspesno)
                {
                    Console.WriteLine($"\nUspesno ste se prijavili! \nVase korisnicko ime je: {k.KorisnickoIme} \nDobro dosli u igru");
                    prijava = true;
                } 
                else
                {
                    Console.WriteLine("\nNeuspesno prijavljivanje, proverite ispravnost korisnickog imena ili lozinke.");
                    prijava = false;
                }

            } while (prijava);
        }
    }
}
