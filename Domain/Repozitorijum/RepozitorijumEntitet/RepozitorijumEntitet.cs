﻿using Domain.Modeli;
using Domain.Repozitorijum.IRepozitorijum.IEntitetRepozitorijum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain.Repozitorijum.RepozitorijumEntitet
{
    public class RepozitorijumEntitet : IEntitetRepozitorijum
    {
        public static List<PomocniEntitet> entiteti = [];

        static RepozitorijumEntitet()
        {
            entiteti = [
                new PomocniEntitet("Crni minion", 30, 50),
                new PomocniEntitet("Plavi minion", 30, 50),
                new PomocniEntitet("Kula", 90, 450),
                new PomocniEntitet("Orao", 50, 250),
                new PomocniEntitet("Sova", 40, 150),
                new PomocniEntitet("Cudoviste", 90, 500),
                ];
        }

        public bool DodajEntitet(PomocniEntitet entitet)
        {
            foreach(PomocniEntitet en in entiteti)
            {
                if(en.NazivEntiteta == entitet.NazivEntiteta)
                {
                    return false;
                }
            }
            entiteti.Add(entitet);
            return true;
        }

        public PomocniEntitet PronadjiEntitet(string naziv)
        {
            foreach(PomocniEntitet e in entiteti)
            {
                if(e.NazivEntiteta == naziv)
                {
                    return e;
                }
            }
            return new PomocniEntitet();
        }

        public void IspisiEntitet()
        {
            foreach(PomocniEntitet e in entiteti)
            {
                Console.WriteLine($"Naziv: {e.NazivEntiteta} Vrednost: {e.VrednostEntiteta} Zivotni Poeni: {e.ZivotniPoeni}\n");
            }
        }

        public List<PomocniEntitet> PregledPomocnihEntiteta()
        {
            return entiteti;
        }
    }
}
