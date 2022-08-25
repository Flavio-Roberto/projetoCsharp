using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace projeto.Models
{
    public class clientes
    {
        [Key]
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        [Required]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido.")]
        public string Email { get; set; }
        public string DataCadastro { get; set; }
        public int qtd { get; set; }
    }
}