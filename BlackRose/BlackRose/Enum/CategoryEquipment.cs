using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BlackRose.Enum
{
    public enum CategoryEquipment
    {
        [Display(Name = "Привода")]
        Weapon,
        [Display(Name = "Одежда")]
        Clothes,
        [Display(Name = "Переферия")]
        Periphery,
        [Display(Name = "Расходники")]
        Consumables,
        [Display(Name = "Наборы")]
        Sets
    }
}
