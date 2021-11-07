using System;

namespace Лабораторная_4
{
    public partial class Set
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
