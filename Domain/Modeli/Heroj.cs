using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Modeli
{
    public class Heroj
    {
        public string NazivHeroja { get; set; } = string.Empty;

        public int BrZivotnihPoena { get; set; } = 0;

        public int JacinaNapada { get; set; } = 0;

        public int StanjeNovcica { get; set; } = 0;

        public Heroj() { }

        public Heroj(string nazH, int brZP, int jN, int stN)
        {
            NazivHeroja = nazH;
            BrZivotnihPoena = brZP;
            JacinaNapada = jN;
            StanjeNovcica = stN;
        }

        public override string? ToString()
        {
            return "\nNaziv Heroja: " + NazivHeroja +
                   "\nBroj zivotnih poena: " + BrZivotnihPoena +
                   "\nJacina napada u zivotnim poena: " + JacinaNapada +
                   "\nTrenutno stanje: " + StanjeNovcica;
        }
    }
}
