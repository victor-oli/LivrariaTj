﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Tj.Livraria.Domain.Entities;
using Tj.Livraria.Domain.Interfaces.Repository;

namespace Tj.Livraria.Infra.Repositories
{
    public class BookRepository : IBookRepository
    {
        private string ConnectionString = "Data Source=localhost;Initial Catalog=Livraria;Trusted_Connection=True;";

        public bool Add(Book entity)
        {
            string query = @"Insert into Livro 
                                (Titulo, Editora, Edicao, AnoPublicacao, Valor) 
                             values 
                                (@Titulo, @Editora, @Edicao, @AnoPublicacao, @Valor)";

            using (var conn = new SqlConnection(ConnectionString))
            {
                return conn.Execute(query, new
                {
                    Titulo = entity.Title,
                    Editora = entity.PublishingCompany,
                    Edicao = entity.Edition,
                    AnoPublicacao = entity.PublicationYear,
                    Valor = entity.Price
                }) == 1;
            }
        }

        public bool Delete(int cod)
        {
            string query = "Delete from Livro where Codl = @cod";

            using (var conn = new SqlConnection(ConnectionString))
            {
                return conn.Execute(query, new
                {
                    cod
                }) == 1;
            }
        }

        public Book Get(int cod)
        {
            string query = "Select Codl, Titulo, Editora, Edicao, AnoPublicacao, Valor from Livro where Codl = @cod";

            using (var conn = new SqlConnection(ConnectionString))
            {
                return conn.QueryFirstOrDefault<Book>(query, new
                {
                    cod
                });
            }
        }

        public List<Book> GetAll()
        {
            string query = "Select Codl, Titulo, Editora, Edicao, AnoPublicacao, Valor from Livro";

            using (var conn = new SqlConnection(ConnectionString))
            {
                return conn.Query<Book>(query)
                    .ToList();
            }
        }

        public bool Update(Book entity)
        {
            string query = @"Update Livro 
                                (Titulo, Editora, Edicao, AnoPublicacao, Valor) 
                            set 
                                (@Titulo, @Editora, @Edicao, @AnoPublicacao, @Valor) 
                            where Codl = @cod";

            using (var conn = new SqlConnection(ConnectionString))
            {
                return conn.Execute(query, new
                {
                    Codl = entity.BookCod,
                    Titulo = entity.Title,
                    Editora = entity.PublishingCompany,
                    Edicao = entity.Edition,
                    AnoPublicacao = entity.PublicationYear,
                    Valor = entity.Price
                }) == 1;
            }
        }
    }
}