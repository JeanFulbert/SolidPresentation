namespace SolidPresentation.DIP._1Simple.InversedWithoutInterface
{
    using System;

    public class Class1
    {
        private readonly Class2 class2;

        public Class1(Class2 class2)
        {
            if (class2 == null)
            {
                throw new ArgumentNullException(nameof(class2));
            }

            this.class2 = class2;
        }

        public void DoSomething()
        {
            this.class2.DoAwesomeComputation();
        }
    }

    public class Class2
    {
        public void DoAwesomeComputation()
        {
            // Awesome computation here
        }
    }
}
