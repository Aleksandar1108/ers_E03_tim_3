using Domain.Modeli;
using Domain.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Tests.Services.AutentifikacioniServisi
{
    public class AutentifikacioniServisiTests
    {
        // Servis koji se lazira
        Mock<IServisAutentifikacije> _authServis;

        // Konstruktor inicijalizator
        public AutentifikacioniServisiTests() => _authServis = new Mock<IServisAutentifikacije>();

        [SetUp]
        public void Setup()
        {
            // Metoda koja priprema podatke pre pokretanja testova
            _authServis = new Mock<IServisAutentifikacije>();
        }

        [Test]
        [TestCase("maja", "123")]
        public void PrijavaSaIspravnimPodacima_VracaTrue(string korisnickoIme, string lozinka)
        {
            // Kreiranje potrebnih promenljivih za test
            var korisnik = new Korisnik(korisnickoIme, lozinka);

            // Priprema Moq-a, koja je ocekivana vrednost koja treba da se vrati
            _authServis.Setup(x => x.Prijava(korisnickoIme, lozinka)).Returns((true, korisnik));

            // Simuliranje ponasanja nad laziranim objektom servisa
            (bool uspesnaAutentifikacija, Korisnik prijavljen) = _authServis.Object.Prijava(korisnickoIme, lozinka);

            // Provera da li je ocekivani rezultat jednak rezultatu testa
            NUnit.Framework.Assert.That(uspesnaAutentifikacija, Is.True);
            NUnit.Framework.Assert.That(prijavljen, Is.Not.Null);
            NUnit.Framework.Assert.That(prijavljen.KorisnickoIme, Is.EqualTo(korisnickoIme));
            NUnit.Framework.Assert.That(prijavljen.Lozinka, Is.EqualTo(lozinka));
        }

        [Test]
        [TestCase("danijel", "123")]
        [TestCase("jovana", "123")]
        public void PrijavaSaNeispravnimPodacima_VracaFalse(string korisnickoIme, string lozinka)
        {
            // Kreiranje potrebnih promenljivih za test
            Korisnik korisnik;

            // Priprema Moq-a, koja je ocekivana vrednost koja treba da se vrati
            _authServis.Setup(x => x.Prijava(korisnickoIme, lozinka)).Returns((false, new Korisnik()));

            // Simuliranje ponasanja nad laziranim objektom servisa
            (bool uspesnaAutentifikacija, korisnik) = _authServis.Object.Prijava(korisnickoIme, lozinka);

            // Provera da li je ocekivani rezultat jednak rezultatu testa
            NUnit.Framework.Assert.That(uspesnaAutentifikacija, Is.False);
            NUnit.Framework.Assert.That(korisnik.KorisnickoIme, Is.Empty);
        }
    }
}
