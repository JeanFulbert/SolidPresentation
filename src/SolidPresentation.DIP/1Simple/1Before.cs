namespace SolidPresentation.DIP._1Simple.Before
{
    public class Class1
    {
        private readonly Class2 class2;

        public Class1()
        {
            this.class2 = new Class2();
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
