using FFP.Models;
using System.Collections;

namespace FFP.Services
{
    public interface IJogadorService
    {
        Task<IEnumerable<Jogador>> GetJogadores();
        Task<Jogador> GetJogadorById(int id);
        Task<IEnumerable<Jogador>> GetJogadorByName(string nome);
        Task Create(Jogador jogador);
        Task Update(Jogador jogador);
        Task Delete(Jogador id);
    }
}
