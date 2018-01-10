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
        string connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename" +
             @"='C:\Users\Andrei\Documents\GitHub\pssc-proiect\IterfataUtilizator\App_Data\Users.mdf';Integrated Security=True";
        public bool StergereMasina(string idRadacina)
        {
            using (var cn = new SqlConnection(connection))
            {
                string _sql = @"DELETE FROM [dbo].[ParcAuto] WHERE [IdRadacina]=@idRadacina";

                var cmd = new SqlCommand(_sql, cn);
                cmd.Parameters
                    .Add(new SqlParameter("@idRadacina", SqlDbType.NVarChar))
                    .Value = idRadacina;
                cn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Dispose();
                    cmd.Dispose();
                    return true;
                }
                else
                {
                    reader.Dispose();
                    cmd.Dispose();
                    return false;
                }
            }
        }

        public void SalvareEvenimente(Eveniment evenimenteNoi)
        {

            string detalii = JsonConvert.SerializeObject(evenimenteNoi.Detalii);
            var tipEveniment=evenimenteNoi.Tip;
            var idEveniment = evenimenteNoi.Id.ToString();
            var idRadacina=evenimenteNoi.IdRadacina.ToString();

            using (var cn = new SqlConnection(connection))
            {
                string _sql = @"INSERT INTO [dbo].[ParcAuto](IdEveniment,TipEveniment,DetaliiEveniment,IdRadacina)" +
                      "VALUES (@idEveniment,@tipEveniment,@detalii,@IdRadacina)";
                var cmd = new SqlCommand(_sql, cn);
                cmd.Parameters
                   .Add(new SqlParameter("@idEveniment", SqlDbType.VarChar))
                   .Value = idEveniment;
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
    }
}
