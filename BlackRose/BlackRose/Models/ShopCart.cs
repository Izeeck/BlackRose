using BlackRose.Data;
using Microsoft.EntityFrameworkCore;

namespace BlackRose.Models
{
    public class ShopCart
    {
        private readonly ApplicationDbContext _appDBContent;
        public ShopCart(ApplicationDbContext appDBContent)
        {
            _appDBContent = appDBContent;
        }
        public string ShopCartId { get; set; }
        public List<ShopCartItem> listShopItems { get; set; }

        public static ShopCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<ApplicationDbContext>();
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", shopCartId);
            return new ShopCart(context) { ShopCartId = shopCartId };
        }

        public void AddtoCart(Equipment equipment)
        {
            _appDBContent.ShopCartItems.Add(new ShopCartItem
            {
                ShopCartId = ShopCartId,
                EquipmentS = equipment,
                Price = equipment.Price
            });

            _appDBContent.SaveChanges();
        }

        public List<ShopCartItem> GetShopItems()
        {
            return _appDBContent.ShopCartItems.Where(c => c.ShopCartId == ShopCartId).Include(x => x.EquipmentS).ToList();
        }
    }
}
