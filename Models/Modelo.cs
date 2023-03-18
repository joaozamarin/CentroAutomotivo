using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CentroAutomotivo.Models
{
    [Table("Modelo")]
    public class Modelo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Informe o nome do Modelo")]
        [StringLength(60, ErrorMessage = "O nome do Modelo deve possuir no máximo 60 caracteres.")]
        public string Nome { get; set; }

        [Display(Name = "Ano")]
        [Required(ErrorMessage = "Informe o ano do Modelo")]
        public int Ano { get; set; }

        [Display(Name = "Marca")]
        [Required]
        public int MarcaId { get; set; }
        [ForeignKey("MarcaId")]
        public Marca Marca { get; set; }

        public ICollection<Veiculo> Veiculos { get; set; }
    }
}