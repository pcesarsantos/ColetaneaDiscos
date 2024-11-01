using System.Collections.Generic;
using System.Threading.Tasks;
using ColetaneaDiscos.Models;

namespace ColetaneaDiscos.Repositories
{
    public interface IDiscoRepository
    {
        Task<IEnumerable<Disco>> GetAll();
        Task<IEnumerable<Disco>> GetByGenero(string genero);
        Task<IEnumerable<Disco>> GetByArtista(string artista);
        Task<Disco> GetById(int id);
        Task<int> Add(Disco disco);
        Task<int> Update(Disco disco);
        Task<int> Delete(int id);
    }
}