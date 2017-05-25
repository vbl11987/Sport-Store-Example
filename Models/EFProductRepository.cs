using System.Collections.Generic;
using System.Linq;

namespace SportsStore.Models
{
    public class EFProductRepository : IProductRepository
    {
        private SportsStoreDbContext context;

        public EFProductRepository(SportsStoreDbContext cont) {
            context = cont;
        }

        public IEnumerable<Product> Products => context.Products;

        public void SaveProduct(Product product){
            if (product.ProductID == 0){
                context.Products.Add(product);
            }
            else {
                Product dbEntry = context.Products.FirstOrDefault(p => p.ProductID == product.ProductID);

                if (dbEntry != null){
                    dbEntry.Name = product.Name;
                    dbEntry.Description = product.Description;
                    dbEntry.Category = product.Category;
                    dbEntry.Price = product.Price;
                }
            }
            context.SaveChanges();
        }

        public Product DeleteProduct(int productID){
            Product dbEntry = context.Products.FirstOrDefault(p => p.ProductID == productID);

            if(dbEntry != null){
                context.Products.Remove(dbEntry);
                context.SaveChanges();
            }

            return dbEntry;
        }
    }
}