﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Sistema_Venda_SI.Model.Models;

public partial class Endereco
{
    public int EndCodigo { get; set; }

    public int EndCodigoCliente { get; set; }

    public string EndCep { get; set; }

    public string EndLogradouro { get; set; }

    public string EndBairro { get; set; }

    public string EndCidade { get; set; }

    public string EndComplemento { get; set; }

    public string EndNumero { get; set; }

    public string EndEstado { get; set; }

    public virtual Cliente EndCodigoClienteNavigation { get; set; }
}