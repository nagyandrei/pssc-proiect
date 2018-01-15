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
using System.Text.RegularExpressions;
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

        public string UpdateMasina(string idRadacina)
        {
            string stare = "";
            using (var cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename" +
             @"='C:\Users\Andrei\Documents\GitHub\pssc-proiect\IterfataUtilizator\App_Data\Users.mdf';Integrated Security=True"))
            {
                string _sql = @"SELECT * FROM [dbo].[ParcAuto] WHERE [IdRadacina]=@idRadacina";


                var cmd = new SqlCommand(_sql, cn);
                cmd.Parameters
                    .Add(new SqlParameter("@idRadacina", SqlDbType.NVarChar))
                    .Value = idRadacina;
                cn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    string[] tokens = reader["DetaliiEveniment"].ToString().Split(':');
                    string[] stareMasina = tokens[19].Split(',');
                    stare = stareMasina[0];
                }


            }
            return stare;

        }

        public List<Masina> IncarcaListaMasini()
        {
          //  List<string> marca = new List<string>();
            List<Masina> masina = new List<Masina>();

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
                        string[] tokens = reader["DetaliiEveniment"].ToString().Split('"');
                   //     marca.Add(tokens[13]);
                        string tip = Regex.Match(tokens[8], @"\d+").Value;
                        Masina m = new Masina(new PlainText(tokens[5]), (TipMasina)Enum.Parse(typeof(TipMasina), tip), new PlainText(tokens[13]), new PlainText(tokens[19]), new PlainText(tokens[25]), new PlainText(tokens[37]), new PlainText(tokens[51]), new PlainText(tokens[45]), new PlainText(tokens[43]), new PlainText(tokens[31]));
                        //object detalii = JsonConvert.DeserializeObject<MasinaDes.RootObject>(reader["DetaliiEveniment"].ToString());
                        // object detalii = JsonConvert.DeserializeObject<List<Eveniment>>(String.Format("{0}", reader["DetaliiEveniment"]));
                        masina.Add(m);

                    }
                }

            }
            return masina;
        }


        public List<Eveniment> IncarcaListaDeEvenimente()
        {
           // List<string> marca = new List<string>();
            List<Eveniment> e = new List<Eveniment>();
            List<Masina> masina = new List<Masina>();

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
                        string[] tokens = reader["DetaliiEveniment"].ToString().Split('"');
                      //  marca.Add(tokens[13]);
                        string tip = Regex.Match(tokens[8], @"\d+").Value;
                        Masina m = new Masina(new PlainText(tokens[5]), (TipMasina)Enum.Parse(typeof(TipMasina), tip), new PlainText(tokens[13]), new PlainText(tokens[19]), new PlainText(tokens[25]), new PlainText(tokens[37]), new PlainText(tokens[51]), new PlainText(tokens[45]), new PlainText(tokens[43]), new PlainText(tokens[31]));
                        //object detalii = JsonConvert.DeserializeObject<MasinaDes.RootObject>(reader["DetaliiEveniment"].ToString());
                        // object detalii = JsonConvert.DeserializeObject<List<Eveniment>>(String.Format("{0}", reader["DetaliiEveniment"]));
                        // masina.Add(m);
                        Eveniment ev = new Eveniment(new PlainText(reader["IdRadacina"].ToString()), (TipEveniment)Enum.Parse(typeof(TipEveniment), reader["TipEveniment"].ToString()), m);
                        e.Add(ev);
                    }
                }

            }
            return e;
        }
    }
}

    

