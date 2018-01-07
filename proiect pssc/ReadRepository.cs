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
                        ////////////////////////////////
                        /////////////////////////// detalii nu merge, nu il face obiect il face doar string
                        /////////////////////////
                        toateEvenimentele = JsonConvert.DeserializeObject<List<Eveniment>>(String.Format("{0}", reader["DetaliiEveniment"]));
                       // object detalii = JsonConvert.DeserializeObject(String.Format("{0}",reader["DetaliiEveniment"]),typeof(Eveniment));
                       // object detalii = JsonConvert.DeserializeObject<List<Eveniment>>(String.Format("{0}", reader["DetaliiEveniment"]));
                        //String readString = String.Format("{0}{1}{2}{3}", reader["id"], reader["TipEveniment"], reader["DetaliiEveniment"], reader["IdRadacina"]));
                        Eveniment e = new Eveniment(new Guid(),(TipEveniment)Enum.Parse(typeof(TipEveniment),reader["TipEveniment"].ToString()),"rip");
                        //toateEvenimentele = JsonConvert.DeserializeObject<List<Eveniment>>(String.Format("{0}{1}{2}{3}", reader["id"], reader["TipEveniment"], reader["DetaliiEveniment"], reader["IdRadacina"]));
                        // Console.WriteLine(String.Format("{0}   {1}   {2}   {3}", reader["id"],reader["TipEveniment"],reader["DetaliiEveniment"],reader["IdRadacina"]));
                        evenimenteCitite.Add(e);
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
