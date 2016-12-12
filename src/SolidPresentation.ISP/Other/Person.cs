namespace SolidPresentation.ISP.Other
{
    using System;

    public class Person
    {
        public Person(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            this.Name = name;
        }

        public string Name { get; private set; }
    }
}