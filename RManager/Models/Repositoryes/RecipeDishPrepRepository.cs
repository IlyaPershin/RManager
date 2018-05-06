using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RManager.Models.Repositoryes
{
    public class RecipeDishPrepRepository
    {
        static ModelContainer cont = new ModelContainer();

        public RecipeDishPrepRepository(ModelContainer _cont)
        {
            cont = _cont;
        }

        public IEnumerable<RecipeDishPrep> RecipesPrepIngr()
        {
            return cont.RecipeDishPrep.OrderBy(c => c.Id);
        }

        static public RecipeDishPrep GetRecipeDishPrepById(int id)
        {
            return cont.RecipeDishPrep.SingleOrDefault(c => c.Id == id);
        }

        static public IEnumerable<RecipeDishPrep> GetRecipesPrepIngsByPrepack(Prepack prepack, IEnumerable<RecipeDishPrep> RecipeDishPreps)
        {
            if (RecipeDishPreps == null)
                RecipeDishPreps = cont.RecipeDishPrep.OrderBy(c => c.Id);
            return RecipeDishPreps.ToList().FindAll(p => p.Prepack.Id == prepack.Id);
        }

        static public IEnumerable<RecipeDishPrep> GetRecipesPrepIngsByDish(Dish dish, IEnumerable<RecipeDishPrep> RecipeDishPreps)
        {
            if (RecipeDishPreps == null)
                RecipeDishPreps = cont.RecipeDishPrep.OrderBy(c => c.Id);
            return RecipeDishPreps.ToList().FindAll(p => p.Dish.Id == dish.Id);
        }

        public void DeleteRecipeDishPrep(int id)
        {
            cont.RecipeDishPrep.Remove(cont.RecipeDishPrep.Find(id));
            cont.SaveChanges();
        }

        public RecipeDishPrep AddRecipeDishPrep(double volume, string description, Prepack prepack, Dish dish)
        {
            RecipeDishPrep p = new RecipeDishPrep
            {
                Volume = volume,
                Description = description,
                Prepack = prepack,
                Dish = dish,
            };
            cont.RecipeDishPrep.Add(p);
            cont.SaveChanges();
            return p;
        }

        public RecipeDishPrep EditRecipeDishPrep(int id, double volume, string description)
        {
            RecipeDishPrep p = cont.RecipeDishPrep.SingleOrDefault(c => c.Id == id);
            p.Volume = volume;
            p.Description = description;
            cont.RecipeDishPrep.Add(p);
            cont.SaveChanges();
            return p;
        }
    }
}