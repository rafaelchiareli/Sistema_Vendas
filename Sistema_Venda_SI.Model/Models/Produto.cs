﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Sistema_Venda_SI.Model.Models;

public partial class Produto
{
    public int ProCodigo { get; set; }

    public string ProCodigoBarras { get; set; }

    public string ProDescricao { get; set; }

    public DateTime ProDataCadastro { get; set; }

    public bool ProDesativado { get; set; }

    public int? ProCodigoTipoProduto { get; set; }

    public int? ProCodigoUnidade { get; set; }

    public virtual ICollection<EntradaProduto> EntradaProduto { get; set; } = new List<EntradaProduto>();

    public virtual ICollection<ItensVenda> ItensVenda { get; set; } = new List<ItensVenda>();

    public virtual TipoProduto ProCodigoTipoProdutoNavigation { get; set; }

    public virtual Unidade ProCodigoUnidadeNavigation { get; set; }
}