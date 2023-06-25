using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CentroAutomotivo.Models
{
    public class AgendamentoDTO
    {
        public int Id { get; set; }
        public string DataHora { get; set; }
        public string Telefone { get; set; }
        public string DescricaoProblema { get; set; }
        public string Resposta { get; set; }
        public bool Reboque { get; set; } = false;
        public int VeiculoId { get; set; }
        public Veiculo Veiculo { get; set; }
        public int StatusOrdemServicoId { get; set; }
        public StatusOrdemServico StatusOrdemServico { get; set; }

        
        public string CEP { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
    }
}