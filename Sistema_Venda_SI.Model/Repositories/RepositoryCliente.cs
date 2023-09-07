using Sistema_Venda_SI.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Sistema_Venda_SI.Model.Repositories
{
    public class RepositoryCliente : RepositoryBase<Cliente>
    {
        public RepositoryCliente(bool saveChanges = true) : base(saveChanges)
        {

        }
        public async Task IncluirAsync(Cliente cliente, Endereco endereco)
        {
            _context.Entry(cliente).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _context.SaveChangesAsync();
            endereco.EndCodigoCliente = cliente.CliCodigo;
            _context.Entry(endereco).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _context.SaveChangesAsync();

        }


    }
}
