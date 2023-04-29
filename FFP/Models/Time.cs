using System.IO;

namespace FFP.Models
{
    public class Time
    {
        Random random = new Random();
        public Time()
        {

        }
        public Time(int id, string nome, string bairro, DateTime fundacao, string presidente)
        {
            Id = id;
            Nome = nome;
            Bairro = bairro;
            Fundacao = fundacao;
            Presidente = presidente;
            JogadorID = random.Next();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Bairro { get; set; }
        public DateTime Fundacao { get; set; }
        public string Presidente { get; set; }
        public int JogadorID { get; set; }
        public virtual ICollection<Jogador> Jogadores { get; set; }
    }
}

