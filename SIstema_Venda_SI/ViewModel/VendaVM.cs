using Sistema_Venda_SI.Model.Models;
using SIstema_Venda_SI.Models;
using System.Security.Cryptography;

namespace SIstema_Venda_SI.ViewModel
{
    public class VendaVM
    {
        public int CodigoVenda { get; set; }
        public DateTime DataVenda { get; set; }

        public int CodigoCliente { get; set; }
        public string NomeCliente { get; set; }
        public int CodigoTipoPagamento { get; set; }
        public string TipoPagamento { get; set; }
        public int QtdParcelas { get; set; }

        public List<ItensVendaProduto> ListaProdutos { get; set; }

        public VendaVM()
        {

        }

        public static VendaVM SelecionarVenda(int codVenda)
        {
            var db = new DBSISTEMASContext();
            var venda = db.Venda.Find(codVenda);

            var listaProdutos = new List<ItensVendaProduto>();
            listaProdutos = ItensVendaProduto.ListaProdutosVenda(codVenda);
            return new VendaVM
            {
                CodigoCliente = venda.VenCodigoCliente,
                CodigoTipoPagamento = venda.VenCodigoTipoPagamento,
                CodigoVenda = venda.VenCodigo,
                DataVenda = venda.VenData,
                ListaProdutos = listaProdutos,
                NomeCliente = db.Cliente.Find(venda.VenCodigoCliente)!.CliNome,
                QtdParcelas = (int)venda.VenQtdParcelas!,
                TipoPagamento = db.TipoPagamento.Find(venda.VenCodigoTipoPagamento)!.TpgDescricao

            };
        }

        internal static List<VendaVM> ListarTodos()
        {
            var db = new DBSISTEMASContext();
            var venda = db.Venda.ToList();
            var listaRetorno = new List<VendaVM>();
            foreach (var item in venda)
            {
                var listaProdutos = new List<ItensVendaProduto>();
                listaProdutos = ItensVendaProduto.ListaProdutosVenda(item.VenCodigo);
                var vendaVm = new VendaVM
                {


                    CodigoCliente = item.VenCodigoCliente,
                    CodigoTipoPagamento = item.VenCodigoTipoPagamento,
                    CodigoVenda = item.VenCodigo,
                    DataVenda = item.VenData,
                    ListaProdutos = listaProdutos,
                    NomeCliente = db.Cliente.Find(item.VenCodigoCliente)!.CliNome,
                    QtdParcelas = (int)item.VenQtdParcelas!,
                    TipoPagamento = db.TipoPagamento.Find(item.VenCodigoTipoPagamento)!.TpgDescricao

                };
                listaRetorno.Add(vendaVm);
            }
            return listaRetorno;
        }
    }
}
