using System;
using System.Web.Mvc;
using CGeers.Core;

namespace MvcApplication.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to ASP.NET MVC!";

            var cacheObject = (Guid?) Cache.Get("MyCachedObject");
            if (cacheObject == null)
            {
                cacheObject = Guid.NewGuid();
                Cache.Add("MyCachedObject", cacheObject, new TimeSpan(0, 0, 30));
            }
            ViewData["MyCachedObject"] = cacheObject;

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
