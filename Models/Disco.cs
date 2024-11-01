namespace ColetaneaDiscos.Models
{
    public class Disco
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Artista {get; set;}
        public int AnoLancamento { get; set; }
        public string Genero { get; set; }
        public string Gravadora { get; set; }
        public List<Faixa> Faixas { get; set; }
        public float DuracaoTotal { get; set; }
        public string Formato { get; set; }
        public string Capa{ get; set; }
        public DateTime DataAquisicao { get; set; }
        public int AvaliacaoPessoal { get; set; }
        public string Comentario { get; set; }

        public Disco() { }
    }


}