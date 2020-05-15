using ChatUygulamasi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChatUygulamasi.Controllers
{
    public class HomeController : Controller
    {
        DataContext db = new DataContext();

        public ActionResult Index()
        {
           

            return View();
        }

        [HttpPost]
        public JsonResult MesajGetir(string alici,string gonderen)
        {

            var mesajlar=db.Mesajs.Where(x => (x.AliciAdi == alici && x.GonderenAdi == gonderen) || (x.AliciAdi == gonderen && x.GonderenAdi == alici)).ToList();

            List<SelectListItem> model = new List<SelectListItem>();

            foreach (var mesaj in mesajlar)
            {
                model.Add(new SelectListItem()
                {
                    Value = mesaj.GonderenAdi,
                    Text = mesaj.MesajMetin,

                }); ;

            }

            return Json(model, JsonRequestBehavior.AllowGet);

        }



    }
}