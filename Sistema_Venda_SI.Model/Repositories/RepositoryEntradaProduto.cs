using Sistema_Venda_SI.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Venda_SI.Model.Repositories
{
    public class RepositoryEntradaProduto : RepositoryBase<EntradaProduto>
    {
        public RepositoryEntradaProduto(bool saveChanges = true) : base(saveChanges)
        {

        }

        
    }
}
