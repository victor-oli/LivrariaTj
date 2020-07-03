using System.Collections.Generic;

namespace Tj.Livraria.Domain.Entities
{
    public class Autor
    {
        public int CodAutor { get; set; }
        public string Name { get; set; }

        public List<Livro> LivroAutor { get; set; } = new List<Livro>();
    }
}