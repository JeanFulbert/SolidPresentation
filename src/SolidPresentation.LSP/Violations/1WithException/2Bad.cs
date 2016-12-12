namespace SolidPresentation.LSP.Violations.WithException.Bad2
{
    using System;
    using System.Collections.Generic;

    public class Bird
    {
        public virtual void Fly()
        {
            Console.WriteLine("Fly to the infinite and beyond");
        }

        public virtual void Eat()
        {
            Console.WriteLine(@"Eat ALL the food \o/");
        }
    }

    public class Duck : Bird
    {
    }

    public class Ostrich : Bird
    {
        public override void Fly()
        {
            throw new UnableToFlyException();
        }
    }

    public class Zoo
    {
        public void StartBirdShow()
        {
            var birds = new Bird[] { new Duck(), new Ostrich() };
            this.LetTheBirdsFly(birds);
        }

        private void LetTheBirdsFly(IEnumerable<Bird> birds)
        {
            foreach (var bird in birds)
            {
                if (!(bird is Ostrich))
                {
                    bird.Fly();
                }
            }
        }
    }

    public class UnableToFlyException : Exception
    {
    }
}
