using Microsoft.AspNetCore.Mvc;
using WheatSpecials.Models.Database;

namespace WheatSpecials.Controllers
{
    public class EditController : Controller
    {
        [ActionName("Index")]
        public IActionResult Index()
        {
            int id = Convert.ToInt32(Request.Path.ToString().Split('/').LastOrDefault());
            WheatBeer item = dbActions.GetItems(item => item.Id == id).SingleOrDefault();

            return View(item);
        }

        [HttpPost]
        [ActionName("Edit")]
        public IActionResult Edit()
        {
            int id = Convert.ToInt32(Request.Path.ToString().Split('/').LastOrDefault());
            dbActions.UpdateItem(id, Request.Form["itemname"], Request.Form["description"], Request.Form["percentage"], Request.Form["image"]);

            return Redirect("/WheatSpecials");
        }

        private readonly DbActions dbActions = new DbActions();
    }
}
