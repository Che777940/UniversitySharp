using IIS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace IIS.Domain.Entities.Structure
{
    public class Faculty : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string ShortName { get; set; } = string.Empty;

        public ICollection<Department> Departments { get; set; } = new List<Department>();

    }
}
