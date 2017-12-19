using AdministratorParc;
using Model.Generic;
using Model.Masina;
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
            var masina = new Masina(new Guid(),TipMasina.Berlina,new PlainText("Bonny"),new PlainText("2031"),new PlainText("200k+"),new PlainText("1.9tdi"),
                                    new PlainText("1986"),new PlainText("300cp"),new PlainText("rosu"),new PlainText("nu bate nu trocane"));

            var admin = new Administrator(new PlainText("bonny"),new PlainText("lash"));
            admin.AdaugaMasina(masina);
            
        }
    }
}
