using System;
using System.Linq;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Lab14
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer human = new Customer("Мужчина", 21, 150, "Адам");
            Customer human1 = new Customer("Женщина", 20, 149, "Ева");

            GroupOfCustomers army = new GroupOfCustomers();
            army.Add(human);
            army.Add(human1);

            BinaryFormatter formatter = new BinaryFormatter();
            SoapFormatter formatter1 = new SoapFormatter();
            XmlSerializer formatter2 = new XmlSerializer(typeof(GroupOfCustomers));
            DataContractJsonSerializer formatter3 = new DataContractJsonSerializer(typeof(GroupOfCustomers));

            using (FileStream fs = new FileStream("groupOfCust.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, army);
            }

            using (FileStream fs = new FileStream("customer.soap", FileMode.OpenOrCreate))
            {
                formatter1.Serialize(fs, human);
            }

            using (TextWriter fs = new StreamWriter("groupOfCust.xml"))
            {
                formatter2.Serialize(fs, army);
            }

            using (FileStream fs = new FileStream("groupOfCust.json", FileMode.OpenOrCreate))
            {
                formatter3.WriteObject(fs, army);
            }

            using (FileStream fs = new FileStream("groupOfCust.dat", FileMode.OpenOrCreate))
            {
                GroupOfCustomers army1;
                army1 = (GroupOfCustomers)formatter.Deserialize(fs);
                Console.WriteLine("Binary\n");
                army1.ToConsole();
            }

            using (FileStream fs = new FileStream("customer.soap", FileMode.OpenOrCreate))
            {
                Customer human3;
                human3 = (Customer)formatter1.Deserialize(fs);
                Console.WriteLine("\nSOAP\n");
                Console.WriteLine(human3.ToString());
            }

            using (FileStream fs = new FileStream("groupOfCust.xml", FileMode.OpenOrCreate))
            {
                GroupOfCustomers army1;
                army1 = (GroupOfCustomers)formatter2.Deserialize(fs);
                Console.WriteLine("\nXML\n");
                army1.ToConsole();
            }


            Customer[] humans = new Customer[] { new Customer("Мужчина", 18, 121, "Авель"), new Customer("Женщина", 15, 123, "Аклима"), new Customer("Мужчина", 15, 180, "Каиф") };
            
            using (FileStream fs = new FileStream("array.xml", FileMode.OpenOrCreate))
            {
                formatter2 = new XmlSerializer(typeof(Customer[]));
                formatter2.Serialize(fs, humans);

            }

            using (FileStream fs = new FileStream("array.xml", FileMode.OpenOrCreate))
            {
                foreach (Customer x in (Customer[])formatter2.Deserialize(fs))
                    Console.WriteLine(x.ToString());
            }

            XPathDocument xmldoc = new XPathDocument("array.xml");

            Console.WriteLine("HERE");
            foreach (XPathItem x in xmldoc.CreateNavigator().Select("//Human/Name"))
                Console.WriteLine(x.Value);
            Console.WriteLine();

            foreach (XPathItem x in xmldoc.CreateNavigator().Select("//Human[Sex = \"Man\"]/Name"))
                Console.WriteLine(x.Value);

            using (FileStream fs = new FileStream("array.xml", FileMode.OpenOrCreate))
            {
                XDocument xdoc = XDocument.Load(fs);
                XElement root = xdoc.Element("ArrayOfCustomer");
                foreach (XElement xe in root.Elements("Human").Where(x => x.Element("Name").Value.Contains("а")).ToList())
                {
                    if (Int32.Parse(xe.Element("Age").Value) > 19)
                    {
                        xe.Add(new XElement("Permission", "Yes"));
                    }
                    else
                    {
                        xe.Remove();
                    }
                }
                root.Add(new XElement("Human",
                            new XElement("LifeLength", "100"),
                            new XElement("Name", "Аменадиил"),
                            new XElement("Sex", "Мужчина"),
                            new XElement("Age", "20"),
                            new XElement("IQ", "200"),
                            new XElement("Permission", "Yes")));
                xdoc.Save("newArray.xml");

            }

        }
    }
}

