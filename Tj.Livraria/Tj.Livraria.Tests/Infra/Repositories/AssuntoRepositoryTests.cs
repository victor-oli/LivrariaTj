using Moq;
using System;
using Tj.Livraria.Domain.Entities;
using Tj.Livraria.Domain.Interfaces.Repository;
using Tj.Livraria.Infra.Repositories;
using Xunit;

namespace Tj.Livraria.Tests.Infra.Repositories
{
    public class AssuntoRepositoryTests
    {
        [Trait("AssuntoRepository", "When Adding"), Fact(DisplayName = "Valid Arguments")]
        public void AddingValidArguments()
        {
            // Arrange
            Assunto assunto = new Assunto
            {
                Descricao = "Terror"
            };

            IAssuntoRepository repository = new AssuntoRepository();

            // Act & Assert
            try
            {
                repository.Add(assunto);
            }
            catch (Exception ex)
            {
                throw new Exception("Add not working correctly", ex);
            }
        }

        [Trait("AssuntoRepository", "When Adding"), Fact(DisplayName = "Invalid Arguments")]
        public void AddingInvalidArguments()
        {

        }
    }
}