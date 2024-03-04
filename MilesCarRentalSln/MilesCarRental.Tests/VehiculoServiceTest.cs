using Domain.Models;
using NSubstitute;
using Repositories;
using Repositories.Repositories;
using Services.Services;

namespace MilesCarRental.Tests
{
    public class VehiculoServiceTest
    {
        private readonly IBaseRepository<Vehiculo> _repository;
        private readonly IVehiculoRepository _vehiculoRepository;
        public VehiculoServiceTest()
        {
            _repository = Substitute.For<IBaseRepository<Vehiculo>>();
            _vehiculoRepository = Substitute.For<IVehiculoRepository>();
        }

        [Fact]
        public void When_LocalidadParamIsNull_ReturnFalse()
        {
            // Arrange
            var vehiculoService = new VehiculoService(_repository, _vehiculoRepository);
            var vehiculo = new Vehiculo { LocalidadId = null };

            // Act
            bool result = vehiculoService.ValidBeforeInsert(vehiculo);

            // Assert
            Assert.False(result);
        }
    }
}
