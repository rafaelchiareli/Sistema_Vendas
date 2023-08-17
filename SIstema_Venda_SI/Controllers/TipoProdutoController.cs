using Microsoft.AspNetCore.Mvc;
using Sistema_Venda_SI.Model.Models;

namespace SIstema_Venda_SI.Controllers
{
    public class TipoProdutoController : Controller
    {
        private readonly DBSISTEMASContext _context;

        public TipoProdutoController(DBSISTEMASContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var listaTipoProduto = _context.TipoProduto.ToList();
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
            if (ModelState.IsValid)
            {
                _context.Entry(tipoProduto).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                _context.SaveChanges();
            }
            return View();
        }


        [HttpGet]
        public IActionResult Edit (int id)
        {
            var tipoProduto = _context.TipoProduto.FirstOrDefault(x => x.TipCodigo == id);

            return View(tipoProduto);

        }

        [HttpPost]
        public IActionResult Edit(TipoProduto tipoProduto)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(tipoProduto).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return View();
            }
            ViewData["MensagemErro"] = "Ocorreu um erro";
            
            return View();
        }
        [HttpGet]
        public IActionResult Delete (int id)
        {

            var tipoProduto = _context.TipoProduto.FirstOrDefault(x => x.TipCodigo == id);
            _context.Entry(tipoProduto).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Details(int id) 
        {
            var tipoProduto = _context.TipoProduto.Find(id);
            return View(tipoProduto);


        }
    }
}
