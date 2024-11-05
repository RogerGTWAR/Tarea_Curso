using AutoMapper;
using Gestor_Api.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SharedModels.Dto.EmpleadosDatos;
using Gestor_Api.Fliters;

namespace Gestor_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly IEmpleadosRepository _empleadoRepo;
        private readonly ILogger<EmpleadosController> _logger;
        private readonly IMapper _mapper;

        public EmpleadosController(IEmpleadosRepository empleadoRepo, ILogger<EmpleadosController> logger, IMapper mapper)
        {
            _empleadoRepo = empleadoRepo;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [MyLoggingAsync("AllEmpleados")]
        [MyLogging("AllEmpleados")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<EmpleadosDto>>> GetEmpleados()
        {
            try
            {
                _logger.LogInformation("Obteniendo los empleados");

                var empleados = await _empleadoRepo.GetAllAsync();

                return Ok(_mapper.Map<IEnumerable<EmpleadosDto>>(empleados));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener los empleados: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error interno del servidor al obtener los empleados");
            }
        }

        [HttpGet("{id}")]
        [MyLoggingAsync("GetSingleEmpleados")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<EmpleadosDto>> GetEmpleado(int id)
        {
            if (id <= 0)
            {
                _logger.LogError($"ID de empleado no válido: {id}");
                return BadRequest("ID de empleado no válido");
            }

            try
            {
                _logger.LogInformation($"Obteniendo empleado con ID: {id}");

                var empleado = await _empleadoRepo.GetByIdAsync(id);

                if (empleado == null)
                {
                    _logger.LogWarning($"No se encontró ningún empleado con ID: {id}");
                    return NotFound("Empleado no encontrado.");
                }

                return Ok(_mapper.Map<EmpleadosDto>(empleado));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener empleado con ID {id}: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error interno del servidor al obtener el empleado.");
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<EmpleadosDto>> PostEmpleado(EmpleadosCreateDto createDto)
        {
            if (createDto == null)
            {
                _logger.LogError("Se recibió un empleado nulo en la solicitud.");
                return BadRequest("El empleado no puede ser nulo.");
            }

            try
            {
                _logger.LogInformation($"Creando un nuevo empleado con nombre: {createDto.PrimerNombre}");

                var existingEmpleado = await _empleadoRepo.GetAsync(e => e.PrimerNombre != null && e.PrimerNombre.ToLower() == createDto.PrimerNombre.ToLower());

                if (existingEmpleado != null)
                {
                    _logger.LogWarning($"El empleado con nombre '{createDto.PrimerNombre}' ya existe.");
                    ModelState.AddModelError("NombreExiste", "¡El empleado con ese nombre ya existe!");
                    return BadRequest(ModelState);
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("El modelo de empleado no es válido.");
                    return BadRequest(ModelState);
                }

                var newEmpleado = _mapper.Map<EmpleadoDatos>(createDto);

                await _empleadoRepo.CreateAsync(newEmpleado);

                _logger.LogInformation($"Nuevo empleado '{createDto.PrimerNombre}' creado con ID: {newEmpleado.Empleado_Id}");
                return CreatedAtAction(nameof(GetEmpleado), new { id = newEmpleado.Empleado_Id }, newEmpleado);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear un nuevo empleado: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error interno del servidor al crear un nuevo empleado.");
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutEmpleado(int id, EmpleadosUpdateDto updateDto)
        {
            if (updateDto == null || id != updateDto.Empleado_Id)
            {
                return BadRequest("Los datos de entrada no son válidos o el ID del empleado no coincide.");
            }

            try
            {
                _logger.LogInformation($"Actualizando empleado con ID: {id}");

                var existingEmpleado = await _empleadoRepo.GetByIdAsync(id);
                if (existingEmpleado == null)
                {
                    _logger.LogWarning($"No se encontró ningún empleado con ID: {id}");
                    return NotFound("El empleado no existe.");
                }

                _mapper.Map(updateDto, existingEmpleado);

                await _empleadoRepo.SaveChangesAsync();

                _logger.LogInformation($"Empleado con ID {id} actualizado correctamente.");
                return NoContent();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!await _empleadoRepo.ExistsAsync(e => e.Empleado_Id == id))
                {
                    _logger.LogWarning($"No se encontró ningún empleado con ID: {id}");
                    return NotFound("El empleado no se encontró durante la actualización.");
                }
                else
                {
                    _logger.LogError($"Error de concurrencia al actualizar el empleado con ID: {id}. Detalles: {ex.Message}");
                    return StatusCode(StatusCodes.Status500InternalServerError,
                        "Error interno del servidor al actualizar el empleado.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar el empleado con ID {id}: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error interno del servidor al actualizar el empleado.");
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteEmpleado(int id)
        {
            try
            {
                _logger.LogInformation($"Eliminando empleado con ID: {id}");

                var empleado = await _empleadoRepo.GetByIdAsync(id);
                if (empleado == null)
                {
                    _logger.LogWarning($"No se encontró ningún empleado con ID: {id}");
                    return NotFound("Empleado no encontrado.");
                }

                await _empleadoRepo.DeleteAsync(empleado);

                _logger.LogInformation($"Empleado con ID {id} eliminado correctamente.");
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar el empleado con ID {id}: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Se produjo un error al eliminar el empleado.");
            }
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PatchEmpleado(int id, JsonPatchDocument<EmpleadosUpdateDto> patchDto)
        {
            if (id <= 0)
            {
                return BadRequest("ID de empleado no válido.");
            }

            try
            {
                _logger.LogInformation($"Aplicando el parche al empleado con ID: {id}");

                var empleado = await _empleadoRepo.GetByIdAsync(id);
                if (empleado == null)
                {
                    _logger.LogWarning($"No se encontró ningún empleado con ID: {id}");
                    return NotFound("El empleado no se encontró");
                }

                var empleadoDto = _mapper.Map<EmpleadosUpdateDto>(empleado);

                patchDto.ApplyTo(empleadoDto, ModelState);

                if (!ModelState.IsValid)
                {
                    _logger.LogError("El modelo de empleado después de aplicar el parche no es válido");
                    return BadRequest(ModelState);
                }

                _mapper.Map(empleadoDto, empleado);

                using (var transaction = await _empleadoRepo.BeginTransactionAsync())
                {
                    try
                    {
                        await _empleadoRepo.SaveChangesAsync();
                        transaction.Commit();
                        _logger.LogInformation($"Parche aplicado correctamente al empleado con ID: {id}");
                        return NoContent();
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        if (!await _empleadoRepo.ExistsAsync(e => e.Empleado_Id == id))
                        {
                            _logger.LogWarning($"No se encontró ningún empleado con ID: {id}");
                            return NotFound();
                        }
                        else
                        {
                            _logger.LogError($"Error de concurrencia al aplicar el parche al empleado con ID: {id}. Detalles: {ex.Message}");
                            return StatusCode(StatusCodes.Status500InternalServerError,
                                "Error interno del servidor al aplicar el parche al empleado.");
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError($"Error al aplicar el parche al empleado con ID {id}: {ex.Message}");
                        transaction.Rollback();
                        return StatusCode(StatusCodes.Status500InternalServerError,
                            "Error interno del servidor al aplicar el parche al empleado.");
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al aplicar el parche al empleado con ID {id}: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error interno del servidor al aplicar el parche al empleado.");
            }
        }
    }
}
