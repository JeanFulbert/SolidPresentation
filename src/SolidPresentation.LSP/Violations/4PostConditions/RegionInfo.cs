using System;

namespace SolidPresentation.LSP.PostConditions.Bad
{
	public class RegionInfo
	{
		public static RegionInfo Usa = new RegionInfo ("Usa");
		public static RegionInfo France = new RegionInfo ("France");
		
		public RegionInfo (string name)
		{
			this.Name = name;
		}

		public string Name { get; private set; }
	}

}
