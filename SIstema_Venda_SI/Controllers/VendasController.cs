using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema_Venda_SI.Model.Service;

namespace SIstema_Venda_SI.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class VendasController : ControllerBase
    {
        private ServiceVenda _ServiceVenda;
        public VendasController()
        {
                _ServiceVenda = new ServiceVenda();
        }
        [HttpGet]
        public async Task<IActionResult> GetVendas()
        {
            return Ok(await _ServiceVenda.oRepositoryVenda.SelecionarTodosAsync());
        }
        [HttpGet]
        public async Task<IActionResult> GetVendasById(int idVenda)
        {
            return Ok(await _ServiceVenda.oRepositoryVenda.SelecionarPkAsync(idVenda));
        }
    }
}
