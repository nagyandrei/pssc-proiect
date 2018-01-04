using Model.Generic;
using proiect_pssc.Evenimente;
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
        public Guid Id { get; private set; }
        public TipMasina Tip { get; private set; }
        public PlainText Marca { get; private set; }
        public PlainText An { get; private set; }
        public PlainText Kilometraj { get; private set; }
        public PlainText Descriere { get; private set; }
        public PlainText Motorizare { get; private set; }
        public PlainText Culoare { get; private set; }
        public PlainText Putere { get; private set; }
        public PlainText CapacitateCilindrica { get; private set; }
        public Masina(Guid id, TipMasina tip, PlainText marca, PlainText an, PlainText km, PlainText motorizare, PlainText cc, PlainText putere, PlainText culoare, PlainText descriere)
        {
            Id = id;
            Tip = tip;
            Marca = marca;
            An = an;
            Kilometraj = km;
            Descriere = descriere;
            Motorizare = motorizare;
            CapacitateCilindrica = cc;
            Culoare = culoare;
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

        private readonly List<Eveniment> _evenimenteNoi = new List<Eveniment>();
        public ReadOnlyCollection<Eveniment> EvenimenteNoi { get => _evenimenteNoi.AsReadOnly(); }

        public override string ToString()
        {
            return Tip + ", " + Marca + ", " + An + ", " + Kilometraj + ", " + Descriere;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        private void Aplica(EvenimentGeneric<Masina> e)
        {
            Id = e.Detalii.Id;
            Tip = e.Detalii.Tip;
            Marca = e.Detalii.Marca;
            An = e.Detalii.An;
            Kilometraj = e.Detalii.Kilometraj;
            Descriere = e.Detalii.Descriere;
            Motorizare = e.Detalii.Motorizare;
            CapacitateCilindrica = e.Detalii.CapacitateCilindrica;
            Culoare = e.Detalii.Culoare;
        }
    }
}
