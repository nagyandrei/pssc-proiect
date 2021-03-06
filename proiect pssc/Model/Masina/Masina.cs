﻿using Model.Generic;
using proiect_pssc.Evenimente;
using proiect_pssc.Model.Masina;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Masina
{
    public class Masina
    {
        public PlainText CIV { get; private set; }
        public TipMasina Tip { get; private set; }
        public PlainText Marca { get; private set; }
        public PlainText An { get; private set; }
        public PlainText Kilometraj { get; private set; }
        public PlainText Descriere { get; private set; }
        public PlainText Motorizare { get; private set; }
        public PlainText Culoare { get; private set; }
        public PlainText Putere { get; private set; }
        public PlainText CapacitateCilindrica { get; private set; }
        public PlainText Pret { get; private set; }
        public PlainText Model { get; private set; }
        public StareMasina stare { get;  set; }

        private readonly List<Eveniment> _evenimenteNoi = new List<Eveniment>();
        public ReadOnlyCollection<Eveniment> EvenimenteNoi { get => _evenimenteNoi.AsReadOnly(); }

        private MagistralaEvenimente _magistralaEveniment;

        public Masina(PlainText civ, TipMasina tip, PlainText marca, PlainText model, PlainText an, PlainText pret, PlainText km, PlainText motorizare, PlainText cc, PlainText putere, PlainText culoare, PlainText descriere)
        {
            CIV = civ;
            Tip = tip;
            Marca = marca;
            An = an;
            Kilometraj = km;
            Descriere = descriere;
            Motorizare = motorizare;
            Putere = putere;
            CapacitateCilindrica = cc;
            Culoare = culoare;
            Pret = pret;
            Model = model;
        }

        public Masina()
        { }

        public Masina(Masina masina, MagistralaEvenimente magistrala = null)
        {
            _magistralaEveniment = magistrala;
            if (masina.CIV == null) throw new NullReferenceException("Id masina invalid");
            var e = new EvenimentGeneric<Masina>(masina.CIV, TipEveniment.AdaugareMasina, masina);
            Aplica1(e);
          //  PublicaEveniment(e);
        }

        public Masina(IEnumerable<Eveniment> evenimente)
        {
            foreach (var e in evenimente)
            {
                RedaEveniment(e);
            }
        }

        public void AdaugaMasina(Masina masina)
        {
            var e = new EvenimentGeneric<Masina>(masina.CIV, TipEveniment.AdaugareMasina, masina);
            Aplica(e);
            PublicaEveniment(e);

        }
        private void Aplica(EvenimentGeneric<Masina> e)
        {
          
            stare = StareMasina.InStoc;
        }


        private void Aplica1(EvenimentGeneric<Masina> e)
        {
            CIV = e.Detalii.CIV;
            Tip = e.Detalii.Tip;
            Marca = e.Detalii.Marca;
            stare = StareMasina.InStoc;
        }

        public void StergereMasina(Masina masina)
        {
            if (stare != StareMasina.InStoc) throw new InvalidOperationException("Nu exista masina pe stoc");
            else
            {
                var e = new EvenimentGeneric<Masina>(masina.CIV, TipEveniment.StergereMasina, masina);
                AplicaStergere(e);
                PublicaEveniment(e);
            }
        }


        private void AplicaStergere(EvenimentGeneric<Masina> e)
        {
            stare = StareMasina.StocInsuficient;
        }

        public void VizualizareRapoarte()
        {
            //methond to be implemented
        }

        public void AprobareNegociere(Masina masina)
        {
            //methond to be implemented
        }

        public void VindeMasina(Masina masina)
        {
            if(masina.stare != StareMasina.InStoc) throw new InvalidOperationException("Nu exista masina pe stoc");
            else
            {
                var e = new EvenimentGeneric<Masina>(masina.CIV, TipEveniment.VanzareMasina, masina);
                AplicaVanzare(e);
                PublicaEveniment(e);
            }
        }

        public void RezevaMasina(Masina masina)
        {
            if (masina.stare != StareMasina.InStoc) throw new InvalidOperationException("Nu exista masina pe stoc");
            else
            {
             //   masina.stare = StareMasina.Rezervata;
                var e = new EvenimentGeneric<Masina>(masina.CIV, TipEveniment.RezervaMasina, masina);
                AplicaRezervare(e);
                PublicaEveniment(e);
            }
        }

        private void AplicaRezervare(EvenimentGeneric<Masina> e)
        {
            e.Detalii.stare = StareMasina.Rezervata;
        }

        private void AplicaVanzare(EvenimentGeneric<Masina> e)
        {
            e.Detalii.stare = StareMasina.StocInsuficient;
        }

        public override string ToString()
        {
            return Tip + ", " + Marca + ", " + An + ", " + Kilometraj + ", " + Descriere;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        private void RedaEveniment(Eveniment e)
        {
            switch (e.Tip)
            {
                case TipEveniment.AdaugareMasina:
                    Aplica1(e.ToGeneric<Masina>());
                    break;
                case TipEveniment.CautareMasina:
                    Aplica1(e.ToGeneric<Masina>());
                    break;
                case TipEveniment.EditareMasina:
                    Aplica1(e.ToGeneric<Masina>());
                    break;
                case TipEveniment.NogocierePret:
                    Aplica1(e.ToGeneric<Masina>());
                    break;
                case TipEveniment.RezervaMasina:
                    AplicaRezervare(e.ToGeneric<Masina>());
                    break;
                case TipEveniment.StergereMasina:
                    AplicaStergere(e.ToGeneric<Masina>());
                    break;
                case TipEveniment.VanzareMasina:
                    AplicaStergere(e.ToGeneric<Masina>());
                    break;
                default:
                    throw new EvenimentNecunoscutException();
            }
        }
        protected void PublicaEveniment(Eveniment eveniment)
        {
            _evenimenteNoi.Add(eveniment);
            //EvenimentMeci?.Invoke(this, eveniment);
            MagistralaEvenimente.Instanta.Value.Trimite(eveniment);
        }
    }
}
