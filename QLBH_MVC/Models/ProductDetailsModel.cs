using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLBH_MVC.Models
{
    public class ProductDetailsModel
    {
        public int ProID { get; set; }
        public string ProName { get; set; }
        public string FullDes { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int View { get; set; }
        public string CatName { get; set; }
        public string ClassifyName { get; set; }
        public List<ProductSameManufacturerModel> ProductSameManufacs { get; set; }
        public List<ProductSameClassifyModel> ProductSameClassifies { get; set; }
    }

    public class ProductSameManufacturerModel
    {
        public int ProID { get; set; }
        public string ProName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
    public class ProductSameClassifyModel
    {
        public int ProID { get; set; }
        public string ProName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}