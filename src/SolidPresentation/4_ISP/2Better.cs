using System;

namespace SolidPresentation.ISP.Better
{
	public interface IPrint
	{
		void Print();
	}

	public interface IStaple
	{
		void Staple();
	}

	public interface IFax
	{
		void Fax();
	}

	public interface IScan
	{
		void Scan();  
	}

	public class MFCX100 : IPrint, IStaple, IFax, IScan
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

	public class P100 : IPrint
	{
		public void Print()
		{
			// Do the print job
		}
	}
}

