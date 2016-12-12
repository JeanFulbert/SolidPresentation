using System;

namespace SolidPresentation.ISP.Bad
{
	public interface IMachine
	{
		void Print();
		void Staple();
		void Fax();
		void Scan();
	}

	public class MFCX100 : IMachine
	{
		public void Print()
		{
			// Do the print job
		}

		public void Staple()
		{
			// Do the staple job
		}

		public void Fax()
		{
			// Do the fax job
		}

		public void Scan()
		{
			// Do the scan job
		}
	}

	public class P100 : IMachine
	{
		public void Print()
		{
			// Do the print job
		}

		public void Staple()
		{
			throw new NotImplementedException();
		}

		public void Fax()
		{
			throw new NotImplementedException();
		}

		public void Scan()
		{
			throw new NotImplementedException();
		}
	}
}

