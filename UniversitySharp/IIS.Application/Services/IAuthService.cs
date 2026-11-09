using IIS.Application.DTOs;
using IIS.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace IIS.Application.Services
{
    public interface IAuthService
    {
        Task<User?> LoginAsync(LoginDto dto);
        Task RegisterStudentAsync(RegisterStudentDto dto);
        Task RegisterTeacherAsync(RegisterTeacherDto dto);
    }
}
