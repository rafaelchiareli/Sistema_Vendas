using Sistema_Venda_SI.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Venda_SI.Model.Repositories
{
    public class RepositoryVenda : RepositoryBase<Venda>
    {
        public RepositoryVenda(bool saveChanges = true) : base(saveChanges)
        {

        }

        public async Task AlterarAsync(Venda venda, List<ItensVenda> itens, List<Parcelas> parcelas = null)
        {
            _context.Entry(venda).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
            var listaItensExistentes = _context.ItensVenda.Where(x => x.ItvCodigoVenda == venda.VenCodigo).ToList();
            if (listaItensExistentes.Count > 0)
            {
                _context.RemoveRange(listaItensExistentes);
            }

            if (itens.Count > 0)
            {
                foreach (var item in itens)
                {
                    item.ItvCodigoVenda = venda.VenCodigo;
                }
                _context.AddRange(itens);
            }

            if (venda.VenCodigoTipoPagamento == 4)
            {
                var listaParcelas = _context.Parcelas.Where(x => x.ParCodigoVenda == venda.VenCodigo).ToList();
                if (listaParcelas.Count > 0)
                {
                    _context.RemoveRange(listaParcelas);
                }
            }
            if (parcelas.Count > 0)
            {
                foreach (var item in parcelas)
                {
                    item.ParCodigoVenda = venda.VenCodigo;
                }
                _context.AddRange(parcelas);


            }
            await _context.SaveChangesAsync();
        }
    }
}
