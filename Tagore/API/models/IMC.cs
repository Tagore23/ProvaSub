namespace API.Models
{
    public class IMC
    {
        public int Id { get; set; }  
        public string AlunoId { get; set; }  
        public decimal Peso { get; set; }
        public decimal Altura { get; set; }
        public decimal ValorIMC { get; set; }
        public string Classificacao { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;

        public Aluno Aluno { get; set; }  
    }
}
