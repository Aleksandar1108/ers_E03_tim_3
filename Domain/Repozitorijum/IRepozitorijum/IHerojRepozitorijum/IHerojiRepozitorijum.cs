using Domain.Modeli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repozitorijum.IRepozitorijum.IHerojRepozitorijum
{
    public interface IHerojiRepozitorijum
    {
        public bool DodajHeroja(Heroj hero);

        public Heroj PronadjiHeroja(string naziv);

        public void IspisiHeroje();

        public List<Heroj> pregledHeroja();
    }
}
