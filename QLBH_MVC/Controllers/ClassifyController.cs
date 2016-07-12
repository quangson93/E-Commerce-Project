using QLBH_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLBH_MVC.Controllers
{
    public class ClassifyController : Controller
    {
        // GET: /Classify/PartialList
        public ActionResult PartialList()
        {
            using (QLBHEntities1 ctx = new QLBHEntities1())
            {
                List<Classify> list = ctx.Classifies.ToList();
                return PartialView(list);
            }
        }
    }
}