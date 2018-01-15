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

        [HttpPost]
        public ActionResult CautaMasina()
        {
            var repo = new ReadRepository();
            masinaRepo = repo.IncarcaListaMasini();
            var eventRepo = repo.IncarcaListaDeEvenimente();
            List<MasinaMVC> masina = new List<MasinaMVC>();
            foreach (Masina x in masinaRepo)
            {
                string ceva = x.CIV.ToString();
                var mVC = new MasinaMVC(
                                        x.CIV.ToString(), x.Tip, x.Marca.ToString(), x.An.ToString(), x.Kilometraj.ToString(),
                                        x.Descriere.ToString(), x.Motorizare.ToString(), x.Culoare.ToString(), x.Putere.ToString(),
                                        x.CapacitateCilindrica.ToString()
                                        );

                masina.Add(mVC);
            }

            ViewBag.Model = masina;
            return View(masina);
           
        }

        public ActionResult AdaugaMasina1()
        {
            return View("AdaugaMasina");
        }

        public ActionResult CautaMasina1()
        {
            return View("CautaMasina");
        }

       

        [HttpPost]
        public ActionResult AdaugaMasina(MasinaMVC mVC)
        {
            //MagistralaComenzi.Instanta.Value.InregistreazaProcesatoareStandard();
            //MagistralaEvenimente.Instanta.Value.InregistreazaProcesatoareStandard();
            //MagistralaEvenimente.Instanta.Value.InchideInregistrarea();
            //Berilna
            var comandaAdaugaMasina = new ComandaAdaugaMasina();
            Masina m = new Masina(new PlainText(mVC.CIV),mVC.Tip,new PlainText(mVC.Marca.ToString()),
                new PlainText(mVC.An),new PlainText(mVC.Kilometraj),new PlainText(mVC.Motorizare),
                new PlainText(mVC.CapacitateCilindrica),new PlainText(mVC.Putere),
                new PlainText(mVC.Culoare),new PlainText(mVC.Descriere));
            comandaAdaugaMasina.Masina1 = m;
         
                MagistralaComenzi.Instanta.Value.Trimite(comandaAdaugaMasina);
            return View("HomePage");
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
           
           // var masina = new MasinaMVC();
            var comandaStergereMasina = new ComandaStergeMasina();
            comandaStergereMasina.CIV = CIV.ToString();
            masinaMVC.Remove(masinaMVC.Find(_=>_.CIV.Equals(CIV)));
            MagistralaComenzi.Instanta.Value.Trimite(comandaStergereMasina);

            return View("HomePage");
        }

        public ActionResult AfisareMasini()
        {
            var repo = new ReadRepository();
            masinaRepo = repo.IncarcaListaMasini();
            var eventRepo = repo.IncarcaListaDeEvenimente();
            List<MasinaMVC> masina = new List<MasinaMVC>();
            foreach (Masina x in masinaRepo)
            {
                Console.WriteLine(x.CIV.ToString());
                string ceva = x.CIV.ToString();
                var mVC = new MasinaMVC(
                                        x.CIV.ToString(),x.Tip,x.Marca.ToString(),x.An.ToString(),x.Kilometraj.ToString(),
                                        x.Descriere.ToString(),x.Motorizare.ToString(),x.Culoare.ToString(),x.Putere.ToString(),
                                        x.CapacitateCilindrica.ToString()
                                        );
               
                masina.Add(mVC);
            }
            //masinaMVC = masinaRepo.Select(x => 
            //new MasinaMVC {
            //    CIV = x.CIV.Text,
            //    Tip = x.Tip,
            //    Marca = x.Marca.Text,
            //    An = x.An.Text,
            //    Kilometraj = x.Kilometraj.Text,
            //    Descriere = x.Descriere.Text,
            //    Motorizare = x.Motorizare.Text,
            //    Culoare = x.Culoare.Text,
            //    Putere = x.Putere.Text,
            //    CapacitateCilindrica = x.CapacitateCilindrica.Text
            //}).ToList();
            ViewBag.Model = masina;
            return View(masina);
        }

    }
}