using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sistema_Venda_SI.Model.Models;
using Sistema_Venda_SI.Model.Service;
using SIstema_Venda_SI.ViewModel;
using System.Runtime.CompilerServices;
using static SIstema_Venda_SI.Helpers.Enumeradores;

namespace SIstema_Venda_SI.Controllers
{
    public class VendaController : Controller
    {
        ServiceVenda _ServiceVenda;
        Configuracao configuracao;
        public VendaController()
        {
            _ServiceVenda = new ServiceVenda();
            configuracao = new Configuracao();
            configuracao = _ServiceVenda.oRepositoryConfiguracao.SelecionarPk(1);
        }
        public IActionResult Index()
        {
            
            return View(VendaVM.ListarTodos());
        }

        public IActionResult GetConfiguracao()
        {
            return Ok(configuracao);
        }
        public void CarregaViewBag()
        {

            ViewData["CodigoCliente"] = new SelectList(_ServiceVenda.oRepositoryCliente.SelecionarTodos(), "CliCodigo", "CliNome");
            ViewData["CodigoTipoPagamento"] = new SelectList(_ServiceVenda.oRepositoryTipoPagamento.SelecionarTodos(), "TpgCodigo", "TpgDescricao");
            ViewBag.listaProdutos = _ServiceVenda.oRepositoryVwEstoque.SelecionarTodos();
        }
        public IActionResult Manter(int codVenda = 0)
        {
            CarregaViewBag();
            if (codVenda > 0)
            {
                return View(VendaVM.SelecionarVenda(codVenda));
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Manter(VendaVM vendaVM)
        {
            try
            {

                var venda = new Venda();
                var listaItens = new List<ItensVenda>();

                venda.VenCodigoCliente = vendaVM.CodigoCliente;
                venda.VenCodigoTipoPagamento = vendaVM.CodigoTipoPagamento;
                venda.VenQtdParcelas = vendaVM.QtdParcelas;
                venda.VenData = vendaVM.DataVenda;
                venda.VenUsuario = "Usuário";

                foreach (var item in vendaVM.ListaProdutos)
                {
                    listaItens.Add(new ItensVenda
                    {
                        ItvCodigoProduto = item.CodigoProduto,
                        ItvQuantidade = item.Quantidade,
                        ItvValorItem = item.ValorVenda
                    });
                }
                venda.ItensVenda = listaItens;

                if (venda.VenCodigoTipoPagamento == (int)eTipoPagamento.CREDIARIO)
                {
                    var listaParcelas = new List<Parcelas>();
                    var dataVencimento = venda.VenData.AddMonths(1);

                    decimal valorTotalVenda = 0; 
                    foreach (var item in venda.ItensVenda)
                    {
                        valorTotalVenda += (decimal)item.ItvValorItem * (decimal)item.ItvQuantidade;
                    }
                    for (int i = 1; i <= venda.VenQtdParcelas; i++)
                    {
                       var parcela = new Parcelas();
                      
                        parcela.ParValorParcela = valorTotalVenda / (int)venda.VenQtdParcelas;
                        parcela.ParNumeroParcela = i;
                        parcela.ParDataVencimento = dataVencimento;
                        dataVencimento = dataVencimento.AddMonths(1);
                        listaParcelas.Add(parcela);
                    }
                    venda.Parcelas = listaParcelas;
                }
                await _ServiceVenda.oRepositoryVenda.IncluirAsync(venda);
                vendaVM.CodigoVenda = venda.VenCodigo;
            
                CarregaViewBag();
                return View(vendaVM);
            }
            catch (Exception ex)
            {

                throw;
            }
          
        }

    }
}
