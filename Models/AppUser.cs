using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace CentroAutomotivo.Models
{
    public class AppUser : IdentityUser
    {
        [Required]
        [StringLength(60)]
        public string Nome { get; set; }

        [StringLength(400)]
        public string FotoPerfil { get; set; }
        
        [Required]
        public bool IsAdmin { get; set; } = false;

        public ICollection<Veiculo> Veiculos { get; set; }
    }
}