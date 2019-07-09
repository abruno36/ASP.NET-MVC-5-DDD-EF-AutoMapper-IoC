﻿using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;

namespace ProjetoModeloDDD.Infra.Data.Repositories
{
    //Implementar de IClienteRepository
    //Herdando de RepositoryBase
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository 
    {
    }
}
