using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Waffle_Shop.Models
{
    // Like a Customer Bag
    public class ShoppingCart
    {
        private readonly AppDbContext db;
        public ShoppingCart(AppDbContext db)
        {
            this.db = db;
        }
        /*public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            var context = services.GetService<AppDbContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString(); 
            // ?? is null check, GetString check cartId already present or not 

            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }*/
        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            var context = services.GetService<AppDbContext>();

            var userContext = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.User;

            var user = userContext.FindFirst(ClaimTypes.NameIdentifier);

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }


        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public void AddToCart(Pie pie, int amount)
        {
            var shoppingCartItem =
                    db.ShoppingCartItems.SingleOrDefault(
                        s => s.Pie.PieId == pie.PieId && s.ShoppingCartId == ShoppingCartId);
            //if it is the first time they are adding apple pie, then shoppingCartItem should be null
            if (shoppingCartItem == null)
            {
                //shoppingcartitem object and add it to customer bag
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Pie = pie,
                    Amount = 1
                };

                db.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            db.SaveChanges();
        }
        public int RemoveFromCart(Pie pie)
        {
            var shoppingCartItem =
                    db.ShoppingCartItems.SingleOrDefault(
                        s => s.Pie.PieId == pie.PieId && s.ShoppingCartId == ShoppingCartId);

            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                //if they have more than 1 apple pie, you should reduce the count
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    db.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }

            db.SaveChanges();

            return localAmount;
        }
        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??
                   (ShoppingCartItems =
                       db.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                           .Include(s => s.Pie)
                           .ToList());
        }
        public void ClearCart()
        {
            var cartItems = db
                .ShoppingCartItems
                .Where(cart => cart.ShoppingCartId == ShoppingCartId);

            db.ShoppingCartItems.RemoveRange(cartItems);

            db.SaveChanges();
        }
        public decimal GetShoppingCartTotal()
        {
            var total = db.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                .Select(c => c.Pie.Price * c.Amount).Sum();
            return total;
        }
    }
}
