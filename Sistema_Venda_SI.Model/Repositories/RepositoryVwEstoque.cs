using Sistema_Venda_SI.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Venda_SI.Model.Repositories
{
    public class RepositoryVwEstoque :RepositoryBase<VwEstoque>
    {
        public RepositoryVwEstoque(bool saveChanges = true) : base(saveChanges)
        {

        }

        public VwEstoque SelecionaEstoqueProduo( int codProduto)
        {
            return _context.VwEstoque.FirstOrDefault(x => x.Procodigo == codProduto);
        }
        
    }
}
