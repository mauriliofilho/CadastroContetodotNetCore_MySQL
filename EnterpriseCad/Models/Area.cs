using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EnterpriseCad.Models
{
    public class Area
    {
        [Key]
        [DisplayName("#")]
        public int idArea { get; set; }

        [Required]
        [DisplayName("Descrição da Área")]
        public string descArea { get; set; }

        [ForeignKey("Empresa")]
        [DisplayName("Empresa")]
        public int idEmpresa { get; set; }
        public Empresa Empresa { get; set; }

        [DisplayName("Data de Criação")]
        public DateTime dataCriacao { get; set; } = DateTime.Now;

    }
}
