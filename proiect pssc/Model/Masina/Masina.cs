using Model.Generic;
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
        public StareMasina stare { get; private set; }

        private readonly List<Eveniment> _evenimenteNoi = new List<Eveniment>();
        public ReadOnlyCollection<Eveniment> EvenimenteNoi { get => _evenimenteNoi.AsReadOnly(); }

        private MagistralaEvenimente _magistralaEveniment;

        public Masina(PlainText civ, TipMasina tip, PlainText marca, PlainText an, PlainText km, PlainText motorizare, PlainText cc, PlainText putere, PlainText culoare, PlainText descriere)
        {
            CIV = civ;
            Tip = tip;
            Marca = marca;
            An = an;
            Kilometraj = km;
            Descriere = descriere;
            Motorizare = motorizare;
            CapacitateCilindrica = cc;
            Culoare = culoare;
        }

        public Masina()
        { }

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

        public void RezevaMasina(Masina masina)
        {
            if (stare != StareMasina.InStoc) throw new InvalidOperationException("Nu exista masina pe stoc");
            else
            {
                stare = StareMasina.Rezervata;
            }
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
                    Aplica(e.ToGeneric<Masina>());
                    break;
                case TipEveniment.CautareMasina:
                    Aplica(e.ToGeneric<Masina>());
                    break;
                case TipEveniment.EditareMasina:
                    Aplica(e.ToGeneric<Masina>());
                    break;
                case TipEveniment.NogocierePret:
                    Aplica(e.ToGeneric<Masina>());
                    break;
                case TipEveniment.RezervaMasina:
                    Aplica(e.ToGeneric<Masina>());
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
