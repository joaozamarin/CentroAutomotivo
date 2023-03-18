using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CentroAutomotivo.Models
{
    [Table("Veiculo")]
    public class Veiculo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Informe o nome do Veículo")]
        [StringLength(30, ErrorMessage = "O nome do Veículo deve possuir no máximo 30 caracteres")]
        public string Nome { get; set; }

        [Display(Name = "Placa")]
        [Required(ErrorMessage = "Informe a placa do Veículo")]
        [StringLength(7, ErrorMessage = "A placa do Veículo deve possuir 7 caracteres", MinimumLength = 7)]
        public string Placa { get; set; }

        [StringLength(400)]
        public string Imagem { get; set; }

        [Display(Name = "Modelo")]
        public int ModeloId { get; set; }
        [ForeignKey("ModeloId")]
        public Modelo Modelo { get; set; }

        [Display(Name = "Proprietário")]
        [Required]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        public ICollection<OrdemServico> OrdensServico { get; set; }
    }
}