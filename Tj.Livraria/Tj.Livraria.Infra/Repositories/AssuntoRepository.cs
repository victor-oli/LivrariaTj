using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Tj.Livraria.Domain.Entities;
using Tj.Livraria.Domain.Interfaces.Repository;

namespace Tj.Livraria.Infra.Repositories
{
    public class AssuntoRepository : IAssuntoRepository
    {
        private string ConnectionString = "Data Source=localhost;Initial Catalog=Livraria;Trusted_Connection=True;";

        public bool Add(Assunto entity)
        {
            string query = "Insert into Assunto (Descricao) values (@Descricao)";

            using (var conn = new SqlConnection(ConnectionString))
            {
                return conn.Execute(query, new
                {
                    entity.Descricao
                }) == 1;
            }
        }

        public bool Delete(int cod)
        {
            string query = "Delete from Assunto where CodAs = @cod";

            using (var conn = new SqlConnection(ConnectionString))
            {
                return conn.Execute(query, new
                {
                    cod
                }) == 1;
            }
        }

        public Assunto Get(int cod)
        {
            string query = "Select CodAs, Descricao from Assunto where CodAs = @cod";

            using (var conn = new SqlConnection(ConnectionString))
            {
                return conn.QueryFirstOrDefault<Assunto>(query, new
                {
                    cod
                });
            }
        }

        public List<Assunto> GetAll()
        {
            string query = "Select CodAs, Descricao from Assunto";

            using(var conn = new SqlConnection(ConnectionString))
            {
                return conn.Query<Assunto>(query)
                    .ToList();
            }
        }

        public bool Update(Assunto entity)
        {
            string query = "Update Assunto (Descricao) set (@Descricao) where CodAs = @cod";

            using (var conn = new SqlConnection(ConnectionString))
            {
                return conn.Execute(query, new
                {
                    cod = entity.CodAssunto,
                    entity.Descricao
                }) == 1;
            }
        }
    }
}