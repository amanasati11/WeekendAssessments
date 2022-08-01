namespace Waffle_Shop.Models
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> AllCategories { get; }
        int UpdateCategory(Category category);
        int CreateCategory(Category category);
        int RemoveCategory(Category category);

    }
}
