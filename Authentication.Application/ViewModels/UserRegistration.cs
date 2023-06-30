using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Authentication.Application.ViewModels
{
    public class UserRegistration
    {
        public UserRegistration()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            UserName = string.Empty;
            Password = string.Empty;
            Email = string.Empty;
            DocumentNumber = string.Empty;
        }

        [Required(ErrorMessage = "Por favor, informe o nome do usuário.")]
        [JsonPropertyName("nome")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Por favor, informe o sobrenome do usuário.")]
        [JsonPropertyName("sobrenome")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Por favor, informe o usuario.")]
        [JsonPropertyName("usuario")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Por favor, informe a senha.")]
        [JsonPropertyName("senha")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Por favor, informe o email.")]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Por favor, informe o CPF do usuário.")]
        [JsonPropertyName("cpf")]
        public string DocumentNumber { get; set; }

        [Required(ErrorMessage = "Por favor, informe o tipo de usuário.")]
        [JsonPropertyName("tipo_usuario")]
        public EUserType UserType { get; set; }
    }
}
