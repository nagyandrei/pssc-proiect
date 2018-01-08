using Model.Masina;
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
            //var repo = new WriteRepository();
            Masina masina = new Masina();
            masina.AdaugaMasina(comanda.Masina1);
           
        }
    }
}
