using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLBH_MVC.Models
{
    public class HomeModel
    {
        public List<ArrangeProduct> MostViewedProducts { get; set; }
        public List<ArrangeProduct> BestSellingProducts { get; set; }
        public List<ArrangeProduct> LatestProducts { get; set; }
        
    }

    public class ArrangeProduct
    {
        public int ProID { get; set; }
        public string ProName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}