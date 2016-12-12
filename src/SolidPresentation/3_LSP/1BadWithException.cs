using System;
using System.Collections.Generic;

namespace SolidPresentation.LSP.Bad
{
	public class Bird
	{
		public virtual void Fly() {}
		public virtual void Eat() {}
	}

	public class Crow : Bird
	{
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
			var birds = new Bird[] { new Crow(), new Duck(), new Ostrich() };
			this.LetTheBirdsFly(birds);
		}

		private void LetTheBirdsFly(IEnumerable<Bird> birds)
		{
			foreach (var bird in birds)
			{
				bird.Fly();
			}
		}
	}
}

