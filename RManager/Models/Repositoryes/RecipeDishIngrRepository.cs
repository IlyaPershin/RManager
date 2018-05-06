using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RManager.Models.Repositoryes
{
    public class RecipeDishIngrRepository
    {
        static ModelContainer cont = new ModelContainer();

        public RecipeDishIngrRepository(ModelContainer _cont)
        {
            cont = _cont;
        }

        public IEnumerable<RecipeDishIngr> RecipesPrepIngr()
        {
            return cont.RecipeDishIngr.OrderBy(c => c.Id);
        }

        static public RecipeDishIngr GetRecipeDishIngrById(int id)
        {
            return cont.RecipeDishIngr.SingleOrDefault(c => c.Id == id);
        }

        static public IEnumerable<RecipeDishIngr> GetRecipesPrepIngsByIngredient(Product ingredient, IEnumerable<RecipeDishIngr> RecipeDishIngrs)
        {
            if (RecipeDishIngrs == null)
                RecipeDishIngrs = cont.RecipeDishIngr.OrderBy(c => c.Id);
            return RecipeDishIngrs.ToList().FindAll(p => p.Ingredient.Id == ingredient.Id);
        }

        static public IEnumerable<RecipeDishIngr> GetRecipesPrepIngsByDish(Dish dish, IEnumerable<RecipeDishIngr> RecipeDishIngrs)
        {
            if (RecipeDishIngrs == null)
                RecipeDishIngrs = cont.RecipeDishIngr.OrderBy(c => c.Id);
            return RecipeDishIngrs.ToList().FindAll(p => p.Dish.Id == dish.Id);
        }

        public void DeleteRecipeDishIngr(int id)
        {
            cont.RecipeDishIngr.Remove(cont.RecipeDishIngr.Find(id));
            cont.SaveChanges();
        }

        public RecipeDishIngr AddRecipeDishIngr(double volume, string description, Product ingredient, Dish dish)
        {
            RecipeDishIngr p = new RecipeDishIngr
            {
                Volume = volume,
                Description = description,
                Ingredient = ingredient,
                Dish = dish,
            };
            cont.RecipeDishIngr.Add(p);
            cont.SaveChanges();
            return p;
        }

        public RecipeDishIngr EditRecipeDishIngr(int id, double volume, string description)
        {
            RecipeDishIngr p = cont.RecipeDishIngr.SingleOrDefault(c => c.Id == id);
            p.Volume = volume;
            p.Description = description;
            cont.RecipeDishIngr.Add(p);
            cont.SaveChanges();
            return p;
        }
    }
}