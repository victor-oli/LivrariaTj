﻿using System.Collections.Generic;
using Tj.Livraria.Domain.Entities;

namespace Tj.Livraria.Infra.Mapping
{
    public abstract class BookMapping
    {
        public static Book Map(dynamic book)
        {
            return new Book
            {
                BookCod = book.Codl,
                PublishingCompany = book.Editora,
                Edition = book.Edicao,
                Price = book.Valor,
                PublicationYear = book.AnoPublicacao,
                Title = book.Titulo
            };
        }

        public static Book MapWithBookRelationship(dynamic book)
        {
            Book bookEntity = Map(book);

            bookEntity.BookSubjects.Add(new Subject
            {
                SubjectCod = book.CodAs,
                Description = book.AssuntoDescricao
            });

            return bookEntity;
        }
    }
}