using Domain.Modeli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repozitorijum.IRepozitorijum.INapitciRepozitorijum
{
    public interface INapitciRepozitorijum
    {
        public bool DodajNapitak(Napitak napitak);
        public Napitak PronadjiNapitak(string nazivNapitka);


    }
}
