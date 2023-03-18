using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CentroAutomotivo.Models
{
    [Table("Servico")]
    public class Servico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Informe o nome do Serviço")]
        [StringLength(90, ErrorMessage = "O nome do Serviço deve possuir no máximo 90 caracteres.")]
        public string Nome { get; set; }

        [Display(Name = "Preço")]
        [Column(TypeName = "decimal(10,2)")]
        [Required(ErrorMessage = "Informe o Preço")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Preco { get; set; }
    }
}