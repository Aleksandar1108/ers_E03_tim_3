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
        public bool KupiPredmet(Heroj h, Prodavnica prod, string naziv)
        {
            foreach(Predmet p in prod.ListaOiN)
            {
                if(naziv == p.NazivPredmeta)
                {
                    if(h.StanjeNovcica >= p.CenaKomada && p.DostupnaKolicina > 0 )
                    {
                        h.StanjeNovcica -= p.CenaKomada;
                        p.DostupnaKolicina--;
                        h.JacinaNapada += p.PojacaniPoeniZaNapad;
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
