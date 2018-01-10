using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiect_pssc.Evenimente
{
    public class ProcesatorEditeazaMasina : ProcesatorEveniment
    {
        public override void Proceseaza(Eveniment e)
        {
            var repo = new WriteRepository();
            repo.SalvareEvenimente(e);
        }
    }
}
