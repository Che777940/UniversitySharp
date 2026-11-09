using IIS.Application.DTOs;
using IIS.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace IIS.Application.Services
{
    public interface ITeacherService
    {
        Task<List<Teacher>> GetAllAsync();
        Task CreateAsync(CreateTeacherDto dto);
    }
}
