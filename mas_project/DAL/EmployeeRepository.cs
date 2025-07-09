using mas_project.Data;
using mas_project.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mas_project.DAL
{
    internal class EmployeeRepository
    {
        private readonly ProjectContext _projectContext;

        public EmployeeRepository(ProjectContext projectContext)
        {
            _projectContext = projectContext;
        }

/*        public async Task<List<Employee>> GetEmployeesByPlayground(int playgroundId)
        {

            var employees = await _projectContext.Employee_Playgrounds
                .Where(ep => ep.PlaygroundId == playgroundId)
                .Select(ep => ep.Employee)
                .ToListAsync();

            return employees;
        }*/
    }
}
