using Domain.Models;
using NSubstitute;
using Repositories;
using Repositories.Repositories;
using Services.Services;

namespace MilesCarRental.Tests
{
    public class LocalidadServiceTest
    {
        private readonly IBaseRepository<Localidad> _repository;
        private readonly ILocalidadRepository _localidadRepository;

        public LocalidadServiceTest()
        {
            _repository = Substitute.For<IBaseRepository<Localidad>>();
            _localidadRepository = Substitute.For<ILocalidadRepository>();
        }

        [Fact]
        public void When_LocalidadName_ReturnFalse()
        {
            // Arrange
            var localidadService = new LocalidadService(_repository, _localidadRepository);
            var nombreLocalidad = new Localidad { Nombre = null };

            // Act
            bool result = localidadService.ValidBeforeInsert(nombreLocalidad);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void When_LocalidadName_ReturnTrue()
        {
            // Arrange
            var localidadService = new LocalidadService(_repository, _localidadRepository);
            var nombreLocalidad = new Localidad { Nombre = "Medellín" };

            // Act
            bool result = localidadService.ValidBeforeInsert(nombreLocalidad);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void When_LocalidadNameIsEmpty_ReturnFalse()
        {
            // Arrange
            var localidadService = new LocalidadService(_repository, _localidadRepository);
            var nombreLocalidad = new Localidad { Nombre = "" };

            // Act
            bool result = localidadService.ValidBeforeInsert(nombreLocalidad);

            // Assert
            Assert.False(result);
        }
    }
}
