using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroServices.Model;

namespace MicroServices.Repository
{
    public interface IEstabelecimentoRepository
    {
        IEnumerable<Estabelecimento> SelecionaEstabelecimentos();
        Estabelecimento SelecionaEstabelecimentoByID(int codEstabelecimento);
        void InsereEstabelecimento(Estabelecimento estabelecimento);
        void ApagaEstabelecimento(int codEstabelecimento);
        void AtualizaEstabelecimento(Estabelecimento estabelecimento);
        void Save();
    }
}
