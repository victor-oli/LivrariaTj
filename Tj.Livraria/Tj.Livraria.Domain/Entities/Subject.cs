using System.Collections.Generic;
using Tj.Livraria.Domain.Exceptions;

namespace Tj.Livraria.Domain.Entities
{
    public class Subject
    {
        public int SubjectCod { get; set; }
        public string Description { get; set; }

        public List<Book> SubjectBooks { get; set; } = new List<Book>();

        public void IsValidToCreateOrUpdate()
        {
            if (string.IsNullOrWhiteSpace(Description))
                throw new NullOrEmptyException("Description can't be null or empty");
        }
    }
}