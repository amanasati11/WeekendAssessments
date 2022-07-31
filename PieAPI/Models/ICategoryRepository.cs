namespace PieAPI.Models
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> AllCategories { get; }
        Category InsertCategory(Category category);
        Category UpdateCategory(Category category);
        Category DeleteCategory(int categoryID);
    }
}
