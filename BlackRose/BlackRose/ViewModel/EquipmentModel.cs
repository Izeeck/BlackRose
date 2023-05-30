using BlackRose.Enum;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BlackRose.ViewModel
{
    public class EquipmentModel
    {
        public int Id { get; set; }
        [Display(Name = "Название")]
        public string? Name { get; set; }
        [Display(Name = "Короткое описание")]
        public string? ShortDesc { get; set; }
        [Display(Name = "Длинное описание")]
        public string? LongDesc { get; set; }
        [Display(Name = "Цена")]
        public double Price { get; set; }
        [Display(Name = "Наличие")]
        public bool Availability { get; set; }
        [Display(Name = "Дата возврата товара")]
        [DataType(DataType.Date)]
        public DateTime DateReturn { get; set; }
        [Display(Name = "Фотография оборудования")]
        public IFormFile? Image { get; set; }

        [Display(Name = "Категория оборудования")]
        public virtual CategoryEquipment? CategoryEquips { get; set; }
    }
}
