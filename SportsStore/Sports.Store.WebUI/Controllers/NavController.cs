using SportsStore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.WebUI.Controllers
{
    public class NavController : Controller
    {
        private IProductRepository repostory;
        public NavController(IProductRepository repo)
        {
            repostory = repo;
        }
        public PartialViewResult Menu(string category=null)
        {
            ViewBag.SelectedCategory = category;
            IEnumerable<string> categories = repostory.Products
                                           .Select(x => x.Category)
                                           .Distinct()
                                           .OrderBy(x => x);
            return PartialView(categories);
        }
        // GET: Nav
        public ActionResult Index()
        {
            return View();
        }
    }
}