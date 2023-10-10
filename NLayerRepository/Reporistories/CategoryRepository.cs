using Microsoft.EntityFrameworkCore;
using NLayer.Core.Models;
using NLayer.Core.Repositories;
using NLayerRepository.Reporsitories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerRepository.Reporistories
{

    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Category> GetSingleCategoryByIdWithProductsAsync(int categoryId)
        {
            //birden fazla bulursa exception dön
            return await _context.Categories
                          .Include(i => i.Product)
                          .Where(w => w.Id == categoryId).SingleOrDefaultAsync();
        }
    }
}
