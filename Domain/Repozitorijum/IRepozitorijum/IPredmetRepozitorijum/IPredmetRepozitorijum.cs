using Domain.Modeli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repozitorijum.IRepozitorijum.IPredmetRepozitorijum
{
    public interface IPredmetRepozitorijum
    {
        public bool DodajPredmet(Predmet predmet);
        public Predmet PronadjiPredmet(string nazivPredmet);
        public List<Predmet> PregledPredmeta();
    }
}
