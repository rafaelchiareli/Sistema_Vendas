using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sistema_Venda_SI.Model.Service;
using SIstema_Venda_SI.ViewModel;
using System.Runtime.CompilerServices;

namespace SIstema_Venda_SI.Controllers
{
    public class VendaController : Controller
    {
        ServiceVenda _ServiceVenda;
        public VendaController()
        {
            _ServiceVenda = new ServiceVenda();
        }
        public IActionResult Index()
        {
            return View();
        }

        public void CarregaViewBag()
        {

            ViewData["CodigoCliente"] = new SelectList(_ServiceVenda.oRepositoryCliente.SelecionarTodos(), "CliCodigo", "CliNome");
            ViewData["CodigoTipoPagamento"] = new SelectList(_ServiceVenda.oRepositoryTipoPagamento.SelecionarTodos(), "TpgCodigo", "TpgDescricao");
            ViewBag.listaProdutos = _ServiceVenda.oRepositoryVwEstoque.SelecionarTodos();
        }
        public IActionResult Manter()
        {
            CarregaViewBag();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>Manter(VendaVM venda)
        {
            CarregaViewBag();
            return View();
        }
        
    }
}
