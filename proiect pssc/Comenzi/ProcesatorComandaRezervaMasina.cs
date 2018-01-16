using Model.Masina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiect_pssc.Comenzi
{
    public class ProcesatorComandaRezervaMasina : ProcesatorComandaGeneric<ComandaRezervaMasina>
    {
        public override void Proceseaza(ComandaRezervaMasina comanda)
        {
            Masina masina = new Masina();
            masina.RezevaMasina(comanda.Masina);
        }
    }
}
