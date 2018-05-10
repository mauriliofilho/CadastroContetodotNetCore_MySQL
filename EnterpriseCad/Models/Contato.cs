using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EnterpriseCad.Models
{
    public class Contato
    {
        [Key]
        [DisplayName("#")]
        public int idContato { get; set; }

        [Required]
        [DisplayName("Nome do Contato")]
        public string nomeContato { get; set; }

        [Required]
        [DisplayName("Número do CPF")]
        public string codCPF { get; set; }

        [DisplayName("Tel Residencial")]
        public string telResidencial { get; set; }

        [DisplayName("Tel Celular")]
        public string telCelular { get; set; }

        [DisplayName("E-mail")]
        public string email { get; set; }

        [ForeignKey("Area")]
        [DisplayName("Area")]
        public int idArea { get; set; }
        public Area Area { get; set; }
    }
}
