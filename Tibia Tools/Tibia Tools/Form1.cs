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

        private void generate_btn_Click(object sender, EventArgs e)
        {
            string html = @"<!DOCTYPE html>
<html>
<head>
<style>
table, th, td {{
    border: 1px solid black;
    border-collapse: collapse;
}}
</style>
</head>
<body>

<h2>Hunt Log</h2>

<table style=\""width: 50 % \"">
<tr>
<th>Name</th><th>Date</th><th>Description</th><th>Type</th><th>Duration (hours)</th><th>Profit</th><th>EXP</th><th>Members</th>
</tr>

{0}
</table >

</body >
</html >

{1}";
            long totalMoney = 0;
            long totalXP = 0;
            string test = "";
            double totalHours = 0.0;
            XDocument doc = Singleton.Instance.GetXML();
            foreach (var child in doc.Element("HuntLog").Elements())
            {
                test += "<tr>";
                foreach (var child1 in child.Elements())
                {
                    //Console.WriteLine(child1.Name + " : " + child1.Value);
                    if (child1.Name == "Profit")
                    {
                        totalMoney += Convert.ToInt64(child1.Value);
                    } else if (child1.Name == "EXP")
                    {
                        totalXP += Convert.ToInt64(child1.Value);
                    } else if (child1.Name == "Duration")
                    {
                        totalHours += Convert.ToDouble(child1.Value);
                    }
                    test += string.Format("<td>{0}</\td>", child1.Value);
                }
                test += "</tr>";
            }
            File.WriteAllText("HuntLogSummary.html", String.Format(html, test, String.Format("<br/>Total Profit: {0}<br/> Total EXP: {1}<br/> Total Hours: {2}", String.Format("{0:#,##0}", totalMoney), String.Format("{0:#,##0}", totalXP), totalHours)));
        }
    }
}
