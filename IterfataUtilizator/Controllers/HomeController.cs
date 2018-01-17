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


        private ReadRepository _readRepo;
        private WriteRepository _writeRepo;

        
        public HomeController(ReadRepository readRepo, WriteRepository writeRepo)
        {
            _readRepo = readRepo;
            _writeRepo = writeRepo;
        }

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
        public ActionResult CautaMasina(MasinaMVC mVC)
        {
            var repo = new ReadRepository();
            masinaRepo = repo.IncarcaListaMasini();
            //  var eventRepo = repo.IncarcaListaDeEvenimente();
            var masina = repo.CautaMasina(mVC.CIV);
              List<MasinaMVC> masinaMVC = new List<MasinaMVC>();

            if (masina != null)
            {
                var masinaCautata = new MasinaMVC(
                                            masina.CIV.ToString(), masina.Tip, masina.Marca.ToString(), masina.Model.ToString(), masina.An.ToString(), masina.Pret.ToString(), masina.Kilometraj.ToString(),
                                            masina.Descriere.ToString(), masina.Motorizare.ToString(), masina.Culoare.ToString(), masina.Putere.ToString(),
                                            masina.CapacitateCilindrica.ToString()
                                            );
                masinaMVC.Add(masinaCautata);
            }
            

            ViewBag.Model = masinaMVC;
            return View("AfisareMasini",masinaMVC);
           
        }

        public ActionResult AdaugaMasina1()
        {
            return View("AdaugaMasina");
        }

        public ActionResult CautaMasina1()
        {
            return View("CautaMasina");
        }
        
        public ActionResult Rezerva(string CIV)
        {
            var repo = new ReadRepository();
            var masina= repo.CautaMasina(CIV);
            //masina.stare = proiect_pssc.Model.Masina.StareMasina.Rezervata;
            var comandaRezervaMasina = new ComandaRezervaMasina();
            comandaRezervaMasina.Masina=masina;
            MagistralaComenzi.Instanta.Value.Trimite(comandaRezervaMasina);
            var receive = new Receive();
            var mesaj = receive.PrimesteMesaj();
            ViewBag.masaj = mesaj;
            return View("HomePage");
        }

        public ActionResult Cumpara(string CIV)
        {
            var repo = new ReadRepository();
            var masina = repo.CautaMasina(CIV);
            //masina.stare = proiect_pssc.Model.Masina.StareMasina.Rezervata;
            var comandaCumparaMasina = new ComandaVindeMasina();
            comandaCumparaMasina.Masina = masina;
            MagistralaComenzi.Instanta.Value.Trimite(comandaCumparaMasina);
            var receive = new Receive();
            var mesaj = receive.PrimesteMesaj();
            ViewBag.masaj = mesaj;
            return View("HomePage");
        }


        [HttpPost]
        public ActionResult AdaugaMasina(MasinaMVC mVC)
        {

            var comandaAdaugaMasina = new ComandaAdaugaMasina();
            Masina m = new Masina(new PlainText(mVC.CIV),mVC.Tip,new PlainText(mVC.Marca.ToString()),new PlainText(mVC.Model.ToString()),
                new PlainText(mVC.An),new PlainText(mVC.Pret.ToString()),new PlainText(mVC.Kilometraj),new PlainText(mVC.Motorizare),
                new PlainText(mVC.CapacitateCilindrica),new PlainText(mVC.Putere),
                new PlainText(mVC.Culoare),new PlainText(mVC.Descriere));
            comandaAdaugaMasina.Masina1 = m;
         
                MagistralaComenzi.Instanta.Value.Trimite(comandaAdaugaMasina);

            var receive = new Receive();
         
            var mesaj = receive.PrimesteMesaj();
            ViewBag.masaj = mesaj;
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

            var comandaStergereMasina = new ComandaStergeMasina();
            comandaStergereMasina.CIV = CIV.ToString();
            masinaMVC.Remove(masinaMVC.Find(_=>_.CIV.Equals(CIV)));
            MagistralaComenzi.Instanta.Value.Trimite(comandaStergereMasina);

            return View("HomePage");
        }

        public ActionResult AfisareMasini()
        {
            var repo = new ReadRepository();
            var masinaRepo = repo.IncarcaListaMasini22222();
           // masinaRepo = repo.IncarcaListaMasini();
            var etc = masinaRepo.Select(_ => _.CIV.ToString()).Distinct().ToList();
            var eventRepo = repo.IncarcaListaDeEvenimente();
            //   List<Masina> nouaMasina = masinaRepo.Select(_=>_.CIV).Distinct().ToList();
         //   var distincIndex = masinaRepo.FindIndex(_ => _.CIV.Text).Distinct();
            List<MasinaMVC> masina = new List<MasinaMVC>();
            foreach (Masina x in masinaRepo)
            {
                Console.WriteLine(x.CIV.ToString());
                string ceva = x.CIV.ToString();
                var mVC = new MasinaMVC(
                                        x.CIV.ToString(),x.Tip,x.Marca.ToString(),x.ToString(),x.An.ToString(),x.Pret.ToString(),x.Kilometraj.ToString(),
                                        x.Descriere.ToString(),x.Motorizare.ToString(),x.Culoare.ToString(),x.Putere.ToString(),
                                        x.CapacitateCilindrica.ToString()
                                        );

                
                    mVC.Stare = x.stare;
                    masina.Add(mVC);
                
            }
            ViewBag.Model = masina;
            return View(masina);
        }

        public ActionResult AfisareMasiniRezervate()
        {
            var repo = new ReadRepository();
            masinaRepo = repo.IncarcaListaMasini();
           // masinaRepo.Sort();

            var id = repo.IncarcaIdRadacina();
            //for (int i=0; i < masinaRepo.Count();i++)
            //{
            //    if(masinaRepo[i].CIV.ToString().Equals(masinaRepo[i+1].CIV.ToString()))
            //        masina
            //}
            var eventRepo = repo.IncarcaListaDeEvenimente();
            List<MasinaMVC> masina = new List<MasinaMVC>();
            foreach (Masina x in masinaRepo)
            {
                Console.WriteLine(x.CIV.ToString());
                string ceva = x.CIV.ToString();
                var mVC = new MasinaMVC(
                                        x.CIV.ToString(), x.Tip, x.Marca.ToString(), x.ToString(), x.An.ToString(), x.Pret.ToString(), x.Kilometraj.ToString(),
                                        x.Descriere.ToString(), x.Motorizare.ToString(), x.Culoare.ToString(), x.Putere.ToString(),
                                        x.CapacitateCilindrica.ToString()
                                        );


                if (mVC.Stare == proiect_pssc.Model.Masina.StareMasina.Rezervata)
                {
                    mVC.Stare = x.stare;
                    masina.Add(mVC);
                }

            }
            ViewBag.Model = masina;
            return View("AfisareMasini",masina);
        }

    }
}