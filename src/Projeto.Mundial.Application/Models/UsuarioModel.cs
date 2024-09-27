using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Projeto.Mundial.Application.Models
{
    public class UsuarioModel
    {
        public UsuarioModel()
        {
            ListaErros = new List<string>();
        }

        [Required(ErrorMessage = "Necessário informar Id do Usuário")]
        public int Id { get; set; }


        [Required(ErrorMessage = "Necessário informar Id do Perfil")]
        public int IdPerfil { get; set; }

        [Required(ErrorMessage = "Necessário informar nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Necessário informar Email")]
        [EmailAddress(ErrorMessage = "O campo Email não contém um endereço de email válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Necessário informar Senha")]
        public string Senha { get; private set; }

        [IgnoreDataMember]
        [JsonIgnore]
        public List<string> ListaErros { get; set; }
    }
}
