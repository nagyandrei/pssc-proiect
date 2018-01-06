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

        public void SalvareEvenimente(Masina masina)
        {
            SalvareEvenimente(masina.EvenimenteNoi);
        }


        private void SalvareEvenimente(ReadOnlyCollection<Eveniment> evenimenteNoi)
        {
            List<Eveniment> toateEvenimentele = IncarcaListaDeEvenimente(null);
            toateEvenimentele.AddRange(evenimenteNoi);
           // String detalii= JsonConvert.SerializeObject(toateEvenimentele); ///aci te uiti
            string detalii;
            var tipEveniment="ceva tip";
            detalii = "rip eveniment";
            var idRadacina = "AR18VAD";

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

                //nu stiu ce e astea
                //if (reader.HasRows)
                //{
                //    reader.Dispose(); 
                //    cmd.Dispose();
                //    return true;
                //}
                //else
                //{
                //    reader.Dispose();
                //    cmd.Dispose();
                //    return false;
                //}
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
