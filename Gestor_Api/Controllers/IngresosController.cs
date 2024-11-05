using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedModels.Dto.Ingresos;
using SharedModels;
using Gestor_Api.Repository.IRepository;
using Gestor_Api.Repository;

namespace Gestor_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngresosController : ControllerBase
    {
        private readonly IIngresosoRepository _ingresosRepo;
        private readonly ILogger<IngresosController> _logger;
        private readonly IMapper _mapper;

        public IngresosController(IIngresosoRepository ingresosRepo, ILogger<IngresosController> logger, IMapper mapper)
        {
            _ingresosRepo = ingresosRepo;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<IngresosDto>>> GetIngresos()
        {
            try
            {
                _logger.LogInformation("Obteniendo los ingresos");

                var ingresos = await _ingresosRepo.GetAllAsync();

                return Ok(_mapper.Map<IEnumerable<IngresosDto>>(ingresos));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener los ingresos: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error interno del servidor al obtener los ingresos");
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IngresosDto>> GetIngreso(int id)
        {
            if (id <= 0)
            {
                _logger.LogError($"ID de ingreso no válido: {id}");
                return BadRequest("ID de ingreso no válido");
            }

            try
            {
                _logger.LogInformation($"Obteniendo ingreso con ID: {id}");

                var ingreso = await _ingresosRepo.GetByIdAsync(id);

                if (ingreso == null)
                {
                    _logger.LogWarning($"No se encontró ningún ingreso con ID: {id}");
                    return NotFound("Ingreso no encontrado.");
                }

                return Ok(_mapper.Map<IngresosDto>(ingreso));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener ingreso con ID {id}: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error interno del servidor al obtener el ingreso.");
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IngresosDto>> PostIngreso(IngresosCreateDto createDto)
        {
            if (createDto == null)
            {
                _logger.LogError("Se recibió un ingreso nulo en la solicitud.");
                return BadRequest("El ingreso no puede ser nulo.");
            }

            try
            {
                _logger.LogInformation($"Creando un nuevo ingreso con descripción: {createDto.Empleado_Id}");

                var newIngreso = _mapper.Map<Ingresos>(createDto);

                await _ingresosRepo.CreateAsync(newIngreso);

                _logger.LogInformation($"Nuevo ingreso '{createDto.Empleado_Id}' creado con ID: {newIngreso.Empleado_Id}");
                return CreatedAtAction(nameof(GetIngreso), new { id = newIngreso.Empleado_Id }, _mapper.Map<IngresosDto>(newIngreso));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear un nuevo ingreso: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error interno del servidor al crear un nuevo ingreso.");
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutIngreso(int id, IngresosUpdateDto updateDto)
        {
            if (updateDto == null || id != updateDto.Ingresos_Id)
            {
                return BadRequest("Los datos de entrada no son válidos o el ID del ingreso no coincide.");
            }

            try
            {
                _logger.LogInformation($"Actualizando ingreso con ID: {id}");

                var existingIngreso = await _ingresosRepo.GetByIdAsync(id);
                if (existingIngreso == null)
                {
                    _logger.LogWarning($"No se encontró ningún ingreso con ID: {id}");
                    return NotFound("El ingreso no existe.");
                }

                _mapper.Map(updateDto, existingIngreso);

                await _ingresosRepo.SaveChangesAsync();

                _logger.LogInformation($"Ingreso con ID {id} actualizado correctamente.");
                return NoContent();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!await _ingresosRepo.ExistsAsync(e => e.Ingresos_Id == id))
                {
                    _logger.LogWarning($"No se encontró ningún ingreso con ID: {id}");
                    return NotFound("El ingreso no se encontró durante la actualización.");
                }
                else
                {
                    _logger.LogError($"Error de concurrencia al actualizar el ingreso con ID: {id}. Detalles: {ex.Message}");
                    return StatusCode(StatusCodes.Status500InternalServerError,
                        "Error interno del servidor al actualizar el ingreso.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar el ingreso con ID {id}: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error interno del servidor al actualizar el ingreso.");
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteIngreso(int id)
        {
            try
            {
                _logger.LogInformation($"Eliminando ingreso con ID: {id}");

                var ingreso = await _ingresosRepo.GetByIdAsync(id);
                if (ingreso == null)
                {
                    _logger.LogWarning($"No se encontró ningún ingreso con ID: {id}");
                    return NotFound("Ingreso no encontrado.");
                }

                await _ingresosRepo.DeleteAsync(ingreso);

                _logger.LogInformation($"Ingreso con ID {id} eliminado correctamente.");
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar el ingreso con ID {id}: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Se produjo un error al eliminar el ingreso.");
            }
        }
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PatchIngreso(int id, JsonPatchDocument<IngresosUpdateDto> patchDto)
        {
            if (id <= 0)
            {
                return BadRequest("ID de ingreso no válido.");
            }

            try
            {
                _logger.LogInformation($"Aplicando el parche al ingreso con ID: {id}");

                var ingreso = await _ingresosRepo.GetByIdAsync(id);
                if (ingreso == null)
                {
                    _logger.LogWarning($"No se encontró ningún ingreso con ID: {id}");
                    return NotFound("El ingreso no se encontró");
                }

                var ingresoDto = _mapper.Map<IngresosUpdateDto>(ingreso);

                patchDto.ApplyTo(ingresoDto, ModelState);

                if (!ModelState.IsValid)
                {
                    _logger.LogError("El modelo de ingreso después de aplicar el parche no es válido");
                    return BadRequest(ModelState);
                }

                _mapper.Map(ingresoDto, ingreso);

                using (var transaction = await _ingresosRepo.BeginTransactionAsync())
                {
                    try
                    {
                        await _ingresosRepo.SaveChangesAsync();
                        transaction.Commit();
                        _logger.LogInformation($"Parche aplicado correctamente al ingreso con ID: {id}");
                        return NoContent();
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        if (!await _ingresosRepo.ExistsAsync(e => e.Ingresos_Id == id))
                        {
                            _logger.LogWarning($"No se encontró ningún ingreso con ID: {id}");
                            return NotFound();
                        }
                        else
                        {
                            _logger.LogError($"Error de concurrencia al aplicar el parche al ingreso con ID: {id}. Detalles: {ex.Message}");
                            return StatusCode(StatusCodes.Status500InternalServerError,
                                "Error interno del servidor al aplicar el parche al ingreso.");
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError($"Error al aplicar el parche al ingreso con ID {id}: {ex.Message}");
                        transaction.Rollback();
                        return StatusCode(StatusCodes.Status500InternalServerError,
                            "Error interno del servidor al aplicar el parche al ingreso.");
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al aplicar el parche al ingreso con ID {id}: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error interno del servidor al aplicar el parche al empleado.");
            }
        }
    }
}
