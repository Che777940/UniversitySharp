using IIS.Application.DTOs;
using IIS.Domain.Entities.Structure;
using System;
using System.Collections.Generic;
using System.Text;

namespace IIS.Application.Services
{
    public interface IDepartmentService
    {
        Task<List<Department>> GetAllAsync();
        Task CreateAsync(CreateDepartmentDto dto);
    }
}
