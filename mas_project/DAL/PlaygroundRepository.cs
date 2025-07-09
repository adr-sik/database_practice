using mas_project.Data;
using mas_project.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mas_project.DAL
{
    public class PlaygroundRepository
    {
        private readonly ProjectContext _projectContext;

        public PlaygroundRepository(ProjectContext projectContext)
        {
            _projectContext = projectContext;
        }

        public async Task<IEnumerable<Playground>> GetAsync()
        {
            return await _projectContext.Playgrounds
                .ToListAsync();
        }

        public async Task<IEnumerable<Playground>> GetPlaygroundsByCompletionDate(DateTime? fromDate, DateTime? toDate)
        {
            IQueryable<Playground> query = _projectContext.Playgrounds;
            if (fromDate.HasValue)
            {
                query = query.Where(p => p.Contract.DateOfCompletionActual >= fromDate.Value);
            }
            if (toDate.HasValue)
            {
                query = query.Where(p => p.Contract.DateOfCompletionActual <= toDate.Value);
            }

            return await query.ToListAsync();
        }
    }
}
