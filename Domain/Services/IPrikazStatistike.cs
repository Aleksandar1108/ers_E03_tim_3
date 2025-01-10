using Domain.Modeli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface IPrikazStatistike
    {
        void Prikazi(Mape mapa, List<Heroj> plaviTim, List<Heroj> crveniTim, decimal ukupnaProdaja, string nazivPlavogtima, string nazivCrvenogTima);
    }
}
