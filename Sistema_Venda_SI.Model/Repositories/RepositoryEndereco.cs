using Sistema_Venda_SI.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Venda_SI.Model.Repositories
{
    public class RepositoryEndereco :RepositoryBase<Endereco>
    {
        public RepositoryEndereco(bool saveChanges = true) : base(saveChanges) 
        {
            
        }
    }
}
