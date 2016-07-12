using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLBH_MVC.Models;
using System.Configuration;
using PagedList;
namespace QLBH_MVC.Controllers
{
    public class ProductController : Controller
    {
        // GET: /Product/ByCat/{id}
        public ActionResult ByCat(int? id, int page = 1)
        {
            if(id.HasValue == false)
            {
                return RedirectToAction("Index", "Home");
            }

            int pageSize = Convert.ToInt32( ConfigurationManager.AppSettings["PageSize"]);
            
           

            using(QLBHEntities1 ctx = new QLBHEntities1())
            {
                var query = ctx.Products.Where(p => p.CatID == id);

                int count = query.Count();
                int nPages = count / pageSize + (count % pageSize > 0 ? 1 : 0);

                ViewBag.PageCount = nPages;
                ViewBag.CatId = id;
                ViewBag.CurPage = page;

                List<Product> list = query
                    .OrderBy(p => p.ProID).ToList();
                return View(list.ToPagedList(page, pageSize));
            }
        }

        // GET: /Product/ByClassify/{id}
        public ActionResult ByClassify(int? id)
        {
            if (id.HasValue == false)
            {
                return RedirectToAction("Index", "Home");
            }

            using (QLBHEntities1 ctx = new QLBHEntities1())
            {
                List<Product> list = ctx.Products.Where(p => p.ClassifyID == id).ToList();
                return View(list);
            }
        }

        // GET:  /Product/ProductDetail/{id}
        public ActionResult ProductDetail(int? id)
        {
            if (id.HasValue == false)
            {
                return RedirectToAction("Index", "Home");
            }

            using (QLBHEntities1 ctx = new QLBHEntities1())
            {
                Product pro = ctx.Products.Include("Category").Include("Classify").Where(p => p.ProID == id).FirstOrDefault();
                if(pro == null)
                {
                    return RedirectToAction("Index", "Home");
                }

                ProductDetailsModel model = new ProductDetailsModel
                {
                    ProID = pro.ProID,
                    ProName = pro.ProName,
                    Price = pro.Price,
                    FullDes = pro.FullDes,
                    Quantity = pro.Quantity,
                    View = pro.View,
                    CatName = pro.Category.CatName,
                    ClassifyName = pro.Classify.ClassifyName,
                    ProductSameManufacs = new List<ProductSameManufacturerModel>(),
                    ProductSameClassifies = new List<ProductSameClassifyModel>()
                };

                var listPSM = ctx.Products.Where(p => p.CatID == pro.CatID && p.ProID != pro.ProID).Take(5).ToList();
                foreach (Product p in listPSM)
                {
                    ProductSameManufacturerModel psm = new ProductSameManufacturerModel
                    {
                        ProID = p.ProID,
                        ProName = p.ProName,
                        Price = p.Price,
                        Quantity = p.Quantity
                    };
                    model.ProductSameManufacs.Add(psm);
                }

                var listPSC = ctx.Products.Where(p => p.ClassifyID == pro.ClassifyID && p.ProID != pro.ProID).Take(5).ToList();
                foreach (Product p in listPSC)
                {
                    ProductSameClassifyModel psc = new ProductSameClassifyModel
                    {
                        ProID = p.ProID,
                        ProName = p.ProName,
                        Price = p.Price,
                        Quantity = p.Quantity
                    };
                    model.ProductSameClassifies.Add(psc);
                }
                pro.View++;
                ctx.SaveChanges();
                return View(model);
            }
        }
    }
}