﻿using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Tj.Livraria.Domain.Entities;
using Tj.Livraria.Domain.Interfaces.Repository;
using Tj.Livraria.Infra.Mapping;
using Tj.Livraria.Infra.ObjectValues;
using Z.Dapper.Plus;

namespace Tj.Livraria.Infra.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private string _connectionString;

        public AuthorRepository(IConfiguration config)
        {
            _connectionString = config.GetSection("Connectionstring").Value;
        }

        public bool Add(Author entity)
        {
            string query = "Insert into Autor (Nome) values (@Nome)";

            using (var conn = new SqlConnection(_connectionString))
            {
                return conn.Execute(query, new
                {
                    Nome = entity.Name
                }) == 1;
            }
        }

        public void AddManyRelations(int bookCod, List<Author> authors)
        {
            DapperPlusManager.Entity<BookAuthor>().Table("Livro_Autor");

            using (var conn = new SqlConnection(_connectionString))
            {
                var r = conn.BulkInsert(authors.Select(x => new BookAuthor
                {
                    Livro_Codl = bookCod,
                    Autor_CodAu = x.AuthorCod
                }));
            }
        }

        public bool Delete(int cod)
        {
            string query = "Delete from Autor where CodAu = @cod";

            using (var conn = new SqlConnection(_connectionString))
            {
                return conn.Execute(query, new
                {
                    cod
                }) == 1;
            }
        }

        public void DeleteManyRelations(int bookCod, List<Author> authors)
        {
            DapperPlusManager.Entity<BookAuthor>().Table("Livro_Autor")
                .Key("Livro_Codl")
                .Key("Autor_CodAu");

            using (var conn = new SqlConnection(_connectionString))
            {
                var r = conn.BulkDelete(authors.Select(x => new BookAuthor
                {
                    Livro_Codl = bookCod,
                    Autor_CodAu = x.AuthorCod
                }));
            }
        }

        public Author Get(int cod)
        {
            string query = "Select CodAu, Nome from Autor where CodAu = @cod";

            using (var conn = new SqlConnection(_connectionString))
            {
                var author = conn.QueryFirstOrDefault<dynamic>(query, new
                {
                    cod
                });

                return AuthorMapping.Map(author);
            }
        }

        public List<Author> GetAll()
        {
            string query = "Select CodAu, Nome from Autor order by 2";

            using (var conn = new SqlConnection(_connectionString))
            {
                var result = conn.Query<dynamic>(query)
                    .ToList();

                List<Author> authorList = new List<Author>();

                result.ForEach(x => 
                    authorList.Add(AuthorMapping.Map(x)));

                return authorList;
            }
        }

        public List<Author> GetAllByBookCod(int bookCod)
        {
            string query = @"Select a.CodAu, a.Nome
                                from Autor a
                                inner join Livro_Autor la on la.Autor_CodAu = a.CodAu
                                inner join Livro l on l.Codl = la.Livro_Codl
                                where l.Codl = @bookCod
                                order by 2";

            using (var conn = new SqlConnection(_connectionString))
            {
                var result = conn.Query<dynamic>(query, new
                {
                    bookCod
                }).ToList();

                List<Author> authorList = new List<Author>();

                result.ForEach(x =>
                    authorList.Add(AuthorMapping.Map(x)));

                return authorList;
            }
        }

        public Author GetByName(string name)
        {
            string query = "Select CodAu, Nome from Autor where Nome = @name";

            using (var conn = new SqlConnection(_connectionString))
            {
                var author = conn.QueryFirstOrDefault<dynamic>(query, new
                {
                    name
                });

                return AuthorMapping.Map(author);
            }
        }

        public bool Update(Author entity)
        {
            string query = "Update Autor set Nome = @Nome where CodAu = @cod";

            using (var conn = new SqlConnection(_connectionString))
            {
                return conn.Execute(query, new
                {
                    cod = entity.AuthorCod,
                    Nome = entity.Name
                }) == 1;
            }
        }
    }
}