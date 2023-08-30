using Sistema_Venda_SI.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Venda_SI.Model.Repositories
{
    public  class RepositoryProduto : RepositoryBase<Produto>
    {
        public RepositoryProduto(bool saveChanges = true) : base(saveChanges)
        {
             
        }
    }
}
