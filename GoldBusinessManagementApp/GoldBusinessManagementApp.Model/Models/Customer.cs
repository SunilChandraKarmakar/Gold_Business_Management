using System.ComponentModel.DataAnnotations;

namespace GoldBusinessManagementApp.Model.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please, provied Full Name.")]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please, provied Nick Name.")]
        [StringLength(50, MinimumLength = 2)]
        public string NickName { get; set; }
        public bool IsDeleted { get; set; }
    }
}