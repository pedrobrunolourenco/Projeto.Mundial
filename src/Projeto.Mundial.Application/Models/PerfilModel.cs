using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Projeto.Mundial.Application.Models
{
    public class PerfilModel
    {

        public PerfilModel()
        {
            ListaErros = new List<string>();
        }

        [Required(ErrorMessage = "Necessário informar Id do Perfil")]
        public int IdPerfil { get; set; }

        [Required(ErrorMessage = "Necessário informar nome")]
        public string Nome { get; set; }

        [IgnoreDataMember]
        [JsonIgnore]
        public List<string> ListaErros { get; set; }
    }

}
