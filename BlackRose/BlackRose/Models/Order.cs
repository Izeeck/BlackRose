using System.ComponentModel.DataAnnotations;

namespace BlackRose.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Ввидите Имя")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Ввидите фамилию")]
        public string SurName { get; set; }
        [Required]
        [Display(Name = " Ввидите адрес")]
        public string Adress { get; set; }
        [Required]
        [Display(Name = "Ввидите номер телефона")]
        public string Phone { get; set; }
        [Required]
        [Display(Name = "Ввидите вашу почту")]
        public string Email { get; set; }
        public DateTime OrderTime { get; set; }
        public List<OrderDetail>? OrderDetails { get; set; }
    }
}
