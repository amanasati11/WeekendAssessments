using Microsoft.EntityFrameworkCore;

namespace PieAPI.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext appDbContext;
        public CategoryRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public IEnumerable<Category> AllCategories => appDbContext.categories;

        public Category DeleteCategory(int categoryID)
        {
            var DeleteCat = AllCategories
                .FirstOrDefault(category => category.CategoryId == categoryID);
            var entry = this.appDbContext.categories.Remove(DeleteCat);
            this.appDbContext.SaveChanges();
            return entry.Entity;
        }

        public Category InsertCategory(Category category)
        {
            var InsertCat = this.appDbContext.categories.Add(category);
            this.appDbContext.SaveChanges();
            return InsertCat.Entity;
        }

        public Category UpdateCategory(Category category)
        {
            var UpdateCat = this.appDbContext.categories.Update(category);
            this.appDbContext.SaveChanges();
            return UpdateCat.Entity;
        }
    }
}
