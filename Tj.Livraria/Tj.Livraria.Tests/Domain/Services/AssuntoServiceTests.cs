using Moq;
using Tj.Livraria.Domain.Entities;
using Tj.Livraria.Domain.Exceptions;
using Tj.Livraria.Domain.Interfaces.Repository;
using Tj.Livraria.Domain.Interfaces.Service;
using Tj.Livraria.Domain.Services;
using Xunit;

namespace Tj.Livraria.Tests.Domain.Services
{
    public class AssuntoServiceTests
    {
        [Trait("AssuntoService", "When adding"), Fact(DisplayName = "With Valid Arguments")]
        public void WithValidArguments()
        {
            // Arrange
            Assunto assunto = new Assunto
            {
                Descricao = "Terror"
            };

            Mock<IAssuntoRepository> mock = new Mock<IAssuntoRepository>();            
            mock.Setup(x => x.Add(assunto)).Returns(true);
            
            IAssuntoService service = new AssuntoService(mock.Object);

            // Act
            bool hasAdded = service.Add(assunto);

            // Assert
            Assert.True(hasAdded);
        }

        [Trait("AssuntoService", "When adding"), Fact(DisplayName = "With Invalid Arguments")]
        public void WithInvalidArguments()
        {
            // Arrange
            Assunto assunto = new Assunto();

            Mock<IAssuntoRepository> mock = new Mock<IAssuntoRepository>();

            IAssuntoService service = new AssuntoService(mock.Object);

            // Act & Assert
            var ex = Assert.Throws<NullOrEmptyException>(() => service.Add(assunto));

            Assert.NotNull(ex);
            Assert.Equal("Description can't be null or empty", ex.Message);
        }
    }
}