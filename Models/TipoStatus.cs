using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CentroAutomotivo.Models
{
    [Table("TipoStatus")]
    public class TipoStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Informe o nome do Tipo Status")]
        [StringLength(30, ErrorMessage = "O nome do Tipo Status deve possuir no máximo 30 caracteres.")]
        public string Nome { get; set; }

        public ICollection<StatusOrdemServico> StatusOrdemServicos { get; set; }
    }
}