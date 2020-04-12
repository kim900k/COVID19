using Covid19.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Covid19.Controllers
{
    public class CovidController : Controller
    {
        private string BuscaPath()
        {
            string fileName = $"{DateTime.Now.Date.ToString("dd-MM-yyyy")}.csv";
            return Path.Combine(Server.MapPath("~/App_Data"), Path.GetFileName(fileName));
        }
        public ActionResult Dashboard(string Regiao, string UF)
        {
            try
            {
                StreamReader reader = new StreamReader(BuscaPath());
                return View(new LabelsDTO());
            } catch(Exception)
            {
                return RedirectToAction("Upload");
            }
        }

        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            if(file != null && file.ContentLength > 0)
                try
                {
                    file.SaveAs(BuscaPath());
                } catch(Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                } else
            {
                ViewBag.Message = "You have not specified a file.";
            }

            return RedirectToAction("Dashboard");
        }
    }
}