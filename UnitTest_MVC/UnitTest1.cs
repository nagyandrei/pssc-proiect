using IterfataUtilizator.Controllers;
using IterfataUtilizator.Models;
using Model.Generic;
using Model.Masina;
using Moq;
using proiect_pssc;
using proiect_pssc.Evenimente;
using System;
using Xunit;


namespace UnitTest_MVC
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
        public void Test()
        {
            var mockReadRepo = new Mock<ReadRepository>();
            var mockWriteRepo = new Mock<WriteRepository>();
            var masina = new Masina(_masina, _magistrala);
            Mock<IReadRepository> mockRepo = new Mock<IReadRepository>();
            mockRepo.Setup(_ => _.CautaMasina("")).Returns(masina);

            var controller = new HomeController(mockReadRepo.Object, mockWriteRepo.Object);

            var model = (MasinaMVC)(((System.Web.Mvc.ViewResult)controller.AfisareMasini()).Model);
            Assert.Equal("5", model.CIV);
            Assert.Equal("Opel", model.Marca);
         

        }


    }
}
