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
using System.Xml;
using Tibia_Tools.Properties;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace Tibia_Tools
{
    public partial class HuntLogForm : Form
    {
        public HuntLogForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            type_CB.SelectedIndex = 0;
            date_TB.Text = DateTime.Now.ToString("MM/dd/yyyy");
            if (File.Exists("HuntLog.xml"))
            {
                XDocument doc = Singleton.Instance.GetXML();
                try
                {
                doc = XDocument.Load("HuntLog.XML");
                Singleton.Instance.SetXML(doc);
                //setting the singleton ID to the last ID in the file, so that we can increment the right number when we try and add a new hunt session
                XElement hunt = doc.Descendants("HuntLog").FirstOrDefault();
                if (hunt.HasElements) {
                var eles = hunt.Elements().ToList();
                //setting the id to the last ID in the xml when prog loads up
                Singleton.Instance.SetID(Convert.ToInt32(eles[eles.Count - 1].FirstAttribute.Value));
                }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error. Something's wrong with the XML file");
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<String> partyMembers = new List<String>();
            String name = name_TB.Text;
            String date = date_TB.Text;
            String desc = desc_TB.Text;
            String duration = duration_TB.Text;
            String profit = profit_TB.Text;
            String exp = exp_TB.Text;
            String party = party_TB.Text;
            if (name != "" && date != "" &&  desc != "" && duration != "" && profit != "" && exp  != "" && party != "")
            {
                profit = Regex.Replace(profit, @"k", "000");
                exp = Regex.Replace(exp, @"k", "000");
                partyMembers = Regex.Replace(party, @"\s+", "").Split(',').ToList();

                //public void AddHunt(String huntName, String huntDate, String huntDesc, String huntDuration, String huntProfit, String huntEXP, List<String> memberList, String huntType)
                Singleton.Instance.AddHunt(name, date, desc, duration, profit, exp, partyMembers, type_CB.SelectedItem.ToString());

            } else
            {
                MessageBox.Show("Please fill out the empty field");
                return;
            }




        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            PartyCalculatorForm test = new PartyCalculatorForm(this);
            test.Show();
        }
    }
}
