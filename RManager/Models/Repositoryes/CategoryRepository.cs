using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RManager.Models.Repositoryes
{
    public class CategoryRepository
    {
        static ModelContainer cont = new ModelContainer();

        public CategoryRepository(ModelContainer _cont)
        {
            cont = _cont;
        }

        public IEnumerable<Category> Categotyes()
        {
            return cont.Category.OrderBy(c => c.Id);
        }

        static public Category GetCategory(int id)
        {
            return cont.Category.SingleOrDefault(c => c.Id == id);
        }

        public void DeleteCategory(int id)
        {
            List<Category> c = cont.Category.ToList().FindAll(ca => ca.ParrentCategory.Id == id);
            for (int i = 0; i < c.Count(); i++)
            {
                DeleteParrent(c[i].Id);
            }

            cont.Category.Remove(cont.Category.Find(id));
            cont.SaveChanges();
        }

        private void DeleteParrent(int id)
        {
            Category category = GetCategory(id);
            category.ParrentCategory = category.ParrentCategory.ParrentCategory;
        }

        public Category AddCategory(string name)
        {
            Category c = new Category
            {
                Name = name,
                ParrentCategory = null
            };
            cont.Category.Add(c);
            cont.SaveChanges();
            return c;
        }

        public Category AddCategory(string name, Category parrent)
        {
            Category c = new Category
            {
                Name = name,
                ParrentCategory = parrent
            };
            cont.Category.Add(c);
            cont.SaveChanges();
            return c;
        }

        public Category AddCategory(string name, int parrent)
        {
            Category c = new Category
            {
                Name = name,
                ParrentCategory = cont.Category.SingleOrDefault(ca => ca.Id == parrent)
            };
            cont.Category.Add(c);
            cont.SaveChanges();
            return c;
        }

        public Category EditCategory(int id, string name, Category parrent)
        {
            Category c = cont.Category.SingleOrDefault(ca => ca.Id == id);
            c.Name = name;
            c.ParrentCategory = parrent;
            cont.SaveChanges();
            return c;
        }

        public Category EditCategory(int id, string name, int parrent)
        {
            Category c = cont.Category.SingleOrDefault(ca => ca.Id == id);
            c.Name = name;
            c.ParrentCategory = cont.Category.SingleOrDefault(ca => ca.Id == parrent);
            cont.SaveChanges();
            return c;
        }
    }
}