using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UI.Messaging;
using UI.ViewModel;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UI.Controlers
{
    public class SearchController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Search(string query)
        {
            SearchViewModel searchViewModel=new SearchViewModel();
            Sender _sender=new Sender();
           
            _sender.Send(query);
            Receiver _Receiver = new Receiver();
          
            //searchViewModel.Result = _Receiver.

            return View();



        }
    }
}
