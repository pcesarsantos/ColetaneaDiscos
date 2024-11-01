using System.Collections.Generic;
using System.Threading.Tasks;
using ColetaneaDiscos.Models;

namespace ColetaneaDiscos.Repositories
{
    public interface IFaixaRepository
    {
        Task<IEnumerable<Faixa>> GetByDisco(int IdDisco);
        Task<int> Add(Faixa faixa);
        Task<int> Update(Faixa faixa);
        Task<int> Delete(int id);
    }
}