namespace BlackRose.Models
{
    public class ShopCartItem
    {
        public int Id { get; set; }
        public Equipment EquipmentS { get; set; }
        public double Price { get; set; }
        public string ShopCartId { get; set; }
    }
}
