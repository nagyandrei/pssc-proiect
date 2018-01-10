using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiect_pssc.Comenzi
{
    public class ProcesatorComandaStergeMasina : ProcesatorComandaGeneric<ComandaStergeMasina>
    {
        public override void Proceseaza(ComandaStergeMasina comanda)
        {
            var write = new WriteRepository();
            var gasit = write.StergereMasina(comanda.CIV);
           
        }
    }
}
