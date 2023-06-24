using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CentroAutomotivo.Models
{
    [Table("Agendamento")]
    public class Agendamento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Data e Hora")]
        [Required]
        public DateTime DataHora { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, 0 );

        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "Informe seu Telefone!")]
        [StringLength(15, MinimumLength = 15)]
        public string Telefone { get; set; }

        [Display(Name = "Descrição do Problema")]
        [Required(ErrorMessage = "Informe o Problema")]
        [StringLength(100, ErrorMessage = "A Descrição do Problema deve possuir no máximo 100 caracteres")]
        public string DescricaoProblema { get; set; }

        [Display(Name = "Resposta")]
        [StringLength(100, ErrorMessage = "A Resposta deve possuir no máximo 100 caracteres")]
        public string Resposta { get; set; }

        [Display(Name = "Precisa de Reboque?")]
        public bool Reboque { get; set; } = false;

        [Display(Name = "Veículo")]
        public int VeiculoId { get; set; }
        [ForeignKey("VeiculoId")]
        public Veiculo Veiculo { get; set; }

        [Display(Name = "Status")]
        public int StatusOrdemServicoId { get; set; }
        [ForeignKey("StatusOrdemServicoId")]
        public StatusOrdemServico StatusOrdemServico { get; set; }

        #region Endereço
        [Display(Name = "CEP")]
        [StringLength(9, MinimumLength = 9)]
        public string CEP { get; set; }

        [Display(Name = "Rua")]
        public string Rua { get; set; }

        [Display(Name = "Número")]
        public string Numero { get; set; }

        [Display(Name = "Bairro")]
        public string Bairro { get; set; }

        [Display(Name = "Cidade")]
        public string Cidade { get; set; }

        [Display(Name = "Estado")]
        [StringLength(2, MinimumLength = 2)]
        public string UF { get; set; }
        #endregion
    }
}