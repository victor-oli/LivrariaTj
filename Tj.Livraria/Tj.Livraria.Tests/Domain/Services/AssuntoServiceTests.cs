using Moq;
using System.Collections.Generic;
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
        public void AddWithValidArguments()
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
        public void AddWithInvalidArguments()
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

        [Trait("AssuntoService", "When getting all"), Fact(DisplayName = "On Success Case")]
        public void GetAllOnSuccessCase()
        {
            // Arrange
            var validResult = new List<Assunto>
            {
                new Assunto{ Descricao = "Terror" }
            };
            Mock<IAssuntoRepository> mock = new Mock<IAssuntoRepository>();
            mock.Setup(x => x.GetAll()).Returns(validResult);

            IAssuntoService service = new AssuntoService(mock.Object);

            // Act
            var assuntoList = service.GetAll();

            // Assert
            Assert.True(assuntoList.Count == 1);
            Assert.Equal(validResult[0].Descricao, assuntoList[0].Descricao);
        }

        [Trait("AssuntoService", "When getting one"), Fact(DisplayName = "With Valid Arguments")]
        public void GetWithValidArguments()
        {
            // Arrange
            var codAssunto = 1;
            var validResult = new Assunto
            {
                CodAssunto = codAssunto,
                Descricao = "Terror"
            };
            Mock<IAssuntoRepository> mock = new Mock<IAssuntoRepository>();
            mock.Setup(x => x.Get(codAssunto)).Returns(validResult);

            IAssuntoService service = new AssuntoService(mock.Object);

            // Act
            var result = service.Get(codAssunto);

            // Assert
            Assert.Equal(validResult.CodAssunto, result.CodAssunto);
            Assert.Equal(validResult.Descricao, result.Descricao);
        }

        [Trait("AssuntoService", "When getting one"), Fact(DisplayName = "With Invalid Arguments")]
        public void GetWithInvalidArguments()
        {
            // Arrange
            var codAssunto = 0;
            Mock<IAssuntoRepository> mock = new Mock<IAssuntoRepository>();
            IAssuntoService service = new AssuntoService(mock.Object);

            // Act & Assert
            var ex = Assert.Throws<NullOrEmptyException>(() => service.Get(codAssunto));

            Assert.NotNull(ex);
            Assert.Equal("You need send a valid subject cod", ex.Message);
        }

        [Trait("AssuntoService", "When updating"), Fact(DisplayName = "With Valid Arguments")]
        public void UpdateWithValidArguments()
        {
            // Arrange
            var subject = new Assunto
            {
                CodAssunto = 1,
                Descricao = "Terror/Suspense"
            };
            Mock<IAssuntoRepository> mock = new Mock<IAssuntoRepository>();
            mock.Setup(x => x.Get(subject.CodAssunto)).Returns(subject);
            mock.Setup(x => x.Update(subject)).Returns(true);

            IAssuntoService service = new AssuntoService(mock.Object);

            // Act
            bool hasUpdated = service.Update(subject);

            // Assert
            Assert.True(hasUpdated);
        }

        [Trait("AssuntoService", "When updating"), Fact(DisplayName = "With Invalid Arguments")]
        public void UpdateWithInvalidArguments()
        {
            // Arrange
            var subject = new Assunto
            {
                CodAssunto = 0,
                Descricao = string.Empty
            };
            Mock<IAssuntoRepository> mock = new Mock<IAssuntoRepository>();
            mock.Setup(x => x.Get(subject.CodAssunto)).Returns(subject);
            mock.Setup(x => x.Update(subject)).Returns(true);

            IAssuntoService service = new AssuntoService(mock.Object);

            // Act & Assert
            var ex = Assert.Throws<NullOrEmptyException>(() => service.Update(subject));

            Assert.NotNull(ex);
            Assert.False(string.IsNullOrWhiteSpace(ex.Message));
        }

        [Trait("AssuntoService", "When deleting"), Fact(DisplayName = "With Valid Arguments")]
        public void DeleteWithValidArguments()
        {
            // Arrange
            var codSubject = 1;
            Mock<IAssuntoRepository> mock = new Mock<IAssuntoRepository>();
            mock.Setup(x => x.Delete(codSubject)).Returns(true);

            IAssuntoService service = new AssuntoService(mock.Object);

            // Act
            bool hasDeleted = service.Delete(codSubject);

            // Assert
            Assert.True(hasDeleted);
        }

        [Trait("AssuntoService", "When deleting"), Fact(DisplayName = "With Invalid Arguments")]
        public void DeleteWithInvalidArguments()
        {
            // Arrange
            var codSubject = 0;
            Mock<IAssuntoRepository> mock = new Mock<IAssuntoRepository>();
            IAssuntoService service = new AssuntoService(mock.Object);

            // Act & Assert
            var ex = Assert.Throws<NullOrEmptyException>(() => service.Delete(codSubject));

            Assert.NotNull(ex);
            Assert.False(string.IsNullOrWhiteSpace(ex.Message));
        }
    }
}