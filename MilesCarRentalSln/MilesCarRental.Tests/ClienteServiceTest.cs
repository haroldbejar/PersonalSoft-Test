using Domain.Models;
using NSubstitute;
using Repositories;
using Repositories.Repositories;
using Services.Services;

namespace MilesCarRental.Tests
{
    public class ClienteServiceTest
    {
        private readonly IBaseRepository<Cliente> _repository;
        private readonly IClienteRepository _clienteRepository;

        public ClienteServiceTest()
        {
            _repository = Substitute.For<IBaseRepository<Cliente>>();
            _clienteRepository = Substitute.For<IClienteRepository>();
        }

        [Fact]

        public void When_ClienteIdentificacion_ReturnFalse()
        {
            // Arrange
            var clienteService = new ClienteService(_repository, _clienteRepository);
            var cliente = new Cliente { Identificacion = null };

            // Act
            bool result = clienteService.ValidBeforeInsert(cliente);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void When_ClienteIdentificacion_ReturnTrue()
        {
            // Arrange
            var clienteService = new ClienteService(_repository, _clienteRepository);
            var cliente = new Cliente { Identificacion = "12345" };

            // Act
            bool result = clienteService.ValidBeforeInsert(cliente);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void When_ClientIdentificationIsEmpty_ReturnFalse()
        {
            // Arrange
            var clienteService = new ClienteService(_repository, _clienteRepository);
            var cliente = new Cliente { Identificacion = "" };

            // Act
            bool result = clienteService.ValidBeforeInsert(cliente);

            // Assert
            Assert.False(result);
        }
    }
}
