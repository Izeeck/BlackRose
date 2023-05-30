using BlackRose.Interfaces;
using BlackRose.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlackRose.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAllOrder _allOrder;
        private readonly ShopCart _shopCart;

        public OrderController(IAllOrder allOrder, ShopCart shopCart)
        {
            _allOrder = allOrder;
            _shopCart = shopCart;
        }
        public IActionResult Checkout()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            _shopCart.listShopItems = _shopCart.GetShopItems();
            if (_shopCart.listShopItems.Count ==0)
            {
                ModelState.AddModelError("", "У Вас должны быть товары!");
            }
            if ( ModelState.IsValid )
            {
                _allOrder.createOrder(order);
                return RedirectToAction("Complite");
            }
            return View(order);//return RedirectToAction("Complite");
        }

        public IActionResult Complite()
        {
            ViewBag.Massage = "Ожидайте звонка оператора";
            return View();
        }
    }
}
