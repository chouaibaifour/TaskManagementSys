using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ProjectModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public ProjectModel()
        {
            Id = null;
            Name = string.Empty;
        }
    }
}
