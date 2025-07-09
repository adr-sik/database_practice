using mas_project.Controllers;
using mas_project.DAL;
using mas_project.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using mas_project.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NuGet.Protocol;
using mas_project.DTO;
using mas_project.Util;

namespace mas_project.Views
{
    public partial class MainForm : Form
    {
        public static string username = "";
        private readonly PlaygroundRepository _playgroundRepository;
        private readonly SlideRepository _slideRepository;
        private readonly SwingRepository _swingRepository;
        private readonly EmployeeRepository _employeeRepository;
        private DateTime fromDate = DateTime.MinValue;
        private DateTime toDate = DateTime.MaxValue;

        private void BasicView()
        {
            addButton.Hide();
            DevicesTab.Hide();
            PlaygroundsTab.Hide();
            panel1.Hide();
            comboBox1.SelectedIndex = -1;
            dataGridView1.DataSource = null;

            button1.Text = "Log In";
            label1.Text = "Offer";
        }
        private void UserView()
        {
            DevicesTab.Show();
            PlaygroundsTab.Show();
            comboBox1.SelectedIndex = -1;
            dataGridView1.DataSource = null;

            button1.Text = "Log Out";
            label1.Text = username;
        }

        private void OwnerView()
        {
            DevicesTab.Show();
            PlaygroundsTab.Show();
            addButton.Show();
            comboBox1.SelectedIndex = -1;
            dataGridView1.DataSource = null;

            button1.Text = "Log Out";
            label1.Text = username;
        }

        public MainForm()
        {
            _playgroundRepository = new PlaygroundRepository(new ProjectContext());
            _slideRepository = new SlideRepository(new ProjectContext());
            _swingRepository = new SwingRepository(new ProjectContext());
            _employeeRepository = new EmployeeRepository(new ProjectContext());
            InitializeComponent();

            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;

            fromMonthCalendar.Hide();
            toMonthCalendar.Hide();
            panel1.Hide();

            BasicView();
        }

        private async Task LoadDevicesAsync<T>(DeviceRepository<T> deviceRepository) where T : Device
        {
            try
            {
                var devices = await deviceRepository.GetAsync();
                dataGridView1.DataSource = devices;
                dataGridView1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (button1.Text == "Log Out")
            {
                username = "";
                MessageBox.Show("Logged out");
                BasicView();
                return;
            }
            LoginForm form2 = new LoginForm();
            if (form2.ShowDialog() == DialogResult.OK)
            {
                if (username == "user")
                {
                    UserView();
                }
                else if (username == "owner")
                {
                    OwnerView();
                }
            }
            else
            {
                MessageBox.Show("Failed to log in");
            }
        }

        private void button2_ClickAsync(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                return;
            }
            var selectedRow = dataGridView1.SelectedRows[0];
            List<DeviceImage> images;

            if (selectedRow.DataBoundItem is Device device)
            {
                switch (comboBox1.Text)
                {
                    case "Slides":
                        images = device.Images.ToList();
                        if (images.Count == 0) break;
                        ImageForm imageForm = new ImageForm(images);
                        imageForm.ShowDialog();
                        break;
                    case "Swings":
                        images = device.Images.ToList();
                        if (images.Count == 0) break;
                        imageForm = new ImageForm(images);
                        imageForm.ShowDialog();
                        break;
                    default:
                        break;
                }
            }
        }

        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox1.SelectedIndex == 0)
            {
                await LoadDevicesAsync(_slideRepository);

                dataGridView1.Columns.RemoveAt(dataGridView1.Columns.Count - 2);
                dataGridView1.Columns.RemoveAt(dataGridView1.Columns.Count - 2);
                dataGridView1.Columns.RemoveAt(dataGridView1.Columns.Count - 2);
                
                dataGridView1.Columns["LengthOfExit"].DisplayIndex = dataGridView1.Columns.Count - 1;
                dataGridView1.Columns["AngleOfFall"].DisplayIndex = dataGridView1.Columns.Count - 1;
            }

            if (comboBox1.SelectedIndex == 1)
            {
                await LoadDevicesAsync(_swingRepository);

                dataGridView1.Columns.RemoveAt(dataGridView1.Columns.Count - 2);
                dataGridView1.Columns.RemoveAt(dataGridView1.Columns.Count - 2);
                dataGridView1.Columns.RemoveAt(dataGridView1.Columns.Count - 2);

                dataGridView1.Columns["RopeLength"].DisplayIndex = dataGridView1.Columns.Count - 1;
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (comboBox1.Visible)
            {
                AddDeviceForm addDeviceForm = new AddDeviceForm();
                addDeviceForm.Show();
            }
            else if (dataGridView1.Columns[0].HeaderCell.Value.ToString() != "TemporaryId")
            {
                /*                int playgroundId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["PlaygroundId"].Value);
                                var employees = await _employeeRepository.GetEmployeesByPlayground(playgroundId);*/
                PlaygroundDTO selectedRow = (PlaygroundDTO)dataGridView1.CurrentRow.DataBoundItem;
                Playground playground = selectedRow.playground;
                var employeePlayground = playground.Employees.ToList();
                var employeeToDisplay = new List<EmployeeDTO>();
                foreach (var ep in employeePlayground) { 
                    var emp = new EmployeeDTO
                        {
                        TemporaryId = ep.Id,
                        TemporaryIdExpiryDate = ep.expiryDate,
                        EmployeeId = ep.Employee.EmployeeId,
                        Name = ep.Employee.Name,
                        Surname = ep.Employee.Surname,
                        PhoneNumber = ep.Employee.PhoneNumber,
                        DateOfEmployment = ep.Employee.DateOfEmployment
                        };
                    employeeToDisplay.Add(emp);
                }
                dataGridView1.DataSource = employeeToDisplay;
                dataGridView1.Refresh();
            }
        }

        private async void PlaygroundsTab_Click(object sender, EventArgs e)
        {
            if (username == "owner")
            {
                panel1.Show();
            }
            infoButton.Show();
            comboBox1.Hide();
            dataGridView1.DataSource = null;

            var playgrounds = await _playgroundRepository.GetAsync();
            List<PlaygroundDTO> playgroundToDisplay = new List<PlaygroundDTO>();
            foreach ( var playground in playgrounds)
            {
                playgroundToDisplay.Add(new PlaygroundDTO(playground));
            }
            dataGridView1.DataSource = playgroundToDisplay;
            addButton.Text = "Employees";
            infoButton.Text = "Info";
            fromTextBox.Text = "";
            toTextBox.Text = "";
            fromDate = DateTime.MinValue;
            toDate = DateTime.MaxValue;
            RefreshPlaygroundsGrid();
        }

        private void DevicesTab_Click(object sender, EventArgs e)
        {
            infoButton.Show();
            comboBox1.Show();
            panel1.Hide();
            dataGridView1.DataSource = null;
            addButton.Text = "Add";
            infoButton.Text = "Images";
        }

        private void fromTextBox_Click(object sender, EventArgs e)
        {
            fromMonthCalendar.Show();

        }

        private void toTextBox_Click(object sender, EventArgs e)
        {
            toMonthCalendar.Show();
        }

        private async void fromMonthCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            fromDate = e.Start;
            toMonthCalendar.MinDate = fromDate;
            fromTextBox.Text = fromDate.Date.ToString("dd-MM-yyyy");
            fromMonthCalendar.Hide();
            var playgrounds = await _playgroundRepository.GetPlaygroundsByCompletionDate(fromDate, toDate);
            List<PlaygroundDTO> playgroundToDisplay = new List<PlaygroundDTO>();
            foreach (var playground in playgrounds)
            {
                playgroundToDisplay.Add(new PlaygroundDTO(playground));
            }
            dataGridView1.DataSource = playgroundToDisplay;
            RefreshPlaygroundsGrid();
        }

        private async void toMonthCalendar_DateSelectedAsync(object sender, DateRangeEventArgs e)
        {
            toDate = e.End;
            fromMonthCalendar.MaxDate = toDate;
            toTextBox.Text = toDate.Date.ToString("dd-MM-yyyy");
            toMonthCalendar.Hide();
            var playgrounds = await _playgroundRepository.GetPlaygroundsByCompletionDate(fromDate, toDate);
            List<PlaygroundDTO> playgroundToDisplay = new List<PlaygroundDTO>();
            foreach (var playground in playgrounds)
            {
                playgroundToDisplay.Add(new PlaygroundDTO(playground));
            }
            dataGridView1.DataSource = playgroundToDisplay;
            RefreshPlaygroundsGrid();
        }

        private void fromMonthCalendar_MouseLeave(object sender, EventArgs e)
        {
            fromMonthCalendar.Hide();
        }

        private void toMonthCalendar_MouseLeave(object sender, EventArgs e)
        {
            toMonthCalendar.Hide();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (comboBox1.Visible == false)
            {
                return;
            }
            if (e.ColumnIndex == dataGridView1.Columns["Materials"].Index && e.RowIndex != -1)
            {
                Device device = (Device)dataGridView1.Rows[e.RowIndex].DataBoundItem;
                MaterialsForm materialsForm = new MaterialsForm(device);
                materialsForm.ShowDialog();
            }
        }

        private void RefreshPlaygroundsGrid()
        {
            dataGridView1.Columns.Remove("playground");
            dataGridView1.Refresh();
        }
    }
}
