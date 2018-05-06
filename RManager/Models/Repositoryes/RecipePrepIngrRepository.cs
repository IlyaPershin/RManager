using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RManager.Models.Repositoryes
{
    public class RecipePrepIngrRepository
    {
        static ModelContainer cont = new ModelContainer();

        public RecipePrepIngrRepository(ModelContainer _cont)
        {
            cont = _cont;
        }

        public IEnumerable<RecipePrepIngr> RecipesPrepIngr()
        {
            return cont.RecipePrepIngr.OrderBy(c => c.Id);
        }

        static public RecipePrepIngr GetRecipePrepIngrById(int id)
        {
            return cont.RecipePrepIngr.SingleOrDefault(c => c.Id == id);
        }

        static public IEnumerable<RecipePrepIngr> GetRecipesPrepIngsByIngredient(Product ingredient, IEnumerable<RecipePrepIngr> recipePrepIngrs)
        {
            if (recipePrepIngrs == null)
                recipePrepIngrs = cont.RecipePrepIngr.OrderBy(c => c.Id);
            return recipePrepIngrs.ToList().FindAll(p => p.Ingredient.Id == ingredient.Id);
        }

        static public IEnumerable<RecipePrepIngr> GetRecipesPrepIngsByPrepack(Prepack prepack, IEnumerable<RecipePrepIngr> recipePrepIngrs)
        {
            if (recipePrepIngrs == null)
                recipePrepIngrs = cont.RecipePrepIngr.OrderBy(c => c.Id);
            return recipePrepIngrs.ToList().FindAll(p => p.Prepack.Id == prepack.Id);
        }

        public void DeleteRecipePrepIngr(int id)
        {
            cont.RecipePrepIngr.Remove(cont.RecipePrepIngr.Find(id));
            cont.SaveChanges();
        }

        public RecipePrepIngr AddRecipePrepIngr(double volume, string description, Product ingredient, Prepack prepack)
        {
            RecipePrepIngr p = new RecipePrepIngr
            {
                Volume = volume,
                Description = description,
                Ingredient = ingredient,
                Prepack = prepack,
            };
            cont.RecipePrepIngr.Add(p);
            cont.SaveChanges();
            return p;
        }

        public RecipePrepIngr EditRecipePrepIngr(int id, double volume, string description)
        {
            RecipePrepIngr p = cont.RecipePrepIngr.SingleOrDefault(c => c.Id == id);
            p.Volume = volume;
            p.Description = description;
            cont.RecipePrepIngr.Add(p);
            cont.SaveChanges();
            return p;
        }
    }
}