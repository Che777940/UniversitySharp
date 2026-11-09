using IIS.Domain.Entities.Scheduling;
using System;
using System.Collections.Generic;
using System.Text;

namespace IIS.Application.Interfaces
{
    public interface IClassroomRepository
    {
        Task<List<Classroom>> GetAllAsync();
        Task AddAsync(Classroom classroom);
    }
}
