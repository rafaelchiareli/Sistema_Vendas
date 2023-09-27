using Microsoft.EntityFrameworkCore;
using Sistema_Venda_SI.Model.Models;
using SIstema_Venda_SI.Models;

namespace SIstema_Venda_SI.ViewModel
{
    public class EntradaProdutoVM : Entrada
    {
        public List<ItensEntrada> ListaProdutos { get; set; }

        public EntradaProdutoVM()
        {
                
        }


        public static EntradaProdutoVM SelecionarEntradaProdutoVM(int codEntrada)
        {
            var db = new DBSISTEMASContext();
            var entrada = db.Entrada.AsNoTracking().FirstOrDefault(x => x.EntCodigo == codEntrada);

            var retorno = new EntradaProdutoVM();
            retorno.EnNuneroNotaFiscal = entrada.EnNuneroNotaFiscal;
            retorno.EntCodigo = entrada.EntCodigo;
            retorno.EntDataHora = entrada.EntDataHora;
            retorno.ListaProdutos = ItensEntrada.ListarItensEntrada(codEntrada);
            return retorno;
        }
        public static List<EntradaProdutoVM> ListarTodasEntradas()
        {
            var db  = new DBSISTEMASContext();
            var listaRetorno = new List<EntradaProdutoVM>();
            var listaEntradas = db.Entrada.AsNoTracking().ToList();
            foreach (var item in listaEntradas)
            {
                var entradProdutoVM = new EntradaProdutoVM()
                {
                    EnNuneroNotaFiscal = item.EnNuneroNotaFiscal,
                    EntCodigo = item.EntCodigo,
                    EntDataHora = item.EntDataHora,
                    EntUsuario = item.EntUsuario,
                    ListaProdutos = ItensEntrada.ListarItensEntrada(item.EntCodigo),

                };
                listaRetorno.Add(entradProdutoVM);

            }
            return listaRetorno;
        }

    }
}
