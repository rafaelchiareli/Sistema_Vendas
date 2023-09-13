using Sistema_Venda_SI.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Venda_SI.Model.Repositories
{
    public class RepositoryEntradaProduto : RepositoryBase<EntradaProduto>
    {
        public RepositoryEntradaProduto(bool saveChanges = true) : base (saveChanges)
        {
                
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
