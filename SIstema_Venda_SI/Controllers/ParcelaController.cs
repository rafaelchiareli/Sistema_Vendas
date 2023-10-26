using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using Sistema_Venda_SI.Model.Models;
using Sistema_Venda_SI.Model.Service;

namespace SIstema_Venda_SI.Controllers
{
    public class ParcelaController : Controller
    {
        private ServiceParcelas _ServiceParcelas;

        public ParcelaController()
        {
            _ServiceParcelas = new ServiceParcelas();
        }

        public IActionResult ListarClientes()
        {
            return Ok(_ServiceParcelas.oRepositoryCliente.SelecionarTodos());
        }
        public IActionResult Edit()
        {

            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Edit(List<Parcelas> parcelas)
        {

            ViewBag.idCliente = Request.Form["txtCliente"].First();
            foreach (var parcela in parcelas)
            {
                if (parcela.ParDataPagamento != null)
                {

                    await _ServiceParcelas.oRepositoryParcela.AlterarAsync(parcela);
                }
            }

            return View();
        }

        public async Task<IActionResult> ListarParcelas(int idCliente)
        {
            var listaParcelas = await _ServiceParcelas.oRepositoryParcela.ListarParcelasCliente(idCliente);
            return PartialView("_Parcelas", listaParcelas);
        }


    }
}
