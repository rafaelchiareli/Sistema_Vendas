using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sistema_Venda_SI.Model.Models;
using Sistema_Venda_SI.Model.Service;
using SIstema_Venda_SI.ViewModel;

namespace SIstema_Venda_SI.Controllers
{
    public class ProdutoController : Controller
    {
        private ServiceProduto _ServiceProduto;

        public ProdutoController()
        {
            _ServiceProduto = new ServiceProduto(); 

        }

        public IActionResult Index()
        {
            var listaProdutosVM = ProdutoVM.ListarTodosProdutos();
            return View(listaProdutosVM);
        }


        [HttpGet]
        public async Task< IActionResult> Edit(int id)
        {
            var produto = await _ServiceProduto.oRepositoryProduto.SelecionarPkAsync(id);
            CarregaDadosViewBag();
            return View(produto);
        }

        public async Task<IActionResult> Edit (Produto produto)
        {
            if (ModelState.IsValid)
            {
                produto = await _ServiceProduto.oRepositoryProduto.AlterarAsync(produto);
                CarregaDadosViewBag();
                return View(produto);
            }
            return View(produto);
        }

        public IActionResult Detail(int id)
        {
            var produtoVM = ProdutoVM.SelecionarProduto(id);
            return View(produtoVM);
        }

        public IActionResult Delete(int id)
        {
            var produtoVM = ProdutoVM.SelecionarProduto(id);
            return View(produtoVM);
        }

        [HttpPost]
        public  async Task<IActionResult> Delete (ProdutoVM produtoVM)
        {
            var produto = await _ServiceProduto.oRepositoryProduto.SelecionarPkAsync(produtoVM.Codigo);
            await _ServiceProduto.oRepositoryProduto.ExcluirAsync(produto);
            return RedirectToAction("Index");
        }
        public void CarregaDadosViewBag()
        {
            ViewData["ProCodigoTipoProduto"] = new SelectList(_ServiceProduto.oRepositoryTipoProduto.SelecionarTodos(), "TipCodigo", "TipDescricao");
            ViewData["ProCodigoUnidade"] = new SelectList(_ServiceProduto.oRepositoryUnidade.SelecionarTodos(), "UnCodigo", "UnDescricao");
        }


        public IActionResult Create()
        {
            CarregaDadosViewBag();
            return View();
        }

  

        [HttpPost]
        public async Task<IActionResult> Create(Produto produto)
        {
            CarregaDadosViewBag();
            if (ModelState.IsValid)
            {
               produto = await _ServiceProduto.oRepositoryProduto.IncluirAsync(produto);    
               
                return View(produto);

               
            }
            else
            {
                return View(produto);
            }
        }
    }
}
