using System;
using System.Collections.Generic;
using System.Text;

namespace IIS.Application.DTOs
{
    public class CreateSubjectDto
    {
        public string Name { get; set; } = string.Empty;
        public int Credits { get; set; }
    }
}
