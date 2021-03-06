﻿using Model.Dealer;
using Model.Generic;
using Model.Masina;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AdministratorParc
{
    public class Administrator
    {
        public PlainText Nume { get; private set; }
        public PlainText Prenume { get; private set; }
        public List<Masina> ListaDeMasini { get; private set; }
        public List<Dealer> ListaDealeri { get; private set; }

        private readonly List<Eveniment> _evenimenteNoi = new List<Eveniment>();
        public ReadOnlyCollection<Eveniment> EvenimenteNoi => _evenimenteNoi.AsReadOnly();

        //something with parc auto 
        public Administrator(PlainText nume, PlainText prenume)
        {
            Nume = nume;
            Prenume = prenume;
        }

        public void AdaugaMasina(Masina masina)
        {
            ListaDeMasini.Add(masina);
            var e = new EvenimentGeneric<Masina>(masina.Id, TipEveniment.AdaugareMasina, masina);
          //  Aplica(e);
            PublicaEveniment(e);
        }

        public void AdaugaDealer()
        {
            //methond to be implemented
        }

        public void VizualizareMasina()
        {

            //methond to be implemented

        }

        public void EditareMasina()
        {
            //methond to be implemented
        }

        public void StergereMasina()
        {
            //methond to be implemented
        }

        public void VizualizareRapoarte()
        {
            //methond to be implemented
        }

        public void AprobareNegociere()
        {
            //methond to be implemented
        }

        public void ViziualizareRaportDealer()
        {
            //methond to be implemented
        }

        public void MarireSalarDealer()
        {
            //methond to be implemented
        }
        protected void PublicaEveniment(Eveniment eveniment)
        {
            _evenimenteNoi.Add(eveniment);
            //EvenimentMeci?.Invoke(this, eveniment);
            MagistralaEvenimente.Instanta.Value.Trimite(eveniment);
        }
    }
}
