using SportsStore.Domian.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Entities;
namespace SportsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IproductRepository repository;
        public ProductController(IproductRepository productRepository)
        {
            this.repository = productRepository;
        }
        public ViewResult List()
        {
            return View(repository.Products);
        }
       
    }
}