using System;
using System.Collections.Generic;
using System.Text;

namespace Lab8
{
    public partial class GetSet<T>
    {
        public class Owner
        {
            public Guid ID;
            public string Name;
            public string Organization;

            public Owner()
            {
                ID = Guid.NewGuid();
                Name = "Vasilisa";
                Organization = "BSTU";
            }
        }

        public Owner myOwner = new Owner();

        public static class Date
        {
            public static DateTime date = new DateTime(2021, 10, 24);
        }
    }
}
