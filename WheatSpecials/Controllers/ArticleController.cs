using Microsoft.AspNetCore.Mvc;
using WheatSpecials.Models.Database;

namespace WheatSpecials.Controllers
{
    public class ArticleController : Controller
    {
        public IActionResult Index()
        {
            int id = Convert.ToInt32(Request.Path.ToString().Split('/').LastOrDefault());
            WheatBeer item = dbActions.GetItems(item => item.Id == id).SingleOrDefault();

            return View(item);
        }

        private readonly DbActions dbActions = new DbActions();
    }
}
