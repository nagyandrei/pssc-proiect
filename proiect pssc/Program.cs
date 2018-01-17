using AdministratorParc;
using Model.Generic;
using Model.Masina;
using proiect_pssc.Comenzi;
using proiect_pssc.Evenimente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiect_pssc
{
    class Program
    {
        static void Main(string[] args)
        {
            MagistralaComenzi.Instanta.Value.InregistreazaProcesatoareStandard();
            MagistralaEvenimente.Instanta.Value.InregistreazaProcesatoareStandard();
            MagistralaEvenimente.Instanta.Value.InchideInregistrarea();

            



            var readRepo = new ReadRepository();
            var writeRepo = new WriteRepository();

            
           
        }
    }
}
