using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Tj.Livraria.Domain.Entities;
using Tj.Livraria.Domain.Interfaces.Repository;

namespace Tj.Livraria.Infra.Repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        private string ConnectionString = "Data Source=localhost;Initial Catalog=Livraria;Trusted_Connection=True;";

        public bool Add(Subject entity)
        {
            string query = "Insert into Assunto (Descricao) values (@Descricao)";

            using (var conn = new SqlConnection(ConnectionString))
            {
                return conn.Execute(query, new
                {
                    Descricao = entity.Description
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

        public Subject Get(int cod)
        {
            string query = "Select CodAs as SubjectCod, Descricao as Description from Assunto where CodAs = @cod";

            using (var conn = new SqlConnection(ConnectionString))
            {
                return conn.QueryFirstOrDefault<Subject>(query, new
                {
                    cod
                });
            }
        }

        public List<Subject> GetAll()
        {
            string query = "Select CodAs as SubjectCod, Descricao as Description from Assunto";

            using(var conn = new SqlConnection(ConnectionString))
            {
                return conn.Query<Subject>(query)
                    .ToList();
            }
        }

        public Subject GetByDescription(string description)
        {
            string query = "Select CodAs as SubjectCod, Descricao as Description from Assunto where Descricao = @description";

            using (var conn = new SqlConnection(ConnectionString))
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

            using (var conn = new SqlConnection(ConnectionString))
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