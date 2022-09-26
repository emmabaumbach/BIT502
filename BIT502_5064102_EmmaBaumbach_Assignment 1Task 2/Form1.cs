using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace BIT502_5064102_EmmaBaumbach_Assignment_1Task_2
{
    public partial class AddMember : Form
    {
        double duration = 0;
        double payFreq = 0;
        double baseCost = 0;
        double netCost = 0;

        private static double CalcPayFreq(bool weekly, bool monthly)
        {
            // Calculates payment frequency
            int payFreq = 0;
            if (weekly == true)
            {
                payFreq = 1;
            }
            if (monthly == true)
            {
                payFreq = 4;
            }
            return payFreq;
        }
        private static double CalcTotalDiscount(double baseCost, bool directDebit, double duration)
        {
            // Calculates the total weekly discount 
            double totalDis = 0;

            if (duration == 52) // $2/week discount overall if user selects 12 month/52 week term
            {
                totalDis += 2;
            }
            if (duration == 104) // $5/week discount overall if user selects 24 month/104 week term
            {
                totalDis += 5;
            }
            if (directDebit) // 1% discount if user selects direct debit
            {
                totalDis += baseCost * 0.01;
            }
            return totalDis;
        }
        private static double CalcExtras(bool access24_7, bool onlineVideos, bool dietConsult, bool personalTraining)
        {
            // Calculates total weekly extras

            double extraWeeklyCharge = 0;
            if (access24_7) // 24/7 access extra 
            {
                extraWeeklyCharge += 1;
            }
            if (onlineVideos) // Online video access extra
            {
                extraWeeklyCharge += 2;
            }
            if (dietConsult) // Diet consulation extra
            {
                extraWeeklyCharge += 20;
            }
            if (personalTraining) // Personal training extra
            {
                extraWeeklyCharge += 20;
            }
            return extraWeeklyCharge;
        }

        private void SubmitData() // Stores new member information to a text file
        {
            var Error = CheckErrors(); // Checks user input for errors


            if (Error == 1) // Presents a message to the user while blocking other actions until the user acknowledges
            {
                MessageBox.Show("You are missing some details in the form. Please try again.");
            }
            else if (Error == 2) // Presents a message to user that their details are incorrect format
            {
                MessageBox.Show("Numerical format required. Please try again");
            }
            else
            {
                SaveForm(); // Saves form to text file
                ReturnColour(); // If user input is in required format, error level colour is removed
                MessageBox.Show("Thank you, your registration form has been submitted successfully.");
            }

        }
        private int CheckErrors() // Check user input for errors
        {
            var Error = 0;

            if (firstNameText.Text.Length == 0) // If first name details are missing then error and highlight the fields with missing details
            {
                Error = 1;
                firstNameText.BackColor = Color.DarkSalmon;
            }
            if (lastNameText.Text.Length == 0) // If last name details are missing then error and highlight the fields with missing details
            {
                Error = 1;
                lastNameText.BackColor = Color.DarkSalmon;
            }
            if (addressText.Text.Length == 0) // If address details are missing then error and highlight the fields with missing details
            {
                Error = 1;
                addressText.BackColor = Color.DarkSalmon;
            }
            if (cityText.Text.Length == 0) // If city details are missing then error and highlight the fields with missing details
            {
                Error = 1;
                cityText.BackColor = Color.DarkSalmon;
            }
            if (cellPhoneText.Text.Length == 0) // If contact details are missing then error and highlight the fields with missing details
            {
                Error = 1;
                cellPhoneText.BackColor = Color.DarkSalmon;
            }

            var cellPhone = cellPhoneText.Text; // If contact details are not numerical then error and highlight the field
            int cell;
            if (!int.TryParse(cellPhone, out cell))
            {
                Error = 2;
                cellPhoneText.BackColor = Color.DarkSalmon;
            }

            if (panel3.Controls.OfType<RadioButton>().All(x => x.Checked == false)) // At least one membership radiobutton in panel3 is checked
            {
                Error = 1;
                basicRadio.BackColor = Color.DarkSalmon;
                regularRadio.BackColor = Color.DarkSalmon;
                premiumRadio.BackColor = Color.DarkSalmon;
            }
            if (panel1.Controls.OfType<RadioButton>().All(x => x.Checked == false)) // At least one duration radiobutton in panel1 is checked
            {
                Error = 1;
                month3Radio.BackColor = Color.DarkSalmon;
                month12Radio.BackColor = Color.DarkSalmon;
                month24Radio.BackColor = Color.DarkSalmon;

            }
            if (panel2.Controls.OfType<RadioButton>().All(x => x.Checked == false)) // At least one payment frequency in panel2 is checked
            {
                Error = 1;
                radioPFWeekly.BackColor = Color.DarkSalmon;
                radioPFMonthly.BackColor = Color.DarkSalmon;
            }
            return Error;
        }
        private void SaveForm() // Saves form to text file
        {
            String membership = "";

            if (basicRadio.Checked == true)
            {
                membership = "Basic";
            }
            if (regularRadio.Checked == true)
            {
                membership = "Regular";
            }
            if (premiumRadio.Checked == true)
            {
                membership = "Premium";
            }

            TextWriter wr = new StreamWriter("C:/Temp/NewMembership.txt"); // Writing to text file

            wr.WriteLine("~ City Gym Membership Form ~");
            wr.WriteLine("");
            wr.WriteLine("Name: " + firstNameText.Text + " " + lastNameText.Text);
            wr.WriteLine("Address: " + addressText.Text);
            wr.WriteLine("City: " + cityText.Text);
            wr.WriteLine("Cell Phone: " + cellPhoneText.Text);
            wr.WriteLine("");
            wr.WriteLine("Membership Type: " + membership);
            wr.WriteLine("3 Month Membership: " + month3Radio.Checked);
            wr.WriteLine("12 Month Membership: " + month12Radio.Checked);
            wr.WriteLine("24 Month Membership: " + month24Radio.Checked);
            wr.WriteLine("");
            wr.WriteLine("Extra (24/7 Access): " + check247.Checked);
            wr.WriteLine("Extra (Online Videos): " + checkOnlineVideo.Checked);
            wr.WriteLine("Extra (Diet Consultation): " + checkDietConsult.Checked);
            wr.WriteLine("Extra (Personal Training): " + checkPT.Checked);
            wr.WriteLine("");
            wr.WriteLine("Direct Debit: " + checkDirectDebit.Checked);
            wr.WriteLine("Payment Frequency (Weekly): " + radioPFWeekly.Checked);
            wr.WriteLine("Payment Frequency (Monthly): " + radioPFMonthly.Checked);

            wr.Close();
        }

        public AddMember()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Basic_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void cityGymPicture_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radioBasic_CheckedChanged(object sender, EventArgs e) // If radio button 'Basic' selected baseCost value = 10
        {
            baseCost = 10;
        }

        private void radioRegular_CheckedChanged(object sender, EventArgs e) // If radio button 'Regular' selected baseCost value = 15
        {
            baseCost = 15;
        }

        private void radioPremium_CheckedChanged(object sender, EventArgs e) // If radio button 'Premium' selected baseCost value = 20
        {
            baseCost = 20;
        }

        private void richTextBox1_TextChanged_2(object sender, EventArgs e)
        {

        }

        private void ButtonSubmit(object sender, EventArgs e) // Calls the function to store new member information to a text file
        {
            SubmitData();
        }

        public void radioPayWeekly_CheckedChanged(object sender, EventArgs e) // If radio button 'Weekly' selected, payfreq = 1 
        {
            payFreq = 1;
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e) // Exits the application
        {
            Environment.Exit(0);
        }

        private void ReturnColour() // Removes all error colours
        {
            firstNameText.BackColor = Color.White;
            lastNameText.BackColor = Color.White;
            addressText.BackColor = Color.White;
            cityText.BackColor = Color.White;
            cellPhoneText.BackColor = Color.White;
            basicRadio.BackColor = Color.DarkSeaGreen;
            regularRadio.BackColor = Color.DarkSeaGreen;
            premiumRadio.BackColor = Color.DarkSeaGreen;
            month3Radio.BackColor = Color.DarkSeaGreen;
            month12Radio.BackColor = Color.DarkSeaGreen;
            month24Radio.BackColor = Color.DarkSeaGreen;
            radioPFWeekly.BackColor = Color.DarkSeaGreen;
            radioPFMonthly.BackColor = Color.DarkSeaGreen;
        }

        private void ButtonReset_Click(object sender, EventArgs e) // Resets all fields to empty, unclicked, unchecked, zeroes calculations and removes errors
        {
            baseCost = 0;
            duration = 0;
            firstNameText.Text = "";
            firstNameText.BackColor = Color.White;
            lastNameText.Text = "";
            lastNameText.BackColor = Color.White;
            addressText.Text = "";
            addressText.BackColor = Color.White;
            cityText.Text = "";
            cityText.BackColor = Color.White;
            cellPhoneText.Text = "";
            cellPhoneText.BackColor = Color.White;
            baseCostText.Text = "";
            extrasCostText.Text = "";
            totalDiscountText.Text = "";
            netCostText.Text = "";
            regPayText.Text = "";
            basicRadio.Checked = false;
            basicRadio.BackColor = Color.DarkSeaGreen;
            regularRadio.Checked = false;
            regularRadio.BackColor = Color.DarkSeaGreen;
            premiumRadio.Checked = false;
            premiumRadio.BackColor = Color.DarkSeaGreen;
            month3Radio.Checked = false;
            month3Radio.BackColor = Color.DarkSeaGreen;
            month12Radio.Checked = false;
            month12Radio.BackColor = Color.DarkSeaGreen;
            month24Radio.Checked = false;
            month24Radio.BackColor = Color.DarkSeaGreen;
            radioPFWeekly.Checked = false;
            radioPFWeekly.BackColor = Color.DarkSeaGreen;
            radioPFMonthly.Checked = false;
            radioPFMonthly.BackColor = Color.DarkSeaGreen;
            check247.Checked = false;
            checkDirectDebit.Checked = false;
            checkPT.Checked = false;
            checkDietConsult.Checked = false;
            checkOnlineVideo.Checked = false;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        private void ButtonCalculate(object sender, EventArgs e)
        {
            // Call function to calculate total of extra items the user has selected as a weekly charge and assigns to double
            double extras = CalcExtras(check247.Checked, checkOnlineVideo.Checked, checkDietConsult.Checked, checkPT.Checked);

            // Call function to calculate total discount for the duration the user has selected and assigns to double
            double totalDis = CalcTotalDiscount(baseCost, checkDirectDebit.Checked, duration);

            // Net cost of membership for the duration
            netCost = (baseCost + extras) - totalDis;

            // Regular payment amount either weekly or monthly 
            double regPay = netCost * payFreq;

            extrasCostText.Text = "$" + Math.Round(extras);
            baseCostText.Text = "$" + Math.Round(baseCost);
            totalDiscountText.Text = "$" + Math.Round(totalDis, 2);
            netCostText.Text = "$" + Math.Round(netCost, 2);
            regPayText.Text = "$" + Math.Round(regPay, 2);
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        public void radioD3Month_CheckedChanged(object sender, EventArgs e)
        {
            duration = 12; // 3 months = 12 weeks
        }

        public void radioD12Month_CheckedChanged(object sender, EventArgs e)
        {
            duration = 52; // 12 months = 52 weeks
        }

        public void radioD24Month_CheckedChanged(object sender, EventArgs e)
        {
            duration = 104; // 24 months = 104 weeks
        }

        private void netCost_TextChanged(object sender, EventArgs e)
        {

        }

        public void radioPayMonthly_CheckedChanged(object sender, EventArgs e)
        {
            payFreq = 4; // if checked convert to weeks

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void check247_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void checkDietConsult_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void HelpButton_Click(object sender, EventArgs e)
        {
            string helpMessage = "Enter new member details, select mandatory options(membership type, duration, pay frequency), and select and extras (optional)." + Environment.NewLine + Environment.NewLine + "Selecting ‘Calculate’ will output amount details based on your selection." + Environment.NewLine + Environment.NewLine + "Click ‘Reset’ to start over, or ‘Submit’ to confirm new member details and submit to the database." + Environment.NewLine + Environment.NewLine + "Alternatively, ‘Main Menu’ will take you back to the main menu, ‘Book a Class’ will open a class booking screen, and the ‘Exit’ button will exit the application.";
            string messageBoxTitle = "Add Member Help";
            MessageBox.Show(helpMessage, messageBoxTitle);
        }

        private void MainMenuButton_Click(object sender, EventArgs e)
        {
            new MainMenu().Show();

        }

        private void BookAClassButton_Click(object sender, EventArgs e)
        {
            new BookAClass().Show();
        }
    }
}