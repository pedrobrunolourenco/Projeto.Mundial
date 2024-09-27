﻿using Projento.Mundial.Domain.Interfaces.Repository;
using Projeto.Mundial.Domain.Entities;

namespace Projeto.Mundial.Data.Repositories
{
    public class RepositoryPerfil : Repository<Perfil>, IRepositoryPerfil
    {
        public RepositoryPerfil(DataContext context) : base(context) 
        {
            
        }
    }
}
