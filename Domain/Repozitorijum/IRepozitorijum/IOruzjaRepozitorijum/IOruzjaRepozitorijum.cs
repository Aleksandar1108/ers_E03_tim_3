using Domain.Modeli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repozitorijum.IRepozitorijum.IOruzja
{
    public interface IOruzjaRepozitorijum
    {
        public bool DodajOruzje(Oruzje oruzje);
        public Oruzje PronadjiOruzje(string NazivOruzja);
    }
}
