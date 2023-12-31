﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.VisualStudio.Web.CodeGeneration.CommandLine;
using Sistema_Venda_SI.Model.Models;
using Sistema_Venda_SI.Model.Service;
using SIstema_Venda_SI.ViewModel;
using SQLitePCL;
using System.Security.Claims;

namespace SIstema_Venda_SI.Controllers
{
   

    public class ClienteController : DefaultController
    {

        private ServiceCliente _ServiceCliente;

        public ClienteController()
        {
           
            _ServiceCliente = new ServiceCliente();
        }

        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.Name);
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
        public async Task<IActionResult> Create(ClienteVM clienteVM)
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

            await _ServiceCliente.oRepositoryCliente.IncluirAsync(cliente, endereco);

            return View(clienteVM);
        }
    }
}
