using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.View;
using Sistema_Venda_SI.Model.Models;
using Sistema_Venda_SI.Model.Service;
using SIstema_Venda_SI.ViewModel;
using System.Reflection.Metadata.Ecma335;

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
            var listaEntradaProdutoVM = EntradaProdutoVM.ListarTodasEntradas();
            return View(listaEntradaProdutoVM);
        }

        public void CarregaListaProdutos()
        {
            ViewBag.listaProdutos = _ServiceEntradaProduto.oRepositoryProduto.SelecionarTodos();
        }
        public IActionResult Create(int codEntrada = 0)
        {
            CarregaListaProdutos();
            if (codEntrada > 0)
            {
                var entradaProdutoVm = EntradaProdutoVM.SelecionarEntradaProdutoVM(codEntrada);
                return View(entradaProdutoVm);

            }
            return View();

        }

        public IActionResult Delete(int codEntrada)
        {
            var entradaProdutoVM = EntradaProdutoVM.SelecionarEntradaProdutoVM(codEntrada);
            return View(entradaProdutoVM);
        }

        [HttpPost]
        public IActionResult Delete(EntradaProdutoVM entradaProdutoVM)
        {
            try
            {
                _ServiceEntradaProduto.oRepositoryEntrada.Excluir(entradaProdutoVM.EntCodigo);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                ViewData["MensagemErro"] = ex.Message.ToString();
                throw;
            }
        }


        public IActionResult Details(int codEntrada)
        {
            var entradaProdutoVM = EntradaProdutoVM.SelecionarEntradaProdutoVM(codEntrada);
            return View(entradaProdutoVM);

        }
        [HttpPost]
        public async Task<IActionResult> Create(EntradaProdutoVM entradaProdutoVM)
        {
            var alterar = false;
            try
            {
                if (entradaProdutoVM.EntCodigo > 0)
                {
                    alterar = true;
                }
                var entrada = new Entrada()
                {
                    EntDataHora = entradaProdutoVM.EntDataHora,
                    EnNuneroNotaFiscal = entradaProdutoVM.EnNuneroNotaFiscal,
                };

                EntradaProdutoVM entradaProdutoSalva;

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
                    listaEntradaProduto.Add(entradaProduto);
                }
                if (alterar)
                {
                    var entradAlterar = _ServiceEntradaProduto.oRepositoryEntrada.SelecionarPk(entradaProdutoVM.EntCodigo);

                    entradAlterar.EnNuneroNotaFiscal = entradaProdutoVM.EnNuneroNotaFiscal;
                    entradAlterar.EntDataHora = entradaProdutoVM.EntDataHora;
                    _ServiceEntradaProduto.oRepositoryEntrada.AlterarAsync(entradAlterar, listaEntradaProduto);

                    entradaProdutoSalva = EntradaProdutoVM.SelecionarEntradaProdutoVM(entradaProdutoVM.EntCodigo);
                }
                else
                {

                    await _ServiceEntradaProduto.oRepositoryEntrada.IncluirAsync(entrada, listaEntradaProduto);
                    entradaProdutoSalva = EntradaProdutoVM.SelecionarEntradaProdutoVM(entrada.EntCodigo);
                }

                ViewData["Mensagem"] = "Dados salvos com sucesso!";
                return View(entradaProdutoSalva);
            }
            catch (Exception ex)
            {

                throw;
            }


        }

    }
}
