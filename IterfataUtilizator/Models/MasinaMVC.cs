using Model.Generic;
using Model.Masina;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IterfataUtilizator.Models
{
    public class MasinaMVC
    {
        public PlainText CIV { get;  set; }
        public TipMasina Tip { get;  set; }
        public PlainText Marca { get;  set; }
        public PlainText An { get;  set; }
        public PlainText Kilometraj { get;  set; }
        public PlainText Descriere { get;  set; }
        public PlainText Motorizare { get;  set; }
        public PlainText Culoare { get;  set; }
        public PlainText Putere { get;  set; }
        public PlainText CapacitateCilindrica { get;  set; }
    }
}