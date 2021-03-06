﻿using System.Collections.Generic;
using Tj.Livraria.Domain.Exceptions;

namespace Tj.Livraria.Domain.Entities
{
    public class Author
    {
        public int AuthorCod { get; set; }
        public string Name { get; set; }

        public List<Book> AuthorBooks { get; set; } = new List<Book>();

        public void IsValidToCreateOrUpdate()
        {
            if (string.IsNullOrWhiteSpace(Name))
                throw new NullOrEmptyException("Name can't be null or empty");

            if (Name.Length > 40)
                throw new FormatException("Name can't be bigger then 40 characters");
        }
    }
}