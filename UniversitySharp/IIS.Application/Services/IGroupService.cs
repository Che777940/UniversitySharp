using IIS.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using IIS.Domain.Entities.Structure;

namespace IIS.Application.Services
{
    public interface IGroupService
    {
        Task<List<Group>> GetAllAsync();
        Task CreateAsync(CreateGroupDto dto);
    }
}
