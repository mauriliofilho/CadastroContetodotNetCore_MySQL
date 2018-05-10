using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EnterpriseCad.Models
{
    public class ContatoViewModel
    {
        [Key]
        public int idContato { get; set; }
        public string nomeContato { get; set; }
        public string codCPF { get; set; }
        public string telResidencial { get; set; }
        public string telCelular { get; set; }
        public string email { get; set; }

        public Empresa Empresa { get; set; }
        public Area Area { get; set; }

        public static explicit operator ContatoViewModel(List<Contato> v)
        {
            throw new NotImplementedException();
        }
    }
}
