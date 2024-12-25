using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Modeli
{
    public class Korisnik
    { 

        public string KorisnickoIme {  get; set; } = string.Empty;
        public string Lozinka {  get; set; } = string.Empty;
        
        public Korisnik() { }

        public Korisnik(string korisnickoIme, string lozinka)
        {
            KorisnickoIme = korisnickoIme;
            Lozinka = lozinka;
        }
    }
}
