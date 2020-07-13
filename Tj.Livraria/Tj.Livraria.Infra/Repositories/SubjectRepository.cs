using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Tj.Livraria.Domain.Entities;
using Tj.Livraria.Domain.Interfaces.Repository;
using Tj.Livraria.Infra.ObjectValues;
using Z.Dapper.Plus;

namespace Tj.Livraria.Infra.Repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        private string _connectionString = "Data Source=localhost;Initial Catalog=Livraria;Trusted_Connection=True;";

        public bool Add(Subject entity)
        {
            string query = "Insert into Assunto (Descricao) values (@Descricao)";

            using (var conn = new SqlConnection(_connectionString))
            {
                return conn.Execute(query, new
                {
                    Descricao = entity.Description
                }) == 1;
            }
        }

        public void AddManyRelations(int bookCod, List<Subject> subjects)
        {
            DapperPlusManager.Entity<BookSubject>().Table("Livro_Assunto");

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.BulkInsert(subjects.Select(x => new BookSubject
                {
                    Livro_Codl = bookCod,
                    Assunto_CodAs = x.SubjectCod
                }));
            }
        }

        public bool Delete(int cod)
        {
            string query = "Delete from Assunto where CodAs = @cod";

            using (var conn = new SqlConnection(_connectionString))
            {
                return conn.Execute(query, new
                {
                    cod
                }) == 1;
            }
        }

        public void DeleteManyRelations(int bookCod, List<Subject> subjects)
        {
            DapperPlusManager.Entity<BookSubject>().Table("Livro_Assunto")
                .Key("Livro_Codl")
                .Key("Assunto_CodAs");

            using (var conn = new SqlConnection(_connectionString))
            {
                var r = conn.BulkDelete(subjects.Select(x => new BookSubject
                {
                    Livro_Codl = bookCod,
                    Assunto_CodAs = x.SubjectCod
                }));
            }
        }

        public Subject Get(int cod)
        {
            string query = "Select CodAs as SubjectCod, Descricao as Description from Assunto where CodAs = @cod";

            using (var conn = new SqlConnection(_connectionString))
            {
                return conn.QueryFirstOrDefault<Subject>(query, new
                {
                    cod
                });
            }
        }

        public List<Subject> GetAll()
        {
            string query = "Select CodAs as SubjectCod, Descricao as Description from Assunto order by 2";

            using(var conn = new SqlConnection(_connectionString))
            {
                return conn.Query<Subject>(query)
                    .ToList();
            }
        }

        public List<Subject> GetAllByBookCod(int bookCod)
        {
            string query = @"Select a.CodAs as SubjectCod, a.Descricao as Description
                                from Assunto a
                                inner join Livro_Assunto la on la.Assunto_CodAs = a.CodAs
                                inner join Livro l on l.Codl = la.Livro_Codl
                                where l.Codl = @bookCod
                                order by 2";

            using (var conn = new SqlConnection(_connectionString))
            {
                return conn.Query<Subject>(query, new
                {
                    bookCod
                }).ToList();
            }
        }

        public Subject GetByDescription(string description)
        {
            string query = "Select CodAs as SubjectCod, Descricao as Description from Assunto where Descricao = @description";

            using (var conn = new SqlConnection(_connectionString))
            {
                return conn.Query<Subject>(query, new
                {
                    description
                }).FirstOrDefault();
            }
        }

        public bool Update(Subject entity)
        {
            string query = "Update Assunto set Descricao = @Descricao where CodAs = @cod";

            using (var conn = new SqlConnection(_connectionString))
            {
                return conn.Execute(query, new
                {
                    cod = entity.SubjectCod,
                    Descricao = entity.Description
                }) == 1;
            }
        }
    }
}