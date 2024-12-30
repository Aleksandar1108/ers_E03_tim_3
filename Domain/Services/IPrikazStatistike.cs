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
        void Prikazi(string nazMape, List<Heroj> plaviTim, List<Heroj> crveniTim, decimal ukupnaProdaja);
    }
}
