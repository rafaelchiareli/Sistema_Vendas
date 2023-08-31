using Sistema_Venda_SI.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Venda_SI.Model.Service
{
    public  class ServiceProduto
    {
      public  RepositoryProduto oRepositoryProduto { get; set; }
        public RepositoryUnidade oRepositoryUnidade { get; set; }
        public ServiceProduto()
        {
                oRepositoryProduto = new RepositoryProduto();
            oRepositoryUnidade = new RepositoryUnidade();
        }
    }
}
