using mas_project.Data;
using mas_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace mas_project.Controllers
{
    public class PlaygroundController : Controller
    {
        private readonly ProjectContext _context;

        public PlaygroundController(ProjectContext context)
        {
            _context = context;
        }

        public IAsyncResult getPlaygrounds()
        {
            return null;
        }
    }
}
