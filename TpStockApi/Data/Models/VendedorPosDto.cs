using System.ComponentModel.DataAnnotations;

namespace TpStockApi.Data.Models
{
    public class VendedorPosDto
    {
        public string? FullName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string UserName { get; set; }
    }
}
