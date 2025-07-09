using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mas_project.Models
{
    public class Device_Material
    {
        public int MaterialId { get; set; }
        public int DeviceId { get; set; }
    }
}
