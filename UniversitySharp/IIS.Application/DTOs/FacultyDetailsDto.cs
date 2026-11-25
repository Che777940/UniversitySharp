using IIS.Domain.Entities.Structure;
using System;
using System.Collections.Generic;
using System.Text;

namespace IIS.Application.DTOs
{
    public class FacultyDetailsDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ShortName { get; set; } = string.Empty;
        public List<Department> Departments { get; set; } = new();
    }
}
