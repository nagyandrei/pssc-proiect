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

            var masina = new Masina(new PlainText("19"),TipMasina.Berlina,new PlainText("Opel"),new PlainText("2031"),new PlainText("200k+"),new PlainText("1.9tdi"),
                                    new PlainText("1986"),new PlainText("300cp"),new PlainText("rosu"),new PlainText("nu bate nu trocane"));

            var admin = new Administrator(new PlainText("bonny"),new PlainText("lash"));

            var comandaAdaugaMasina = new ComandaAdaugaMasina();
            comandaAdaugaMasina.Masina1 = masina;
            MagistralaComenzi.Instanta.Value.Trimite(comandaAdaugaMasina);

            //var comandaStergereMasina = new ComandaStergeMasina();
            //MagistralaComenzi.Instanta.Value.Trimite(comandaStergereMasina);


            //var comandaCautareMasina = new ComandaCautaMasina();
            //MagistralaComenzi.Instanta.Value.Trimite(comandaCautareMasina);



            var readRepo = new ReadRepository();
            var writeRepo = new WriteRepository();

            //var comandaRezervaMasina = new ComandaRezervaMasina();
            //var masina1 = new Masina();
            //comandaRezervaMasina.Masina = masina1;
            //comandaRezervaMasina.IdRadacina = "19";
            //MagistralaComenzi.Instanta.Value.Trimite(comandaRezervaMasina);

            //   var gasit=readRepo.UpdateMasina("19");
          
            //var read = new Receive();
            //read.PrimesteEveiment();

           // Console.WriteLine(gasit);
            Console.ReadKey();
           
        }
    }
}
