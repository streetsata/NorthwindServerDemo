using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICategoryRepository : IRepositoryBase<Category>
    {
        // HttpGet
        IEnumerable<Category> GetAllCategories();
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Category GetCategoryById(int id);
        Task<Category> GetCategoryByIdAsync(int id);
        Category GetCatgoryWithOwnProducts(int id);
        Task<Category> GetCatgoryWithOwnProductsAsync(int id);

        // HttpPost
        void CreateCategory(Category category);

        // HttpPut
        void UpdateCategory(Category category);

        // HttpDelete
        void DeleteCategory(Category category);
    }
}
