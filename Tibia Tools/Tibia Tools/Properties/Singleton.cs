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
            Console.WriteLine(eles[eles.Count - 1].FirstAttribute.Value);
        }

        public void AddHunt(String huntName, String huntDate, String huntDesc, String huntType, String huntDuration, String huntProfit, String huntEXP, List<String> memberList)
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
            List<XElement> membersList = new List<XElement>();
            memberList.ForEach(delegate (String _name) {
                membersList.Add(new XElement("Name", _name));

            });
            Console.WriteLine("Inside addhunt");
            Console.WriteLine(id);
            XElement hunt = doc.Descendants("HuntLog").FirstOrDefault();
            if (hunt != null)
            {
                Console.WriteLine("Inside hunt != null");
                IncrementID();
                XElement name = new XElement("Name", huntName);
                XElement date = new XElement("Date", huntDate);
                XElement desc = new XElement("Desc", huntDesc);
                XElement type = new XElement("Type", huntType);
                XElement duration = new XElement("Duration", huntDuration);
                XElement profit = new XElement("Profit", huntProfit);
                XElement EXP = new XElement("EXP", huntEXP);
                XElement members = new XElement("Members", membersList[0]);
                hunt.Add(new XElement("Hunt", new XAttribute("ID", id.ToString()),
                    name, date, desc, type, duration, profit, EXP, members));
                XElement test = doc.Descendants("Hunt").Where(x => (string)x.Attribute("ID") == id.ToString()).FirstOrDefault();
                IEnumerable<XElement> rows = test.Descendants("Members");
                XElement firstRow = rows.First();
                for (int i = 1; i < membersList.Count; i++)
                {
                    members.Add(new XElement(membersList[i]));
                }
                doc.Save("HuntLog.xml");
            }
        }
    }
}
