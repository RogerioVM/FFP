using FFP.Models;

namespace FFP.Context
{
    public class SeedingService
    {
        private readonly DataContext _context;

        public SeedingService(DataContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Times.Any() || _context.Jogadores.Any())
            {
                return; // DB has been seeded
            }

            Random random = new Random();

            Time t1 = new Time(1, "Topazio", "Jardim Angelica", new DateTime(year: 2002, month: 10, day: 10), "Luiz");
            Time t2 = new Time(2, "UDA", "Jardim Angelica", new DateTime(year: 2012, month: 10, day: 10), "Dédé");

            Jogador j1 = new Jogador(1, "Rogerio", "Meia", 30, "Esquerdo", "Aguiar");
            

            _context.Times.AddRange(t1, t2); // AddRange permite que adicione vários objetos de uma vez

            _context.Jogadores.Add(j1);

            _context.SaveChanges();
        }
    }
}
