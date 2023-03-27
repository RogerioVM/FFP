﻿using System.IO;

namespace FFP.Models
{
    public class Time
    {
        public Time()
        {

        }
        public Time(string nome, string bairro, DateTime fundacao, string presidente)
        {
            Nome = nome;
            Bairro = bairro;
            Fundacao = fundacao;
            Presidente = presidente;
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
}