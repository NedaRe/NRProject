using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SearchEngineeUI.Models;

namespace SearchEngineeUI.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        [HttpPost]
        public ActionResult Search()
        {
            ResultMessage messgae = new ResultMessage
            {
                SearchKey = "static search",
                Result =
                    $"We couldn't find much informtion for this. if you are interested search for one of bellow subject and Class Object orInheritence"
            };

            @ViewBag.Message = $"What we found is: {messgae.Result}";
            return PartialView("_Result");
        }
    }
}