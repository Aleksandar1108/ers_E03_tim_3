using Domain.Modeli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface IServisAutentifikacije
    {
        public (bool, Korisnik) Prijava(string korisnickoIme, string lozinka);
    }
}
