using Model.Masina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiect_pssc.Comenzi
{
    public class ComandaEditeazaMasina:Comanda 
    {
        public Masina Masina { get; set; }
    }
}
