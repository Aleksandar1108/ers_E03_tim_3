using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Modeli
{
    public class Heroj
    {
        public string nazivHeroja { get; set; } = string.Empty;

        public int brZivotnihPoena { get; set; } = 0;

        public int jacinaNapada { get; set; } = 0;

        public int stanjeNovcica {  get; set; } = 0;

        public Heroj() { }

        public Heroj(string nazH,int brZP, int jN, int stN)
        {
            nazivHeroja = nazH;
            brZivotnihPoena = brZP;
            jacinaNapada = jN;
            stanjeNovcica = stN;
        }

        public override string? ToString()
        {
            return "\nNaziv Heroja: " + nazivHeroja +
                   "\nBroj zivotnih poena: " + brZivotnihPoena +
                   "\nJacina napada u zivotnim poena: " + jacinaNapada +
                   "\nTrenutno stanje: " + stanjeNovcica;
        }
    }
}
