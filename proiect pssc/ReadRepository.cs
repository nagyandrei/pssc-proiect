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
    public class ReadRepository:IReadRepository
    {
        public Masina CautaMasina(string idRadacina)
        {
            Masina m = new Masina();
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
                    while (reader.Read())
                    {
                        string[] tokens = reader["DetaliiEveniment"].ToString().Split('"');
                        //     marca.Add(tokens[13]);
                        string tip = Regex.Match(tokens[8], @"\d+").Value;
                        m = new Masina(new PlainText(tokens[5]), (TipMasina)Enum.Parse(typeof(TipMasina), tip), new PlainText(tokens[13]), new PlainText(tokens[67]), new PlainText(tokens[19]), new PlainText(tokens[61]), new PlainText(tokens[25]), new PlainText(tokens[37]), new PlainText(tokens[51]), new PlainText(tokens[45]), new PlainText(tokens[43]), new PlainText(tokens[31]));
                        string stare = Regex.Match(tokens[70], @"\d+").Value;
                        //object detalii = JsonConvert.DeserializeObject<MasinaDes.RootObject>(reader["DetaliiEveniment"].ToString());
                        // object detalii = JsonConvert.DeserializeObject<List<Eveniment>>(String.Format("{0}", reader["DetaliiEveniment"]));
                        m.stare = (StareMasina)Enum.Parse(typeof(StareMasina), stare);
                       
                    }
                }

            }
            return m;

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

        public List<string> IncarcaIdRadacina()
        {
            List<string> id = new List<string>();
            using (var cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename" +
              @"='C:\Users\Andrei\Documents\GitHub\pssc-proiect\IterfataUtilizator\App_Data\Users.mdf';Integrated Security=True"))
            {
                string _sql = @"SELECT (idRadacina) FROM [dbo].[ParcAuto] ";
                var cmd = new SqlCommand(_sql, cn);
                cn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        id.Add(reader["idRadacina"].ToString());
                    }
                }

            }
            id = id.Distinct().ToList();
            return id;
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
                        Masina m = new Masina(new PlainText(tokens[5]), (TipMasina)Enum.Parse(typeof(TipMasina), tip), new PlainText(tokens[13]), new PlainText(tokens[67]),new PlainText(tokens[19]), new PlainText(tokens[61]),new PlainText(tokens[25]), new PlainText(tokens[37]), new PlainText(tokens[51]), new PlainText(tokens[49]), new PlainText(tokens[43]), new PlainText(tokens[31]));
                        string stare = Regex.Match(tokens[70], @"\d+").Value;
                        //object detalii = JsonConvert.DeserializeObject<MasinaDes.RootObject>(reader["DetaliiEveniment"].ToString());
                        // object detalii = JsonConvert.DeserializeObject<List<Eveniment>>(String.Format("{0}", reader["DetaliiEveniment"]));
                        m.stare = (StareMasina)Enum.Parse(typeof(StareMasina), stare);
                        masina.Add(m);
                    }
                }

            }
            return masina;
        }

        public List<Masina> IncarcaListaMasini22222()
        {
            //  List<string> marca = new List<string>();
            List<Masina> masina = new List<Masina>();
            List<string> idradacina = IncarcaIdRadacina();

            foreach (string id in idradacina)
            {
                using (var cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename" +
                  @"='C:\Users\Andrei\Documents\GitHub\pssc-proiect\IterfataUtilizator\App_Data\Users.mdf';Integrated Security=True"))
                {
                    string _sql = @"SELECT row_number() over (partition by IdRadacina order by IdRadacina) as number, DetaliiEveniment FROM [dbo].[ParcAuto] where IdRadacina=@idradacina order by number desc";
                    var cmd = new SqlCommand(_sql, cn);
                    cmd.Parameters
                      .Add(new SqlParameter("@idradacina", SqlDbType.VarChar))
                      .Value = id;
                    cn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string[] tokens = reader["DetaliiEveniment"].ToString().Split('"');
                            string tip = Regex.Match(tokens[8], @"\d+").Value;
                            Masina m = new Masina(new PlainText(tokens[5]), (TipMasina)Enum.Parse(typeof(TipMasina), tip), new PlainText(tokens[13]), new PlainText(tokens[67]), new PlainText(tokens[19]), new PlainText(tokens[61]), new PlainText(tokens[25]), new PlainText(tokens[37]), new PlainText(tokens[51]), new PlainText(tokens[49]), new PlainText(tokens[43]), new PlainText(tokens[31]));
                            string stare = Regex.Match(tokens[70], @"\d+").Value;
                            //object detalii = JsonConvert.DeserializeObject<MasinaDes.RootObject>(reader["DetaliiEveniment"].ToString());
                            // object detalii = JsonConvert.DeserializeObject<List<Eveniment>>(String.Format("{0}", reader["DetaliiEveniment"]));
                            m.stare = (StareMasina)Enum.Parse(typeof(StareMasina), stare);
                            masina.Add(m);
                        }
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
                        Masina m = new Masina(new PlainText(tokens[5]), (TipMasina)Enum.Parse(typeof(TipMasina), tip), new PlainText(tokens[13]), new PlainText(tokens[67]), new PlainText(tokens[19]), new PlainText(tokens[61]), new PlainText(tokens[25]), new PlainText(tokens[37]), new PlainText(tokens[51]), new PlainText(tokens[49]), new PlainText(tokens[43]), new PlainText(tokens[31]));
                        string stare = Regex.Match(tokens[70], @"\d+").Value;
                        //object detalii = JsonConvert.DeserializeObject<MasinaDes.RootObject>(reader["DetaliiEveniment"].ToString());
                        // object detalii = JsonConvert.DeserializeObject<List<Eveniment>>(String.Format("{0}", reader["DetaliiEveniment"]));
                        m.stare = (StareMasina)Enum.Parse(typeof(StareMasina), stare);
                        Eveniment ev = new Eveniment(new PlainText(reader["IdRadacina"].ToString()), (TipEveniment)Enum.Parse(typeof(TipEveniment), reader["TipEveniment"].ToString()), m);
                        e.Add(ev);
                    }
                }

            }
            return e;
        }
    }
}

    

