using System.Collections.Generic;

namespace Tj.Livraria.Domain.Entities
{
    public class Assunto
    {
        public int CodAssunto { get; set; }
        public string Descricao { get; set; }

        public List<Livro> LivroAssunto { get; set; } = new List<Livro>();
    }
}