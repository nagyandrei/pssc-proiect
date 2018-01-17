using Model.Masina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiect_pssc
{
    public interface IReadRepository
    {
         Masina CautaMasina(string idRadacina);
         string UpdateMasina(string idRadacina);
    }
}
