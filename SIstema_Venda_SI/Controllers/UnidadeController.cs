using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema_Venda_SI.Model.Models;
using Sistema_Venda_SI.Model.Service;

namespace SIstema_Venda_SI.Controllers
{
    public class UnidadeController : Controller
    {
        // GET: UnidadeController

        private ServiceUnidade _ServiceUnidade;

        public UnidadeController()
        {
            _ServiceUnidade = new ServiceUnidade();
        }


        public async Task<ActionResult> Index()
        {
            var listaUnidades = await _ServiceUnidade.oRepositoryUnidade.SelecionarTodosAsync();
            return View(listaUnidades);
        }

        // GET: UnidadeController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var unidade = await _ServiceUnidade.oRepositoryUnidade.SelecionarPkAsync(id);

            return View(unidade);
        }

        // GET: UnidadeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UnidadeController/Create
        [HttpPost]

        public async Task<IActionResult> Create(Unidade unidade)
        {
            if (ModelState.IsValid)
            {
                unidade = await _ServiceUnidade.oRepositoryUnidade.IncluirAsync(unidade);
                return View(unidade);
            }
            return View();

        }

        // GET: UnidadeController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var unidade = await _ServiceUnidade.oRepositoryUnidade.SelecionarPkAsync(id);
            return View(unidade);
        }

        // POST: UnidadeController/Edit/5
        [HttpPost]

        public async Task<IActionResult> Edit(Unidade unidade)
        {
            if (ModelState.IsValid)
            {
                unidade = await _ServiceUnidade.oRepositoryUnidade.AlterarAsync(unidade);
                return View(unidade);
            }
            return View();
        }

        // GET: UnidadeController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
           await _ServiceUnidade.oRepositoryUnidade.ExcluirAsync(id);
            return RedirectToAction("Index");

        }

        // POST: UnidadeController/Delete/5


    }
}
