using System.Collections.Generic;

namespace Tj.Livraria.Domain.Entities
{
    public class Livro
    {
        public int CodLivro { get; set; }
        public string Titulo { get; set; }
        public string Editora { get; set; }
        public int Edicao { get; set; }
        public string AnoPublicacao { get; set; }
        public decimal Valor { get; set; }

        public List<Autor> LivroAutor { get; set; } = new List<Autor>();
        public List<Subject> LivroAssunto { get; set; } = new List<Subject>();
    }
}