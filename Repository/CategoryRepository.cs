using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(RepositoryContext repositoryContext) 
            : base(repositoryContext)
        {
        }

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
    }
}
