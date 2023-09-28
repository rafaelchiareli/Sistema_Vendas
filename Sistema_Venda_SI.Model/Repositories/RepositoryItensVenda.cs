﻿using Sistema_Venda_SI.Model.Interfaces;
using Sistema_Venda_SI.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Venda_SI.Model.Repositories
{
    public class RepositoryItensVenda : RepositoryBase<ItensVenda>
    {
        public RepositoryItensVenda(bool saveChanges = true) : base(saveChanges) 
        {
                
        }
    }
}
