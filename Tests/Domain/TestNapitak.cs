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
    public class TestNapitak
    {
        [Test]
        [TestCase("Mali napitak", 50, 20, 5)]
        [TestCase("Veliki napitak", 100, 50, 3)]
        [TestCase("Eliksir života", 200, 100, 2)]
        public void KonstruktorNapitakOkej(string naziv, int cena, int povratakPoena, int dostupnaKolicina)
        {
            // Act
            Napitak napitak = new Napitak(naziv, cena, povratakPoena, dostupnaKolicina);

            // Assert
            NUnit.Framework.Assert.That(napitak, Is.Not.Null);
            NUnit.Framework.Assert.That(napitak.NazivNapitka, Is.EqualTo(naziv));
            NUnit.Framework.Assert.That(napitak.Cena, Is.EqualTo(cena));
            NUnit.Framework.Assert.That(napitak.PojacaniPoeniZaNapad , Is.EqualTo(povratakPoena));
            NUnit.Framework.Assert.That(napitak.DostupnaKolicina, Is.EqualTo(dostupnaKolicina));
        }

        [Test]
        public void Napitak_BezNaziva_BacaIzuzetak()
        {
            // Assert
            NUnit.Framework.Assert.Throws<ArgumentException>(() =>
            {
                // Act
                Napitak napitak = new Napitak("", 100, 50, 3);
            }, "Napitak ne sme imati prazan naziv.");
        }

        [Test]
        public void Napitak_SaNegativnomCenom_BacaIzuzetak()
        {
            // Assert
            NUnit.Framework.Assert.Throws<ArgumentException>(() =>
            {
                // Act
                Napitak napitak = new Napitak("Test napitak", -10, 50, 3);
            }, "Cena ne sme biti negativna.");
        }


    }
}
