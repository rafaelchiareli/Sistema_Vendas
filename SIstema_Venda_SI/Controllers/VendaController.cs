using Microsoft.AspNetCore.Mvc;
using Sistema_Venda_SI.Model.Service;

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
    }
}
