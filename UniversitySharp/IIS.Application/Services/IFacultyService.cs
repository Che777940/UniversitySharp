using IIS.Application.DTOs;
using IIS.Domain.Entities.Structure;
using System;
using System.Collections.Generic;
using System.Text;

namespace IIS.Application.Services
{
    public interface IFacultyService
    {
        Task<List<Faculty>> GetAllAsync();
        Task<FacultyDetailsDto?> GetDetailsAsync(Guid id);
        Task CreateAsync(CreateFacultyDto dto);
    }
}
