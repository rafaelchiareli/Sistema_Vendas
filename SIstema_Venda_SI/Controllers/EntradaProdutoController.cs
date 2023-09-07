using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.View;
using Sistema_Venda_SI.Model.Models;
using Sistema_Venda_SI.Model.Service;
using SIstema_Venda_SI.ViewModel;

namespace SIstema_Venda_SI.Controllers
{
    public class EntradaProdutoController : Controller
    {

        private ServiceEntradaProduto _ServiceEntradaProduto;
        public EntradaProdutoController()
        {
            _ServiceEntradaProduto = new ServiceEntradaProduto();
        }
        public IActionResult Index()
        {
            return View();
        }

        public  IActionResult Create()
        {
            ViewBag.listaProdutos = _ServiceEntradaProduto.oRepositoryProduto.SelecionarTodos();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EntradaProdutoVM entradaProdutoVM)
        {

            try
            {
                var entrada = new Entrada()
                {
                    EntDataHora = entradaProdutoVM.EntDataHora,
                    EnNuneroNotaFiscal = entradaProdutoVM.EnNuneroNotaFiscal,
                };

                var listaEntradaProduto = new List<EntradaProduto>();
                foreach (var item in entradaProdutoVM.ListaProdutos)
                {
                    var entradaProduto = new EntradaProduto()
                    {
                        EnpCodigoProduto = item.CodigoProduto,
                        EnpQuantidade = item.Quantidade,
                        EnpValorCusto = item.ValorCusto,
                        EnpValorVenda = item.ValorVenda,
                    };
                }

                await _ServiceEntradaProduto.oRepositoryEntradaProduto.IncluirAsync(entrada, listaEntradaProduto);

                return View();
            }
            catch (Exception ex)
            {

                throw;
            }

          
        }

    }
}
