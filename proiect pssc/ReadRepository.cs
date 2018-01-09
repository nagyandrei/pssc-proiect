using Model.Generic;
using Model.Masina;
using Newtonsoft.Json;
using proiect_pssc.Evenimente;
using proiect_pssc.Model.Masina;
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
        public bool CautaMasina(string idRadacina)
        {
            using (var cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename" +
             @"='C:\Users\Andrei\Documents\GitHub\pssc-proiect\IterfataUtilizator\App_Data\Users.mdf';Integrated Security=True"))
            {
                string _sql = @"SELECT * FROM [dbo].[ParcAuto] WHERE [IdRadacina]=@idRadacina";
 
      
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

        public List<Eveniment> IncarcaListaDeEvenimente()
        {
            List<Eveniment> toateEvenimentele = new List<Eveniment>();
            List<Eveniment> evenimenteCitite = new List<Eveniment>();
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
                        object detalii = JsonConvert.DeserializeObject<MasinaDes.RootObject>(reader["DetaliiEveniment"].ToString());
                        // object detalii = JsonConvert.DeserializeObject<List<Eveniment>>(String.Format("{0}", reader["DetaliiEveniment"]));

                       
                        Eveniment e = new Eveniment(new PlainText(""),(TipEveniment)Enum.Parse(typeof(TipEveniment),reader["TipEveniment"].ToString()),detalii);
                        evenimenteCitite.Add(e);
                    }
                }
                
            }
            return toateEvenimentele;
        }
    }

    
}
