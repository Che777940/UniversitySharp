using IIS.Application.DTOs;
using IIS.Domain.Entities.Academics;
using System;
using System.Collections.Generic;
using System.Text;

namespace IIS.Application.Services
{
    public interface ISubjectService
    {
        Task<List<Subject>> GetAllAsync();
        Task CreateAsync(CreateSubjectDto dto);
    }
}
