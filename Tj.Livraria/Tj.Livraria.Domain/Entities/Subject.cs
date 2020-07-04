using System.Collections.Generic;

namespace Tj.Livraria.Domain.Entities
{
    public class Subject
    {
        public int SubjectCod { get; set; }
        public string Description { get; set; }

        public List<Book> SubjectBooks { get; set; } = new List<Book>();
    }
}