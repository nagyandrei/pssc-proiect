using Model.Masina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiect_pssc.Evenimente
{
    public class ProcesatorAdaugaMasina : ProcesatorEveniment
    {
        public override void Proceseaza(Eveniment e)
        {
           //var masina = e.ToGeneric<Masina>();
            var repo = new WriteRepository();
            repo.SalvareEvenimente(e);
          //  Console.WriteLine(masina.ToString());
          //to be implemented
        }
    }
}
