using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CentroAutomotivo.Models;

namespace CentroAutomotivo.ViewModel
{
    public class IndexClienteVM
    {
        public int OrdemServicoId { get; set; }
        public Agendamento Agendamento { get; set; }
    }
}