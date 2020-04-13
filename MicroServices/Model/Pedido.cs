using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServices.Model
{
    public class Pedido
    {
        [Key]
        public int CodigoPedido { get; set; }
        [ForeignKey("Estabelecimento")]
        public int CodigoEstabelecimento { get; set; }
        public string Categoria { get; set; }
        public string Solicitante { get; set; }
        public string Item { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorPedido { get; set; }
        public DateTime DataSolicitacao { get; set; }
        public virtual Estabelecimento Estabelecimento { get; set; }
        public virtual StatusPedido StatusPedido { get; set; }
    }
}
