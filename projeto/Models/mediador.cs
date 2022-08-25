using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace projeto.Models
{
    public class mediador : DbContext
    {   
        public virtual DbSet<produtos> produtos { get; set; }
    }
}