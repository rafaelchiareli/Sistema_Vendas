using Microsoft.AspNetCore.Mvc;
using Sistema_Venda_SI.Model.Models;
using Sistema_Venda_SI.Model.Service;

namespace SIstema_Venda_SI.Controllers
{
    public class ConfiguracaoController : Controller
    {
        private ServiceConfiguracao _ServiceConfiguracao;
        public ConfiguracaoController()
        {
            _ServiceConfiguracao = new ServiceConfiguracao();
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Manter()
        {
            var configuracao = await _ServiceConfiguracao.oRepositoryConfiguracao.SelecionarPkAsync(1);
            return View(configuracao);
        }

        [HttpPost]
        public async Task<IActionResult> Manter(Configuracao configuracao)
        {
            if (ModelState.IsValid)
            {
                await _ServiceConfiguracao.oRepositoryConfiguracao.AlterarAsync(configuracao);
                ViewData["Mensagem"] = "Dados salvos com sucesso.";
                return View(configuracao);
            }
            return View(configuracao);
         
        }
    }
}
