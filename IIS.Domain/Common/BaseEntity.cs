using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace IIS.Domain.Common
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdateAt { get; set; }
    }
}
