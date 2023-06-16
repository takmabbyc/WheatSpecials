using System.Linq.Expressions;

namespace WheatSpecials.Models.Database
{
    public class DbActions
    {
        public void CreateNewItem(string name)
        {
            WheatBeer wheatBeer = new WheatBeer { Name = name };

            using (var context = new Context())
            {
                context.WheatBeers.Add(wheatBeer);

                context.SaveChanges();
            }
        }

        public IEnumerable<WheatBeer> GetItems(Func<WheatBeer, bool> expression = null)
        {
            using (var context = new Context())
            {
                if (expression is null)
                {
                    return context.WheatBeers.ToArray();
                }

                return context.WheatBeers.Where(expression).ToArray();
            }
        }

        public void UpdateItem(int id, string name, string description, string alcoholPercentage, string imageUrl)
        {
            using (var context = new Context())
            {
                WheatBeer itemToUpdate = context.WheatBeers.Where(wheatBeer => wheatBeer.Id == id).SingleOrDefault();
                itemToUpdate.Id = id;
                itemToUpdate.Name = name;
                itemToUpdate.Description = description;
                itemToUpdate.AlcoholPercentage = alcoholPercentage;
                itemToUpdate.ImageUrl = imageUrl;

                context.SaveChanges();
            }
        }

        public void RemoveItem(int id)
        {
            using (var context = new Context())
            {
                WheatBeer itemToRemove = context.WheatBeers.Where(wheatBeer => wheatBeer.Id == id).SingleOrDefault();
                context.WheatBeers.Remove(itemToRemove);

                context.SaveChanges();
            }
        }
    }
}
