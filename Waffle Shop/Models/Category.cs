namespace Waffle_Shop.Models
{
    // Parent Class
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        
        // Child Reference
        public List<Pie> Pies { get; set; }

    }
}
