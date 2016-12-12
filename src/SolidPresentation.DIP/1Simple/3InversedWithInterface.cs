namespace SolidPresentation.DIP._1Simple.InversedWithInterface
{
    using System;

    public class Class1
    {
        private readonly IDoAwesomeComputation awesomeComputation;

        public Class1(IDoAwesomeComputation awesomeComputation)
        {
            if (awesomeComputation == null)
            {
                throw new ArgumentNullException(nameof(awesomeComputation));
            }

            this.awesomeComputation = awesomeComputation;
        }

        public void DoSomething()
        {
            this.awesomeComputation.DoAwesomeComputation();
        }
    }

    public interface IDoAwesomeComputation
    {
        void DoAwesomeComputation();
    }

    public class Class2 : IDoAwesomeComputation
    {
        public void DoAwesomeComputation()
        {
            // Awesome computation here
        }
    }
}
