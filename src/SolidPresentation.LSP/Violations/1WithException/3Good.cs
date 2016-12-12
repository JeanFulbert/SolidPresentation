namespace SolidPresentation.LSP.Violations.WithException.Good
{
    using System;
    using System.Collections.Generic;

    public class Bird
    {
        public virtual void Eat()
        {
            Console.WriteLine(@"Eat ALL the food \o/");
        }
    }

    public class FlyingBird : Bird
    {
        public virtual void Fly()
        {
            Console.WriteLine("Fly to the infinite and beyond");
        }
    }

    public class Duck : FlyingBird { }

    public class Ostrich : Bird { }

    public class Zoo
    {
        public void StartBirdShow()
        {
            var birds = new FlyingBird[] { new Duck() };
            this.LetTheBirdsFly(birds);
        }

        private void LetTheBirdsFly(IEnumerable<FlyingBird> birds)
        {
            foreach (var bird in birds)
            {
                bird.Fly();
            }
        }
    }


    public class UnableToFlyException : Exception
    {
    }
}
