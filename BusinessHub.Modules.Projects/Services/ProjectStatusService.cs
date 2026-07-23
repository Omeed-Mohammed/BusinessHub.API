using BusinessHub.Contracts.Projects.DTOs;
using BusinessHub.Contracts.Projects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Modules.Projects.Services
{
    public class ProjectStatusService
    {
        private readonly IProjectStatusRepository _repo;

        public ProjectStatusService(IProjectStatusRepository repo)
        {
            _repo = repo;
        }

        public List<ProjectStatusDto> GetAllProjectStatus()
        {
            return _repo.GetAllProjectStatus() ?? new List<ProjectStatusDto>();
        }
    }
}
