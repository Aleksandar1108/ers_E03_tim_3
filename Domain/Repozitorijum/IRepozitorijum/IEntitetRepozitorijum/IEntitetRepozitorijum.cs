using Domain.Modeli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repozitorijum.IRepozitorijum.IEntitetRepozitorijum
{
    public interface IEntitetRepozitorijum
    {
        public bool DodajEntitet(PomocniEntitet entitet);

        public PomocniEntitet PronadjiEntitet(string naziv);

        public void IspisiEntitet();
    }
}
