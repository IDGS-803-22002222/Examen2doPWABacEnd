using System.ComponentModel.DataAnnotations;

namespace Examen2doPWA.DTOs
{
    public class ParticipanteRegistroDto
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "Los apellidos son obligatorios")]
        public string Apellidos { get; set; } = string.Empty;

        [Required(ErrorMessage = "El email es obligatorio")]
        [EmailAddress(ErrorMessage = "Email no válido")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "El usuario de Twitter es obligatorio")]
        public string UsuarioTwitter { get; set; } = string.Empty;

        [Required(ErrorMessage = "La ocupación es obligatoria")]
        public string Ocupacion { get; set; } = string.Empty;

        public string Avatar { get; set; } = string.Empty;
    }
}
