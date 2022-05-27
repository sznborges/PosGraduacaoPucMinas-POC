using Gestor.Dashboard.Application.Requests;
using Gestor.Dashboard.Application.Requests.GetTicketsByType;

namespace Gestor.Dashboard.Tests.Application.Validators
{
    public class BaseValidatorTest
    {
        [Fact]
        public void Validate_WithInvalidStartRangeData_Error()
        {
            // Arrange
            var validator = new BaseValidator<DashboardRequestBase>();
            var request = new DashboardRequestBase
            {
                EndRangeDate = DateTime.Today,
                Limit = 3
            };

            // Act
            var result = validator.Validate(request);

            // Assert
            Assert.NotNull(result);
            Assert.False(result.IsValid);
            Assert.Equal("StartRangeDate", result.Errors[0].PropertyName);
        }

        [Fact]
        public void Validate_WithInvalidEndRangeData_Error()
        {
            // Arrange
            var validator = new BaseValidator<DashboardRequestBase>();
            var request = new DashboardRequestBase
            {
                StartRangeDate = DateTime.Today,
                Limit = 3
            };

            // Act
            var result = validator.Validate(request);

            // Assert
            Assert.NotNull(result);
            Assert.False(result.IsValid);
            Assert.Equal("EndRangeDate", result.Errors[0].PropertyName);
        }

        [Fact]
        public void Validate_WithInvalidLimit_Error()
        {
            // Arrange
            var validator = new BaseValidator<DashboardRequestBase>();
            var request = new DashboardRequestBase
            {
                StartRangeDate = DateTime.Today,
                EndRangeDate = DateTime.Today.AddDays(4),
                Limit = 0
            };

            // Act
            var result = validator.Validate(request);

            // Assert
            Assert.NotNull(result);
            Assert.False(result.IsValid);
            Assert.Equal("Limit", result.Errors[0].PropertyName);
        }

        [Fact]
        public void Validate_Ok()
        {
            // Arrange
            var validator = new BaseValidator<DashboardRequestBase>();
            var request = new DashboardRequestBase
            {
                StartRangeDate = DateTime.Today,
                EndRangeDate = DateTime.Today.AddDays(4),
                Limit = 6
            };

            // Act
            var result = validator.Validate(request);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.IsValid);
        }
    }
}
