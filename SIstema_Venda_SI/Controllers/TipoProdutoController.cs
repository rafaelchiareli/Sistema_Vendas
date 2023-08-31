using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using Sistema_Venda_SI.Model.Models;
using Sistema_Venda_SI.Model.Service;

namespace SIstema_Venda_SI.Controllers
{
    public class TipoProdutoController : Controller
    {

        private ServiceTipoProduto _ServiceTipoProduto;
        public TipoProdutoController()
        {
            _ServiceTipoProduto = new ServiceTipoProduto();
        }

        public async Task<IActionResult> Index()
        {
            var listaTipoProduto = await _ServiceTipoProduto.oRepositoryTipoProduto.SelecionarTodosAsync();
            return View(listaTipoProduto);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TipoProduto tipoProduto)
        {
            var tipoProdutoSalvo = await _ServiceTipoProduto.oRepositoryTipoProduto.IncluirAsync(tipoProduto);

            return View(tipoProdutoSalvo);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var tipoProduto = await _ServiceTipoProduto.oRepositoryTipoProduto.SelecionarPkAsync(id);

            return View(tipoProduto);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(TipoProduto tipoProduto)
        {
            if (ModelState.IsValid)
            {
                var tipoProdutoSalvo = await _ServiceTipoProduto.oRepositoryTipoProduto.AlterarAsync(tipoProduto);
               
                return View(tipoProdutoSalvo);
            }
            ViewData["MensagemErro"] = "Ocorreu um erro";

            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _ServiceTipoProduto.oRepositoryTipoProduto.ExcluirAsync(id);

            return RedirectToAction("Index");

        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var tipoProduto = await _ServiceTipoProduto.oRepositoryTipoProduto.SelecionarPkAsync(id);
            return View(tipoProduto);


        }
    }
}
