using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLBH_MVC.Models;

namespace QLBH_MVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/Index
        public ActionResult Index()
        {
            using(QLBHEntities1 ctx = new QLBHEntities1())
            {
                HomeModel model = new HomeModel
                {
                    BestSellingProducts = new List<ArrangeProduct>(),
                    LatestProducts = new List<ArrangeProduct>(),
                    MostViewedProducts = new List<ArrangeProduct>()
                };

                List<Product> lstSales = ctx.Products.OrderByDescending(p => p.Sales).Take(10).ToList();
                foreach(Product p in lstSales)
                {
                    ArrangeProduct ap = new ArrangeProduct
                    {
                        ProID = p.ProID,
                        ProName = p.ProName,
                        Price = p.Price,
                        Quantity = p.Quantity
                    };
                    model.BestSellingProducts.Add(ap);
                }

                List<Product> lstViews = ctx.Products.OrderByDescending(p => p.View).Take(10).ToList();
                foreach (Product p in lstViews)
                {
                    ArrangeProduct ap = new ArrangeProduct
                    {
                        ProID = p.ProID,
                        ProName = p.ProName,
                        Price = p.Price,
                        Quantity = p.Quantity
                    };
                    model.MostViewedProducts.Add(ap);
                }

                List<Product> lstLatest = ctx.Products.OrderByDescending(p => p.DayAdd).Take(10).ToList();
                foreach (Product p in lstLatest)
                {
                    ArrangeProduct ap = new ArrangeProduct
                    {
                        ProID = p.ProID,
                        ProName = p.ProName,
                        Price = p.Price,
                        Quantity = p.Quantity
                    };
                    model.LatestProducts.Add(ap);
                }
                return View(model);
            }
        }
    }
}