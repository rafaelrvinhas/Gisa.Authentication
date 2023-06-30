using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Authentication.Application.ViewModels
{
    public class UserLogin
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Por favor, informe o email para efetuar o login.")]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Por favor, informe a senha.")]
        [JsonPropertyName("senha")]
        public string Password { get; set; }
    }
}
