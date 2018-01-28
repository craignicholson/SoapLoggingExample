// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SoapLoggerExtension.cs" company="Craig Nicholson">
//   MIT
// </copyright>
// <summary>
//   Defines the SoapLoggerExtension type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoapLoggingExample.Extensions
{
    using System;
    using System.IO;
    using System.Web.Services.Protocols;
    using System.Xml.Linq;

    using SoapMessage = System.Web.Services.Protocols.SoapMessage;

    /// <inheritdoc />
    /// <summary>
    /// The soap logger extension.
    /// </summary>
    public class SoapLoggerExtension : SoapExtension
    {
        /// <summary>
        /// The logger we will use to log transactions to help with debugging.
        /// </summary>
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// The _ old stream.
        /// </summary>
        private Stream requestStream;

        /// <summary>
        /// The _ new stream.
        /// </summary>
        private Stream responseStream;

        /// <inheritdoc />
        /// <summary>
        /// The get initializer.
        /// </summary>
        /// <param name="methodInfo">
        /// The method info.
        /// </param>
        /// <param name="attribute">
        /// The attribute.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.Object" />.
        /// </returns>
        public override object GetInitializer(LogicalMethodInfo methodInfo, SoapExtensionAttribute attribute)
        {
            Logger.Debug("GetInitializer(LogicalMethodInfo methodInfo, SoapExtensionAttribute attribute)");
            return null;
        }

        /// <inheritdoc />
        /// <summary>
        /// The get initializer.
        /// </summary>
        /// <param name="serviceType">
        /// The service type.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.Object" />.
        /// </returns>
        public override object GetInitializer(Type serviceType)
        {
            Logger.Debug("GetInitializer(Type serviceType)");
            return null;
        }

        /// <inheritdoc />
        /// <summary>
        /// The initialize.
        /// </summary>
        /// <param name="initializer">
        /// The initializer.
        /// </param>
        public override void Initialize(object initializer)
        {
            Logger.Debug("Initialize");
        }

        /// <inheritdoc />
        /// <summary>
        /// The chain stream.
        /// </summary>
        /// <param name="stream">
        /// The stream.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.IO.Stream" />.
        /// </returns>
        public override Stream ChainStream(Stream stream)
        {
            Logger.Debug("ChainStream");
            this.requestStream = stream;
            this.responseStream = new MemoryStream();
            return this.responseStream;
        }

        /// <inheritdoc />
        /// <summary>
        /// The process message.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public override void ProcessMessage(SoapMessage message)
        {
            Logger.Debug(message.Stage);
            Logger.Debug(message.SoapVersion);
            switch (message.Stage)
            {
                case SoapMessageStage.BeforeSerialize:
                    break;

                case SoapMessageStage.AfterSerialize:
                    this.PrettyXml("REQUEST");
                    CopyStream(this.responseStream, this.requestStream);
                    this.responseStream.Position = 0;
                    break;

                case SoapMessageStage.BeforeDeserialize:
                    CopyStream(this.requestStream, this.responseStream);
                    this.PrettyXml("RESPONSE");
                    break;

                case SoapMessageStage.AfterDeserialize:
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// The log.
        /// </summary>
        /// <param name="stage">
        /// The stage.
        /// </param>
        public void PrettyXml(string stage)
        {
            this.responseStream.Position = 0;
            var reader = new StreamReader(this.responseStream);
            var requestXml = reader.ReadToEnd();
            Logger.Debug($"{stage} | {requestXml.TrimEnd('\r', '\n') }");
            this.responseStream.Position = 0;
            if (!string.IsNullOrWhiteSpace(requestXml))
            {
                var prettyXml = XDocument.Parse(requestXml);
                Logger.Debug($"Formatted | \n{prettyXml}");
            }
        }

        /// <summary>
        /// The reverse incoming stream.
        /// </summary>
        public void ReverseIncomingStream()
        {
            Logger.Debug("ReverseIncomingStream");
            this.ReverseStream(this.responseStream);
        }

        /// <summary>
        /// The reverse outgoing stream.
        /// </summary>
        public void ReverseOutgoingStream()
        {
            Logger.Debug("ReverseOutgoingStream");
            this.ReverseStream(this.responseStream);
        }

        /// <summary>
        /// The reverse stream.
        /// </summary>
        /// <param name="stream">
        /// The stream.
        /// </param>
        public void ReverseStream(Stream stream)
        {
            Logger.Debug("ReverseStream");
            TextReader tr = new StreamReader(stream);
            var str = tr.ReadToEnd();
            var data = str.ToCharArray();
            Array.Reverse(data);
            var strReversed = new string(data);

            TextWriter tw = new StreamWriter(stream);
            stream.Position = 0;
            tw.Write(strReversed);
            tw.Flush();
        }

        /// <summary>
        /// The copy stream.
        /// </summary>
        /// <param name="fromStream">
        /// The from stream.
        /// </param>
        /// <param name="toStream">
        /// The to stream.
        /// </param>
        private static void CopyStream(Stream fromStream, Stream toStream)
        {
            Logger.Debug("CopyStream");
            try
            {
                var sr = new StreamReader(fromStream);
                var sw = new StreamWriter(toStream);
                sw.WriteLine(sr.ReadToEnd());
                sw.Flush();
            }
            catch (Exception ex)
            {
                var message = $"CopyStream failed because: {ex.Message}";
                Logger.Error(message, ex);
            }
        }
    }
}
