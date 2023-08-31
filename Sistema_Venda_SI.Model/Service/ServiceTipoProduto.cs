using Sistema_Venda_SI.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Venda_SI.Model.Service
{
    public class ServiceTipoProduto
    {
        public RepositoryTipoProduto oRepositoryTipoProduto { get; set; }

        public ServiceTipoProduto()
        {
            oRepositoryTipoProduto = new RepositoryTipoProduto();
        }
    }
}
