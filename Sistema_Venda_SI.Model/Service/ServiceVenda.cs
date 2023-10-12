using Sistema_Venda_SI.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Venda_SI.Model.Service
{
    public class ServiceVenda
    {
        public RepositoryVenda oRepositoryVenda { get; set; }
        public RepositoryItensVenda oRepositoryItensVenda { get; set; }
        public RepositoryCliente oRepositoryCliente { get; set; }
        public RepositoryTipoPagamento oRepositoryTipoPagamento { get; set; }
        public RepositoryVwEstoque oRepositoryVwEstoque { get; set; }   
        public ServiceVenda()
        {
            oRepositoryVenda = new RepositoryVenda();
            oRepositoryItensVenda = new RepositoryItensVenda();
            oRepositoryCliente = new RepositoryCliente();
            oRepositoryTipoPagamento  = new RepositoryTipoPagamento();
            oRepositoryVwEstoque = new RepositoryVwEstoque();
        }

    }
}
