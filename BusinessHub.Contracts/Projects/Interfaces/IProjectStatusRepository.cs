using BusinessHub.Contracts.Projects.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Contracts.Projects.Interfaces
{
    public interface IProjectStatusRepository
    {
        List<ProjectStatusDto> GetAllProjectStatus();
    }
}
