using System;
using System.Collections.Generic;
using System.Text;
using IIS.Domain.Entities.Structure;

namespace IIS.Application.Interfaces
{
    public interface IGroupRepository
    {
        Task<List<Group>> GetAllAsync();
        Task AddAsync(Group group);
    }
}
