using BlackRose.Data;
using BlackRose.Interfaces;
using BlackRose.Models;

namespace BlackRose.Repositories
{
    public class OrdersRepository : IAllOrder
    {
        private readonly ApplicationDbContext applicaBDContext;
        private readonly ShopCart shopCart;

        public OrdersRepository(ApplicationDbContext applicaBDContext, ShopCart shopCart)
        {
            this.applicaBDContext = applicaBDContext;
            this.shopCart = shopCart;
        }

        public void createOrder(Order order)
        {
            order.OrderTime = DateTime.Now;
            applicaBDContext.Order.Add(order);
            var items = shopCart.listShopItems;

            foreach (var el in items)
            {
                var orderDetail = new OrderDetail()
                {
                    EquipmentId = el.EquipmentS.Id,
                    OrderId = order.Id,
                    Price = el.EquipmentS.Price
                };
                applicaBDContext.OrderDetail.Add(orderDetail);

            }
            //applicaBDContext.SaveChanges();

        }
    }
}
