using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Tj.Livraria.Domain.Entities;
using Tj.Livraria.Domain.Interfaces.Repository;

namespace Tj.Livraria.Infra.Repositories
{
    public class AssuntoRepository : IAssuntoRepository
    {
        private string ConnectionString = "Data Source=localhost;Initial Catalog=Livraria;Trusted_Connection=True;";

        public void Add(Assunto entity)
        {
            string query = "Insert into Assunto (Descricao) values (@Descricao)";

            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Execute(query, new
                {
                    entity.Descricao
                });
            }
        }

        public void Delete(int cod)
        {
            throw new NotImplementedException();
        }

        public Assunto Get(int cod)
        {
            throw new NotImplementedException();
        }

        public List<Assunto> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Assunto entity)
        {
            throw new NotImplementedException();
        }
    }
}