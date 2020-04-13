using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroServices.Model;
using Microsoft.EntityFrameworkCore;

namespace MicroServices.Database
{
    public class StatusPedidoContext : DbContext
    {
        public StatusPedidoContext(DbContextOptions<StatusPedidoContext> options) : base(options)
        {

        }

        public DbSet<StatusPedido> StatusPedido { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=192.168.199.128; initial catalog=TESTE;user id=sa; password=$iemensPLM;");
        }
    }
}
