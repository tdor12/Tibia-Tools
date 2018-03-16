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
            if (File.Exists("HuntLog.xml"))
            {

                MessageBox.Show("HuntLog.xml FOUND!!");
                XDocument doc = Singleton.Instance.GetXML();
                doc = XDocument.Load("HuntLog.XML");
                Singleton.Instance.SetXML(doc);

                XElement hunt = doc.Descendants("HuntLog").FirstOrDefault();
                if (hunt.HasElements) {
                var eles = hunt.Elements().ToList();
                //setting the id to the last ID in the xml when prog loads up
                Singleton.Instance.SetID(Convert.ToInt32(eles[eles.Count - 1].FirstAttribute.Value));
                List<String> myList = new List<string> { "Italo The Tank(EK 320)", "Italo The ED (321 ED)" };
                Singleton.Instance.AddHunt("Draken Walls Test", "3/20/2018", "Testing, bro", "Duo", "3", "100", "123456", myList);
            }
                Singleton.Instance.PrintEles();
                


            } else
            {
                MessageBox.Show("HuntLog.xml not found, creating one.");
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
    }
}
