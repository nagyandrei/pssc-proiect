﻿using AdministratorParc;
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

            var masina = new Masina(new Guid(),TipMasina.Berlina,new PlainText("Bonny"),new PlainText("2031"),new PlainText("200k+"),new PlainText("1.9tdi"),
                                    new PlainText("1986"),new PlainText("300cp"),new PlainText("rosu"),new PlainText("nu bate nu trocane"));

            var admin = new Administrator(new PlainText("bonny"),new PlainText("lash"));
            admin.AdaugaMasina(masina);
            var comandaAdaugaMasina = new ComandaAdaugaMasina();
            MagistralaComenzi.Instanta.Value.Trimite(comandaAdaugaMasina);
            var writeRepo = new WriteRepository();
          //  writeRepo.SalvareEvenimente(masina);

            var readRepo = new ReadRepository();
            readRepo.IncarcaListaDeEvenimente();

            Console.ReadKey();
        }
    }
}
