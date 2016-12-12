using System;
using System.Collections.Generic;

namespace SolidPresentation.LSP.Better
{
	public class Bird
	{
		public void Eat() {}
	}

	public class FlightBird : Bird
	{
		public void Fly() {}
	}

	public class Crow : FlightBird
	{
	}

	public class Duck : FlightBird
	{
	}

	public class Ostrich : Bird
	{
	}

	public class Zoo
	{
		public void StartBirdShow()
		{
			var birds = new FlightBird[] { new Duck(), new Crow() };
			this.LetTheBirdsFly(birds);
		}

		private void LetTheBirdsFly(IEnumerable<FlightBird> flyghtBirds)
		{
			foreach (var bird in flyghtBirds)
			{
				bird.Fly();
			}
		}
	}
}

