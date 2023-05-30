namespace BlackRose.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int EquipmentId { get; set; }
        public double Price { get; set; }
        public virtual Equipment Equipment { get; set; }
        public virtual Order Order { get; set; }
    }
}
