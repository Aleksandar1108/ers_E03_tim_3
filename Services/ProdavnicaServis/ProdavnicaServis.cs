using Domain.Modeli;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ProdavnicaServis
{
    public class ProdavnicaServis : IProdavnicaServis
    {
        public ProdavnicaServis() { }
        public bool KupiNapitak(Heroj h, Prodavnica p, string naziv)
        {
            foreach(Oruzje oruzje in p.Oruzja)
            {
                if(naziv == oruzje.NazivOruzja)
                {
                    if(h.StanjeNovcica >= oruzje.CenaKomada && oruzje.DostupnaKolicina > 0 )
                    {
                        h.StanjeNovcica -= oruzje.CenaKomada;
                        oruzje.DostupnaKolicina--;
                        h.JacinaNapada += oruzje.PojacaniPoeniZaNapad;
                        return true;

                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        public bool KupiOruzje(Heroj h, Prodavnica p, string naziv)
        {
            foreach(Napitak napitak in p.Napici)
            {
                if(naziv == napitak.NazivNapitka)
                {
                    if(h.StanjeNovcica >= napitak.CenaKomada && napitak.DostupnaKolicina >0)
                    {
                        h.StanjeNovcica -= napitak.CenaKomada;
                        napitak.DostupnaKolicina--;
                        h.JacinaNapada += napitak.Bppn;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }    
            }
            return false;
        }
        
    }
    
}
