using Domain.Models;
using NSubstitute;
using Repositories;
using Repositories.Repositories;
using Services.Services;

namespace MilesCarRental.Tests
{
    public class ReservacionServiceTest
    {
        private readonly IBaseRepository<Reservacion> _repository;
        private readonly IReservacionRepository _reservacionRepository;

        public ReservacionServiceTest()
        {
            _repository = Substitute.For<IBaseRepository<Reservacion>>();
            _reservacionRepository = Substitute.For<IReservacionRepository>();
        }

        [Fact]
        public void When_ReservacionIsValid_ReturnTrue()
        {
            // Arrange
            var reservacionService = new ReservacionService(_repository, _reservacionRepository);

            var reservacion = new Reservacion
            {
                ClienteId = "123",
                VehiculoId = "456",
                LocalidadRecogidaId = "789",
                LocalidaDevolucionId = "101112",
                FechaRecogida = DateTime.Now.AddDays(1),
                FechaDevolucion = DateTime.Now.AddDays(2)
            };

            // Act
            bool result = reservacionService.ValidBeforeInsert(reservacion);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void When_AnyPropertyIsNull_ReturnsFalse()
        {
            // Arrange
            var reservacionService = new ReservacionService(_repository, _reservacionRepository);

            var reservacion = new Reservacion
            {
                ClienteId = "12",
                VehiculoId = "10",
                LocalidadRecogidaId = "458",
                LocalidaDevolucionId = "963",
                FechaRecogida = DateTime.Now.AddDays(1),
                FechaDevolucion = DateTime.Now.AddDays(2)
            };

            // Act
            var properties = typeof(Reservacion).GetProperties();
            foreach (var property in properties)
            {
                // Si la propieda es null
                if (property.PropertyType == null)
                {
                    property.SetValue(reservacion, ""); 
                    bool result = reservacionService.ValidBeforeInsert(reservacion);
                    // Assert
                    Assert.False(result);
                    property.SetValue(reservacion, null); 
                }
            }
        }
    }
}
