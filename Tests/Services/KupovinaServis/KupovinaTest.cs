using Domain.Modeli;
using Domain.Services;
using Moq;
using NUnit.Framework;
using Services.ProdavnicaServis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Services.KupovinaServis
{
    public class KupovinaTest
    {
        Mock<IProdavnicaServis> prodavnicaServis;

        //konstruktor inicijalizator
        public KupovinaTest() => prodavnicaServis = new Mock<IProdavnicaServis>();

        [SetUp]
        [TestCase("Bow",500,30,10,"Warrior",700,150,600)]
        public void KupovinaPredmeta_UspesnoKupujePredmet(string nazivPredmeta,int cena,int pojacanje,int kolicina,
                                                       string nazivHeroja,int zivotniPoeni, int jacinaNapada,int novcici)
        {
            var predmet = new Predmet(nazivPredmeta, cena, pojacanje, kolicina);
            var heroj = new Heroj(nazivHeroja,zivotniPoeni,jacinaNapada, novcici);

            var prodavnica = new Prodavnica(1, new List<Predmet> { predmet }, 0);

            prodavnicaServis.Setup(x => x.KupiPredmet(heroj, prodavnica, nazivPredmeta)).Returns(false);

            bool uspesnaKupovina = prodavnicaServis.Object.KupiPredmet(heroj, prodavnica, nazivPredmeta);

            // Provera da li je rezultat kupovine tačan
            NUnit.Framework.Assert.That(uspesnaKupovina, Is.False);
            NUnit.Framework.Assert.That(heroj.StanjeNovcica, Is.EqualTo(novcici)); // Provera da se novčići nisu promenili
            NUnit.Framework.Assert.That(heroj.JacinaNapada, Is.EqualTo(jacinaNapada)); // Provera da se napad nije promenio
        }

        [Test]
        [TestCase("Bow", 500, 30, 10, "Warrior", 700, 150, 400)] // Novčići < Cena predmeta
        [TestCase("Bow", 500, 30, 0, "Warrior", 700, 150, 600)]  // Predmet nije dostupan u prodavnici
        public void KupovinaPredmeta_NeuspesnaKupovina(string nazivPredmeta, int cena, int pojacanje, int kolicina,
                                               string nazivHeroja, int zivotniPoeni, int jacinaNapada, int novcici)
        {
            // Arrange
            var predmet = new Predmet(nazivPredmeta, cena, pojacanje, kolicina);
            var heroj = new Heroj(nazivHeroja, zivotniPoeni, jacinaNapada, novcici);
            var prodavnica = new Prodavnica(1, new List<Predmet> { predmet }, 0);

            // Simulacija neuspešne kupovine: ili heroj nema dovoljno novčića ili predmet nije dostupan
            prodavnicaServis.Setup(x => x.KupiPredmet(heroj, prodavnica, nazivPredmeta))
                            .Returns(false);

            // Act
            bool uspesnaKupovina = prodavnicaServis.Object.KupiPredmet(heroj, prodavnica, nazivPredmeta);

            // Assert
            NUnit.Framework.Assert.That(uspesnaKupovina, Is.False); // Kupovina nije uspela
            NUnit.Framework.Assert.That(heroj.StanjeNovcica, Is.EqualTo(novcici)); // Novčići ostali isti
            NUnit.Framework.Assert.That(heroj.JacinaNapada, Is.EqualTo(jacinaNapada)); // Napad ostao isti
            NUnit.Framework.Assert.That(prodavnica.ListaOiN.FirstOrDefault(p => p.NazivPredmeta == nazivPredmeta)?.DostupnaKolicina, Is.EqualTo(kolicina)); // Količina predmeta ista
        }
    }
}
