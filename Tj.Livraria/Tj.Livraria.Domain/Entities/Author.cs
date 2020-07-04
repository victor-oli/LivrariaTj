using System;
using System.Collections.Generic;

namespace Tj.Livraria.Domain.Entities
{
    public class Author
    {
        public int AuthorCod { get; set; }
        public string Name { get; set; }

        public List<Livro> AuthorBooks { get; set; } = new List<Livro>();
    }
}