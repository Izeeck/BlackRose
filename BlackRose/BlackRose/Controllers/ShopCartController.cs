using BlackRose.Interfaces;
using BlackRose.Models;
using BlackRose.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BlackRose.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly IEquipmentRepository _carRep;
        private readonly ShopCart _shopCart;

        public ShopCartController(IEquipmentRepository carRep, ShopCart shopCart)
        {
            _carRep = carRep;
            _shopCart = shopCart;
        }

        public ViewResult Index()
        {
            var item = _shopCart.GetShopItems();
            _shopCart.listShopItems = item;

            var obj = new ShopCartViewModel { shopCart = _shopCart };
            return View(obj);
        }

        public RedirectToActionResult addtoCart(int id)
        {
            var item = _carRep.Equipment.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                _shopCart.AddtoCart(item);
            }
            return RedirectToAction("Index");
        }
    }
}
