using Model.Masina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiect_pssc.Comenzi
{
    public class ProcesatorComandaCautaMasina : ProcesatorComandaGeneric<ComandaCautaMasina>
    {
        public override void Proceseaza(ComandaCautaMasina comanda)
        {
           
            var read = new ReadRepository();
            
            var gasit = read.CautaMasina("18");
           
            
        }
    }
}
