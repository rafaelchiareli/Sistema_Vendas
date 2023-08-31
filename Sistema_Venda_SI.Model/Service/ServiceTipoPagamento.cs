using Sistema_Venda_SI.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Venda_SI.Model.Service
{
    
    public class ServiceTipoPagamento
    {
        public RepositoryTipoPagamento oRepositoryTipoPagamento { get; set; }
        public ServiceTipoPagamento()
        {
            oRepositoryTipoPagamento = new RepositoryTipoPagamento();
        }
    }
}
