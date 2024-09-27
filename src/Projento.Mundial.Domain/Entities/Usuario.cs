using FluentValidation;
using Projeto.Mundial.Domain.Extensions;

namespace Projeto.Mundial.Domain.Entities
{
    public class Usuario : Entity
    {

        public Usuario()
        {

        }

        public Usuario(int id, int idPerfil, string nome, string email, string senha)
        {
            Id = id;
            IdPerfil = idPerfil;
            Nome = nome;
            Email = email;
            Senha = senha;
            Criacao = DateTime.Now;
        }


        // EF
        public Perfil Perfil { get; set; }

        public int Id { get; private set; }
        public int IdPerfil { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public DateTime Criacao { get; private set; }

        public override bool Validar()
        {
            ValidationResult = new UsuarioValidation().Validate(this);
            foreach (var erro in ValidationResult.Errors)
            {
                ListaErros.Add(erro.ErrorMessage);
            }
            return ValidationResult.IsValid;

        }

        public void AtribuirIdPerfil(int idPerfil)
        {
            IdPerfil = idPerfil;
        }

        public void AtribuirNome(string nome)
        {
            Nome = nome;
        }

        public void AtribuirEmail(string email)
        {
            Email = email;
        }

        public void AtribuirSenha(string senha)
        {
            Senha = senha.Criptografar();
        }

        public class UsuarioValidation : AbstractValidator<Usuario>
        {
            public UsuarioValidation()
            {
                RuleFor(p => p.Id)
                     .NotEqual(0)
                     .WithMessage("Id do usuário não pode ser zero.");

                RuleFor(p => p.IdPerfil)
                     .NotEqual(0)
                     .WithMessage("Id do Perfil não pode ser zero.");

                RuleFor(p => p.Nome)
                    .NotEmpty()
                    .WithMessage("O nome deve ser informado.");

                RuleFor(p => p.Email)
                    .EmailAddress()
                    .WithMessage("Email deve ser válido");

                RuleFor(p => p.Senha)
                    .MinimumLength(3)
                    .WithMessage("O nome deve ter no mínimo 3 caracteres.");
            }

        }
    }
}