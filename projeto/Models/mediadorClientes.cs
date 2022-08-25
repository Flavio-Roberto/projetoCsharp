using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace projeto.Models
{
    public class mediadorClientes : DbContext
    {
        public virtual DbSet<clientes> clientes { get; set; }
    }
}