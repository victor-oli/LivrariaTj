using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Tj.Livraria.Domain.Entities;
using Tj.Livraria.Domain.Exceptions;
using Tj.Livraria.Domain.Interfaces.Repository;
using Tj.Livraria.Infra.Mapping;

namespace Tj.Livraria.Infra.Repositories
{
    public class BookRepository : IBookRepository
    {
        private string _connectionString = "Data Source=localhost;Initial Catalog=Livraria;Trusted_Connection=True;";

        public bool Add(Book entity)
        {
            string query = @"Insert into Livro 
                                (Titulo, Editora, Edicao, AnoPublicacao, Valor) 
                             values 
                                (@Titulo, @Editora, @Edicao, @AnoPublicacao, @Valor)";

            using (var conn = new SqlConnection(_connectionString))
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
            string deleteSubjectRelationshipsQuery = "delete from Livro_Assunto where Livro_Codl = @cod";
            string deleteAuthorRelationshipsQuery = "delete from Livro_Autor where Livro_Codl = @cod";
            string deleteBookQuery = "Delete from Livro where Codl = @cod";

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        conn.Execute(deleteSubjectRelationshipsQuery, new
                        {
                            cod
                        }, transaction);

                        conn.Execute(deleteAuthorRelationshipsQuery, new
                        {
                            cod
                        }, transaction);

                        int deleteBookAffectedRows = conn.Execute(deleteBookQuery, new
                        {
                            cod
                        }, transaction);

                        transaction.Commit();

                        return deleteBookAffectedRows > 1;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();

                        throw new RelationshipViolationException($"An error occurred while trying to delete any relationship associated with bookCod {cod}", ex);
                    }
                }
            }
        }

        public Book Get(int cod)
        {
            string query = @"Select
                                Codl BookCod,
                                Titulo Title,
                                Editora PublishingCompany,
                                Edicao Edition,
                                AnoPublicacao PublicationYear,
                                Valor Price 
                            from Livro where Codl = @cod";

            using (var conn = new SqlConnection(_connectionString))
            {
                return conn.QueryFirstOrDefault<Book>(query, new
                {
                    cod
                });
            }
        }

        public List<Book> GetAll()
        {
            string query = @"Select
                                Codl BookCod,
                                Titulo Title,
                                Editora PublishingCompany,
                                Edicao Edition,
                                AnoPublicacao PublicationYear,
                                Valor Price 
                            from Livro";

            using (var conn = new SqlConnection(_connectionString))
            {
                return conn.Query<Book>(query)
                    .ToList();
            }
        }

        public List<Book> GetAllByAuthor(int authorCod)
        {
            string query = @"Select l.Codl, l.Titulo, l.Editora, l.Edicao, l.AnoPublicacao, l.Valor, a.CodAu, a.Nome AuthorName
                                from livro l
                                inner join Livro_Autor la on la.Livro_Codl = l.Codl
                                inner join Autor a on a.CodAu = la.Autor_CodAu
                                where a.CodAu = @authorCod";

            using (var conn = new SqlConnection(_connectionString))
            {
                var result = conn.Query<dynamic>(query, new
                {
                    authorCod
                }).ToList();

                List<Book> bookList = new List<Book>();

                result.ForEach(x =>
                    bookList.Add(BookMapping.MapWithAuthorRelationship(x)));

                return bookList;
            }
        }

        public List<Book> GetAllBySubject(int subjectCod)
        {
            string query = @"Select l.Codl, l.Titulo, l.Editora, l.Edicao, l.AnoPublicacao, l.Valor, a.CodAs, a.Descricao assuntoDescricao
                                from Livro l
                                inner
                                join Livro_Assunto la on la.Livro_Codl = la.Livro_Codl
                                inner
                                join Assunto a on a.CodAs = la.Assunto_CodAs
                                WHERE a.CodAs = @subjectCod";

            using (var conn = new SqlConnection(_connectionString))
            {
                var result = conn.Query<dynamic>(query, new
                {
                    subjectCod
                }).ToList();

                List<Book> bookList = new List<Book>();

                result.ForEach(x =>
                    bookList.Add(BookMapping.MapWithSubjectRelationship(x)));

                return bookList;
            }
        }

        public Book GetByTitleAndEdition(string title, int edition)
        {
            string query = @"Select Codl, Titulo, Editora, Edicao, AnoPublicacao, Valor 
                                from Livro 
                                where Titulo = @title and Edicao = @edition";

            using (var conn = new SqlConnection(_connectionString))
            {
                var book = conn.QueryFirstOrDefault<dynamic>(query, new
                {
                    title,
                    edition
                });

                return BookMapping.Map(book);
            }
        }

        public bool Update(Book entity)
        {
            string query = @"Update Livro set
                                Titulo = @Titulo, Editora = @Editora, Edicao = @Edicao, AnoPublicacao = @AnoPublicacao, Valor = @Valor
                            where Codl = @cod";

            using (var conn = new SqlConnection(_connectionString))
            {
                return conn.Execute(query, new
                {
                    cod = entity.BookCod,
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