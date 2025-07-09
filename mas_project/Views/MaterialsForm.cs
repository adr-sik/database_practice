using mas_project.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using mas_project.Data;
using mas_project.Models;

namespace mas_project.Views
{
    public partial class MaterialsForm : Form
    {
        private readonly MaterialRepository _materialRepository;
        public MaterialsForm(Device device)
        {
            _materialRepository = new MaterialRepository(new ProjectContext());
            InitializeComponent();
            PopulateGrid(device);
        }

        public void PopulateGrid(Device device)
        {
            //var materials = _materialRepository.GetMaterialsByDevice(device);
            var materials = device.Materials.ToList();
            dataGridView1.DataSource = materials;
            dataGridView1.Columns.Remove(dataGridView1.Columns["Devices"]);
        }
    }
}
