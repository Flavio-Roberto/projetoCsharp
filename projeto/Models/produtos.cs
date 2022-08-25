using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace projeto.Models
{
    public class produtos
    {
        [Key]
        public int ProdutoId { get; set; }
        public string Nome { get; set; }
        [Required]
        public string Valor { get; set; }
        public int Disponivel { get; set; }
        public int idclientes { get; set; }
    }
}