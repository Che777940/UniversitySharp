using IIS.Domain.Entities.Structure;
using System;
using System.Collections.Generic;
using System.Text;

namespace IIS.Application.Interfaces
{
    public interface IFacultyRepository
    {
        Task<List<Faculty>> GetAllAsync();
    }
}
