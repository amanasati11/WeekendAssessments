namespace Waffle_Shop.Models
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> AllCategories { get; }

    }
}
