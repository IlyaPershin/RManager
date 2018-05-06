using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RManager.Models.Repositoryes
{
    public class RecipePrepPrepRepository
    {
        static ModelContainer cont = new ModelContainer();

        public RecipePrepPrepRepository(ModelContainer _cont)
        {
            cont = _cont;
        }

        public IEnumerable<RecipePrepPrep> RecipesPrepIngr()
        {
            return cont.RecipePrepPrep.OrderBy(c => c.Id);
        }

        static public RecipePrepPrep GetRecipePrepPrepById(int id)
        {
            return cont.RecipePrepPrep.SingleOrDefault(c => c.Id == id);
        }

        static public IEnumerable<RecipePrepPrep> GetRecipesPrepIngsByPrepack(Prepack prepack, IEnumerable<RecipePrepPrep> RecipePrepPreps)
        {
            if (RecipePrepPreps == null)
                RecipePrepPreps = cont.RecipePrepPrep.OrderBy(c => c.Id);
            return RecipePrepPreps.ToList().FindAll(p => p.Prepack.Id == prepack.Id);
        }

        static public IEnumerable<RecipePrepPrep> GetRecipesPrepIngsByResult(Prepack result, IEnumerable<RecipePrepPrep> RecipePrepPreps)
        {
            if (RecipePrepPreps == null)
                RecipePrepPreps = cont.RecipePrepPrep.OrderBy(c => c.Id);
            return RecipePrepPreps.ToList().FindAll(p => p.Result.Id == result.Id);
        }

        public void DeleteRecipePrepPrep(int id)
        {
            cont.RecipePrepPrep.Remove(cont.RecipePrepPrep.Find(id));
            cont.SaveChanges();
        }

        public RecipePrepPrep AddRecipePrepPrep(double volume, string description, Prepack prepack, Prepack result)
        {
            RecipePrepPrep p = new RecipePrepPrep
            {
                Volume = volume,
                Description = description,
                Prepack = prepack,
                Result = result,
            };
            cont.RecipePrepPrep.Add(p);
            cont.SaveChanges();
            return p;
        }

        public RecipePrepPrep EditRecipePrepPrep(int id, double volume, string description)
        {
            RecipePrepPrep p = cont.RecipePrepPrep.SingleOrDefault(c => c.Id == id);
            p.Volume = volume;
            p.Description = description;
            cont.RecipePrepPrep.Add(p);
            cont.SaveChanges();
            return p;
        }
    }
}