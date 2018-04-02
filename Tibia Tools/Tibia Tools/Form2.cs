using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tibia_Tools
{
    public partial class PartyCalculatorForm : Form
    {
        private HuntLogForm huntForm;
        public PartyCalculatorForm(HuntLogForm form)
        {
            InitializeComponent();
            huntForm = form;
        }

        private void PartyCalculatorForm_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;

        }

        private void supplyCost_TB_TextChanged(object sender, EventArgs e)
        {

        }

        private void calculate_btn_Click(object sender, EventArgs e)
        {
            if (supplyCost_TB.Text != "" && totalLoot_TB.Text != "")
            {
                List<String> profitList = new List<String>();
                profitList = Regex.Replace(supplyCost_TB.Text, @"\s+", "").Split(',').ToList();
                int totalWaste = 0;
                int totalLoot = 0;
                try
                {
                    totalLoot = Convert.ToInt32(totalLoot_TB.Text);
                    foreach (string item in profitList)
                    {
                        totalWaste += Convert.ToInt32(item);
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Error in trying to convert string to integer. Check your input. ", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int totalProfit = totalLoot - totalWaste;
                totalProfit_TB.Text = (totalProfit).ToString();
                dividedProfit_TB.Text = (totalProfit / profitList.Count).ToString();

            } else
            {
                MessageBox.Show("Please fill in both required fields", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void populate_btn_Click(object sender, EventArgs e)
        {
            int profit = 0;
            if (dividedProfit_TB.Text != "")
            {
                try
                {
                    profit = Convert.ToInt32(dividedProfit_TB.Text);
                    TextBox foo = (TextBox)huntForm.Controls["profit_TB"];
                    foo.Text = profit.ToString();
                }
                catch (FormatException)
                {
                    MessageBox.Show("Issue converting divided profit", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            } else {
                MessageBox.Show("Fill out the fields and calculate first. ", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
              
            }
        }

        private void supplyCost_TB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }
        }

        private void totalLoot_TB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
