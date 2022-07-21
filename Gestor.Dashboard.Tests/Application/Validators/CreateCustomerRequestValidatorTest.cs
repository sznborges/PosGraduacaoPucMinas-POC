using Bogus;
using Gestor.Dashboard.Application.Requests;
using Gestor.Dashboard.Application.Requests.CreateCustomer;

namespace Gestor.Dashboard.Tests.Application.Validators
{
    public class CreateCustomerRequestValidatorTest
    {
        [Fact]
        public void Validate_WithNameGreaterThan80_Error()
        {
            // Arrange
            var validator = new CreateCustomerRequestValidator();
            var request = new CreateCustomerRequest
            {
                Name = new Faker().Random.String2(90)
            };

            // Act
            var result = validator.Validate(request);

            // Assert
            Assert.NotNull(result);
            Assert.False(result.IsValid);
            Assert.Equal("Name", result.Errors[0].PropertyName);
        }

        [Fact]
        public void Validate_WithEmailGreaterThan80_Error()
        {
            // Arrange
            var validator = new CreateCustomerRequestValidator();
            var request = new CreateCustomerRequest
            {
                Name = new Faker().Random.String2(80),
                Email = new Faker().Random.String2(90)
            };

            // Act
            var result = validator.Validate(request);

            // Assert
            Assert.NotNull(result);
            Assert.False(result.IsValid);
            Assert.Equal("Email", result.Errors[0].PropertyName);
        }

        [Fact]
        public void Validate_InvalidDDD_Error()
        {
            // Arrange
            var validator = new CreateCustomerRequestValidator();
            var request = new CreateCustomerRequest
            {
                Name = new Faker().Random.String2(80),
                Email = new Faker().Internet.Email(),
                DDD = "12345"
            };

            // Act
            var result = validator.Validate(request);

            // Assert
            Assert.NotNull(result);
            Assert.False(result.IsValid);
            Assert.Equal("DDD", result.Errors[0].PropertyName);
        }

        [Fact]
        public void Validate_InvalidPhone_Error()
        {
            // Arrange
            var validator = new CreateCustomerRequestValidator();
            var request = new CreateCustomerRequest
            {
                Name = new Faker().Random.String2(80),
                Email = new Faker().Internet.Email(),
                DDD = "55",
                Phone = "1245"
            };

            // Act
            var result = validator.Validate(request);

            // Assert
            Assert.NotNull(result);
            Assert.False(result.IsValid);
            Assert.Equal("Phone", result.Errors[0].PropertyName);
        }

        [Fact]
        public void Validate_Valid_ShouldNotReturnError()
        {
            // Arrange
            var validator = new CreateCustomerRequestValidator();
            var request = new CreateCustomerRequest
            {
                CPF = "547.718.210-54",
                Name = new Faker().Random.String2(80),
                Email = new Faker().Internet.Email(),
                DDD = "55",
                Phone = "965685214"
            };

            // Act
            var result = validator.Validate(request);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.IsValid);
        }

    }
}
