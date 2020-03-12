using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMKart.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace CMKart.Controllers
{
    public class ProductController : Controller
    {
        public IProductRepository pRepo=new ProductRepository();

        //public ProductController( IProductRepository pRepo)
        //{

        //    pRepo = new ProductRepository();
        //    this.pRepo = pRepo;
        //}
        public IActionResult Index()
        {

            var pCategory=pRepo.GetProductCatergory();
            return View(pCategory);
        }


        public IActionResult GetProducts()
        {

            return View("Products");
        }
    }
}