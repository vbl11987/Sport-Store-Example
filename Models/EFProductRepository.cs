using System.Collections.Generic;

namespace SportsStore.Models
{
    public class EFProductRepository : IProductRepository
    {
        private SportsStoreDbContext context;

        public EFProductRepository(SportsStoreDbContext cont) {
            context = cont;
        }

        public IEnumerable<Product> Products => context.Products;
    }
}