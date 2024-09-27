using FluentValidation;

namespace Projeto.Mundial.Domain.Entities
{
    public class Perfil : Entity
    {
        public Perfil()
        {

        }

        public Perfil(int idPefil, string nome)
        {
            IdPerfil = idPefil;
            Nome = nome;
            Criacao = DateTime.Now;
        }

        public int IdPerfil { get; private set; }
        public string Nome { get; private set; }
        public DateTime Criacao { get; private set; }

        // Relacionamento
        public List<Usuario> Usuarios { get; private set; }



        public void AtribuirNome(string nome)
        {
            Nome = nome;
        }

        public void AtribuirCriacao()
        {
            Criacao = DateTime.Now;
        }

        public override bool Validar()
        {
            ValidationResult = new PerfilValidation().Validate(this);
            foreach (var erro in ValidationResult.Errors)
            {
                ListaErros.Add(erro.ErrorMessage);
            }
            return ValidationResult.IsValid;
        }

        public class PerfilValidation : AbstractValidator<Perfil>
        {
            public PerfilValidation()
            {
                RuleFor(t => t.IdPerfil)
                     .NotEqual(0)
                     .WithMessage("Id do perfil não pode ser zero.");

                RuleFor(t => t.Nome)
                    .MinimumLength(3)
                    .WithMessage("Informe o nome do perfil com no mínimo 3 caracteres.");

            }
        }
    }
}
