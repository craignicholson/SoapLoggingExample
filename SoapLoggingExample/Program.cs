// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Craig Nicholson">
//   MIT
// </copyright>
// <summary>
//   Defines the Program type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoapLoggingExample
{
    using System;
    using System.Diagnostics;
    using System.Net;

    /// <summary>
    /// EExample program to demonstrate capturing a soap request and response.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The logger we will use to log transactions to help with debugging.
        /// </summary>
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// The main.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        public static void Main(string[] args)
        {
            Logger.Info("Enter");

            Logger.Info("CallWebService Starting");
            CallWebService();
            Logger.Info("CallWebService Done");

            Console.ReadLine();
        }

        /// <summary>
        /// The call web service.
        /// </summary>
        private static void CallWebService()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            // Ask MilSoft for the data via a MultiSpeak web request
            var client = new OA_Server.OA_Server { Url = "http://10.86.1.31/Simulators/MultiSpeak/30ac/OA_Server.asmx" };
            var messageId = Guid.NewGuid();
            var header = new OA_Server.MultiSpeakMsgHeader
            {
                UserID = "User123",
                Pwd = "***********",
                AppName = "TestApp",
                AppVersion = "0",
                Company = "ElectSolve",
                Version = "3.0ac",
                MessageID = messageId.ToString(),
                TimeStamp = DateTime.Now,
                TimeStampSpecified = true
            };
            client.MultiSpeakMsgHeaderValue = header;

            // self-signed cert override when TLS is enabled with self signed cert this code block ignores the warnings.
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            var response = client.GetOutageDurationEvents("2017-10-27-0003");
        }
    }
}
