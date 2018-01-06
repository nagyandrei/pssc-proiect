using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiect_pssc.Comenzi
{
    public static class MagistralaComenziEx
    {
        public static void InregistreazaProcesatoareStandard(this MagistralaComenzi magistrala)
        {
            magistrala.InregistreazaProcesator(new ProcesatorComandaAdaugaMasina());
            magistrala.InregistreazaProcesator(new ProcesatorComandaCautaMasina());
            magistrala.InregistreazaProcesator(new ProcesatorComandaEditeazaMasina());
            magistrala.InregistreazaProcesator(new ProcesatorComandaRezervaMasina());
            magistrala.InregistreazaProcesator(new ProcesatorComandaStergeMasina());
            magistrala.InregistreazaProcesator(new ProcesatorComandaVindeMasina());
        }
    }
}
