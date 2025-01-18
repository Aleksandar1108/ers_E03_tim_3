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
    public class TestOruzje
    {
        [Test]
        [TestCase("Noz",70,17,14)]
        [TestCase("Buzdovan",90,18,10)]
        [TestCase("Bomba",165,15,10)]

        public void KonstruktorOruzjeOkej(string naziv,int cena,int pojaciPoeni,int dostupnaKolicina)
        {
            Oruzje oruzje = new Oruzje(naziv,cena,pojaciPoeni,dostupnaKolicina);
            NUnit.Framework.Assert.That(oruzje, Is.Not.Null);
            NUnit.Framework.Assert.That(oruzje.NazivOruzja, Is.EqualTo(naziv));
            NUnit.Framework.Assert.That(oruzje.CenaKomada, Is.EqualTo(cena));
            NUnit.Framework.Assert.That(oruzje.PojacaniPoeniZaNapad, Is.EqualTo(pojaciPoeni));
            NUnit.Framework.Assert.That(oruzje.DostupnaKolicina, Is.EqualTo(dostupnaKolicina));
        }
    }
}
