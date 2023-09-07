using Sistema_Venda_SI.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Venda_SI.Model.Service
{
    public class ServiceEntradaProduto
    {
        public RepositoryEntradaProduto oRepositoryEntradaProduto;
        public RepositoryEntrada oRepositoryEntrada;
        public RepositoryProduto oRepositoryProduto;
        public ServiceEntradaProduto()
        {
            oRepositoryEntrada = new RepositoryEntrada();
            oRepositoryEntradaProduto = new RepositoryEntradaProduto();
            oRepositoryProduto = new RepositoryProduto();
                
        }
    }
}
