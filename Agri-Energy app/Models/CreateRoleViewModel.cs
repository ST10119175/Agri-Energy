using System.ComponentModel.DataAnnotations;

namespace Agri_Energy_APP.Models
{
    public class CreateRoleViewModel
    {
        [Required]
        [Display(Name = "Role")]
        public string RoleName { get; set; }
    }
}

