using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserApiNewWeb.Models
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(255)]
        [Display(Name ="Full Name")]
        public string FullName { get; set; }
        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword{ get; set; }
    }
}
