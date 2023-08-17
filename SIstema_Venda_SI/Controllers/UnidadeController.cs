using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema_Venda_SI.Model.Models;

namespace SIstema_Venda_SI.Controllers
{
    public class UnidadeController : Controller
    {
        // GET: UnidadeController

        private readonly DBSISTEMASContext _context;

        public UnidadeController(DBSISTEMASContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            var listaUnidades = _context.Unidade.ToList();
            return View(listaUnidades);
        }

        // GET: UnidadeController/Details/5
        public ActionResult Details(int id)
        {
            var unidade = _context.Unidade.FirstOrDefault(x => x.UnCodigo == id);

            return View(unidade);
        }

        // GET: UnidadeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UnidadeController/Create
        [HttpPost]
     
        public IActionResult Create(Unidade unidade)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(unidade).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                _context.SaveChanges();
                return View(unidade);
            }
            return View();
           
        }

        // GET: UnidadeController/Edit/5
        public ActionResult Edit(int id)
        {
            var unidade = _context.Unidade.FirstOrDefault(x => x.UnCodigo == id);
            return View(unidade);
        }

        // POST: UnidadeController/Edit/5
        [HttpPost]
      
        public ActionResult Edit(Unidade unidade)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(unidade).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return View(unidade);
            }
            return View();
        }

        // GET: UnidadeController/Delete/5
        public ActionResult Delete(int id)
        {
            var unidade = _context.Unidade.FirstOrDefault(x => x.UnCodigo == id);
            _context.Entry(unidade).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction ("Index");
                
                }

        // POST: UnidadeController/Delete/5
     
      
    }
}
