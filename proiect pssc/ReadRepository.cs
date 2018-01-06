using Model.Masina;
using Newtonsoft.Json;
using proiect_pssc.Evenimente;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiect_pssc
{
    public class ReadRepository
    {
        public List<Eveniment> IncarcaListaDeEvenimente()
        {
            List<Eveniment> toateEvenimentele = new List<Eveniment>();

            //    toateEvenimentele = JsonConvert.DeserializeObject<List<Eveniment>>(detalii);

            using (var cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename" +
              @"='C:\Users\Andrei\Documents\GitHub\pssc-proiect\IterfataUtilizator\App_Data\Users.mdf';Integrated Security=True"))
            {
                string _sql = @"SELECT * FROM [dbo].[ParcAuto] ";
                var cmd = new SqlCommand(_sql, cn);
                cn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(String.Format("{0} {1} {2} {3}", reader["id"],reader["TipEveniment"],reader["DetaliiEveniment"],reader["IdRadacina"]));
                    }
                }
                
               
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


            return toateEvenimentele;
        }
    }
}
