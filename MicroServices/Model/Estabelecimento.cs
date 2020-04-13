using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServices.Model
{
    public class Estabelecimento
    {
        [Key]
        public int CodigoEstabelecimento { get; set; }
        public string NomeEstabelecimento { get; set; }
        public string Categoria { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public bool Aberto { get; set; }
    }
}
