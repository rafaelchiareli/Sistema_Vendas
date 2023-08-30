using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using Sistema_Venda_SI.Model.Models;
using Sistema_Venda_SI.Model.Service;

namespace SIstema_Venda_SI.Controllers
{
    public class TipoProdutoController : Controller
    {
       
     
        public TipoProdutoController(DBSISTEMASContext context)
        {
            
        }

        public async Task< IActionResult> Index()
        {
            var listaTipoProduto = await _serviceTipoProduto.oRepositoryTipoProduto.SelecionarTodosAsync();
            return View(listaTipoProduto);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TipoProduto tipoProduto)
        {
            //if (ModelState.IsValid)
            //{
            //    _context.Entry(tipoProduto).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            //    _context.SaveChanges();
            //}
            return View();
        }


        [HttpGet]
        public IActionResult Edit (int id)
        {
          //  var tipoProduto = _context.TipoProduto.FirstOrDefault(x => x.TipCodigo == id);

            return View();

        }

        [HttpPost]
        public IActionResult Edit(TipoProduto tipoProduto)
        {
            if (ModelState.IsValid)
            {
                //_context.Entry(tipoProduto).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                //_context.SaveChanges();
                //return View();
            }
            ViewData["MensagemErro"] = "Ocorreu um erro";
            
            return View();
        }
        [HttpGet]
        public IActionResult Delete (int id)
        {

            //var tipoProduto = _context.TipoProduto.FirstOrDefault(x => x.TipCodigo == id);
            //_context.Entry(tipoProduto).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            //_context.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Details(int id) 
        {
            // var tipoProduto = _context.TipoProduto.Find(id);
            return View();


        }
    }
}
