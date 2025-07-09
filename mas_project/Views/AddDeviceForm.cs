using mas_project.DAL;
using mas_project.Data;
using mas_project.Models;
using mas_project.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebPages;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace mas_project.Views
{
    public partial class AddDeviceForm : Form
    {
        private readonly SlideRepository _slideRepository;
        private readonly SwingRepository _swingRepository;
        private readonly MaterialRepository _materialRepository;

        public AddDeviceForm()
        {
            _slideRepository = new SlideRepository(new ProjectContext());
            _swingRepository = new SwingRepository(new ProjectContext());
            _materialRepository = new MaterialRepository(new ProjectContext());
            InitializeComponent();
            customPanel.Hide();
        }

        private async void addButton_Click(object sender, EventArgs e)
        {
            ResetErrorMessages();

            if (!CheckBoxesValid())
            {
                return;
            }

            if (Int32.Parse(maxAgeTextBox.Text) < Int32.Parse(minAgeTextBox.Text))
            {
                maxAgeErrorLabel.Visible = true;
                return;
            }

            List<Material> materialList = new List<Material>();
            foreach (var checkedItem in checkedListBox1.CheckedItems)
            {
                var material = await _materialRepository.GetMaterialIdByName(checkedItem.ToString());
                materialList.Add(material);
            }

            if (typeComboBox.Text == "Slide")
            {
                Slide slideAdd = CreateSlide
                    (
                    nameTextBox.Text,
                    securityCertificateTextBox.Text,
                    "materialList",
                    int.Parse(minAgeTextBox.Text),
                    int.Parse(maxAgeTextBox.Text),
                    (Substrate)Enum.Parse(typeof(Substrate), substrateComboBox.Text),
                    decimal.Parse(customTextBox1.Text),
                    decimal.Parse(customTextBox2.Text)
                    );
                await _slideRepository.AddDeviceAsync(slideAdd, materialList);
            }
            else
            {
                Swing swingAdd = CreateSwing
                    (
                    nameTextBox.Text,
                    securityCertificateTextBox.Text,
                    "materialList",
                    int.Parse(minAgeTextBox.Text),
                    int.Parse(maxAgeTextBox.Text),
                    (Substrate)Enum.Parse(typeof(Substrate), substrateComboBox.Text),
                    decimal.Parse(customTextBox1.Text)
                    );
                await _swingRepository.AddDeviceAsync(swingAdd, materialList);
            }
            MessageBox.Show("Device added.");
        }

        private Slide CreateSlide(string DeviceName, string securityCertificate, string materialList, int minAge, int maxAge, Util.Substrate substrate, decimal lengthOfExit, decimal angleOfFall)
        {
            Slide slide = new Slide
            {
                Name = DeviceName,
                SecurityCertificate = securityCertificate,
                MinAge = minAge,
                MaxAge = maxAge,
                Substrate = substrate,
                lengthOfExit = lengthOfExit,
                angleOfFall = angleOfFall
            };

            return slide;
        }

        private Swing CreateSwing(string DeviceName, string securityCertificate, string materialList, int minAge, int maxAge, Util.Substrate substrate, decimal ropeLength)
        {
            Swing swing = new Swing
            {
                Name = DeviceName,
                SecurityCertificate = securityCertificate,
                MinAge = minAge,
                MaxAge = maxAge,
                Substrate = substrate,
                RopeLength = ropeLength
            };

            return swing;
        }

        private bool CheckBoxesValid()
        {
            bool allValid = true;
            if (string.IsNullOrEmpty(nameTextBox.Text))
            {
                allValid = false;
                nameErrorLabel.Visible = true;
            }
            if (!int.TryParse(minAgeTextBox.Text, out int intResult1))
            {
                allValid = false;
                minAgeErrorLabel.Visible = true;
            }
            if (!int.TryParse(maxAgeTextBox.Text, out int intResult2))
            {
                allValid = false;
                maxAgeErrorLabel.Visible = true;
            }
            if (string.IsNullOrEmpty(securityCertificateTextBox.Text))
            {
                allValid = false;
                securityCertificateErrorLabel.Visible = true;   
            }
            if (typeComboBox.Text.IsEmpty())
            {
                allValid = false;
                typeErrorLabel.Visible = true;
            }
            if (substrateComboBox.Text.IsEmpty())
            {
                allValid = false;
                substrateErrorLabel.Visible = true;
            }
            if (checkedListBox1.CheckedItems.Count == 0)
            {
                allValid = false;
                materialErrorLabel.Visible = true;
            }

            if (typeComboBox.Text == "Slide")
            {
                if (!decimal.TryParse(customTextBox1.Text, out decimal decimalResult1))
                {
                    allValid = false;
                    customErrorLabel1.Visible = true;
                }
                if (!decimal.TryParse(customTextBox2.Text, out decimal decimalResult2))
                {
                    allValid = false;
                    customErrorLabel2.Visible = true;
                }
            }
            else if (typeComboBox.Text == "Swing")
            {
                if (!decimal.TryParse(customTextBox1.Text, out decimal decimalResult))
                {
                    allValid = false;
                    customErrorLabel1.Visible = true;
                }
            }
            return allValid;
        }

        private void typeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (typeComboBox.Text == "Slide")
            {
                customPanel.Visible = true;
                customLabel1.Text = "Length of exit";
                customLabel2.Text = "Angle of fall";
                customLabel2.Visible = true;
                customTextBox2.Visible = true;
            }
            else
            {
                customPanel.Visible = true;
                customLabel1.Text = "Rope length";
                customLabel2.Visible = false;
                customTextBox2.Visible = false;
                customErrorLabel2.Visible = false;
            }
        }

        private void ResetErrorMessages()
        {
            nameErrorLabel.Visible = false;
            minAgeErrorLabel.Visible = false;
            maxAgeErrorLabel.Visible = false;
            securityCertificateErrorLabel.Visible = false;
            typeErrorLabel.Visible = false;
            substrateErrorLabel.Visible = false;
            materialErrorLabel.Visible = false;
            customErrorLabel1.Visible = false;
            customErrorLabel2.Visible = false;
        }
    }
}
