using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SearchEngineeUI.Models;

namespace SearchEngineeUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SearchResult(string key)
        {
            ResultMessage messgae = new ResultMessage
            {
                SearchKey = key,
                Result =
                $"We couldn't find much informtion for {key}<br/> if you are interested search for one of bellow subject</br>Class</br>Object</br>Inheritence"
            };

            return View();
        }
 
    }
}