using Sistema_Venda_SI.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Venda_SI.Model.Service
{

  
    public class ServiceConfiguracao
    {
        public   RepositoryConfiguracao oRepositoryConfiguracao { get; set; }   

        public ServiceConfiguracao()
        {
            oRepositoryConfiguracao = new RepositoryConfiguracao();
        }
    }
}
