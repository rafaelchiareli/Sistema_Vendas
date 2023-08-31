using Sistema_Venda_SI.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Venda_SI.Model.Service
{
    
    public class ServiceCliente
    {
       public RepositoryCliente oRepositoryCliente { get; set; }
        public RepositoryEndereco oRepositoryEndereco { get; set; }
        public ServiceCliente()
        {
            oRepositoryCliente = new RepositoryCliente();
            oRepositoryEndereco = new RepositoryEndereco(); 
        }
    }
}
