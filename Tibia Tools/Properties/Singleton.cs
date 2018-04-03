using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Tibia_Tools.Properties
{
    public class Singleton
    {
        private static Singleton instance;
        private XDocument doc = new XDocument();
        private int id;
        private List<System.Windows.Forms.TextBox> addHuntFields;


        private Singleton() {; }

        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }

        public void SetXML(XDocument _writer)
        {
            this.doc = _writer;
        }

        public void SetAddHuntFields(List<System.Windows.Forms.TextBox> listt)
        {
            this.addHuntFields = listt;
        }
        public List<System.Windows.Forms.TextBox> GetAddHuntFields()
        {
            return this.addHuntFields;
        }

        public XDocument GetXML()
        {
            return this.doc;
        }
        public void IncrementID()
        {
            this.id = id + 1;
        }

        public int GetID()
        {
            return this.id;
        }

        public void SetID(int id)
        {
            this.id = id;
        }

        public void PrintEles()
        {
            XElement hunt = doc.Descendants("HuntLog").FirstOrDefault();
            var eles = hunt.Elements().ToList();
        }

        public void AddHunt(String huntName, String huntDate, String huntDesc, String huntDuration, String huntProfit, String huntEXP, String huntLevel, String huntMembers, String huntType)
        {
            if (!File.Exists("HuntLog.xml"))
            {
                XmlWriter writer = XmlWriter.Create("HuntLog.xml");
                writer.WriteStartDocument();
                writer.WriteStartElement("HuntLog");
                writer.WriteEndElement();
                writer.Flush();
                writer.Close();
                XDocument doc = Singleton.Instance.GetXML();
                doc = XDocument.Load("HuntLog.XML");
                Singleton.Instance.SetXML(doc);
            }
            XElement hunt = doc.Descendants("HuntLog").FirstOrDefault();
            if (hunt != null)
            {
                IncrementID();
                XElement name = new XElement("Name", huntName);
                XElement date = new XElement("Date", huntDate);
                XElement desc = new XElement("Desc", huntDesc);
                XElement type = new XElement("Type", huntType);
                XElement duration = new XElement("Duration", huntDuration);
                XElement profit = new XElement("Profit", huntProfit);
                XElement EXP = new XElement("EXP", huntEXP);
                XElement level = new XElement("Level", huntLevel);
                XElement members = new XElement("Members", huntMembers);
                hunt.Add(new XElement("Hunt", new XAttribute("ID", id.ToString()),
                    name, date, desc, type, duration, profit, EXP, level, members));
                doc.Save("HuntLog.xml");
            }
        }
    }
}
