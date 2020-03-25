using System;
using System.Diagnostics.Contracts;
using System.Text;

namespace SimpleLoggers
{
    public class LogHelper
    {
        public static string FormatException(Exception ex)
        {
            var messageBuilder = new StringBuilder();

            messageBuilder.AppendLine(ex.Message);

            if (ex.InnerException != null)
            {
                messageBuilder.AppendLine();
                messageBuilder.AppendLine(ex.InnerException.Message ?? string.Empty);
            }

            if (ex.StackTrace != null)
            {
                messageBuilder.AppendLine();
                messageBuilder.Append(ex.StackTrace ?? string.Empty);
            }

            return messageBuilder.ToString();
        }

        public static void LogException(string message, ILogger logger, Exception ex)
        {
            var messageBuilder = new StringBuilder();

            if (string.IsNullOrEmpty(message) == false)
            {
                messageBuilder.AppendLine(message);
                messageBuilder.AppendLine();
            }

            messageBuilder.AppendLine(FormatException(ex));

            logger.Error(messageBuilder.ToString());        // exception is always logged as Error
        }
    }
}
