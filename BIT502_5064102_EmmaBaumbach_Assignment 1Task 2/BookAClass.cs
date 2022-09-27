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
    public partial class BookAClass : Form
    {
        public BookAClass()
        {
            InitializeComponent();
        }

        private void helpButton_Click(object sender, EventArgs e)
        // Shows a messagebox with instructions and information about features on the page
        {
            string helpMessage = "Enter a valid Membership ID to select a member." + Environment.NewLine + Environment.NewLine + "Once the user has been selected, choose the Fitness Class and preferred day/ time, followed by preferred week, then select ‘Book a Class’ or ‘Clear’ to start over." + Environment.NewLine + Environment.NewLine + "Alternatively, ‘Main Menu’ will take you back to the main menu, ‘Search’ will open a Database Search screen, and the ‘Exit’ button will exit the application.";
            string helpBoxTitle = "Book a Class Help";
            MessageBox.Show(helpMessage, helpBoxTitle);
        }

        private void mainMenuButton_Click(object sender, EventArgs e)
        // Opens the Main Menu form
        {
            new MainMenu().Show();
        }

        private void exitButton_Click(object sender, EventArgs e)
        // Exits the application
        {
            Environment.Exit(0);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void searchButton_Click(object sender, EventArgs e)
        // Opens Search Members form
        {
            new SearchMembers().Show();
        }
    }
}
