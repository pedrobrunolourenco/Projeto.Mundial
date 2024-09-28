using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Projeto.Mundial.Application.Models
{
    public class UsuarioResult
    {
        public UsuarioResult()
        {
            ListaErros = new List<string>();
        }

        public int Id { get; set; }


        public int IdPerfil { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        [IgnoreDataMember]
        [JsonIgnore]
        public List<string> ListaErros { get; set; }
    }
}
