using DealershipManager.Dtos;
using DealershipManager.Services;
using SecondHandDealership.Models;

namespace DealershipManager.Tests.Services
{
    public class CarValidatorTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void IsValidAddCarDto_NullOrEmptyCarBrand_ShouldReturnFalse(string brand)
        {
            // Arrange
            var dto = new AddCarDto
            {
                Brand = brand,
                Category = CarCategories.Crossover,
                Model = "Model",
                Price = 10000,
                ProductionYear = 2010,
            };

            var sut = new CarValidator();

            // Act
            var result = sut.IsValidAddCarDto(dto);

            // Assert
            Assert.False(result);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void IsValidAddCarDto_NullOrEmptyCarModel_ShouldReturnFalse(string model)
        {
            // Arrange
            var dto = new AddCarDto
            {
                Brand = "brand",
                Category = CarCategories.Crossover,
                Model = model,
                Price = 10000,
                ProductionYear = 2010,
            };

            var sut = new CarValidator();

            // Act
            var result = sut.IsValidAddCarDto(dto);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void IsValidAddCarDto_FutureProductionYear_ShouldReturnFalse()
        {
            // Arrange
            var dto = new AddCarDto
            {
                Brand = "Brand",
                Category = CarCategories.Crossover,
                Model = "Model",
                Price = 10000,
                ProductionYear = DateTime.UtcNow.Year + 1,
            };

            var sut = new CarValidator();

            // Act
            var result = sut.IsValidAddCarDto(dto);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void IsValidAddCarDto_NegativePrice_ShouldReturnFalse()
        {
            // Arrange
            var dto = new AddCarDto
            {
                Brand = "Brand",
                Category = CarCategories.Crossover,
                Model = "Model",
                Price = -10000,
                ProductionYear = DateTime.UtcNow.Year,
            };

            var sut = new CarValidator();

            // Act
            var result = sut.IsValidAddCarDto(dto);

            // Assert
            Assert.False(result);
        }
        
        [Fact]
        public void IsValidAddCarDto_UnspecifiedCategory_ShouldReturnFalse()
        {
            // Arrange
            var dto = new AddCarDto
            {
                Brand = "Brand",
                Category = CarCategories.Unspecified,
                Model = "Model",
                Price = 10000,
                ProductionYear = DateTime.UtcNow.Year,
            };

            var sut = new CarValidator();

            // Act
            var result = sut.IsValidAddCarDto(dto);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void IsValidAddCarDto_ValidData_ShouldReturnTrue()
        {
            // Arrange
            var dto = new AddCarDto
            {
                Brand = "Brand",
                Category = CarCategories.Sedan,
                Model = "Model",
                Price = 10000,
                ProductionYear = DateTime.UtcNow.Year,
            };

            var sut = new CarValidator();

            // Act
            var result = sut.IsValidAddCarDto(dto);

            // Assert
            Assert.True(result);
        }
    }  
}
