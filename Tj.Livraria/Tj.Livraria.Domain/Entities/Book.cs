using System.Collections.Generic;
using Tj.Livraria.Domain.Exceptions;

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

        public void IsValidToCreate()
        {
            if (string.IsNullOrWhiteSpace(Title))
                throw new NullOrEmptyException("Title can't be null or empty");

            if (string.IsNullOrWhiteSpace(PublishingCompany))
                throw new NullOrEmptyException("PublishingCompany can't be null or empty");

            if (Edition < 1)
                throw new NullOrEmptyException("Edition can't be null or empty");

            if (string.IsNullOrWhiteSpace(PublicationYear))
                throw new NullOrEmptyException("PublicationYear can't be null or empty");

            if (Price < 0)
                throw new NullOrEmptyException("Price can't be null or empty");
        }
    }
}