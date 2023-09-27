using Microsoft.EntityFrameworkCore;
using Sistema_Venda_SI.Model.Models;
using System.Net.WebSockets;

namespace SIstema_Venda_SI.Models
{
    public class ItensEntrada
    {
        public int CodigoEntrada { get; set; }
        public int CodigoProduto { get; set; }
        public string NomeProduto { get; set; }

        public decimal ValorCusto { get; set; }
        public decimal ValorVenda { get; set; }
        public int Quantidade { get; set; }

        public ItensEntrada()
        {
                
        }

        public static List<ItensEntrada> ListarItensEntrada(int codEntrada)
        {
            var db = new DBSISTEMASContext();

            var listaRetorno = new List<ItensEntrada>();
            var entradaProdutos = db.EntradaProduto.AsNoTracking().Where(x => x.EnpCodigoEntrada == codEntrada).ToList();
            foreach (var item in entradaProdutos)
            {
               var itensEntrada = new ItensEntrada()
               {
                    CodigoEntrada= item.EnpCodigoEntrada,
                    CodigoProduto = item.EnpCodigoProduto,
                    NomeProduto = db.Produto.FirstOrDefault(x => x.ProCodigo == item.EnpCodigoProduto).ProDescricao,
                    Quantidade  = item.EnpQuantidade,
                    ValorCusto = item.EnpValorCusto,
                    ValorVenda  = item.EnpValorVenda
               };
                listaRetorno.Add(itensEntrada);

            }
            return listaRetorno;
        }
    }
}
