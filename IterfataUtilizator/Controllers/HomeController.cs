using Creating_a_custom_user_login_form.Models;
using IterfataUtilizator.Models;
using Model.Masina;
using proiect_pssc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Model.Generic;
using IterfataUtilizator.App_Start;
using proiect_pssc.Evenimente;
using proiect_pssc.Comenzi;

namespace IterfataUtilizator.Controllers
{
    public class HomeController : Controller
    {
        List<Masina> masinaRepo = new List<Masina>();
        List<MasinaMVC> masinaMVC = new List<MasinaMVC>();

        public ActionResult Index()
        {
            return View("Login");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult CautaMasina()
        {
            return View();
        }

        public ActionResult AdaugaMasina1()
        {
            return View("AdaugaMasina");
        }

        [HttpPost]
        public ActionResult AdaugaMasina(Models.MasinaMVC mVC)
        {
            MagistralaComenzi.Instanta.Value.InregistreazaProcesatoareStandard();
            MagistralaEvenimente.Instanta.Value.InregistreazaProcesatoareStandard();
            MagistralaEvenimente.Instanta.Value.InchideInregistrarea();
            var comandaAdaugaMasina = new ComandaAdaugaMasina();
            Masina m = new Masina(new PlainText(mVC.CIV.ToString()),mVC.Tip,new PlainText(mVC.Marca.ToString()),new PlainText(mVC.An.ToString()),
                new PlainText(mVC.Kilometraj.ToString()),new PlainText(mVC.Motorizare.ToString()),new PlainText(mVC.CapacitateCilindrica.ToString()),new PlainText(mVC.Putere.ToString()),
                new PlainText(mVC.Culoare.ToString()),new PlainText(mVC.Descriere.ToString()));
            comandaAdaugaMasina.Masina1 = m;
            MagistralaComenzi.Instanta.Value.Trimite(comandaAdaugaMasina);

            return View("AfisareMasini");
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                if (user.IsValid(user.UserName, user.Password))
                {

                    FormsAuthentication.SetAuthCookie(user.UserName, user.RememberMe);
                    return View("HomePage");
                }
                else
                {
                    ModelState.AddModelError("", "Login data is incorrect!");
                }
            }
            return View(user);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("HomePage", "Home");
        }

        public ActionResult Delete(string CIV )
        {
            //var config = new DDDconfig();
            //config.config();
            MagistralaComenzi.Instanta.Value.InregistreazaProcesatoareStandard();
            MagistralaEvenimente.Instanta.Value.InregistreazaProcesatoareStandard();
            MagistralaEvenimente.Instanta.Value.InchideInregistrarea();
            var masina = new MasinaMVC();
            var comandaStergereMasina = new ComandaStergeMasina();
            comandaStergereMasina.CIV = CIV.ToString();
            masinaMVC.Remove(masinaMVC.Find(_=>_.CIV.Equals(CIV)));
            MagistralaComenzi.Instanta.Value.Trimite(comandaStergereMasina);

            return View("HomePage");
        }

        public ActionResult AfisareMasini()
        {
            var repo = new ReadRepository();
            masinaRepo = repo.IncarcaListaDeEvenimente();

            masinaMVC = masinaRepo.Select(x => 
            new MasinaMVC {
                CIV = x.CIV,
                Tip = x.Tip,
                Marca = x.Marca,
                An = x.An,
                Kilometraj = x.Kilometraj,
                Descriere = x.Descriere,
                Motorizare = x.Motorizare,
                Culoare = x.Culoare,
                Putere = x.Putere,
                CapacitateCilindrica = x.CapacitateCilindrica
            }).ToList();
            ViewBag.Model = masinaMVC;
            return View(masinaMVC);
        }

    }
}