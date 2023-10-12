using SIstema_Venda_SI.Models;

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


    }
}
