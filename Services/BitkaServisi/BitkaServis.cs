using Domain.Modeli;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Services.BitkaServisi
{
    public class BitkaServis : IServisBitka
    {

        public bool NapadniHeroja(Heroj napadac, Heroj zrtva)
        {
            try
            {
                zrtva.BrZivotnihPoena -= napadac.JacinaNapada;
                if(zrtva.BrZivotnihPoena <= 0)
                {
                    zrtva.BrZivotnihPoena = 0;
                    napadac.StanjeNovcica += 300;
                }
            }catch(Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            return true;
        }

        public bool NapadniPomocniEntitet(Heroj napadac, PomocniEntitet entitet)
        {
            try
            {
                entitet.ZivotniPoeni -= napadac.JacinaNapada;
                if(entitet.ZivotniPoeni <= 0)
                {
                    entitet.ZivotniPoeni = 0;
                    
                    int vrednost = Math.Clamp(entitet.VrednostEntiteta, 20, 90);
                    napadac.StanjeNovcica += vrednost;
                }
            }catch (Exception e) 
            {
                Console.WriteLine(e);
               
                return false;
            }
            return true;
        }
    }
}
