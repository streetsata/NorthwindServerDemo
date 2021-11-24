using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface ICategoryRepository : IRepositoryBase<Category>
    {
        // HttpGet
        IEnumerable<Category> GetAllCategories();
        Category GetCategoryById(int id);
        Category GetCatgoryWithOwnProducts(int id);

        // HttpPost
        void CreateCategory(Category category);

        // HttpPut
        void UpdateCategory(Category category);
    }
}
