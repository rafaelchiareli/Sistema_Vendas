using Microsoft.EntityFrameworkCore;
using Sistema_Venda_SI.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Venda_SI.Model.Repositories
{
    public  class RepositoryParcela : RepositoryBase<Parcelas>
    {
        public RepositoryParcela(bool saveChanges = true) : base(saveChanges)
        {
                
        }

        public async Task<List<Parcelas>> ListarParcelasCliente(int idCliente)
        {
            var vendas = _context.Venda.Where(x=> x.VenCodigoCliente == idCliente).Select(x => x.VenCodigo).ToList();

            return await _context.Parcelas.Where(x => vendas.Contains((int)x.ParCodigoVenda!) && x.ParDataPagamento == null) .ToListAsync(); 
        }
    }
}
