using Domain.Enumeracija;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Modeli
{
    public class Mape
    {
        public string NazivMape { get; set; } = string.Empty;
        public Enumeracija.TipMape.Tip TipMape { get; set; }
        public int MaxBrojIgraca { get; set; } = 0;
        public string NazivPlavogTima { get; set; } = string.Empty;
        public string NazivCrvenogTima { get; set; } = string.Empty;
        public int BrPomocnihEntiteta { get; set; } = 0;



        public Mape() { }

        public Mape(string nazm, Enumeracija.TipMape.Tip tm, int mbi, string nPt, string nCt, int brpE)
        {
            NazivMape = nazm;
            TipMape = tm;
            MaxBrojIgraca = mbi;
            NazivPlavogTima = nPt;
            NazivCrvenogTima = nCt; 
            BrPomocnihEntiteta = brpE;
        }

        public override string? ToString()
        {
            return "\nNaziv mape: " + NazivMape + 
                   "\nTip mape: " + TipMape + 
                   "\nMaksimalan broj igraca: " + MaxBrojIgraca + 
                   "\nNaziv plavog tima: " + NazivPlavogTima + 
                   "\nNaziv crvenog tima: " +NazivCrvenogTima + 
                   "\nBroj pomocnih entiteta: " + BrPomocnihEntiteta;
        }
    }


    


}
