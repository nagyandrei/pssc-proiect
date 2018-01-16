using proiect_pssc.Comenzi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiect_pssc.Evenimente
{
    public static class MagistralaEx
    {
        public static void InregistreazaProcesatoareStandard(this MagistralaEvenimente magistrala)
        {
            magistrala.InregistreazaProcesator(TipEveniment.AdaugareMasina, new ProcesatorAdaugaMasina());
            magistrala.InregistreazaProcesator(TipEveniment.RezervaMasina, new ProcesatorRezervaMasina());
        }
    }
}
