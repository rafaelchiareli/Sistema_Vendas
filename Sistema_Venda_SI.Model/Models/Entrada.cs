﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Sistema_Venda_SI.Model.Models;

public partial class Entrada
{
    public int EntCodigo { get; set; }

    public DateTime? EntDataHora { get; set; }

    public string EntUsuario { get; set; }

    public string EnNuneroNotaFiscal { get; set; }

    public virtual EntradaProduto EntradaProduto { get; set; }
}