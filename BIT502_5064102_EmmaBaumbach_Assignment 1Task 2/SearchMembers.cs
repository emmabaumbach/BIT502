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
                Application.OpenForms.OfType<AddMember>().First().Close();
                new AddMember().Show();
            }
            else
            {
                new AddMember().Show();
            }
            Application.OpenForms.OfType<SearchMembers>().First().Close();
        }

        private void bookClassButton_Click(object sender, EventArgs e)
        // If BookAClass Form is open then brings to front, otherwise opens new
        {
            if (Application.OpenForms.OfType<BookAClass>().Count() == 1)
            {
                Application.OpenForms.OfType<BookAClass>().First().Close();
                new BookAClass().Show();
            }
            else
            {
                new BookAClass().Show();
            }
            Application.OpenForms.OfType<SearchMembers>().First().Close();
        }

        private void clearButton_Click(object sender, EventArgs e)
        // Clears search fields and set the DataSource for the GridView to full Member dataset
        {
            DataView memberDataView = new DataView(cityGymMembershipDataSet.Member);
            memberBindingSource.DataSource = memberDataView;

            searchTextBox.Text = "";
        }

        private void helpButton_Click(object sender, EventArgs e) 
        // Shows a messagebox with instructions and information about features on the page
        {
            string helpMessage = "Search by entering member name and selecting 'Search'. Filter these results further by selecting Membership Type and selecting 'Filter'." + Environment.NewLine + Environment.NewLine + "‘Clear’ will clear the searchbar." + Environment.NewLine + Environment.NewLine + "‘Remove Filter’ will remove the Membership Type filter." + Environment.NewLine + Environment.NewLine + "Alternatively, ‘Main Menu’ will take you back to the main menu, ‘Add a Member’ will open the add a member form, ‘Book a Class’ will open a booking form, and the ‘Exit’ button to exit the application.";
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
            // TODO: This line of code loads data into the 'cityGymMembershipDataSet.Membership' table. You can move, or remove it, as needed.
            this.membershipTableAdapter.Fill(this.cityGymMembershipDataSet.Membership);
            // TODO: This line of code loads data into the 'cityGymMembershipDataSet.BookingClassDetails' table. You can move, or remove it, as needed.
            this.bookingClassDetailsTableAdapter.Fill(this.cityGymMembershipDataSet.BookingClassDetails);
            // TODO: This line of code loads data into the 'cityGymMembershipDataSet.MemberDetails' table. You can move, or remove it, as needed.
            this.memberDetailsTableAdapter.Fill(this.cityGymMembershipDataSet.MemberDetails);
            // TODO: This line of code loads data into the 'cityGymMembershipDataSet.Booking' table. You can move, or remove it, as needed.
            this.bookingTableAdapter.Fill(this.cityGymMembershipDataSet.Booking);
            // TODO: This line of code loads data into the 'cityGymMembershipDataSet.Member' table. You can move, or remove it, as needed.
            this.memberTableAdapter.Fill(this.cityGymMembershipDataSet.Member);

        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            // Create the dataview to filter
            DataView memberDataView = new DataView(cityGymMembershipDataSet.Member);

            String filter = membersFilter(false);
            memberDataView.RowFilter = filter;

            memberBindingSource.DataSource = memberDataView;         
        }

        private void filterButton_Click(object sender, EventArgs e)
        {
            // Create the dataview to filter
            DataView memberDataView = new DataView(cityGymMembershipDataSet.Member);


            String filter = membersFilter(true);
            memberDataView.RowFilter = filter;

            memberBindingSource.DataSource = memberDataView;
        }

        private String membersFilter(bool filterByMembershipType)
        {
            string filter = "";

            if (filterByMembershipType)
            {
                int filterMembershipById = 0;

                if (radioBasic.Checked)
                {
                    filterMembershipById = 1;
                }
                else if (radioRegular.Checked)
                {
                    filterMembershipById = 2;
                }
                else if (radioPremium.Checked)
                {
                    filterMembershipById = 3;
                }
                if (filterMembershipById > 0)
                {
                    filter += "MembershipId = " + filterMembershipById.ToString() + " AND (";
                }
            } else
            {
                filter += "(";
            }

            filter += "[FirstName] LIKE '" + searchTextBox.Text + "*'";
            filter += " OR[LastName] LIKE '" + searchTextBox.Text + "*'";
            filter += " OR[FirstName] + ' ' + [LastName] LIKE '" + searchTextBox.Text + "*'";
            filter += ")";
            return filter;
        }

        private void radioPremium_CheckedChanged(object sender, EventArgs e)
        {
        }
        
        private void radioRegular_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void radioBasic_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void removeFilterButton_Click(object sender, EventArgs e)
        {
            // Reset all radio buttons, reset the data view
            radioBasic.Checked = false;
            radioRegular.Checked = false;
            radioPremium.Checked = false;

            DataView memberDataView = new DataView(cityGymMembershipDataSet.Member);
            memberBindingSource.DataSource = memberDataView;
        }
    }
}
