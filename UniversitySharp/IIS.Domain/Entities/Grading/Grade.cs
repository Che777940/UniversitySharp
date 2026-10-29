using IIS.Domain.Common;
using IIS.Domain.Entities.Academics;
using IIS.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace IIS.Domain.Entities.Grading
{
    public class Grade : BaseEntity
    {
        public Guid StudentId { get; set; }
        public Guid CourseId {  get; set; }
        public int Value { get; set; }

        public DateTime Date { get; set; }
        public string? Comment { get; set; }

        public Student Student { get; set; } = null!;
        public Course Course { get; set; } = null!;
    }
}
