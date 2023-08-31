using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_Venda_SI.Model.Models;
using Sistema_Venda_SI.Model.Service;

namespace SIstema_Venda_SI.Controllers
{
    public class TipoPagamentoController : Controller
    {
        private ServiceTipoPagamento _ServiceTipoPagamento;

        public TipoPagamentoController()
        {
            _ServiceTipoPagamento = new ServiceTipoPagamento();
        }

        public async Task<IActionResult> Index()
        {
            var listaTipoPagamento = await _ServiceTipoPagamento.oRepositoryTipoPagamento.SelecionarTodosAsync();

            return View(listaTipoPagamento);
        }

        public async Task<IActionResult> Details(int id)
        {
            var tipoPagamento = await _ServiceTipoPagamento.oRepositoryTipoPagamento.SelecionarPkAsync(id);
          
            return View(tipoPagamento);

        }

        public async Task<IActionResult> Edit(int id)
        {
            var tipoPagamento = await _ServiceTipoPagamento.oRepositoryTipoPagamento.SelecionarPkAsync(id);
            return View(tipoPagamento);
        }

        [HttpPost]
        public  async Task<IActionResult> Edit(TipoPagamento tipoPagamento)
        {
            if (ModelState.IsValid)
            {
                var tipoPagamentoAlterado = await _ServiceTipoPagamento.oRepositoryTipoPagamento.AlterarAsync(tipoPagamento);
     

               
                return View(tipoPagamentoAlterado);

            }
            ViewData["MensagemErro"] = "Ocorreu um erro";
            return View(tipoPagamento);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TipoPagamento tipoPagamento) 
        { 
            if (ModelState.IsValid)
            {
                var tipoPagamentoAlterado = await _ServiceTipoPagamento.oRepositoryTipoPagamento.IncluirAsync(tipoPagamento);
                return View(tipoPagamentoAlterado);
            }
            ViewData["MensagemErro"] = "Ocorreu um erro";
            return View(tipoPagamento);

        }

        public async Task <IActionResult> Delete (int id)
        {

          await _ServiceTipoPagamento.oRepositoryTipoPagamento.ExcluirAsync(id);
            return RedirectToAction("Index");

        }
    }
}
