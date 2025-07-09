using Elfie.Serialization;
using mas_project.Models;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace mas_project.Views
{
    public partial class ImageForm : Form
    {
        private List<DeviceImage> _images;
        int index = 0;
        public ImageForm(List<DeviceImage> images)
        {
            _images = images;
            InitializeComponent();
            LoadImage();
        }

        private void LoadImage()
        {
            if (index == _images.Count)
            {
                index = 0;
            }

            string relativePath = $"..\\{_images[index].URL}";
            string fullPath = Path.GetFullPath(relativePath);
            pictureBox1.ImageLocation = fullPath;

            index++;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            LoadImage();
        }
    }
}
