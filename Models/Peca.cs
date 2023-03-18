using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CentroAutomotivo.Models
{
    [Table("Peca")]
    public class Peca
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Informe o nome da Peça")]
        [StringLength(30, ErrorMessage = "O nome da Peça deve possuir no máximo 30 caracteres.")]
        public string Nome { get; set; }

        [Display(Name = "Quantidade")]
        [Required(ErrorMessage = "Informe a Quantidade")]
        public int Quantidade { get; set; }

        [Display(Name = "Preço")]
        [Column(TypeName = "decimal(10,2)")]
        [Required(ErrorMessage = "Informe o Preço")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Preco { get; set; }
    }
}