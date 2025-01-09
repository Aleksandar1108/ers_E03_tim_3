using Domain.Enumeracija;
using Domain.Modeli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repozitorijum.IRepozitorijum.IMapaRepozitorijum
{
    public interface IMapaRepozitorijum
    {
        IEnumerable<TipMape.Tip> PregledMapa();

        public void DodajMapu(TipMape.Tip tipMape);

        public void InicijalizujMape();
    }
}
