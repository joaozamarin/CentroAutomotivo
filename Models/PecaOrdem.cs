using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CentroAutomotivo.Models
{
    [Table("PecaOrdem")]
    public class PecaOrdem
    {
        [Key, Column(Order = 1)]
        public int OrdemServicoId { get; set; }
        [ForeignKey("OrdemServicoId")]
        public OrdemServico OrdemServico { get; set; }

        [Key, Column(Order = 2)]
        public int PecaId { get; set; }
        [ForeignKey("PecaId")]
        public Peca Peca { get; set; }
        public int Quantidade { get; set; }
    }
}