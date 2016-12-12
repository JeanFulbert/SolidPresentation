using System;

namespace SolidPresentation.LSP.Violations.PreConditions.Good
{
    public class Formatter
    {
        public virtual bool CanFormat(string message)
        {
            return !string.IsNullOrEmpty(message);
        }

        public virtual string Format(string message)
        {
            if (!this.CanFormat(message))
                throw new ArgumentException("Message can't be formatted");

            var formattedMessage = message.Replace(".", ".\n");
            return formattedMessage;
        }
    }

    public class LoremIpsumGenerator
    {
        private const string LoremIpsum =
            @"Lorem ipsum dolor sit amet, consectetur adipiscing elit." +
            " Phasellus interdum metus sit amet ligula dignissim, vitae maximus arcu cursus." +
            " Lorem ipsum dolor sit amet, consectetur adipiscing elit." +
            " Suspendisse congue vel enim vitae tempor." +
            " Quisque maximus lacus velit, in pulvinar lorem aliquet vel." +
            " Cras eu sem et risus placerat hendrerit." +
            " Ut posuere laoreet mi, in elementum enim fermentum sit amet." +
            " Nam mauris nisl, dignissim in efficitur a, semper a mi. Nulla facilisi. ";

        public string GenerateFormattedLoremIpsum(Formatter formatter)
        {
            if (!formatter.CanFormat(LoremIpsum))
            {
                return string.Empty;
            }

            return formatter.Format(LoremIpsum);
        }
    }

    public class SmsFormatter : Formatter
    {
        private const int MaxCaracters = 160;

        public override bool CanFormat(string message)
        {
            return base.CanFormat(message) && message.Length <= MaxCaracters;
        }
    }
}
