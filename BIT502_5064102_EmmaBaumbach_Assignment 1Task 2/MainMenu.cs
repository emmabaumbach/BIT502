using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BIT502_5064102_EmmaBaumbach_Assignment_1Task_2
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void addMember_Click(object sender, EventArgs e)
        {
            new AddMember().Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void addMember_Click_1(object sender, EventArgs e)
        {
            new AddMember().Show();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            string helpMessage = "Select an option or click the ‘Exit’ button to exit the application.";
            string messageBoxTitle = "Main Menu Help";
            MessageBox.Show(helpMessage, messageBoxTitle);
        }
    }
}
