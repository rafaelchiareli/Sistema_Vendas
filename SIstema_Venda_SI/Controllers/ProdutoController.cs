using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sistema_Venda_SI.Model.Models;

namespace SIstema_Venda_SI.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly DBSISTEMASContext _context;

        public ProdutoController(DBSISTEMASContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var listaProdutos = _context.Produto.ToList();
            return View(listaProdutos);
        }

        public void CarregaDadosViewBag()
        {
            ViewData["ProCodigoTipoProduto"] = new SelectList(_context.TipoProduto, "TipCodigo", "TipDescricao");
            ViewData["ProCodigoUnidade"] = new SelectList(_context.Unidade, "UnCodigo", "UnDescricao");
        }
        public IActionResult Create()
        {
            CarregaDadosViewBag();
            return View();
        }

  

        [HttpPost]
        public IActionResult Create(Produto produto)
        {
            CarregaDadosViewBag();
            if (ModelState.IsValid)
            {
                _context.Entry(produto).State = EntityState.Added;
                _context.SaveChanges();
               
                return View(produto);

               
            }
            else
            {
                return View(produto);
            }
        }
    }
}
