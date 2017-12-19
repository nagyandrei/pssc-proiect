using Model.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Masina
{
    public class Masina
    {
        public TipMasina Tip { get; private set; }
        public PlainText Marca { get; private set; }
        public PlainText An { get; private set; }
        public PlainText Kilometraj { get; private set; }
        public PlainText Descriere { get; private set; }
        public PlainText Motorizare { get; private set; }
        public PlainText Culoare { get; private set; }
        public PlainText Putere { get; private set; }
        public PlainText CapacitateCilindrica { get; private set; }
        public Masina(TipMasina tip, PlainText marca, PlainText an, PlainText km, PlainText motorizare, PlainText cc, PlainText putere, PlainText culoare, PlainText descriere)
        {
            Tip = tip;
            Marca = marca;
            An = an;
            Kilometraj = km;
            Descriere = descriere;
            Motorizare = motorizare;
            CapacitateCilindrica = cc;
            Culoare = culoare;
        }

        public override string ToString()
        {
            return Tip + ", " + Marca + ", " + An + ", " + Kilometraj + ", " + Descriere;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


    }
}
