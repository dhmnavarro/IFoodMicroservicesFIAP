using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroServices.Database;
using MicroServices.Model;

namespace MicroServices.Repository
{
    public class EstabelecimentoRepository : IEstabelecimentoRepository
    {
        private readonly EstabelecimentoContext _dbContext;

        public EstabelecimentoRepository(EstabelecimentoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public IEnumerable<Estabelecimento> SelecionaEstabelecimentos()
        {
            return _dbContext.Estabelecimento.ToList();
        }

        public Estabelecimento SelecionaEstabelecimentoByID(int codEstabelecimento)
        {
            return _dbContext.Estabelecimento.Find(codEstabelecimento);
        }

        public void InsereEstabelecimento(Estabelecimento estabelecimento)
        {
            _dbContext.Add(estabelecimento);
            Save();
        }

        public void AtualizaEstabelecimento(Estabelecimento estabelecimento)
        {
            _dbContext.Entry(estabelecimento).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Save();
        }

        public void ApagaEstabelecimento(int codEstabelecimento)
        {
            var estabelecimento = _dbContext.Estabelecimento.Find(codEstabelecimento);
            _dbContext.Estabelecimento.Remove(estabelecimento);
            Save();
        }
    }
}
