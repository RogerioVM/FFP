using FFP.Context;
using FFP.Models;
using Microsoft.EntityFrameworkCore;

namespace FFP.Services
{
    public class JogadorService : IJogadorService
    {
        private readonly DataContext _dataContext;
        public JogadorService(DataContext dataContext)
        {
            _dataContext= dataContext;
        }
        public async Task<IEnumerable<Jogador>> GetJogadores()
        {
            return await _dataContext.Jogadores.ToListAsync();
        }
        public async Task<Jogador> GetJogadorById(int id)
        {
            var jogador = await _dataContext.Jogadores.FindAsync(id);
            return jogador;
        }
        public async Task<IEnumerable<Jogador>> GetJogadorByName(string nome)
        {
            IEnumerable<Jogador> jogador;
            if (!string.IsNullOrEmpty(nome))
            {
                jogador = await _dataContext.Jogadores
                            .Where(j => j.Nome.Contains(nome))
                            .ToListAsync();
            } else
            {
                return await GetJogadores();
            }

            return jogador;

        }
        public async Task Create(Jogador jogador)
        {
            _dataContext.Jogadores.Add(jogador);
            await _dataContext.SaveChangesAsync();
        }
        public async Task Update(Jogador jogador)
        {
            _dataContext.Entry(jogador).State = EntityState.Modified;
            await _dataContext.SaveChangesAsync();
        }
        public async Task Delete(Jogador id)
        {
            _dataContext.Jogadores.Remove(id);
            await _dataContext.SaveChangesAsync();
        }
    }
}
