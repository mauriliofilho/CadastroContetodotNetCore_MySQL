using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EnterpriseCad.Models
{
    public class Empresa
    {
        [Key]
        [DisplayName("#")]
        public int idEmpresa { get; set; }

        [Required]
        [DisplayName("Descrição da Empresa")]
        public string nomeEmpresa { get; set; }
        [Required]
        [DisplayName("CNPJ da Empresa")]
        public string codCNPJ { get; set; }

        [DisplayName("Data de Criação")]
        public DateTime dataCriacao { get; set; } = DateTime.UtcNow;
    }
}
