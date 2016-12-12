using System;

namespace SolidPresentation.LSP.PostConditions.Bad
{
	public class Size
	{
		public Size (float width, float height, float depth)
		{
			this.Width = width;
			this.Height = height;
			this.Depth = depth;
		}

		public float Width { get; private set; }
		public float Height { get; private set; }
		public float Depth { get; private set; }

		public float Volume { get { return this.Width * this.Height * this.Depth; } }
	}

}
