using Sistema_Venda_SI.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Venda_SI.Model.Repositories
{
    public class RepositoryEntrada : RepositoryBase<Entrada>
    {
        public RepositoryEntrada(bool saveChanges = true) : base (saveChanges)
        {
                
        }


        public void AlterarAsync(Entrada entrada, List<EntradaProduto> listaEntradaProduto)
        {
            _context.Entry(entrada).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            var listaEntradaProdutoExistente = _context.EntradaProduto.Where(x => x.EnpCodigoEntrada == entrada.EntCodigo).ToList();
            _context.EntradaProduto.RemoveRange(listaEntradaProdutoExistente);
            _context.SaveChanges();
            var codigo = entrada.EntCodigo;
            foreach (var item in listaEntradaProduto)
            {
                item.EnpCodigoEntrada = codigo;

            }
            _context.EntradaProduto.AddRange(listaEntradaProduto);
            _context.SaveChangesAsync();

        }

        public async Task IncluirAsync(Entrada entrada, List<EntradaProduto> listaEntradaProduto)
        {
            try
            {
                _context.Entry(entrada).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                await _context.SaveChangesAsync();
                foreach (var item in listaEntradaProduto)
                {
                    item.EnpCodigoEntrada = entrada.EntCodigo;
                    _context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
