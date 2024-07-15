using Shop.Infrastructure;
using Shop.Infrastructure.Web.StandardTable;
using Shop.Module.Catalog.Entities;
using Shop.Module.Catalog.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shop.Module.Catalog.Services
{
    /// <summary>
    /// Define the service interface for processing product classification related operations.
    /// </summary>
    public interface ICategoryService
    {
        /// <summary>
        /// Get all categories.
        /// </summary>
        /// <returns>分类列表。</returns>
        Task<IList<CategoryResult>> GetAll();

        /// <summary>
        /// Get all categories from cache.
        /// </summary>
        /// <returns>Category List </returns>
        Task<IList<Category>> GetAllByCache();

        /// <summary>
        /// Clear category-related cache.
        /// </summary>
        Task ClearCache();

        /// <summary>
        /// Create New Category
        /// </summary>
        /// <param name="category">The classification entity to create.</param>
        Task Create(Category category);

        /// <summary>
        /// Update an existing category.
        /// </summary>
        /// <param name="category">The classification entity to update.</param>
        Task Update(Category category);

        /// <summary>
        /// Delete the specified category.
        /// </summary>
        /// <param name="category">The classification entity to delete.</param>
        Task Delete(Category category);

        /// <summary>
        /// Get a list of categories, supporting paging and searching.
        /// </summary>
        /// <param name="param">Pagination and search parameters. </param>
        /// <returns>List of categories that meet the criteria. </returns>
        Task<Result<StandardTableResult<CategoryResult>>> List(StandardTableParam param);

        /// <summary>
        /// Toggles display of categories in the menu.
        /// </summary>
        /// <param name="id">The ID of the category.</param>
        Task SwitchInMenu(int id);

        /// <summary>
        /// Get all subcategories under the specified parent category.
        /// </summary>
        /// <param name="parentId">The ID of the parent category.</param>
        /// <param name="all">List of all available categories.</param>
        /// <returns>List of subcategories.</returns>
        IList<CategoryResult> GetChildrens(int parentId, IList<CategoryResult> all);

        /// <summary>
        /// Get the first-level category and the corresponding second-level sub-category.
        /// </summary>
        /// <param name="parentId">The ID of the parent category. If null, get the top-level category and its subcategories.</param>
        /// <param name="isPublished">Whether to only get published categories. </param>
        /// <param name="includeInMenu">Whether to only get the categories included in the menu. </param>
        /// <returns>Category List. </returns>
        Task<IList<CategoryTwoSubResult>> GetTwoSubCategories(int? parentId = null, bool isPublished = true, bool includeInMenu = true);

        /// <summary>
        /// Get only the second-level subcategories of the specified parent category.
        /// </summary>
        /// <param name="parentId">The ID of the parent category. If it is null, get the second-level subcategories of the top-level category.</param>
        /// <param name="isPublished">Whether to only get published categories.</param>
        /// <param name="includeInMenu">Whether to only get categories included in the menu.</param>
        /// <returns>Category List. </returns>
        Task<IList<CategoryTwoSubResult>> GetTwoOnlyCategories(int? parentId = null, bool isPublished = true, bool includeInMenu = true);
    }
}
