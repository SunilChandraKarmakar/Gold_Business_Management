using System.ComponentModel.DataAnnotations;

namespace GoldBusinessManagementApp.Model.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please, enter date.")]
        [DataType(DataType.PhoneNumber)]
        public int Date { get; set; }

        [Required(ErrorMessage = "Please, enter month.")]
        [DataType(DataType.PhoneNumber)]
        public int Month { get; set; }

        [Required(ErrorMessage = "Please, enter year.")]
        [DataType(DataType.PhoneNumber)]
        public int Year { get; set; }

        public string? Code { get; set; }

        [Required(ErrorMessage = "Please, select customer name.")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Please, provied product details.")]
        [StringLength(50, MinimumLength = 2)]
        [DataType(DataType.MultilineText)]
        public string Details { get; set; }

        [Required(ErrorMessage = "Please, provied product Weight.")]
        [StringLength(50, MinimumLength = 2)]
        public string Weight { get; set; }

        [Required(ErrorMessage = "Please, provied product amount.")]
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Customer Customer { get; set; }
    }
}