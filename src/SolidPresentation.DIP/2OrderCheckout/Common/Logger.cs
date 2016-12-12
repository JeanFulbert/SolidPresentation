namespace SolidPresentation.DIP.Common
{
    using System;
    using System.Diagnostics;

    public static class Logger
    {
        public static void Error(string message, Exception exception)
        {
            Debug.WriteLine("-- " + message + " --");
            Debug.WriteLine("\t" + exception.Message);
        }
    }
}