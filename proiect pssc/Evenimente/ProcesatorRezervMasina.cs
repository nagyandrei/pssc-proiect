using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiect_pssc.Evenimente
{
    public class ProcesatorRezervaMasina : ProcesatorEveniment
    {
        public override void Proceseaza(Eveniment e)
        {

            var repo = new WriteRepository();
            var trimite = new Send();
            trimite.TrimiteMesaj("Masina a fost rezervata");
            repo.SalvareEvenimente(e);

        }
    }
}
