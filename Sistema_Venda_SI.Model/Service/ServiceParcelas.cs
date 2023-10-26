using Sistema_Venda_SI.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Venda_SI.Model.Service
{
    public class ServiceParcelas
    {
        public RepositoryParcela oRepositoryParcela { get; set; }
        public RepositoryCliente oRepositoryCliente { get; set; }

        public ServiceParcelas()
        {
                oRepositoryParcela = new RepositoryParcela();   
            oRepositoryCliente = new RepositoryCliente();   
        }
    }
}
