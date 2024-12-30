using Domain.Modeli;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.StatistikaServis
{
    public class BitkaStatistika 
    {
        private IPrikazStatistike prikaz;

        public BitkaStatistika(IPrikazStatistike prikaz)
        {
            this.prikaz = prikaz;
        }

        public void PrikaziStatistiku(Mape mapa, List<Heroj> plaviTim, List<Heroj> crveniTim,decimal ukupnaProdaja)
        {
            prikaz.Prikazi(mapa,plaviTim,crveniTim,ukupnaProdaja);
        }
    }
}
