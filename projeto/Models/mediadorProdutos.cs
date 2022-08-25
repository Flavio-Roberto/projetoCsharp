using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace projeto.Models
{
    public class mediadorProdutos : DbContext
    {
        public virtual DbSet<produtos> produtos { get; set; }
    }
}