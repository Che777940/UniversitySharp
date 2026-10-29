using IIS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace IIS.Domain.Entities.Academics
{
    public class Subject : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public int Credits { get; set; }

        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
