using Model.Masina;
using proiect_pssc.Evenimente;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        private void SalvareEvenimente(ReadOnlyCollection<Eveniment> evenimenteNoi)
        {
            
        }
    }

}
