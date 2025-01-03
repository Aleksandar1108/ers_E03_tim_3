using Domain.Modeli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface ITimoviServis
    {
        (List<Heroj> PlaviTim, List<Heroj> CrveniTim) KreirajTimove(int maxBrojIgraca, List<Heroj> heroji);
    }
}
