using Microsoft.EntityFrameworkCore;
using NLayer.Core.Models;
using NLayer.Core.Repositories;
using NLayerRepository.Reporsitories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerRepository.Reporistories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {

        }
        public async Task<List<Product>> GetProductWithCategory()
        {
            //Eager_loading;
            return await _context.Products.Include(i => i.Category).ToListAsync();
        }
    }

}
