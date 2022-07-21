using Gestor.Dashboard.Application.Requests;

namespace Gestor.Dashboard.Tests.Application.Validators
{
    public class CpfValidatorTest
    {
        [Theory]
        [InlineData("594.935.670-52")]
        [InlineData("823.061.370-21")]
        [InlineData("00334963079")]
        [InlineData("54141625060")]
        public void IsCpf_WhenValidCpf_ReturnTrue(string cpf)
        {
            // Act
            var result = CpfValidator.IsCpf(cpf);

            // Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData("525.935.700-12")]
        [InlineData("823.161.370-21")]
        [InlineData("00134534563079")]
        [InlineData("54144235060")]
        [InlineData("00000000000")]
        [InlineData("11111111111")]
        [InlineData(null)]
        public void IsCpf_WhenIsValidCpf_ReturnFalse(string cpf)
        {
            // Act
            var result = CpfValidator.IsCpf(cpf);

            // Assert
            Assert.False(result);
        }

    }
}
