using Model.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dealer
{
    public class Dealer
    {
        public PlainText Nume { get; private set; }
        public PlainText Prenume { get; private set; }
        public string CNP { get; private set; }

        public Dealer(PlainText nume, PlainText prenume, string cnp)
        {
            //  Contract.Requires(cnp.Length == 13, "CNP-ul trebuie sa contina 13 caractere!");
            Nume = nume;
            Prenume = prenume;
            CNP = cnp;
        }

       public void Negociere()
        {

        }

        public void CauatareMasina()
        {

        }

        public override string ToString()
        {
            return Prenume + " " + Nume + ", " + CNP;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
