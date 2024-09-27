using FluentValidation.Results;

namespace Projeto.Mundial.Domain.Entities
{
    public abstract class Entity
    {
        public Entity()
        {
            ListaErros = new List<string>();
        }
        public List<string> ListaErros { get; private set; }
        public ValidationResult ValidationResult { get; set; }
        public abstract bool Validar();
    }
}
