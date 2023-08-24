using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.IdentityModel.Tokens;
using Sistema_Venda_SI.Model.Models;
using System.Runtime.Serialization.Formatters;

namespace SIstema_Venda_SI.ViewModel
{
    public class ProdutoVM
    {

        public int Codigo { get; set; }

        public string Descricao { get; set; }

        public DateTime DataCadastro { get; set; }


        public int? CodigoTipoProduto { get; set; }
        public int? CodigoUnidade { get; set; }
        public string TipoProduto { get; set; }


        public string Unidade  { get; set; }

        public ProdutoVM()
        {
                
        }


        public static ProdutoVM SelecionarProduto(int id)
        {
            var db = new DBSISTEMASContext();
            var produto = db.Produto.Find(id);
            return new ProdutoVM()
            {
                Codigo = produto.ProCodigo,
                Descricao = produto.ProDescricao,
                DataCadastro = produto.ProDataCadastro,
                CodigoTipoProduto = produto.ProCodigoTipoProduto,
                CodigoUnidade = produto.ProCodigoUnidade,
                TipoProduto = db.TipoProduto.Find(produto.ProCodigoTipoProduto).TipDescricao,
                Unidade = db.Unidade.Find(produto.ProCodigoUnidade).UnDescricao,

            };
            

        }
        public static List<ProdutoVM> ListarTodosProdutos()
        {
            var db = new DBSISTEMASContext();
            //lista de produtoVM que será retornada
            var listaRetorno = new List<ProdutoVM>();
            //lista que inclui todos os produtos cadastrados
            var listaProdutosCadastrados = db.Produto.ToList();
           foreach ( var item in listaProdutosCadastrados)
            {
                var produto = new ProdutoVM();
                produto.Codigo = item.ProCodigo;
                produto.Descricao = item.ProDescricao;
                produto.DataCadastro = item.ProDataCadastro;
                produto.CodigoTipoProduto = item.ProCodigoTipoProduto;
                produto.TipoProduto = db.TipoProduto.FirstOrDefault(x => x.TipCodigo == item.ProCodigoTipoProduto).TipDescricao;
                produto.Unidade = db.Unidade.FirstOrDefault(x => x.UnCodigo == item.ProCodigoUnidade).UnDescricao;
                listaRetorno.Add(produto);

            }
            return listaRetorno;
            

        }

    }
}
