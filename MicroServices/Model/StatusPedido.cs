using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServices.Model
{
    public class StatusPedido
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Pedido")]
        public int CodigoPedido { get; set; }
        public string Status { get; set; }
        public bool RetiraPedido { get; set; }
        public DateTime DataEntrega { get; set; }
        public virtual Pedido Pedido { get; set; }
    }
}
