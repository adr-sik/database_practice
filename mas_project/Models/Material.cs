using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    namespace mas_project.Models
    {
        public class Material
        {
            public int MaterialId { get; set; }
            public string Name { get; set; } = null!;
            public virtual ICollection<Device>? Devices { get; set; }
        }
    }
