using Domain.Modeli;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Domain
{
    [TestFixture]
    public class TestKorisnik
    {
        [Test]
        [TestCase("David", "54321")]
        [TestCase("Aleksandar","123445")]
        [TestCase("Pera","123")]

        public void KonstruktorOkej(string korisnickoIme,string lozinka)
        {
            Korisnik korisnik = new(korisnickoIme, lozinka);

            //provera da li je ocekivani rezultat jednak rezultatu testa
            NUnit.Framework.Assert.That(korisnik,Is.Not.Null);
            NUnit.Framework.Assert.That(korisnik.KorisnickoIme,Is.EqualTo(korisnickoIme));
            NUnit.Framework.Assert.That(korisnik.Lozinka,Is.EqualTo(lozinka));
            
        }
    }
}
