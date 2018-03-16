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

        /*
         *Date: MM/DD/YYYY
         * HuntName:
         * Desc:
         * Type: Solo, Duo, Trio, 4man
         * Duration:
         * Profit:
         * TotalExp:
         * MemberNames:
         * 
         */
        private void Form1_Load(object sender, EventArgs e)
        {
            List<System.Windows.Forms.TextBox> populating = new List<System.Windows.Forms.TextBox> { name_TB, date_TB, desc_TB, type_TB, duration_TB, profit_TB, exp_TB, party_TB};
            Singleton.Instance.SetAddHuntFields(populating);
            if (File.Exists("HuntLog.xml"))
            {

                //MessageBox.Show("HuntLog.xml FOUND!!");
                //setting the doc to the existing file
                XDocument doc = Singleton.Instance.GetXML();
                doc = XDocument.Load("HuntLog.XML");
                Singleton.Instance.SetXML(doc);
                //setting the singleton ID to the last ID in the file, so that we can increment the right number when we try and add a new hunt session
                XElement hunt = doc.Descendants("HuntLog").FirstOrDefault();
                if (hunt.HasElements) {
                var eles = hunt.Elements().ToList();
                //setting the id to the last ID in the xml when prog loads up
                Singleton.Instance.SetID(Convert.ToInt32(eles[eles.Count - 1].FirstAttribute.Value));
                //List<String> myList = new List<string> { "Italo The Tank(EK 320)", "Italo The ED (321 ED)" };
                //Singleton.Instance.AddHunt("Draken Walls Test", "3/20/2018", "Testing, bro", "Duo", "3", "100", "123456", myList);
                }
          
            } else
            {
                //MessageBox.Show("HuntLog.xml not found, creating one.");
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.NewLineOnAttributes = true;

                using (XmlWriter writer = XmlWriter.Create("HuntLog.xml", settings)) 
                {
                    Singleton.Instance.IncrementID();
                    writer.WriteStartDocument();
                    //huntlog begin
                    writer.WriteStartElement("HuntLog");
                    
                    //hunt begin
                    writer.WriteStartElement("Hunt");
                    writer.WriteAttributeString("ID", "0");
                    writer.WriteElementString("Name", "Draken Walls Test");
                    writer.WriteElementString("Date", "3/16/2018");
                    writer.WriteElementString("Desc", "Testing out to see if this works");
                    writer.WriteElementString("Type", "Solo");
                    writer.WriteElementString("Duration", "0");
                    writer.WriteElementString("Profit", "0");
                    writer.WriteElementString("EXP", "0");

                    //members begin
                    writer.WriteStartElement("Members");
                    writer.WriteElementString("Name", "Italo The Tank");
                    //members end
                    writer.WriteEndElement();
                    //hunt end
                    writer.WriteEndElement();

                    //huntlog end
                    writer.WriteEndElement();
                    writer.Flush();
                    writer.Close();
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
            Console.WriteLine("Values inside of addhuntvalues:");
            for (int i = 0; i < addHuntValues.Count; i++)
            {
                Console.WriteLine(addHuntValues[i]);
            }
            Console.WriteLine("Values for party member names");
            foreach (var nam in partyMembers)
            {
                Console.WriteLine(nam);
            }

            //AddHunt(String huntName, String huntDate, String huntDesc, String huntType, String huntDuration, String huntProfit, String huntEXP, List<String> memberList)
            Singleton.Instance.AddHunt(addHuntValues[0], addHuntValues[1], addHuntValues[2], addHuntValues[3], addHuntValues[4], addHuntValues[5], addHuntValues[6], partyMembers);



        }
    }
}
