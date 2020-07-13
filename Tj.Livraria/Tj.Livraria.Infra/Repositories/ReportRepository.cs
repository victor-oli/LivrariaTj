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

        public List<AuthorsBySubject> GetAuthorsBySubject()
        {
            string createOrReplaceViewQuery = @"create or alter VIEW autores_por_assunto as
                                                select a.Descricao Assunto, count(au.CodAu) QntdAutores
                                                from Assunto a
                                                left join Livro_Assunto las on las.Assunto_CodAs = a.CodAs
                                                left join Livro_Autor lau on lau.Livro_Codl = las.Livro_Codl
                                                left join Autor au on au.CodAu = lau.Autor_CodAu
                                                group by a.Descricao";

            string query = @"select
                                Assunto Subject,
                                QntdAutores AuthorCount
                            from autores_por_assunto
                            order by 1 asc, 2 desc";

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Execute(createOrReplaceViewQuery);

                return conn.Query<AuthorsBySubject>(query)
                    .ToList();
            }
        }

        public List<BooksBySubject> GetBooksBySubject()
        {
            string createOrReplaceViewQuery = @"create or alter VIEW livros_por_assunto as
                                                select a.Descricao Assunto, count(las.Livro_Codl) QntdLivros
                                                from Assunto a
                                                left join Livro_Assunto las on las.Assunto_CodAs = a.CodAs
                                                group by a.Descricao";

            string query = @"select 
                                Assunto Subject,
                                QntdLivros BookCount 
                             from livros_por_assunto
                             order by 1 asc, 2 desc";

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Execute(createOrReplaceViewQuery);

                return conn.Query<BooksBySubject>(query)
                    .ToList();
            }
        }
    }
}