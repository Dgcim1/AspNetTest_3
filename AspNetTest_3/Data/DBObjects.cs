using AspNetTest_3.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace AspNetTest_3.Data
{
    public class DBObjects
    {
        public static void TruncateProducts(ApplicationDbContext context)
        {
            context.Products.RemoveRange(context.Products);
            context.SaveChanges();
        }

        public static void InitialProductTypes(ApplicationDbContext context)
        {
            if (!context.ProductTypes.Any())
            {
                context.ProductTypes.AddRange(ProductTypes.Select(pair => pair.Value));
            }
            context.SaveChanges();
        }

        public static void InitialProducts(ApplicationDbContext context)
        {
            if (!context.Products.Any())
            {
                context.Products.AddRange(Products.Select(pair => pair.Value));
            }
            context.SaveChanges();
        }

        public static Dictionary<string, ProductType> ProductTypes { get; } =
            new ProductType[] {
                new ProductType {
                    Name = "Пончики",
                    Description = "Великолепные вкуснейшие пончики"
                },
                new ProductType {
                    Name = "Напитки",
                    Description = "Вкусные теплые и охлажденные напитки"
                },
            }.ToDictionary(key => key.Name, val => val);

        public static Dictionary<string, Product> Products { get; } =
            new Product[] {
                new Product {
                    Name = "Желтый пончик",
                    Price = 100.00m,
                    LongDescription = "Длиииное описание",
                    ShortDescription = "Самый желтый пончик в мире!",
                    ProductType = ProductTypes["Пончики"],
                    ProductTypeId = ProductTypes["Пончики"].id,
                    Proteins = 20,
                    Fats = 30,
                    Carbohydrates = 25,
                    EnergyValue = 1200,
                    Picture = "ponch-1.jpg"
                },
                new Product {
                    Name = "Ненастоящий пончик",
                    Price = 60.00m,
                    LongDescription = "Длиииное описание",
                    ShortDescription = "Такой пончик существует разве что в симпсонах, так что смотрите и пускайте слюнки, такое вы не получите!",
                    ProductType = ProductTypes["Пончики"],
                    ProductTypeId = ProductTypes["Пончики"].id,
                    Proteins = 20,
                    Fats = 30,
                    Carbohydrates = 25,
                    EnergyValue = 1200,
                    Picture = "ponch-2.webp"
                },
            }.ToDictionary(key => key.Name, val => val);
    }
}
