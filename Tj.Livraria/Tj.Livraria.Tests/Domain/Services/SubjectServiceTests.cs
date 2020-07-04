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
    public class SubjectServiceTests
    {
        [Trait("SubjectService", "When adding"), Fact(DisplayName = "With Valid Arguments")]
        public void AddWithValidArguments()
        {
            // Arrange
            Subject subject = new Subject
            {
                Description = "Terror"
            };

            Mock<ISubjectRepository> mock = new Mock<ISubjectRepository>();
            mock.Setup(x => x.Add(subject)).Returns(true);

            ISubjectService service = new SubjectService(mock.Object);

            // Act
            bool hasAdded = service.Add(subject);

            // Assert
            Assert.True(hasAdded);
        }

        [Trait("SubjectService", "When adding"), Fact(DisplayName = "With Invalid Arguments")]
        public void AddWithInvalidArguments()
        {
            // Arrange
            Subject subject = new Subject();

            Mock<ISubjectRepository> mock = new Mock<ISubjectRepository>();

            ISubjectService service = new SubjectService(mock.Object);

            // Act & Assert
            var ex = Assert.Throws<NullOrEmptyException>(() => service.Add(subject));

            Assert.NotNull(ex);
            Assert.Equal("Description can't be null or empty", ex.Message);
        }

        [Trait("SubjectService", "When getting all"), Fact(DisplayName = "On Success Case")]
        public void GetAllOnSuccessCase()
        {
            // Arrange
            var validResult = new List<Subject>
            {
                new Subject{ Description = "Terror" }
            };
            Mock<ISubjectRepository> mock = new Mock<ISubjectRepository>();
            mock.Setup(x => x.GetAll()).Returns(validResult);

            ISubjectService service = new SubjectService(mock.Object);

            // Act
            var subjectList = service.GetAll();

            // Assert
            Assert.True(subjectList.Count == 1);
            Assert.Equal(validResult[0].Description, subjectList[0].Description);
        }

        [Trait("SubjectService", "When getting one"), Fact(DisplayName = "With Valid Arguments")]
        public void GetWithValidArguments()
        {
            // Arrange
            var subjectCod = 1;
            var validResult = new Subject
            {
                SubjectCod = subjectCod,
                Description = "Terror"
            };
            Mock<ISubjectRepository> mock = new Mock<ISubjectRepository>();
            mock.Setup(x => x.Get(subjectCod)).Returns(validResult);

            ISubjectService service = new SubjectService(mock.Object);

            // Act
            var result = service.Get(subjectCod);

            // Assert
            Assert.Equal(validResult.SubjectCod, result.SubjectCod);
            Assert.Equal(validResult.Description, result.Description);
        }

        [Trait("SubjectService", "When getting one"), Fact(DisplayName = "With Invalid Arguments")]
        public void GetWithInvalidArguments()
        {
            // Arrange
            var subjectCod = 0;
            Mock<ISubjectRepository> mock = new Mock<ISubjectRepository>();
            ISubjectService service = new SubjectService(mock.Object);

            // Act & Assert
            var ex = Assert.Throws<NullOrEmptyException>(() => service.Get(subjectCod));

            Assert.NotNull(ex);
            Assert.Equal("You need send a valid subject cod", ex.Message);
        }

        [Trait("SubjectService", "When updating"), Fact(DisplayName = "With Valid Arguments")]
        public void UpdateWithValidArguments()
        {
            // Arrange
            var subject = new Subject
            {
                SubjectCod = 1,
                Description = "Terror/Suspense"
            };
            Mock<ISubjectRepository> mock = new Mock<ISubjectRepository>();
            mock.Setup(x => x.Get(subject.SubjectCod)).Returns(subject);
            mock.Setup(x => x.Update(subject)).Returns(true);

            ISubjectService service = new SubjectService(mock.Object);

            // Act
            bool hasUpdated = service.Update(subject);

            // Assert
            Assert.True(hasUpdated);
        }

        [Trait("SubjectService", "When updating"), Fact(DisplayName = "With Invalid Arguments")]
        public void UpdateWithInvalidArguments()
        {
            // Arrange
            var subject = new Subject
            {
                SubjectCod = 0,
                Description = string.Empty
            };
            Mock<ISubjectRepository> mock = new Mock<ISubjectRepository>();
            mock.Setup(x => x.Get(subject.SubjectCod)).Returns(subject);
            mock.Setup(x => x.Update(subject)).Returns(true);

            ISubjectService service = new SubjectService(mock.Object);

            // Act & Assert
            var ex = Assert.Throws<NullOrEmptyException>(() => service.Update(subject));

            Assert.NotNull(ex);
            Assert.False(string.IsNullOrWhiteSpace(ex.Message));
        }

        [Trait("SubjectService", "When deleting"), Fact(DisplayName = "With Valid Arguments")]
        public void DeleteWithValidArguments()
        {
            // Arrange
            var subjectCod = 1;
            Mock<ISubjectRepository> mock = new Mock<ISubjectRepository>();
            mock.Setup(x => x.Delete(subjectCod)).Returns(true);

            ISubjectService service = new SubjectService(mock.Object);

            // Act
            bool hasDeleted = service.Delete(subjectCod);

            // Assert
            Assert.True(hasDeleted);
        }

        [Trait("SubjectService", "When deleting"), Fact(DisplayName = "With Invalid Arguments")]
        public void DeleteWithInvalidArguments()
        {
            // Arrange
            var subjectCod = 0;
            Mock<ISubjectRepository> mock = new Mock<ISubjectRepository>();
            ISubjectService service = new SubjectService(mock.Object);

            // Act & Assert
            var ex = Assert.Throws<NullOrEmptyException>(() => service.Delete(subjectCod));

            Assert.NotNull(ex);
            Assert.False(string.IsNullOrWhiteSpace(ex.Message));
        }
    }
}