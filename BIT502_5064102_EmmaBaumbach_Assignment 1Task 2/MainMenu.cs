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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void addMember_Click(object sender, EventArgs e)
        // If AddMembers Form is open then brings to front, otherwise opens new
        {
            if (Application.OpenForms.OfType<AddMember>().Count() == 1)
            {
                Application.OpenForms.OfType<AddMember>().First().BringToFront();
            }
            else
            {
                new AddMember().Show();
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        // Exits the application
        {
            Environment.Exit(0);
        }

        private void helpButton_Click(object sender, EventArgs e)
        // Shows a messagebox with instructions and information about features on the page
        {
            string helpMessage = "Select an option or click the ‘Exit’ button to exit the application.";
            string messageBoxTitle = "Main Menu Help";
            MessageBox.Show(helpMessage, messageBoxTitle);
        }

        private void bookClassButton_Click(object sender, EventArgs e)
        // If BookAClass Form is open then brings to front, otherwise opens new
        {
            if (Application.OpenForms.OfType<BookAClass>().Count() == 1)
            {
                Application.OpenForms.OfType<BookAClass>().First().BringToFront();
            }
            else
            {
                new BookAClass().Show();
            }
        }
        private void searchButton_Click(object sender, EventArgs e)
        // If SearchMembers Form is open then brings to front, otherwise opens new
        {
            if (Application.OpenForms.OfType<SearchMembers>().Count() == 1)
            {
                Application.OpenForms.OfType<SearchMembers>().First().Close();
                new SearchMembers().Show();
            }
            else
            {
                new SearchMembers().Show();
            }
        }
    }
}
