using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BarkodOkuma.Data;

namespace BarkodOkuma.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            var result = new Models.AllProducts().All();

            return View(result);


        }


       
	}
}