using mas_project.Data;
using mas_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mas_project.DAL
{
    internal class SwingRepository : DeviceRepository<Swing>
    {
        private readonly ProjectContext _projectContext;

        public SwingRepository(ProjectContext projectContext) : base(projectContext)
        {
        }

    }
}
