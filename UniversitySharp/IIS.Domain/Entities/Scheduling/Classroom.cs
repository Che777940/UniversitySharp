using IIS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace IIS.Domain.Entities.Scheduling
{
    public class Classroom : BaseEntity
    {
        public string Number { get; set; } = string.Empty;
        public string Building {  get; set; } = string.Empty;
        public int Capacity { get; set; }

        public ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
    }
}
