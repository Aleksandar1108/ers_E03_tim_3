using Domain.Modeli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repozitorijum.IRepozitorijum.IProdavnicaRepozitorijum
{
    public interface IProdavnicaRepozitorijum
    {
        IEnumerable<Prodavnica> PregledProdavnice();
    }
}
