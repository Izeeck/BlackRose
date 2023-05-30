using BlackRose.Enum;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BlackRose.Models
{
    public class EventAirsoft
    {
        public int Id { get; set; }
        [Display(Name = "Название мероприятия")]
        [Required(ErrorMessage = "Вам нужно ввести название мероприятия")]
        [MaxLength(15, ErrorMessage = "Максимум 15 символов")]
        public string? Name { get; set; }
        [Display(Name = "Короткое описание")]
        [Required]
        public string? ShortDesc { get; set; }
        [Display(Name = "Длинное описание")]
        [Required]
        public string? LongDesc { get; set; }
        [Display(Name = "Место проведения")]
        [Required]
        public string? Venuet { get; set; }
        [Display(Name = "Цена")]
        [Required]
        public ushort PriceEvent { get; set; }
        [Display(Name = "Метка на главную")]
        public bool IsFavorite { get; set; }
        [Display(Name = "Количество игроков")]
        [Required]
        public int NumberOfParticipants { get; set; }
        [Display(Name = "Дата начала мероприятия")]
        [DataType(DataType.Date)]
        public DateTime DateStart { get; set; }
        [Display(Name = "Дата окончания мероприятия")]
        [DataType(DataType.Date)]
        public DateTime DateFinish { get; set; }
        [Display(Name = "Метка о прошло/нет")]
        public bool Passed { get; set; }
        [Display(Name = "Добавление фото")]
        public byte[]? PhotoFile { get; set; }
        [Display(Name = "Категории мероприятия")]
        public virtual CategoryEvent? Category { get; set; }
    }
}
