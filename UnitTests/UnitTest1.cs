using Moq;
using System;
using Xunit;
using proiect_pssc.Evenimente;
using proiect_pssc.Comenzi;
using Model.Masina;
using Model.Generic;
using proiect_pssc.Model.Masina;
using proiect_pssc;

namespace UnitTests
{
    public class UnitTest1
    {
        private Mock<ProcesatorEveniment> _mockProcesatorAdaugaMasina;
        private MagistralaEvenimente _magistrala;
        private Masina _masina;


        public UnitTest1()
        {
            _masina = new Masina(new PlainText("5"), TipMasina.Berlina, new PlainText("Opel"), new PlainText("Vectra"), new PlainText("2031"), new PlainText("2300"), new PlainText("200k+"), new PlainText("1.9tdi"),
                                new PlainText("1986"), new PlainText("300cp"), new PlainText("rosu"), new PlainText("nu bate nu trocane"));
            _magistrala = new MagistralaEvenimente();
            _magistrala.InregistreazaProcesatoareStandard();
            _mockProcesatorAdaugaMasina = new Mock<ProcesatorEveniment>();
            _magistrala.InregistreazaProcesator(TipEveniment.AdaugareMasina, _mockProcesatorAdaugaMasina.Object);
            _magistrala.InregistreazaProcesator(TipEveniment.RezervaMasina, _mockProcesatorAdaugaMasina.Object);
            // _magistrala.InchideInregistrarea();
        }

        [Fact]
        public void SetareProprietatiTest()
        {
           
            var masina = new Masina(_masina, _magistrala);
           
            Assert.Equal(masina.CIV.ToString(), "5");
            Assert.Equal(StareMasina.InStoc, masina.stare);

        }

        [Fact]
        public void SetareProprietatiException()
        {
            _masina = new Masina(null, TipMasina.Berlina, new PlainText("Opel"), new PlainText("Vectra"), new PlainText("2031"), new PlainText("2300"), new PlainText("200k+"), new PlainText("1.9tdi"),
                            new PlainText("1986"), new PlainText("300cp"), new PlainText("rosu"), new PlainText("nu bate nu trocane"));

       
            Assert.Throws<NullReferenceException>(()=> new Masina(_masina, _magistrala));

        }

        [Fact]
        
        public void PublicaEvenimentTest()
        {
         
           // var meciDto = new MeciDto() { Id = meciId };
            var masina = new Masina(_masina, _magistrala);

            _mockProcesatorAdaugaMasina.Verify(_ =>
                    _.Proceseaza(It.Is<Eveniment>(e => e.IdRadacina == masina.CIV)), Times.Once);

        }

        [Fact]
        public void RezervaMasinaTest()
        {
            var masina = new Masina(_masina, _magistrala);
            masina.RezevaMasina(masina);
            Assert.Equal(masina.stare, StareMasina.Rezervata);
            
        }

       

       
    }
}

