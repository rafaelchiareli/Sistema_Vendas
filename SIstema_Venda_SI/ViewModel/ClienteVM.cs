using Sistema_Venda_SI.Model.Models;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace SIstema_Venda_SI.ViewModel
{
    public class ClienteVM
    {
        public enum eTipoCliente
        {
            Pessoa_Fisica,
            Pessoa_Juridica
        }
        #region DadosCliente
        public int Codigo { get; set; }
        public string Nome { get; set; }
        [Display(Name ="Data de Nascimento")]
        public DateTime? DataNascimento { get; set; }
        [Display(Name ="Nome da Mãe")]
        public string NomeMae { get; set; }
        public string Telefone { get; set; }
        public string Sexo { get; set; }
        public string CpfCnjp { get; set; }
        public string Cpf { get; set; }
        public string Cnpj { get; set; }
        public string Email { get; set; }
        public eTipoCliente TipoCliente { get; set; }
        public DateTime? DataCadastro { get; set; } = DateTime.Now;
        #endregion

        #region DadosEndereco
        public int CodigoEndereco { get; set; }
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Numero { get; set; }
        #endregion

        public ClienteVM()
        {

        }


        public static ClienteVM SelecionarCliente(int id)
        {
            var db = new DBSISTEMASContext();
            var cliente = db.Cliente.Find(id);
            var enderecoCliente = db.Endereco.FirstOrDefault(x => x.EndCodigoCliente == id);
            var clienteVM = new ClienteVM();
            clienteVM.Bairro = enderecoCliente.EndBairro;
            clienteVM.CEP = enderecoCliente.EndCep;
            clienteVM.Cidade = enderecoCliente.EndCidade;
            clienteVM.Cnpj = cliente.CliCpfcnpj.Length == 14 ? cliente.CliCpfcnpj : "";
            clienteVM.Cpf = cliente.CliCpfcnpj.Length < 14 ? cliente.CliCpfcnpj : "";
            clienteVM.Codigo = cliente.CliCodigo;
            clienteVM.CodigoEndereco = enderecoCliente.EndCodigo;
            clienteVM.Complemento = enderecoCliente.EndComplemento;
            clienteVM.DataCadastro = cliente.CliDataCadastro;
            clienteVM.DataNascimento = cliente.CliDataNascimento;
            clienteVM.Email = cliente.CliEmail;
            clienteVM.Estado = enderecoCliente.EndEstado;
            clienteVM.Logradouro = enderecoCliente.EndLogradouro;
            clienteVM.Nome = cliente.CliNome;
            clienteVM.NomeMae = cliente.CliNomeMae;
            clienteVM.Numero = enderecoCliente.EndNumero;
            clienteVM.Sexo = cliente.CliSexo;
            clienteVM.Telefone = cliente.CliTelefone;
            clienteVM.TipoCliente = cliente.CliCpfcnpj.Length < 14 ? eTipoCliente.Pessoa_Fisica : eTipoCliente.Pessoa_Juridica;
            return clienteVM;
        }
        public static List<ClienteVM> ListarTodosClientes()
        {
            var db = new DBSISTEMASContext();
            return (from cliente in db.Cliente
                    join endereco in db.Endereco on cliente.CliCodigo
                    equals endereco.EndCodigoCliente
                    select new ClienteVM
                    {
                        Bairro = endereco.EndBairro,
                        CEP = endereco.EndCep,
                        Cidade = endereco.EndCidade,
                        Cnpj = cliente.CliCpfcnpj.Length == 14 ? cliente.CliCpfcnpj : "",
                        Cpf = cliente.CliCpfcnpj.Length < 14 ? cliente.CliCpfcnpj : "",
                        Codigo = cliente.CliCodigo,
                        CodigoEndereco = endereco.EndCodigo,
                        Complemento = endereco.EndComplemento,
                        DataCadastro = cliente.CliDataCadastro,
                        DataNascimento = cliente.CliDataNascimento,
                        Email = cliente.CliEmail,
                        Estado = endereco.EndEstado,
                        Logradouro = endereco.EndLogradouro,
                        Nome = cliente.CliNome,
                        NomeMae = cliente.CliNomeMae,
                        Numero = endereco.EndNumero,
                        Sexo = cliente.CliSexo,
                        Telefone = cliente.CliTelefone,
                        TipoCliente = cliente.CliCpfcnpj.Length < 14 ? eTipoCliente.Pessoa_Fisica : eTipoCliente.Pessoa_Juridica



                    }).ToList();


        }

    }
}
