﻿using Model.Generic;
using Model.Masina;
using proiect_pssc.Model.Masina;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IterfataUtilizator.Models
{
    public class MasinaMVC
    {
        public MasinaMVC(string cIV, TipMasina tip, string marca,string model, string an,string pret, string kilometraj, string descriere, string motorizare, string culoare, string putere, string capacitateCilindrica)
        {
            CIV = cIV;
            Tip = tip;
            Marca = marca;
            An = an;
            Kilometraj = kilometraj;
            Descriere = descriere;
            Motorizare = motorizare;
            Culoare = culoare;
            Putere = putere;
            CapacitateCilindrica = capacitateCilindrica;
            Model = model;
            Pret = pret;
        }

        public MasinaMVC() { }

        public string CIV { get;  set; }
        public TipMasina Tip { get;  set; }
        public string Marca { get;  set; }
        public string Model { get; set; }
        public string An { get;  set; }
        public string Pret { get; set; }
        public string Kilometraj { get;  set; }
        public string Descriere { get;  set; }
        public string Motorizare { get;  set; }
        public string Culoare { get;  set; }
        public string Putere { get;  set; }
        public StareMasina Stare { get; set; }
        public string CapacitateCilindrica { get;  set; }
      //  public IEnumerable<MasinaMVC> mVC { get; set; }
    }
}