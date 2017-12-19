using Model.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Client
{
    public class Client
    {
        public PlainText Nume { get; private set; }
        public PlainText Prenume { get; private set; }
        public string CNP { get; private set; }
        //  public StareClient Stare { get; private set; }


        public Client(PlainText nume, PlainText prenume, string cnp)
        {
            //  Contract.Requires(cnp.Length == 13, "CNP-ul trebuie sa contina 13 caractere!");
            Nume = nume;
            Prenume = prenume;
            CNP = cnp;
        }

        public override string ToString()
        {
            return Prenume + " " + Nume + ", " + CNP;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public void CautareMasina()
        {
            //Do nothing
        }

        public void Inregistrare()
        {
            //Do nothing
        }

        public void RezervaMasina()
        {
            //Do nothing
        }

        public void CumparaMasina()
        {
            //Do nothing

        }

        //public void ClientMultumit()
        //{
        //    Stare = StareClient.Multumit;
        //}
        //public void ClientNemultumit()
        //{
        //    Stare = StareClient.Nemultumit;
        //}
    }
}