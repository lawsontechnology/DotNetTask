    using ApplicationFormTask.Core.Application.Dto;
    using ApplicationFormTask.Core.Application.Implementation.Service;
    using ApplicationFormTask.Core.Application.Interface.Repositories;
    using ApplicationFormTask.Core.Domain.Entities;
    using ApplicationFormTask.Core.Domain.Enum;
    using Moq;
    using System;
    using System.Threading.Tasks;
    using Xunit;

namespace ApplicationFormTask.XUnitTest
{
    public class PersonalInformationServiceTests
    {
        private readonly Mock<IPersonalInformationRepository> _mockPersonalInformationRepo;
        private readonly Mock<IAuditLogRepository> _mockAuditLogRepo;
        private readonly PersonalInformationService _service;

        public PersonalInformationServiceTests()
        {
            _mockPersonalInformationRepo = new Mock<IPersonalInformationRepository>();
            _mockAuditLogRepo = new Mock<IAuditLogRepository>();
            _service = new PersonalInformationService(_mockPersonalInformationRepo.Object, _mockAuditLogRepo.Object);
        }

        [Fact]
        public async Task Create_ShouldReturnSuccessResponse()
        {
            // Arrange
            var requestModel = new PersonalInformationRequestModel
            {
                CurrentResidence = "123 Street",
                DOB = DateOnly.Parse("2000-01-01"),
                Email = "test@example.com",
                FirstName = "John",
                LastName = "Doe",
                IDNumber = "123456789",
                PhoneNumber = "123-456-7890",
                QuestionTypeToAnswer = QuestionType.Paragraph,
                Nationality = "Country",
                Gender = Gender.Male
            };

            _mockPersonalInformationRepo.Setup(repo => repo.CreateAsync(It.IsAny<PersonalInformation>())).Returns(Task.FromResult(new PersonalInformation()));
            _mockAuditLogRepo.Setup(repo => repo.CreateAsync(It.IsAny<AuditLog>())).Returns(Task.FromResult(new AuditLog()));
            _mockPersonalInformationRepo.Setup(repo => repo.SaveAsync()).Returns(Task.FromResult(0));

            // Act
            var result = await _service.Create(requestModel);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Status);
            Assert.Equal("Successfully Created ", result.Message);
            Assert.Equal("test@example.com", result.Data.Email);
        }


        [Fact]
        public async Task GetInformation_ShouldReturnInformation_WhenEmailExists()
        {
            // Arrange
            var email = "test@example.com";
            var personalInformation = new PersonalInformation
            {
                Email = email,
                FirstName = "John",
                LastName = "Doe",
                CurrentResidence = "123 Street",
                DOB = DateOnly.Parse("2000-01-01"),
                IDNumber = "123456789",
                PhoneNumber = "123-456-7890",
                QuestionTypeToAnswer = QuestionType.Paragraph, 
                Nationality = "Country",
                Gender = Gender.Male 
            };

            _mockPersonalInformationRepo.Setup(repo => repo.GetAsync(email))
                .ReturnsAsync(personalInformation);
            _mockAuditLogRepo.Setup(repo => repo.CreateAsync(It.IsAny<AuditLog>())).Returns(Task.FromResult(new AuditLog()));
            _mockAuditLogRepo.Setup(repo => repo.SaveAsync()).Returns(Task.FromResult(0));

            // Act
            var result = await _service.GetInformation(email);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Status);
            Assert.NotNull(result.Data);
            Assert.Equal(email, result.Data.Email);
            Assert.Equal("John", result.Data.FirstName);
            Assert.Equal("Doe", result.Data.LastName);
        }

        [Fact]
        public async Task GetInformation_ShouldReturnFailureResponse_WhenEmailDoesNotExist()
        {
            // Arrange
            var email = "non-existing-email@example.com";

            _mockPersonalInformationRepo.Setup(repo => repo.GetAsync(email))
                .ReturnsAsync((PersonalInformation)null);

            // Act
            var result = await _service.GetInformation(email);

            // Assert
            Assert.NotNull(result);
            Assert.False(result.Status);
            Assert.Equal($"{email} Cannot be found From The DataBase", result.Message);
        }

        [Fact]
        public async Task GetAllInformation_ShouldReturnAllInformation()
        {
            // Arrange
            var personalInformationList = new List<PersonalInformation>
    {
        new PersonalInformation { Id = "1", FirstName = "John", LastName = "Doe" },
        new PersonalInformation { Id = "2", FirstName = "Jane", LastName = "Doe" }
    };

            _mockPersonalInformationRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(personalInformationList);
            _mockAuditLogRepo.Setup(repo => repo.CreateAsync(It.IsAny<AuditLog>())).Returns(Task.FromResult(new AuditLog()));
            _mockAuditLogRepo.Setup(repo => repo.SaveAsync()).Returns(Task.FromResult(0));

            // Act
            var result = await _service.GetAllInformation();

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Status);
            Assert.Equal(2, result.Data.Count);
            Assert.Equal("John", result.Data.First().FirstName);
        }

        [Fact]
        public async Task DeleteInformation_ShouldReturnSuccessResponse_WhenIdExists()
        {
            // Arrange
            var informationId = "existing-id";
            var personalInformation = new PersonalInformation { Id = informationId, IsDeleted = false };

             _mockPersonalInformationRepo.Setup(repo => repo.GetAsync(informationId)).ReturnsAsync(personalInformation);
            _mockAuditLogRepo.Setup(repo => repo.CreateAsync(It.IsAny<AuditLog>())).Returns(Task.FromResult(new AuditLog()));
            _mockPersonalInformationRepo.Setup(repo => repo.SaveAsync()).Returns(Task.FromResult(0));

            // Act
            var result = await _service.DeleteInformation(informationId);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Status);
            Assert.Equal("Successfully Deleted", result.Message);
        }

        [Fact]
        public async Task DeleteInformation_ShouldReturnFailureResponse_WhenIdDoesNotExist()
        {
            // Arrange
            var informationId = "non-existing-id";

            _mockPersonalInformationRepo.Setup(repo => repo.GetAsync(informationId)).ReturnsAsync((PersonalInformation)null);

            // Act
            var result = await _service.DeleteInformation(informationId);

            // Assert
            Assert.NotNull(result);
            Assert.False(result.Status);
            Assert.Equal($"Id : {informationId} CanNot Be Found In the DataBase", result.Message);
        }

    }

}
