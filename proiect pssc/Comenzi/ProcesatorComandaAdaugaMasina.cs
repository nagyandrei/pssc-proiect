using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiect_pssc.Comenzi
{
    public class ProcesatorComandaAdaugaMasina:ProcesatorComandaGeneric<ComandaAdaugaMasina>
    {
        public override void Proceseaza(ComandaAdaugaMasina  comanda)
        {
            var repo = new WriteRepository();
           // repo.SalvareEvenimente();
           
        }
    }
}
