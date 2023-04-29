using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using DapperProje.Models;


namespace DapperProje.Controllers
{
    public class SevkiyatController : Controller
    {
        // GET: Sevkiyat
        public ActionResult Index()
        {
            return View(DP.ReturnList<SevkiyatModels>("SevkiyatListele"));
        }

        public ActionResult EY(int id = 0)
        {
            if (id==0)
            {
                return View();
            }
            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@SevkiyatNo", id);
                return View(DP.ReturnList<SevkiyatModels>("SevkiyatSirala", param).FirstOrDefault<SevkiyatModels>());
            }
        }

        [HttpPost]
        public ActionResult EY(SevkiyatModels sevkiyat)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@SevkiyatNo", sevkiyat.SevkiyatNo);
            param.Add("@SevkiyatYeri", sevkiyat.SevkiyatYeri);
            param.Add("@SevkiyatTarihi", sevkiyat.SevkiyatTarihi);
            param.Add("@SirketAdi", sevkiyat.SirketAdi);
            param.Add("@Telefon", sevkiyat.Telefon);
            DP.ExReturn("SevkiyatEY", param);
            return RedirectToAction("Index");
        } 

        public ActionResult Delete(int id = 0)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@SevkiyatNo", id);
            DP.ExReturn("SevkiyatSil", param);
            return RedirectToAction("Index");
        }
    }
}