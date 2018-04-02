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
using System.Diagnostics;

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
            MaximizeBox = false;
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
                    MessageBox.Show("Error. Something's wrong with the XML file","Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // List<String> partyMembers = new List<String>();
            String name = name_TB.Text;
            String date = date_TB.Text;
            String desc = desc_TB.Text;
            String duration = duration_TB.Text;
            String profit = profit_TB.Text;
            String exp = exp_TB.Text;
            String party = party_TB.Text;
            String level = level_TB.Text;
            if (name != "" && date != "" &&  desc != "" && duration != "" && profit != "" && exp  != "" && party != "" && level != "")
            {
                profit = Regex.Replace(profit, @"k", "000");
                exp = Regex.Replace(exp, @"k", "000");
                //partyMembers = Regex.Replace(party, @"\s+", "").Split(',').ToList();

                //public void AddHunt(String huntName, String huntDate, String huntDesc, String huntDuration, String huntProfit, String huntEXP, List<String> memberList, String huntType)
                Singleton.Instance.AddHunt(name, date, desc, duration, profit, exp, level, party, type_CB.SelectedItem.ToString());

            } else 
            {
                MessageBox.Show("Please fill out the empty field", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }




        }

        String shortenNumber(String num)
        {
            int index = 0;
            int it = 0;
            String number = "";
            if (num.Length > 3)
            {
                number = num.Substring(0, num.IndexOf(',') + 2);
                for (int i = 0; i < num.Count(x => x == ','); i++)
                {
                    number += "k";
                }
                return number;
            }

            return num;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            PartyCalculatorForm test = new PartyCalculatorForm(this);
            test.Show();
        }
        //<table class=""sortable"" style=\""width: 50 % \"">
        private void generate_btn_Click(object sender, EventArgs e)
        {
            string html = @"<!DOCTYPE html>
<html>
<head>
<style>
body {{
    background-color: ##6c6c6c;
}}
table {{
    border: 1px solid black;
    border-collapse: collapse;
    width: 100%;
}}

p {{
    font-family: Verdana, Geneva, sans-serif;
    background-color: #4CAF50;
    color: white;
}}
th, td {{
    text-align: left;
    padding: 8px;
    font-family: Verdana, Geneva, sans-serif;
    border: 1px solid black;
}}

tr:nth-child(even){{background-color: #f2f2f2}}

th {{
    background-color: #4CAF50;
    color: white;
    font-family: Verdana, Geneva, sans-serif;
}}
h1 {{
    font-family: Verdana, Geneva, sans-serif;
    padding: 5px;
    background-color: #4CAF50;
    color: white;
}}

#foot {{
	position:absolute;
	bottom:0;
	font-family: Verdana, Geneva, sans-serif;

}}
</style>
</head>
<body>

<h1><center>Hunt Log</center></h1>
<table id=""myTable"" width=""50%"">
<thead>
<tr>
    <th onclick=""sortTable(0)"">Name</th>

    <th onclick=""sortTable(1)"">Date</th>
    <th onclick=""sortTable(2)"">Description</th>
    <th onclick=""sortTable(3)"">Type</th>
    <th>Duration (hours)</th>
    <th>Profit</th>
    <th>EXP</th>
    <th>Level</th>
    <th onclick=""sortTable(8)"">Members</th>
</tr>
</thead>
<tbody>

{0}
</tbody>
</table>
<!--Didn't want to write this myself, so here's the link to where I grabbed it from: https://www.w3schools.com/howto/howto_js_sort_table.asp -->
<script>
function sortTable(n) {{
  var table, rows, switching, i, x, y, shouldSwitch, dir, switchcount = 0;
  table = document.getElementById(""myTable"");
  switching = true;
            //Set the sorting direction to ascending:
            dir = ""asc"";
            /*Make a loop that will continue until
            no switching has been done:*/
            while (switching)
            {{
                //start by saying: no switching is done:
                switching = false;
                rows = table.getElementsByTagName(""TR"");
                /*Loop through all table rows (except the
                first, which contains table headers):*/
                for (i = 1; i < (rows.length - 1); i++)
                {{
                    //start by saying there should be no switching:
                    shouldSwitch = false;
                    /*Get the two elements you want to compare,
                    one from current row and one from the next:*/
                    x = rows[i].getElementsByTagName(""TD"")[n];
                    y = rows[i + 1].getElementsByTagName(""TD"")[n];
                    /*check if the two rows should switch place,
                    based on the direction, asc or desc:*/
                    if (dir == ""asc"")
                    {{
                        if (x.innerHTML.toLowerCase() > y.innerHTML.toLowerCase())
                        {{
                            //if so, mark as a switch and break the loop:
                            shouldSwitch = true;
                            break;
                        }}
                    }}
                    else if (dir == ""desc"")
                    {{
                        if (x.innerHTML.toLowerCase() < y.innerHTML.toLowerCase())
                        {{
                            //if so, mark as a switch and break the loop:
                            shouldSwitch = true;
                            break;
                        }}
                    }}
                }}
                if (shouldSwitch)
                {{
                    /*If a switch has been marked, make the switch
                    and mark that a switch has been done:*/
                    rows[i].parentNode.insertBefore(rows[i + 1], rows[i]);
                    switching = true;
                    //Each time a switch is done, increase this count by 1:
                    switchcount++;
                }}
                else
                {{
                    /*If no switching has been done AND the direction is,
                    set the direction to ""desc"" and run the while loop again.*/
                    if (switchcount == 0 && dir == ""asc"")
                    {{
                        dir = ""desc"";
                        switching = true;
                    }}
                }}
            }}
        }}
</script>
{1}
<div id=""foot""> 2017, Italo Moraes </div>
</body >
</html >
";
            long totalMoney = 0;
            long totalXP = 0;
            string test = "";
            double totalHours = 0.0;
            XDocument doc = Singleton.Instance.GetXML();
            try
            {
                foreach (var child in doc.Element("HuntLog").Elements())
                {
                    test += "<tr>";
                    foreach (var child1 in child.Elements())
                    {
                        //Console.WriteLine(child1.Name + " : " + child1.Value);
                        if (child1.Name == "Profit")
                        {
                            totalMoney += Convert.ToInt64(child1.Value);
                            test += string.Format("<td>{0}</td>", shortenNumber(String.Format("{0:#,##0}", Convert.ToInt64(child1.Value))));
                            continue;

                        }
                        else if (child1.Name == "EXP")
                        {
                            totalXP += Convert.ToInt64(child1.Value);
                            test += string.Format("<td>{0}</td>", shortenNumber(String.Format("{0:#,##0}", Convert.ToInt64(child1.Value))));
                            continue;
                        }
                        else if (child1.Name == "Duration")
                        {
                            totalHours += Convert.ToDouble(child1.Value);
                        }
                        test += string.Format("<td>{0}</td>\n", child1.Value);
                    }
                    test += "</tr>\n";
                }
                File.WriteAllText("HuntLogSummary.html", String.Format(html, test, String.Format("<center><p><b>\nTotal Profit: {0} ({3})<br/>\n Total EXP: {1} ({4})<br/>\n Total Hours: {2}\n</b></p></center>", String.Format("{0:#,##0}", totalMoney), String.Format("{0:#,##0}", totalXP), totalHours, shortenNumber(String.Format("{0:#,##0}", totalMoney)), shortenNumber(String.Format("{0:#,##0}", totalXP)))));
                Console.WriteLine(shortenNumber(String.Format("{0:#,##0}", totalMoney)));
                Process.Start(@"HuntLogSummary.html");
            }
            catch (System.NullReferenceException)
            {
                MessageBox.Show("Something wrong with your XML file. Make sure there are entries in it.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void duration_TB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void profit_TB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void exp_TB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void level_TB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AboutBox1 about = new AboutBox1();
            about.Visible = true;
        }
    }
}
