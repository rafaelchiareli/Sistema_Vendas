using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_Venda_SI.Model.Models;

namespace SIstema_Venda_SI.Controllers
{
    public class TipoPagamentoController : Controller
    {
        private readonly DBSISTEMASContext _context;

        public TipoPagamentoController(DBSISTEMASContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var listaTipoPagamento = _context.TipoPagamento.ToList();

            return View(listaTipoPagamento);
        }

        public IActionResult Details(int id)
        {
            TipoPagamento tipoPagamento = new TipoPagamento();
            //outra maneira de se consultar uma informação do nosso modelo.
            tipoPagamento = ( from p in _context.TipoPagamento where p.TpgCodigo == id select p ).FirstOrDefault();
            return View(tipoPagamento);

        }

        public IActionResult Edit(int id)
        {
            var tipoPagamento = _context.TipoPagamento.FirstOrDefault(x => x.TpgCodigo == id);
            return View(tipoPagamento);
        }

        [HttpPost]
        public IActionResult Edit(TipoPagamento tipoPagamento)
        {
            if (ModelState.IsValid)
            {

     

                _context.Entry(tipoPagamento).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return View(tipoPagamento);

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
        public IActionResult Create(TipoPagamento tipoPagamento) 
        { 
            if (ModelState.IsValid)
            {
                _context.Entry(tipoPagamento).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                _context.SaveChanges();
            }
            ViewData["MensagemErro"] = "Ocorreu um erro";
            return View(tipoPagamento);

        }

        public IActionResult Delete (int id)
        {

            var tipoPagamento = _context.TipoPagamento.FirstOrDefault(x => x.TpgCodigo == id);
            _context.Entry(tipoPagamento).State = EntityState.Deleted; 
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
