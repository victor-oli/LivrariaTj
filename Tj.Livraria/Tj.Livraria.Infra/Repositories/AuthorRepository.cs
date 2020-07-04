using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Tj.Livraria.Domain.Entities;
using Tj.Livraria.Domain.Interfaces.Repository;

namespace Tj.Livraria.Infra.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private string ConnectionString = "Data Source=localhost;Initial Catalog=Livraria;Trusted_Connection=True;";

        public bool Add(Author entity)
        {
            string query = "Insert into Autor (Nome) values (@Nome)";

            using (var conn = new SqlConnection(ConnectionString))
            {
                return conn.Execute(query, new
                {
                    Nome = entity.Name
                }) == 1;
            }
        }

        public bool Delete(int cod)
        {
            string query = "Delete from Autor where CodAu = @cod";

            using (var conn = new SqlConnection(ConnectionString))
            {
                return conn.Execute(query, new
                {
                    cod
                }) == 1;
            }
        }

        public Author Get(int cod)
        {
            string query = "Select CodAu, Nome from Autor where CodAu = @cod";

            using (var conn = new SqlConnection(ConnectionString))
            {
                return conn.QueryFirstOrDefault<Author>(query, new
                {
                    cod
                });
            }
        }

        public List<Author> GetAll()
        {
            string query = "Select CodAu, Nome from Autor";

            using (var conn = new SqlConnection(ConnectionString))
            {
                return conn.Query<Author>(query)
                    .ToList();
            }
        }

        public bool Update(Author entity)
        {
            string query = "Update Autor (Nome) set (@Nome) where CodAu = @cod";

            using (var conn = new SqlConnection(ConnectionString))
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