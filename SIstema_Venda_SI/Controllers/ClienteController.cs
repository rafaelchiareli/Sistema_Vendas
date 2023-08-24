using Microsoft.AspNetCore.Mvc;
using Sistema_Venda_SI.Model.Models;
using SIstema_Venda_SI.ViewModel;
using SQLitePCL;

namespace SIstema_Venda_SI.Controllers
{
    public class ClienteController : Controller
    {
        private readonly DBSISTEMASContext _context;
        public ClienteController(DBSISTEMASContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var listaClientesVM = ClienteVM.ListarTodosClientes();
            return View(listaClientesVM);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Details(int id)
        {
            var clienteVM = ClienteVM.SelecionarCliente(id);
            return View(clienteVM);

        }
        [HttpPost]
        public IActionResult Create(ClienteVM clienteVM)
        {
            //criamos o objeto cliente e atribuimos os valores de seus atributos a partir do objeto clienteVM que veio da view
            var cliente = new Cliente();
            cliente.CliCpfcnpj = clienteVM.CpfCnjp;
            cliente.CliDataCadastro = clienteVM.DataCadastro;
            cliente.CliDataNascimento = clienteVM.DataNascimento;
            cliente.CliEmail = clienteVM.Email;
            cliente.CliNome = clienteVM.Nome;
            cliente.CliNomeMae = clienteVM.NomeMae;
            cliente.CliSexo = clienteVM.Sexo;
            cliente.CliTelefone = clienteVM.Telefone;

            var listaEndereco = new List<Endereco>();
            //criamos o objeto endereço e atribuimos os valores de seus atributos a partir do objeto clienteVM que veio da view
            var endereco = new Endereco()
            {
                EndCep = clienteVM.CEP,
                EndBairro = clienteVM.Bairro,
                EndCidade = clienteVM.Cidade,
                EndComplemento = clienteVM.Complemento,
                EndEstado = clienteVM.Estado,
                EndLogradouro = clienteVM.Logradouro,
                EndNumero = clienteVM.Numero,

            };
            _context.Entry(cliente).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            _context.SaveChanges();
            endereco.EndCodigoCliente = cliente.CliCodigo;
            _context.Entry(endereco).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            _context.SaveChanges();

            return View();
        }
    }
}
