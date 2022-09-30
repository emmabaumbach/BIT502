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
            string helpMessage = "Enter a valid Membership ID to select a member." + Environment.NewLine + Environment.NewLine + "Once the user has been selected, choose the Fitness Class and preferred day/ time, followed by preferred week, then select the ‘Book Class’ button or ‘Clear’ to start over." + Environment.NewLine + Environment.NewLine + "Alternatively, ‘Main Menu’ will take you back to the main menu, 'Add a Member' will take you to the member registration form, ‘Search’ will open a Database Search screen, and the ‘Exit’ button will exit the application.";
            string helpBoxTitle = "Book a Class Help";
            MessageBox.Show(helpMessage, helpBoxTitle);
        }

        private void mainMenuButton_Click(object sender, EventArgs e)
        // Brings forward MainMenu
        {
            BookAClass bookAClass = (BookAClass)Application.OpenForms["BookAClass"];
            bookAClass.Close();
            Application.OpenForms["MainMenu"].BringToFront();
        }

        private void exitButton_Click(object sender, EventArgs e)
        // Exits the application
        {
            Environment.Exit(0);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void searchMembersButton_Click(object sender, EventArgs e)
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
            Application.OpenForms.OfType<BookAClass>().First().Close();
        }

        private void addMemberButton_Click(object sender, EventArgs e)
        // If AddMembers Form is open then brings to front, otherwise opens new
        {
            if (Application.OpenForms.OfType<AddMember>().Count() == 1)
            {
                Application.OpenForms.OfType<AddMember>().First().Close();
                new AddMember().Show();
            }
            else
            {
                new AddMember().Show();
            }
            Application.OpenForms.OfType<BookAClass>().First().Close();
        }
    }
}
