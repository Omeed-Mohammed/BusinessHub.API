using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Contracts.Projects.DTOs
{
    public class ProjectStatusDto
    {
        public int StatusID { get; set; }

        public string Name { get; set; }

        public ProjectStatusDto(
            int statusID,
            string name)
        {
            StatusID = statusID;
            Name = name;
        }
    }
}
