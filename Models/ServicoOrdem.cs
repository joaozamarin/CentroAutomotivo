using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CentroAutomotivo.Models
{
    [Table("ServicoOrdem")]
    public class ServicoOrdem
    {
        [Key, Column(Order = 1)]
        public int OrdemServicoId { get; set; }
        [ForeignKey("OrdemServicoId")]
        public OrdemServico OrdemServico { get; set; }

        [Key, Column(Order = 2)]
        public int ServicoId { get; set; }
        [ForeignKey("ServicoId")]
        public Servico Servico { get; set; }
    }
}