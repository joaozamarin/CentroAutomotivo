using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CentroAutomotivo.Models;

namespace CentroAutomotivo.ViewModel
{
    public class HistoricoVM
    {
        public List<OrdemServico> OrdemServicos { get; set; }
        public List<Agendamento> Agendamentos { get; set; }
    }
}