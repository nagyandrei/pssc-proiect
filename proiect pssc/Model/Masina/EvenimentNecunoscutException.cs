using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace proiect_pssc.Model.Masina
{
    [Serializable]
    internal class EvenimentNecunoscutException : Exception
    {
        public EvenimentNecunoscutException()
        {
        }

        public EvenimentNecunoscutException(string message) : base(message)
        {
        }

        public EvenimentNecunoscutException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EvenimentNecunoscutException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
