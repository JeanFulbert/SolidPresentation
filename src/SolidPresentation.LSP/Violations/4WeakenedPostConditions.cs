using System;

namespace SolidPresentation.LSP.Violations.WeakenedPostConditions
{
    public abstract class Formatter
    {
        public virtual string Format(String message)
        {

            // do formatting
            return message.Trim();
        }
    }

    // weakened postcondition
    public class WeakenedMobileFormatter : Formatter
    {

        public override string Format(String message)
        {

            //do formatting
            return message;
        }

    }
    // strengthened postcondition
    public class StrengthenedMobileFormatter : Formatter
    {
        public override string Format(String message)
        {

            //do formatting
            return message.Trim().PadLeft(5);
        }
    }
}

