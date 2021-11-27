using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(RepositoryContext repositoryContext) 
            : base(repositoryContext)
        {
        }

        // Sync
        public IEnumerable<Category> GetAllCategories()
        {
            return FindAll()
                .OrderBy(c => c.CategoryName)
                .ToList();
        }

        public Category GetCategoryById(int id)
        {
            return FindByCondition(c => c.Id.Equals(id)).FirstOrDefault();
        }

        public Category GetCatgoryWithOwnProducts(int id)
        {
            return FindByCondition(c => c.Id.Equals(id))
                .Include(p => p.Products)
                .FirstOrDefault();
        }
        public void CreateCategory(Category category)
        {
            Create(category);
        }

        public void UpdateCategory(Category category)
        {
            Update(category);
        }

        public void DeleteCategory(Category category)
        {
            Delete(category);
        }

        // Async
        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await FindAll()
                .OrderBy(c => c.CategoryName)
                .ToListAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await FindByCondition(c => c.Id.Equals(id))
                .FirstOrDefaultAsync();
        }

        public async Task<Category> GetCatgoryWithOwnProductsAsync(int id)
        {
            return await FindByCondition(c => c.Id.Equals(id))
                .Include(p => p.Products)
                .FirstOrDefaultAsync();
        }
    }
}
