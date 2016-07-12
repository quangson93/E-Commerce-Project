using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLBH_MVC.Models;
namespace QLBH_MVC.Controllers
{
    public class CategoryController : Controller
    {
        // GET: /Category/PartialList
        public ActionResult PartialList()
        {
            using(QLBHEntities1 ctx = new QLBHEntities1())
            {
                List<Category> list = ctx.Categories.ToList();
                return PartialView(list);
            }
        }
    }
}