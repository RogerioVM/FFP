namespace FFP.Models
{
    public class Jogador
    {
        public Jogador()
        {

        }
        public Jogador(string nome, string posicao, int idade, string peDominante, string endereco)
        {
            Nome = nome;
            Posicao = posicao;
            Idade = idade;
            PeDominante = peDominante;
            Endereco = endereco;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Posicao { get; set; }
        public int Idade { get; set; }
        public string PeDominante { get; set; }
        public string Endereco { get; set; }
        public int TimeID { get; set; }
        public Time Time { get; set; }
    }
}

}
