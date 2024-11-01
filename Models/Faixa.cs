namespace ColetaneaDiscos.Models
{
    public class Faixa {
        public int Id { get; set; }
        public string NomeDaFaixa { get; set; }
        public float TempoDeDuracao { get; set; }
        public int IdDisco { get; set; }

        public Faixa() { }

        public Faixa(int id, string nomeDaFaixa, float tempoDeDuracao, int idDisco) {
            Id             = id;
            NomeDaFaixa    = nomeDaFaixa;
            TempoDeDuracao = tempoDeDuracao;
            IdDisco        = idDisco;
        }
    }
}