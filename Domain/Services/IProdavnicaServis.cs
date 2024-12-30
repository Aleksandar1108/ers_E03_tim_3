using Domain.Modeli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface IProdavnicaServis
    {
        public bool KupiOruzje(Heroj h, Prodavnica p, string naziv);

        public bool KupiNapitak(Heroj h, Prodavnica p, string naziv);
    }
}
