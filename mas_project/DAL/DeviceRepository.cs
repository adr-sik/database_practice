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
    public abstract class DeviceRepository<T> where T : Device
    {
        private readonly ProjectContext _projectContext;

        public DeviceRepository(ProjectContext projectContext)
        {
            _projectContext = projectContext;
        }

        public async Task<IEnumerable<T>> GetAsync()
        {
            return await _projectContext.Devices
                .OfType<T>()
                .ToListAsync();
        }

/*        public async Task<List<string>> GetImagesAsync(int deviceId)
        {
            return await _projectContext.Images
                .Where(i => i.DeviceId == deviceId)
                .Select(image => image.URL)
                .ToListAsync();
        }*/

        public async Task AddDeviceAsync(Device device, List<Material> materialIds)
        {
            using (var transaction = await _projectContext.Database.BeginTransactionAsync())
            {
                try
                {
                    _projectContext.Devices.Add(device);
                    await _projectContext.SaveChangesAsync();

                    foreach (var materialId in materialIds)
                    {
                        var deviceMaterial = AssignMaterial(materialId.MaterialId, device.CatalogNumber);
                        _projectContext.Device_Materials.Add(deviceMaterial);
                        await _projectContext.SaveChangesAsync();
                    }

                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    MessageBox.Show(ex.ToString());
                    throw;
                }
            }
        }

        private Device_Material AssignMaterial(int materialId, int deviceId)
        {
            Device_Material dm = new Device_Material { MaterialId = materialId, DeviceId = deviceId };
            return dm;
        }
    }
}
