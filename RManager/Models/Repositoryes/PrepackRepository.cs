using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RManager.Models.Repositoryes
{
    public class PrepackRepository
    {
        static ModelContainer cont = new ModelContainer();

        public PrepackRepository(ModelContainer _cont)
        {
            cont = _cont;
        }

        public IEnumerable<Prepack> Prepacks()
        {
            return cont.Prepack.OrderBy(c => c.Id);
        }

        static public Prepack GetPrepackById(int id)
        {
            return cont.Prepack.SingleOrDefault(c => c.Id == id);
        }

        static public IEnumerable<Prepack> GetPrepacksByName(string name)
        {
            return cont.Prepack.ToList().FindAll(p => p.Name == name);
        }

        static public IEnumerable<Prepack> GetPrepacksByName(string name, IEnumerable<Prepack> Prepacks)
        {
            return Prepacks.ToList().FindAll(p => p.Name == name);
        }

        public void DeletePrepack(int id)
        {
            if (cont.RecipeDishPrep.ToList().Exists(o => o.Prepack.Id == id) ||
                //cont.RecipePrepIngr.ToList().Exists(o => o.Prepack.Id == id) ||
                cont.RecipePrepPrep.ToList().Exists(o => o.Prepack.Id == id))// ||
                //cont.RecipePrepPrep.ToList().Exists(o => o.Result.Id == id))
            {
                //cont.Prepack.SingleOrDefault(p => p.Id == id).IsExist = false;
                return;
            }
            cont.Prepack.Remove(cont.Prepack.Find(id));
            cont.SaveChanges();
        }

        public Prepack AddPrepack(Prepack prepack)
        {
            Prepack p = new Prepack
            {
                Name = prepack.Name,
                Description = prepack.Description,
                FinalVolume = prepack.FinalVolume,
                IsExist = true,
                Measure = prepack.Measure,
                VendorCode = prepack.VendorCode,
                CookStartTime = prepack.CookStartTime,
                CookEndTime = prepack.CookEndTime,
                LossDuringCleaning = prepack.LossDuringCleaning,
                LossDuringFrying = prepack.LossDuringFrying,
                OtherLosses = prepack.OtherLosses,

                Energy = prepack.Energy,
            };

            prepack.IsExist = false;

            cont.Prepack.Add(p);
            cont.SaveChanges();
            return p;
        }

        public Prepack AddPrepack(string name, string description, double finalVolume, byte measure,
            string vendorCode, DateTime start, DateTime end,
            double cleanLoss, double fryLoss, double otherLosses,
            double protains, double fats, double carbohydrates, double energyCalorie, double energyJoule)
        {
            Prepack p = new Prepack
            {
                Name = name,
                Description = description,
                FinalVolume = finalVolume,
                IsExist = true,
                Measure = (Measure)measure,
                VendorCode = vendorCode,
                CookStartTime = start,
                CookEndTime = end,
                LossDuringCleaning = cleanLoss,
                LossDuringFrying = fryLoss,
                OtherLosses = otherLosses,

                Energy =
                {
                    Protains = protains,
                    Fats = fats,
                    Carbohydrates = carbohydrates,
                    EnergyCalorie = energyCalorie,
                    EnergyJoule = energyJoule,
                },
            };
            cont.Prepack.Add(p);
            cont.SaveChanges();
            return p;
        }

        public Prepack EditPrepack(string vendorCode, string name, string description, double finalVolume, byte measure,
            DateTime start, DateTime end,
            double cleanLoss, double fryLoss, double otherLosses,
            double protains, double fats, double carbohydrates, double energyCalorie, double energyJoule)
        {
            Prepack p = cont.Prepack.SingleOrDefault(pr => pr.IsExist && pr.VendorCode == vendorCode);
            if (cont.RecipeDishPrep.ToList().Exists(r => r.Prepack.Id == p.Id) ||
                cont.RecipePrepPrep.ToList().Exists(r => r.Prepack.Id == p.Id) ||
                cont.RecipePrepPrep.ToList().Exists(r => r.Result.Id == p.Id) ||
                cont.RecipePrepIngr.ToList().Exists(r => r.Prepack.Id == p.Id))
            {
                IEnumerable<RecipeDishPrep> rdp = cont.RecipeDishPrep.ToList().FindAll(r => r.Dish.IsExist && r.Prepack.IsExist && r.Prepack.VendorCode == vendorCode);
                IEnumerable<RecipePrepPrep> rrp = cont.RecipePrepPrep.ToList().FindAll(r => r.Result.IsExist && r.Prepack.IsExist && r.Prepack.VendorCode == vendorCode);
                IEnumerable<RecipePrepPrep> rpr = cont.RecipePrepPrep.ToList().FindAll(r => r.Result.IsExist && r.Prepack.IsExist && r.Result.VendorCode == vendorCode);
                IEnumerable<RecipePrepIngr> rpi = cont.RecipePrepIngr.ToList().FindAll(r => r.Ingredient.IsExist && r.Prepack.IsExist && r.Prepack.VendorCode == vendorCode);
                p = AddPrepack(p);

                List<Dish> dishes = new List<Dish>(rdp.Select(r => r.Dish)).Distinct().ToList();
                foreach (Dish d in dishes)
                {
                    Dish dish = new DishRepository(cont).AddDish(d);
                    foreach (RecipeDishPrep rd in cont.RecipeDishPrep.ToList().FindAll(r => r.Dish.Id == d.Id))
                    {
                        new RecipeDishPrepRepository(cont).AddRecipeDishPrep(rd.Volume, rd.Description, p, dish);
                    }
                }

                List<Prepack> results = new List<Prepack>(rrp.Select(r => r.Result)).Distinct().ToList();
                foreach (Prepack res in results)
                {
                    Prepack result = AddPrepack(res);
                    foreach (RecipePrepPrep rd in cont.RecipePrepPrep.ToList().FindAll(r => r.Result.Id == res.Id))
                    {
                        new RecipePrepPrepRepository(cont).AddRecipePrepPrep(rd.Volume, rd.Description, p, result);
                    }
                }

                foreach (RecipePrepPrep r in rpr)
                {
                    new RecipePrepPrepRepository(cont).AddRecipePrepPrep(r.Volume, r.Description, r.Prepack, p);
                }

                foreach (RecipePrepIngr r in rpi)
                {
                    new RecipePrepIngrRepository(cont).AddRecipePrepIngr(r.Volume, r.Description, r.Ingredient, p);
                }
            }
            else
            {
                p = cont.Prepack.SingleOrDefault(c => c.VendorCode.Equals(vendorCode));
                p.Name = name;
                p.Description = description;
                p.FinalVolume = finalVolume;
                p.Measure = (Measure)measure;
                p.CookStartTime = start;
                p.CookEndTime = end;
                p.LossDuringCleaning = cleanLoss;
                p.LossDuringFrying = fryLoss;
                p.OtherLosses = otherLosses;

                p.Energy = new EnergyValue
                {
                    Protains = protains,
                    Fats = fats,
                    Carbohydrates = carbohydrates,
                    EnergyCalorie = energyCalorie,
                    EnergyJoule = energyJoule,
                };
            }
            cont.SaveChanges();
            return p;
        }
    }
}