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
    public class TestHeroj
    {
        [Test]
        [TestCase("Pudge",900,210,300)]
        [TestCase("Phantom Assasin",100,25,400)]
        [TestCase("Hog Rider",100,25,400)]

        public void KonstruktorHerojaOkej(string naziv,int zivotniPoeni,int napad,int zlatniNovcici)
        {
            Heroj heroj = new Heroj(naziv,zivotniPoeni,napad,zlatniNovcici);

            NUnit.Framework.Assert.That(heroj, Is.Not.Null);
            NUnit.Framework.Assert.That(heroj.NazivHeroja, Is.EqualTo(naziv));
            NUnit.Framework.Assert.That(heroj.BrZivotnihPoena, Is.EqualTo(zivotniPoeni));
            NUnit.Framework.Assert.That(heroj.JacinaNapada, Is.EqualTo(napad));
            NUnit.Framework.Assert.That(heroj.StanjeNovcica, Is.EqualTo(zlatniNovcici));
        }
    }
}
