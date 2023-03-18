using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CentroAutomotivo.Models
{
    [Table("Marca")]
    public class Marca
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Informe o nome da Marca")]
        [StringLength(30, ErrorMessage = "O nome da Marca deve possuir no máximo 30 caracteres.")]
        public string Nome { get; set; }

        public ICollection<Modelo> Modelos { get; set; }
    }
}