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
        int memTypeFilter = 0;

        public SearchMembers()
        {
            InitializeComponent();
        }

        private void mainMenuButton_Click(object sender, EventArgs e)
        // Brings forward MainMenu
        {
            SearchMembers searchMembers = (SearchMembers)Application.OpenForms["SearchMembers"];
            searchMembers.Close();
            Application.OpenForms["MainMenu"].BringToFront();
        }

        private void addMemberButton_Click(object sender, EventArgs e)
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

        private void clearButton_Click(object sender, EventArgs e)
        // Clears search fields and set the DataSource for the GridView to the full Member dataset
        {
            memberDataGridView.DataSource = cityGymMembershipDataSet.Member;
            searchTextBox.Text = "";
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

        private void searchButton_Click(object sender, EventArgs e)
        {
            // Create a dataview that we can then filter
            DataView memberDataView = new DataView(cityGymMembershipDataSet.Member);

            // A filter over both first and last name
            // Create the filter string
            string filter = "";
           
            filter = "[FirstName] LIKE '" + searchTextBox.Text + "*'";
            filter += " OR[LastName] LIKE '" + searchTextBox.Text + "*'";
            //filter += " OR[MemberID] LIKE '" + searchTextBox.Text + "*'";
            filter += " OR[FirstName] + ' ' + [LastName] LIKE '" + searchTextBox.Text + "*'";
            //+ ' ' + [MemberID] 

            // Apply this filter
            memberDataView.RowFilter = filter;

            // Use this DataView as the DataSource for the GridView
            memberDataGridView.DataSource = memberDataView;
            
        }

        private void filterButton_Click(object sender, EventArgs e)
        {
            DataView membershipTypeDataView = new DataView(cityGymMembershipDataSet.Member);

            string filter = "";

            filter = "[MembershipID] LIKE '" + memTypeFilter;

            membershipTypeDataView.RowFilter = filter;

            // Use this DataView as the DataSource for the GridView
            memberDataGridView.DataSource = membershipTypeDataView;
        }

        private void radioPremium_CheckedChanged(object sender, EventArgs e)
        {
            memTypeFilter += 3;
        }
        
        private void radioRegular_CheckedChanged(object sender, EventArgs e)
        {
            memTypeFilter = 2;
        }

        private void radioBasic_CheckedChanged(object sender, EventArgs e)
        {
            memTypeFilter = 1;
        }
    }
}
