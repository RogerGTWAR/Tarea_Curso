using AutoMapper;
using Gestor_Api.Controllers;
using Gestor_Api.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using SharedModels;
using SharedModels.Dto.EmpleadosDatos;

namespace GestorTest
{
    public class EmpleadosControllerTest
    {
        private readonly Mock<IEmpleadosRepository> _mockRepo;
        private readonly Mock<ILogger<EmpleadosController>> _mockLogger;
        private readonly Mock<IMapper> _mockMapper;
        private readonly EmpleadosController _controller;

        public EmpleadosControllerTest()
        {
            _mockRepo = new Mock<IEmpleadosRepository>();
            _mockLogger = new Mock<ILogger<EmpleadosController>>();
            _mockMapper = new Mock<IMapper>();
            _controller = new EmpleadosController(_mockRepo.Object,
                _mockLogger.Object, _mockMapper.Object);
        }
        [Fact]
        public async Task GetEmpleados_ReturnsOkResult_WithListOfEmpleados()
        {
            // Arrange
            var empleados = new List<EmpleadoDatos> {
            new EmpleadoDatos { Empleado_Id = 13, PrimerNombre = "Dominick" } };

            var EmpleadosDtos = new List<EmpleadosDto>
            {
                new EmpleadosDto { Empleado_Id = 13, PrimerNombre = "Dominick" }
            };
            _mockRepo.Setup(repo => repo.GetAllAsync(null)).ReturnsAsync(empleados);
            _mockMapper
                .Setup(mapper =>
                mapper.Map<IEnumerable<EmpleadosDto>>(It.IsAny<IEnumerable<EmpleadoDatos>>()))
                .Returns(EmpleadosDtos);

            // Act
            var result = await _controller.GetEmpleados();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<List<EmpleadosDto>>(okResult.Value);
            Assert.Single(returnValue);
            Assert.Equal("Dominick", returnValue[0].PrimerNombre);
        }

        [Fact]
        public async Task GetEmpleados_ReturnNotFound_WhenStudentNotFound()
        {
            // Arrange
            _mockRepo.Setup(repo => repo.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync((EmpleadoDatos)null);

            // Act
            var result = await _controller.GetEmpleado(1);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);
            Assert.Equal("Empleado no encontrado.", notFoundResult.Value);
        }

        [Fact]
        public async Task GetEmpleado_ReturnsOkResult_WhenStudentFound()
        {
            // Arrange
            var empleado = new EmpleadoDatos { Empleado_Id = 1, PrimerNombre = "Carlos Ríos" };
            var EmpleadoDto = new EmpleadosDto { Empleado_Id = 1, PrimerNombre = "Carlos Ríos" };

            _mockRepo.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(empleado);
            _mockMapper.Setup(mapper => mapper.Map<EmpleadosDto>(It.IsAny<EmpleadoDatos>()))
                .Returns(EmpleadoDto);

            // Act
            var result = await _controller.GetEmpleado(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<EmpleadosDto>(okResult.Value);
            Assert.Equal("Carlos Ríos", returnValue.PrimerNombre);
        }

        [Fact]
        public async Task PostEmpleado_ReturnsBadRequest_WhenModelStateIsInvalid()
        {
            // Arrange
            _controller.ModelState.AddModelError("PrimerNombre", "Required");

            var empleadoCreateDto = new EmpleadosCreateDto { PrimerNombre = "" };

            // Act
            var result = await _controller.PostEmpleado(empleadoCreateDto);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            Assert.IsType<SerializableError>(badRequestResult.Value);
        }



    }
}
