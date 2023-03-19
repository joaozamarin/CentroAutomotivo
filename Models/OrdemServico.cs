using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CentroAutomotivo.Models
{
    [Table("OrdemServico")]
    public class OrdemServico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Data de Entrada")]
        [Required]
        public DateTime DataEntrada { get; set; } = DateTime.Now;

        [Display(Name = "Data de Saída")]
        public DateTime DataSaida { get; set; }

        [Display(Name = "Descrição")]
        [StringLength(100, ErrorMessage = "A descrição deve possuir no máximo 100 caracteres")]
        public string Descricao { get; set; }

        [Display(Name = "Status")]
        [Required]
        public int StatusOrdemServicoId { get; set; }
        [ForeignKey("StatusOrdemServicoId")]
        public StatusOrdemServico StatusOrdemServico { get; set; }

        [Display(Name = "Veículo")]
        [Required]
        public int VeiculoId { get; set; }
        [ForeignKey("VeiculoId")]
        public Veiculo Veiculo { get; set; }

        public ICollection<ServicoOrdem> ServicosOrdem { get; set; }
        public ICollection<PecaOrdem> PecasOrdem { get; set; }
    }
}