
using mas_project.Views;

namespace mas_project
{
    public class Program
    {
        public static MainForm startForm;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            startForm = new MainForm();
            Application.Run(startForm);
        }
    }
}
