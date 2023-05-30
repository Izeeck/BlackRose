using BlackRose.Enum;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BlackRose.Models
{
    public class Equipment
    {
        public int Id { get; set; }
        [Display(Name = "Название")]
        [Required]
        public string? Name { get; set; }
        [Display(Name = "Короткое описание")]
        [StringLength(20, ErrorMessage = "{0} должено быть не меньше {2} и не больше {1} символов", MinimumLength = 4)]
        [Required]
        public string? ShortDesc { get; set; }
        [Display(Name = "Длинное описание")]
        [StringLength(100, ErrorMessage = "{0} должен быть не меньше {2} и не больше {1} символов", MinimumLength = 15)]
        [Required]
        public string? LongDesc { get; set; }
        [Display(Name = "Цена")]
        [Required]
        public double Price { get; set; }
        [Display(Name = "Наличие")]
        public bool Availability { get; set; }
        [Display(Name = "Дата возврата товара")]
        [DataType(DataType.Date)]
        public DateTime DateReturn { get; set; }
        [Display(Name = "Фотография оборудования")]
        public byte[]? Image { get; set; }
        [Display(Name = "Категория оборудования")]
        public virtual CategoryEquipment? CategoryEquips { get; set; }
    }
}
