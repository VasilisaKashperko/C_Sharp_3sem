using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Xml;

namespace Lab14
{
    [Serializable]
    [XmlRoot("Human")]

    public class GroupOfCustomers
    {
        private List<Customer> units = new List<Customer>();
        public GroupOfCustomers()
        {

        }
        [XmlAttribute]
        public int Count => units.Count;
        [XmlArray("ListofUnits")]
        [XmlArrayItem("Human")]
        [XmlIgnore]
        public List<Customer> ListofUnits
        {
            get => units;
            set => units = value;
        }
        public void Add(Customer human)
        {
            Customer x = human;
            units.Add(x);
        }
        public void Remove(Customer human)
        {
            Customer x = human;
            units.Remove(x);
        }
        public void ToConsole()
        {
            Customer[] arr = units.ToArray();
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine((i + 1).ToString() + ' ' + arr[i].ToString() + '\n');
            }
        }
    }
}

