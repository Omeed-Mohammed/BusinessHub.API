using BusinessHub.Contracts.Projects.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Contracts.Projects.Interfaces
{
    public interface IProjectEmployeeRepository
    {
        int AddProjectEmployee(ProjectEmployeeDto projectEmployee, string currentUser);

        bool UpdateProjectEmployee(ProjectEmployeeDto projectEmployee, string currentUser);

        ProjectEmployeeDto? GetProjectEmployeeByID(int projectEmployeeID);

        List<ProjectEmployeeDto> GetProjectEmployeeByEmployeeID(int employeeID);

        List<ProjectEmployeeDto> GetProjectEmployeesByProjectID(int projectID);

        bool DeactivateProjectEmployee(int projectEmployeeID);

        bool ReactivateProjectEmployee(int projectEmployeeID);
    }
}
