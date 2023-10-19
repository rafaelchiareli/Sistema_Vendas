using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Sistema_Venda_SI.Model.Models;

namespace SIstema_Venda_SI.Models
{
    public class ItensVendaProduto
    {
        public int CodigoVenda { get; set; }

        public int CodigoProduto { get; set; }

        public string Produto { get; set; }
        public  decimal? Quantidade { get; set; }

        public  decimal? ValorVenda { get; set; }

        public ItensVendaProduto()
        {
                
        }

        public static List<ItensVendaProduto> ListaProdutosVenda(int codVenda)
        {
            var db = new DBSISTEMASContext();
            var listaRetorno = new List<ItensVendaProduto>();
            var listaItens = db.ItensVenda.Where(x => x.ItvCodigoVenda  == codVenda).ToList();
            foreach (var item in listaItens)
            {
                listaRetorno.Add(new ItensVendaProduto
                {
                    CodigoVenda = codVenda,
                    CodigoProduto = item.ItvCodigoProduto,
                    Produto = db.Produto.Find(item.ItvCodigoProduto)!.ProDescricao,
                    Quantidade = item.ItvQuantidade,
                    ValorVenda = item.ItvValorItem,

                });


            }
            return listaRetorno;


        }


    }
}
