using Domain.Modeli;
using Domain.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Tests.Services.BitkaServis
{
    
    public class BorbaTest
    {
        Mock<IBorbaServis> borbaServis;

        public BorbaTest() => borbaServis = new Mock<IBorbaServis>();

        [Test]
        [TestCase("Warrior",700,150,"Mage",500,200,"Warrior")]
        [TestCase("Assassin",400,250,"Tank",1000,100,"Tank")]
        [TestCase("Archer", 500, 180, "Knight", 500, 180, "Draw")] // Nerešeno

        public void BorbaHeroja_TestRezultataBorbe(string nazivHeroja1,int zivotniPoeni1,int napad1,
                                                   string nazivHeroja2,int zivotniPoeni2,int napad2,string ocekivaniPobednik)
        {

            var heroj1 = new Heroj(nazivHeroja1, zivotniPoeni1, napad1, 0);
            var heroj2 = new Heroj(nazivHeroja2, zivotniPoeni2, napad2, 0);

            borbaServis.Setup(x => x.BorbaHeroja(It.IsAny<Mape>(), It.IsAny<List<Heroj>>(), It.IsAny<List<Heroj>>(), It.IsAny<List<PomocniEntitet>>(), It.IsAny<List<Predmet>>())).Returns((new List<Heroj> { heroj1}, new List<Heroj> { heroj2},1));

            var rezultat = borbaServis.Object.BorbaHeroja(new Mape(), new List<Heroj> { heroj1 }, new List<Heroj> { heroj2 }, new List<PomocniEntitet>(), new List<Predmet>());

            if(ocekivaniPobednik == "Warrior")
            {
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(rezultat.plaviTim[0].NazivHeroja, "Warrior");
            }
            else if(ocekivaniPobednik == "Tank")
            {
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(rezultat.crveniTim[0].NazivHeroja, "Tank");
            }
            else
            {
                NUnit.Framework.Assert.Equals(rezultat.plaviTim.Count, 0);
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(rezultat.crveniTim.Count, 0);
            }
        }
    }
}
