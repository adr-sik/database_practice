using mas_project.Data;
using mas_project.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace mas_project.DAL
{
    internal class MaterialRepository
    {
        private readonly ProjectContext _projectContext;

        public MaterialRepository(ProjectContext projectContext)
        {
            _projectContext = projectContext;
        }

        public List<Material> GetMaterialsByDevice(Device device)
        {
            if (device.Materials == null)
            {
                return new List<Material>();
            }
            var materials = device.Materials.ToList();

            return materials;
        }

        public async Task<Material> GetMaterialIdByName(string name)
        {
            var material = await _projectContext.Materials
                .Where(m => m.Name == name)
                .FirstOrDefaultAsync();

            return material;
        }
    }
}
