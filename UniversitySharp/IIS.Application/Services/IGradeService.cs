using IIS.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace IIS.Application.Services
{
    public interface IGradeService
    {
        Task<List<GradeDto>> GetStudentGradesAsync(Guid studentId);
        Task AddGradeAsync(CreateGradeDto dto);
    }
}
