namespace SolidPresentation.LSP.Violations.HistoryContraint.Bad
{
	public class Time
	{
		protected int hours;
		protected int minutes;

		public Time(int hours, int minutes)
		{
			this.minutes = minutes;
			this.hours = hours;
		}

		public int Hours { get { return this.hours; } }
		public int Minutes { get { return this.minutes; } }
	}

	public class FlexibleTime : Time
	{
		public FlexibleTime(int hours, int minutes)
			: base(hours, minutes)
		{
		}

		public void ChangeTime(int hours, int minutes)
		{
			this.minutes = minutes;
			this.hours = hours;
		}
	}
}

