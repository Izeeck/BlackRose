using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BlackRose.Enum
{
    public enum CategoryEvent
    {
        [Display(Name = "Улица")]
        Street,
        [Display(Name = "Здания")]
        Building
    }
}
