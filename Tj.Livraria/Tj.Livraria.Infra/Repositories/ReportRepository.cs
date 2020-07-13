using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Tj.Livraria.Domain.Interfaces.Repository;
using Tj.Livraria.Domain.Views;

namespace Tj.Livraria.Infra.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private string _connectionString = "Data Source=localhost;Initial Catalog=Livraria;Trusted_Connection=True;";

        public List<BooksBySubject> GetBooksBySubject()
        {
            string query = @"select 
                                Assunto Subject,
                                QntdLivros BookCount 
                             from livros_por_assunto
                             order by 1 asc, 2 desc";

            using (var conn = new SqlConnection(_connectionString))
            {
                return conn.Query<BooksBySubject>(query)
                    .ToList();
            }
        }
    }
}