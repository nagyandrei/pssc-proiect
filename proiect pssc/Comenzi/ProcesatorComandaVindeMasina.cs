using Model.Masina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiect_pssc.Comenzi
{
    public class ProcesatorComandaVindeMasina : ProcesatorComandaGeneric<ComandaVindeMasina>
    {
        public override void Proceseaza(ComandaVindeMasina comanda)
        {
            Masina masina = new Masina();
            masina.VindeMasina(comanda.Masina);
        }
    }
}
