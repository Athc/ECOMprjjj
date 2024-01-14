using Microsoft.EntityFrameworkCore;
using ECOMMERCE.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECOMMERCE.Data;

namespace ECOMMERCE.Repositories
{
    public class HomeRepository : IHomeRepository
    {
        private readonly ApplicationDbContext _db;

        public HomeRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Category>> Categories()
        {
            return await _db.Categories.ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProducts(string sTerm = "", int categoryId = 0)
        {
            sTerm = sTerm.ToLower();
            IEnumerable<Product> products = await (from product in _db.Products
                                                   join category in _db.Categories
                                                   on product.CategoryId equals category.Id
                                                   where string.IsNullOrWhiteSpace(sTerm) || (product != null && product.ProductName.ToLower().StartsWith(sTerm))
                                                   select new Product
                                                   {
                                                       ProductId = product.ProductId,
                                                       Image = product.Image,
                                                       CategoryId = product.CategoryId,
                                                       Price = product.Price,
                                                       ProductName = product.ProductName,
                                                       CategoryName = category.CategoryName
                                                   }
                         ).ToListAsync();

            if (categoryId > 0)
            {
                products = products.Where(p => p.CategoryId == categoryId).ToList();
            }

            return products;
        }
    }
}
