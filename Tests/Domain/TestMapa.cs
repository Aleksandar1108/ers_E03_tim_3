using Domain.Enumeracija;
using Domain.Modeli;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Domain
{
    public class TestMapa
    {
        [Test]
        public void KonstruktorMapeOkej()
        {
            // Arrange
            string nazivMape = "Battle Arena";
            TipMape.Tip tipMape = TipMape.Tip.ZIMSKA;
            int maxBrojIgraca = 10;
            string nazivPlavogTima = "Blue Team";
            string nazivCrvenogTima = "Red Team";
            int brojPomocnihEntiteta = 5;

            // Act
            Mape mapa = new Mape(nazivMape, tipMape, maxBrojIgraca, nazivPlavogTima, nazivCrvenogTima, brojPomocnihEntiteta);

            // Assert
            NUnit.Framework.Assert.That(mapa, Is.Not.Null);
            NUnit.Framework.Assert.That(mapa.NazivMape, Is.EqualTo(nazivMape));
            NUnit.Framework.Assert.That(mapa.TipMape, Is.EqualTo(tipMape));
            NUnit.Framework.Assert.That(mapa.MaxBrojIgraca, Is.EqualTo(maxBrojIgraca));
            NUnit.Framework.Assert.That(mapa.NazivPlavogTima, Is.EqualTo(nazivPlavogTima));
            NUnit.Framework.Assert.That(mapa.NazivCrvenogTima, Is.EqualTo(nazivCrvenogTima));
            NUnit.Framework.Assert.That(mapa.BrPomocnihEntiteta, Is.EqualTo(brojPomocnihEntiteta));
        }

        [Test]
        public void ToString_VracaIspravanString()
        {
            // Arrange
            string nazivMape = "Battle Arena";
            TipMape.Tip tipMape = TipMape.Tip.ZIMSKA;
            int maxBrojIgraca = 10;
            string nazivPlavogTima = "Blue Team";
            string nazivCrvenogTima = "Red Team";
            int brojPomocnihEntiteta = 5;

            Mape mapa = new Mape(nazivMape, tipMape, maxBrojIgraca, nazivPlavogTima, nazivCrvenogTima, brojPomocnihEntiteta);

            // Act
            var rezultat = mapa.ToString();

            // Assert
            NUnit.Framework.Assert.That(rezultat, Does.Contain("Tip mape: " + tipMape));
            NUnit.Framework.Assert.That(rezultat, Does.Contain("Maksimalan broj igraca: " + maxBrojIgraca));
            NUnit.Framework.Assert.That(rezultat, Does.Contain("Naziv plavog tima: " + nazivPlavogTima));
            NUnit.Framework.Assert.That(rezultat, Does.Contain("Naziv crvenog tima: " + nazivCrvenogTima));
            NUnit.Framework.Assert.That(rezultat, Does.Contain("Broj pomocnih entiteta: " + brojPomocnihEntiteta));
        }
    }
}
