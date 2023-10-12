using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace SIstema_Venda_SI.Models
{
    public class ItensVendaProduto
    {
        public int CodigoVenda { get; set; }

        public int CodigoProduto { get; set; }

        public  int Quantidade { get; set; }

        public  decimal ValorVenda { get; set; }

        public ItensVendaProduto()
        {
                
        }


    }
}
