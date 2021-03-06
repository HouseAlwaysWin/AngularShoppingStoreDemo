using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Infrastructure.Data {
    public class StoreContextSeed {
        public static async Task SeedAsync (StoreContext context, ILoggerFactory loggerFactory) {
            try {
                if (!context.ProductBrands.Any ()) {
                    var brandsData = File.ReadAllText ("../Infrastructure/Data/SeedData/brands.json");
                    var brands = JsonConvert.DeserializeObject<List<ProductBrand>> (brandsData);

                    foreach (var brand in brands) {
                        context.ProductBrands.Add (brand);
                    }

                    await context.SaveChangesAsync ();
                }

                if (!context.ProductyTypes.Any ()) {
                    var typesData = File.ReadAllText ("../Infrastructure/Data/SeedData/types.json");
                    var types = JsonConvert.DeserializeObject<List<ProductType>> (typesData);

                    foreach (var type in types) {
                        context.ProductyTypes.Add (type);
                    }

                    await context.SaveChangesAsync ();
                }

                if (!context.Products.Any ()) {
                    var productsData = File.ReadAllText ("../Infrastructure/Data/SeedData/products.json");
                    var products = JsonConvert.DeserializeObject<List<Product>> (productsData);

                    foreach (var product in products) {
                        context.Products.Add (product);
                    }

                    await context.SaveChangesAsync ();
                }
            } catch (Exception ex) {
                var logger = loggerFactory.CreateLogger<StoreContextSeed> ();
                logger.LogError (ex.Message);
            }
        }
    }
}