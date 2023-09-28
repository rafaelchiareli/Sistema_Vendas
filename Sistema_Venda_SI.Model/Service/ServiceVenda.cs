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
        public ServiceVenda()
        {
            oRepositoryVenda = new RepositoryVenda();
            oRepositoryItensVenda = new RepositoryItensVenda();
        }

    }
}
