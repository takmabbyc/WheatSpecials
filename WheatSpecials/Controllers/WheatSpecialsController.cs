using Microsoft.AspNetCore.Mvc;
using WheatSpecials.Models.Database;

namespace WheatSpecials.Controllers
{
    public class WheatSpecialsController : Controller
    {
        public IActionResult Index()
        {
            IEnumerable<WheatBeer> wheatBeers = dbActions.GetItems();
            return View(wheatBeers);
        }

        [HttpPost]
        [ActionName("AddNew")]
        public IActionResult PostAddNew()
        {
            string itemName = Request.Form["itemname"];

            dbActions.CreateNewItem(itemName);

            return RedirectToAction("Index");
        }

        [ActionName("Remove")]
        public IActionResult Remove()
        {
            int id = Convert.ToInt32(Request.Path.ToString().Split('/').LastOrDefault());

            dbActions.RemoveItem(id);

            return RedirectToAction("Index");
        }

        private readonly DbActions dbActions = new DbActions();
    }
}
