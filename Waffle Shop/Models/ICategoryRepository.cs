namespace Waffle_Shop.Models
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> AllCategories { get; }
        int UpdateStudent(Category category);
        int CreateStudent(Category category);
        int RemoveStudent(Category category);

    }
}
