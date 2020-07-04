using System.Collections.Generic;

namespace Tj.Livraria.Domain.Entities
{
    public class Book
    {
        public int BookCod { get; set; }
        public string Title { get; set; }
        public string PublishingCompany { get; set; }
        public int Edition { get; set; }
        public string PublicationYear { get; set; }
        public decimal Price { get; set; }

        public List<Author> BookAuthors { get; set; } = new List<Author>();
        public List<Subject> BookSubjects { get; set; } = new List<Subject>();
    }
}