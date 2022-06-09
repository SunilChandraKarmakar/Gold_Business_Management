using System.ComponentModel.DataAnnotations;

namespace GoldBusinessManagementApp.Model.Models
{
    public class Customer
    {
        public Customer()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Please, provied full name.")]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please, provied nick name.")]
        [StringLength(50, MinimumLength = 2)]
        public string NickName { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}