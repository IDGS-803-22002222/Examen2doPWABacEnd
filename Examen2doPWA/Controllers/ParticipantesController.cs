using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Examen2doPWA.Data;
using Examen2doPWA.Models;
using Examen2doPWA.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen2doPWA.Controllers
{
    [ApiController]
    [Route("api")]
    public class ParticipantesController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ILogger<ParticipantesController> _logger;

        public ParticipantesController(AppDbContext context, ILogger<ParticipantesController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/listado
        [HttpGet("listado")]
        public async Task<ActionResult<IEnumerable<Participante>>> GetParticipantes([FromQuery] string? q)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(q))
                {
                    var participantes = await _context.Participantes
                        .OrderByDescending(p => p.FechaRegistro)
                        .ToListAsync();
                    return Ok(participantes);
                }

                var participantesFiltrados = await _context.Participantes
                    .Where(p => p.Nombre.Contains(q) ||
                                p.Apellidos.Contains(q) ||
                                (p.Nombre + " " + p.Apellidos).Contains(q))
                    .OrderByDescending(p => p.FechaRegistro)
                    .ToListAsync();

                return Ok(participantesFiltrados);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener participantes");
                return StatusCode(500, new { message = "Error al obtener los participantes" });
            }
        }

        // GET: api/participante/numerro
        [HttpGet("participante/{id}")]
        public async Task<ActionResult<Participante>> GetParticipante(int id)
        {
            try
            {
                var participante = await _context.Participantes.FindAsync(id);

                if (participante == null)
                {
                    return NotFound(new { message = "Participante no encontrado" });
                }

                return Ok(participante);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener participante");
                return StatusCode(500, new { message = "Error al obtener el participante" });
            }
        }

        // POST: api/registro
        [HttpPost("registro")]
        public async Task<ActionResult<Participante>> RegistrarParticipante(ParticipanteRegistroDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                // Validar que el email no exista
                var existeEmail = await _context.Participantes
                    .AnyAsync(p => p.Email == dto.Email);

                if (existeEmail)
                {
                    return BadRequest(new { message = "El email ya está registrado" });
                }

                var participante = new Participante
                {
                    Nombre = dto.Nombre,
                    Apellidos = dto.Apellidos,
                    Email = dto.Email,
                    UsuarioTwitter = dto.UsuarioTwitter,
                    Ocupacion = dto.Ocupacion,
                    Avatar = string.IsNullOrEmpty(dto.Avatar)
                        ? $"https://i.pravatar.cc/150?img={Random.Shared.Next(1, 70)}"
                        : dto.Avatar,
                    FechaRegistro = DateTime.UtcNow
                };

                _context.Participantes.Add(participante);
                await _context.SaveChangesAsync();

                return CreatedAtAction(
                    nameof(GetParticipante),
                    new { id = participante.Id },
                    participante
                );
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al registrar participante");
                return StatusCode(500, new { message = "Error al registrar el participante" });
            }
        }
    }
}