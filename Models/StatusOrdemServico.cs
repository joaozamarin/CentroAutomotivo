using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CentroAutomotivo.Models
{
    [Table("StatusOrdemServico")]
    public class StatusOrdemServico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Informe o Nome")]
        [StringLength(30, ErrorMessage = "O Nome deve possuir no máximo 30 caracteres")]
        public string Nome { get; set; }

        [Display(Name = "Cor")]
        [Required(ErrorMessage = "Informe a Cor (Hexadecimal)")]
        [StringLength(7, MinimumLength = 7)]
        public string Cor { get; set; }
    }
}