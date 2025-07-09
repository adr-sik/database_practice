using mas_project.Data;
using mas_project.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mas_project.DAL
{
    internal class SlideRepository : DeviceRepository<Slide>
    {
        private readonly ProjectContext _projectContext;

        public SlideRepository(ProjectContext projectContext) : base(projectContext)
        {
        }

       
    }
}
