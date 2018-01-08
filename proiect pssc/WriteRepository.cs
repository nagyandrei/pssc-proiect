using Model.Masina;
using Newtonsoft.Json;
using proiect_pssc.Evenimente;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiect_pssc
{
    public class WriteRepository
    {
        public Masina writeToDb(Masina masina)
        {
            Guid id = masina.Id;
            //serch db
            return masina;
        }

        public Masina updateDb(Masina masina)
        {
            Guid id;
            return masina;//
        }

        public Masina deteleFromDb(Masina masina)
        {
            return masina;
        }

        //public void SalvareEvenimente(ReadOnlyCollection<Eveniment> e)
        //{
        //    this.SalvareEvenimente(e);
        //}
        
        public Masina GasesteMasina(Guid idMasina)
        {
            //load events
            //   var evenimenteMasina = IncarcaListaDeEvenimente()
            //                         .Where(e => e.IdRadacina == idMasina);

            //creare meci din evenimente
            //  return new Masina(evenimenteMasina);
            return null;
        }

        public void SalvareEvenimente(Eveniment evenimenteNoi)
        {

            // string detalii= JsonConvert.SerializeObject(evenimenteNoi);
            string detalii = "";
            var tipEveniment=evenimenteNoi.Tip;
           
            var idRadacina="codul masinii";

            using (var cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename" +
              @"='C:\Users\Andrei\Documents\GitHub\pssc-proiect\IterfataUtilizator\App_Data\Users.mdf';Integrated Security=True"))
            {
                string _sql = @"INSERT INTO [dbo].[ParcAuto](TipEveniment,DetaliiEveniment,IdRadacina)" +
                      "VALUES (@tipEveniment,@detalii,@IdRadacina)";
                var cmd = new SqlCommand(_sql, cn);
                cmd.Parameters
                    .Add(new SqlParameter("@tipEveniment", SqlDbType.VarChar))
                    .Value =tipEveniment;
                cmd.Parameters
                    .Add(new SqlParameter("@detalii", SqlDbType.VarChar))
                    .Value = detalii;
                cmd.Parameters
                    .Add(new SqlParameter("@IdRadacina", SqlDbType.VarChar))
                    .Value = idRadacina;
                cn.Open();
                var reader = cmd.ExecuteReader();

               
            }
        }

        private List<Eveniment> IncarcaListaDeEvenimente(String detalii)
        {
            List<Eveniment> toateEvenimentele = new List<Eveniment>();
           
             //   toateEvenimentele = JsonConvert.DeserializeObject<List<Eveniment>>(detalii);

            return toateEvenimentele;
        }
    }

}
