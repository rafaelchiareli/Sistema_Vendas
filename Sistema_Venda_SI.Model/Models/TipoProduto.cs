﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Sistema_Venda_SI.Model.Models;

public partial class TipoProduto
{
    public int TipCodigo { get; set; }

    public string TipDescricao { get; set; }

    public bool TipDestivado { get; set; }

    public virtual ICollection<Produto> Produto { get; set; } = new List<Produto>();
}