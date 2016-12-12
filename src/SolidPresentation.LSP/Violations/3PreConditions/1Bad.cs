using System;

namespace SolidPresentation.LSP.Violations.PreConditions.Bad
{
    public class Formatter
    {
        public virtual string Format(string message)
        {
            if (string.IsNullOrEmpty(message))
                throw new ArgumentException("Should not be null or empty");

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
            return formatter.Format(LoremIpsum);
        }
    }

    public class SmsFormatter : Formatter
    {
        private const int MaxCaracters = 160;

        public override string Format(string message)
        {
            if (string.IsNullOrEmpty(message) || message.Length > MaxCaracters)
                throw new ArgumentException("Should not be null nor empty nor exceeding 160 caracters");

            return base.Format(message);
        }
    }
}
