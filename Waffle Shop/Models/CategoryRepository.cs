namespace Waffle_Shop.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext appDbContext;
        public CategoryRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public IEnumerable<Category> AllCategories => appDbContext.Categories;

        public int CreateCategory(Category category)
        {
            appDbContext.Categories.Add(category);
            return appDbContext.SaveChanges();
        }

        public int RemoveCategory(Category category)
        {
            appDbContext.Categories.Remove(category);
            return appDbContext.SaveChanges();
        }

        public int UpdateCategory(Category category)
        {
            appDbContext.Categories.Update(category);
            return appDbContext.SaveChanges();
        }
    }
}

        