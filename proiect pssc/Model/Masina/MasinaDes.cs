using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiect_pssc.Model.Masina
{
    public class MasinaDes
    {
        public class Marca
        {
            public string Text { get; set; }
        }

        public class An
        {
            public string Text { get; set; }
        }

        public class Kilometraj
        {
            public string Text { get; set; }
        }

        public class Descriere
        {
            public string Text { get; set; }
        }

        public class Motorizare
        {
            public string Text { get; set; }
        }

        public class Culoare
        {
            public string Text { get; set; }
        }

        public class CapacitateCilindrica
        {
            public string Text { get; set; }
        }

        public class RootObject
        {
            public string Id { get; set; }
            public int Tip { get; set; }
            public Marca Marca { get; set; }
            public An An { get; set; }
            public Kilometraj Kilometraj { get; set; }
            public Descriere Descriere { get; set; }
            public Motorizare Motorizare { get; set; }
            public Culoare Culoare { get; set; }
            public object Putere { get; set; }
            public CapacitateCilindrica CapacitateCilindrica { get; set; }
            public int stare { get; set; }
            public List<object> EvenimenteNoi { get; set; }
        }
    }
}
