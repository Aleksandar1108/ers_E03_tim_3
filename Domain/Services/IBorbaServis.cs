using Domain.Modeli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface IBorbaServis
    {
        (List<Heroj> plaviTim, List<Heroj> crveniTim, int brojPobeda) BorbaHeroja(Mape mapa,List<Heroj> plaviTim, List<Heroj> crveniTim, List<PomocniEntitet> pomocniEntiteti, List<Predmet> predmeti);
    }
}

