namespace Waffle_Shop.Models
{
    public class ShoppingCartItem
    {
        // Properties
        public int ShoppingCartItemId { get; set; }
        public Pie Pie { get; set; }
        public int Amount { get; set; }
        public string ShoppingCartId { get; set; } // This item belongs to which bag, Individual for all
    }
}
