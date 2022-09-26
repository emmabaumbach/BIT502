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
        {
            new MainMenu().Show();
        }

        private void addMemberButton_Click(object sender, EventArgs e)
        {
            new AddMember().Show();
        }

        private void bookClassButton_Click(object sender, EventArgs e)
        {
            new BookAClass().Show();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            nameText.Text = "";
            memTypeText.Text = "";
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            string helpMessage = "Help";
            string messageBoxTitle = "Search Members Help";
            MessageBox.Show(helpMessage, messageBoxTitle);
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
