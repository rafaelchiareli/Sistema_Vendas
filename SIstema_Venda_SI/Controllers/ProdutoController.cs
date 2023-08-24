using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sistema_Venda_SI.Model.Models;
using SIstema_Venda_SI.ViewModel;

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
            var listaProdutosVM = ProdutoVM.ListarTodosProdutos();
            return View(listaProdutosVM);
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var produto = _context.Produto.Find(id);
            CarregaDadosViewBag();
            return View(produto);
        }

        public IActionResult Edit (Produto produto)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(produto).State = EntityState.Modified;
                _context.SaveChanges();
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
        public IActionResult Delete (ProdutoVM produtoVM)
        {
            var produto = _context.Produto.Find(produtoVM.Codigo);
            _context.Entry(produto).State = EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction("Index");
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
