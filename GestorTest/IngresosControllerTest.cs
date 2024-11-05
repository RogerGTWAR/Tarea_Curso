using AutoMapper;
using Gestor_Api.Controllers;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using SharedModels.Dto.Ingresos;
using SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestor_Api.Repository.IRepository;
using SharedModels.Dto.EmpleadosDatos;

namespace GestorTest
{
    //Revisar
    public class IngresosControllerTest
    {
        private readonly Mock<IIngresosoRepository> _mockRepo;
        private readonly Mock<ILogger<IngresosController>> _mockLogger;
        private readonly Mock<IMapper> _mockMapper;
        private readonly IngresosController _controller;

        public IngresosControllerTest()
        {
            _mockRepo = new Mock<IIngresosoRepository>();
            _mockLogger = new Mock<ILogger<IngresosController>>();
            _mockMapper = new Mock<IMapper>();
            _controller = new IngresosController(_mockRepo.Object,
                _mockLogger.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task GetIngresos_ReturnsOkResult_WithListOfIngresos()
        {
            // Arrange
            var ingresos = new List<Ingresos> {
                new Ingresos { Ingresos_Id = 1, PrimerNombre = "Ingreso 1" },
                new Ingresos { Ingresos_Id = 2, PrimerNombre = "Ingreso 2" }
            };

            var ingresosDto = new List<IngresosDto>
            {
                new IngresosDto { Ingresos_Id = 1, PrimerNombre = "Ingreso 1" },
                new IngresosDto { Ingresos_Id = 2, PrimerNombre = "Ingreso 2" }
            };

            _mockRepo.Setup(repo => repo.GetAllAsync(null)).ReturnsAsync(ingresos);
            _mockMapper
                .Setup(mapper => mapper.Map<IEnumerable<IngresosDto>>(It.IsAny<IEnumerable<Ingresos>>()))
                .Returns(ingresosDto);

            // Act
            var result = await _controller.GetIngresos();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<List<IngresosDto>>(okResult.Value);
            Assert.Equal(2, returnValue.Count);
            Assert.Equal("Ingreso 1", returnValue[0].PrimerNombre);
            Assert.Equal("Ingreso 2", returnValue[1].PrimerNombre);
        }

        [Fact]
        public async Task GetIngreso_ReturnNotFound_WhenIngresoNotFound()
        {
            // Arrange
            _mockRepo.Setup(repo => repo.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync((Ingresos)null);

            // Act
            var result = await _controller.GetIngreso(1);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);
            Assert.Equal("Ingreso no encontrado.", notFoundResult.Value);
        }

        [Fact]
        public async Task GetIngreso_ReturnsOkResult_WhenIngresoFound()
        {
            // Arrange
            var ingreso = new Ingresos { Ingresos_Id = 1, PrimerNombre = "Ingreso 1" };
            var ingresoDto = new IngresosDto { Ingresos_Id = 1, PrimerNombre = "Ingreso 1" };

            _mockRepo.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(ingreso);
            _mockMapper.Setup(mapper => mapper.Map<IngresosDto>(It.IsAny<Ingresos>()))
                .Returns(ingresoDto);

            // Act
            var result = await _controller.GetIngreso(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<IngresosDto>(okResult.Value);
            Assert.Equal("Ingreso 1", returnValue.PrimerNombre);
        }
        //Corregir tiene errores


        [Fact]
        public async Task PutIngreso_ReturnsBadRequest_WhenIngresoIdDoesNotMatchDtoId()
        {
            // Arrange
            var ingresoUpdateDto = new IngresosUpdateDto { Ingresos_Id = 1 };
            var result = await _controller.PutIngreso(2, ingresoUpdateDto);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Los datos de entrada no son válidos o el ID del ingreso no coincide.", badRequestResult.Value);
        }

        [Fact]
        public async Task PutIngreso_ReturnsNotFound_WhenIngresoNotFound()
        {
            // Arrange
            var ingresoUpdateDto = new IngresosUpdateDto { Ingresos_Id = 1 };
            _mockRepo.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync((Ingresos)null);

            // Act
            var result = await _controller.PutIngreso(1, ingresoUpdateDto);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal("El ingreso no existe.", notFoundResult.Value);
        }

        [Fact]
        public async Task PutIngreso_ReturnsNoContent_WhenIngresoUpdated()
        {
            // Arrange
            var ingresoUpdateDto = new IngresosUpdateDto { Ingresos_Id = 1, PrimerNombre = "Ingreso Actualizado" };
            var existingIngreso = new Ingresos { Ingresos_Id = 1, PrimerNombre = "Ingreso Original" };

            _mockRepo.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(existingIngreso);

            // Act
            var result = await _controller.PutIngreso(1, ingresoUpdateDto);

            // Assert
            var noContentResult = Assert.IsType<NoContentResult>(result);
            _mockRepo.Verify(repo => repo.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task DeleteIngreso_ReturnsNotFound_WhenIngresoNotFound()
        {
            // Arrange
            _mockRepo.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync((Ingresos)null);

            // Act
            var result = await _controller.DeleteIngreso(1);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal("Ingreso no encontrado.", notFoundResult.Value);
        }

        [Fact]
        public async Task DeleteIngreso_ReturnsNoContent_WhenIngresoDeleted()
        {
            // Arrange
            var existingIngreso = new Ingresos { Ingresos_Id = 1, PrimerNombre = "Ingreso a Eliminar" };
            _mockRepo.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(existingIngreso);

            // Act
            var result = await _controller.DeleteIngreso(1);

            // Assert
            var noContentResult = Assert.IsType<NoContentResult>(result);
            _mockRepo.Verify(repo => repo.DeleteAsync(existingIngreso), Times.Once);
        }

        [Fact]
        public async Task PatchIngreso_ReturnsBadRequest_WhenIngresoIdIsInvalid()
        {
            // Act
            var result = await _controller.PatchIngreso(0, It.IsAny<JsonPatchDocument<IngresosUpdateDto>>());

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("ID de ingreso no válido.", badRequestResult.Value);
        }

        [Fact]
        public async Task PatchIngreso_ReturnsNotFound_WhenIngresoNotFound()
        {
            // Arrange
            _mockRepo.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync((Ingresos)null);

            // Act
            var result = await _controller.PatchIngreso(1, It.IsAny<JsonPatchDocument<IngresosUpdateDto>>());

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal("El ingreso no se encontró", notFoundResult.Value);
        }
    }
}
