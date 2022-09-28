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
    public partial class SearchMembers : Form
    {
        public SearchMembers()
        {
            InitializeComponent();
        }

        private void mainMenuButton_Click(object sender, EventArgs e)
        // Opens Main Menu form
        {
            new MainMenu().Show();
        }

        private void addMemberButton_Click(object sender, EventArgs e)
        // Opens Add Member form
        {
            new AddMember().Show();
        }

        private void bookClassButton_Click(object sender, EventArgs e)
        // Opens Book a Class form
        {
            new BookAClass().Show();
        }

        private void clearButton_Click(object sender, EventArgs e) 
        // Clears search fields
        {
            nameText.Text = "";
            memTypeText.Text = "";
        }

        private void helpButton_Click(object sender, EventArgs e) 
        // Shows a messagebox with instructions and information about features on the page
        {
            string helpMessage = "Search by member name and/or membership type and select ‘Search’." + Environment.NewLine + Environment.NewLine + "‘Clear’ will clear all fields." + Environment.NewLine + Environment.NewLine + "Use the Filter Results section to filter members by name or membership." + Environment.NewLine + Environment.NewLine + "Alternatively, ‘Main Menu’ will take you back to the main menu, ‘Book a Class’ will open a booking screen, and the ‘Exit’ button to exit the application.";
            string messageBoxTitle = "Search Members Help";
            MessageBox.Show(helpMessage, messageBoxTitle);
        }

        private void exitButton_Click(object sender, EventArgs e) 
        // Exits the application
        {
            Environment.Exit(0);
        }

        private void memberBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.memberBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.cityGymMembershipDataSet);

        }

        private void SearchMembers_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cityGymMembershipDataSet.Booking' table. You can move, or remove it, as needed.
            this.bookingTableAdapter.Fill(this.cityGymMembershipDataSet.Booking);
            // TODO: This line of code loads data into the 'cityGymMembershipDataSet.Member' table. You can move, or remove it, as needed.
            this.memberTableAdapter.Fill(this.cityGymMembershipDataSet.Member);

        }
    }
}
