using proiect_pssc.Comenzi;
using proiect_pssc.Evenimente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace IterfataUtilizator.App_Start
{
    public class DDDconfig
    {
        public void config()
        {
            MagistralaComenzi.Instanta.Value.InregistreazaProcesatoareStandard();
            MagistralaEvenimente.Instanta.Value.InregistreazaProcesatoareStandard();
            MagistralaEvenimente.Instanta.Value.InchideInregistrarea();
        }
    }
}