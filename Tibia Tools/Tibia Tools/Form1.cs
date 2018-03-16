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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            date_TB.Text = DateTime.Now.ToString("MM/dd/yyyy");
            List<System.Windows.Forms.TextBox> populating = new List<System.Windows.Forms.TextBox> { name_TB, date_TB, desc_TB, duration_TB, profit_TB, exp_TB, party_TB};
            Singleton.Instance.SetAddHuntFields(populating);
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
            List<String> addHuntValues = new List<String>();
            List<String> partyMembers = new List<String>();
           // String[] partyMembers = { "Empty" };
            List<System.Windows.Forms.TextBox> listerino = Singleton.Instance.GetAddHuntFields();
            for (int i = 0; i < listerino.Count; i++)
            {
                if (listerino[i].Text != "")
                {
                    if (listerino[i] == profit_TB || listerino[i] == exp_TB)
                    {
                        listerino[i].Text = Regex.Replace(listerino[i].Text, @"k", "000");
                    }
                    //Console.WriteLine(listerino[i].Text);
                    if (i == listerino.Count - 1)
                    {
                        String foo = listerino[i].Text;
                        partyMembers = Regex.Replace(foo, @"\s+", "").Split(',').ToList();
                        break;
                    }

                    addHuntValues.Add(listerino[i].Text);
                }
                else
                {
                    MessageBox.Show("Please fill out the empty field");
                    listerino[i].Focus();
                    return;
                }
            }


            //AddHunt(String huntName, String huntDate, String huntDesc, String huntType, String huntDuration, String huntProfit, String huntEXP, List<String> memberList)
            Singleton.Instance.AddHunt(addHuntValues[0], addHuntValues[1], addHuntValues[2], addHuntValues[3], addHuntValues[4], addHuntValues[5], partyMembers, type_CB.SelectedItem.ToString());



        }
    }
}
