using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Modeli
{
    public class PomocniEntitet 
    {
        public string NazivEntiteta { get; set; } = "";

        public int VrednostEntiteta { get; set; } = 0;

        public int ZivotniPoeni { get; set; } = 0;

        public PomocniEntitet() { }

        public PomocniEntitet(string nazivEntiteta, int vrednostEntiteta, int zivotniPoeni)
        {
            NazivEntiteta = nazivEntiteta;
            VrednostEntiteta = vrednostEntiteta;
            ZivotniPoeni = zivotniPoeni;
        }


        public override string? ToString()
        {
            return base.ToString();
        }

      
    }
}
