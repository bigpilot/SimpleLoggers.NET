using System;
using System.Diagnostics;

namespace SimpleLoggers
{
    public class EventViewerLogger : ILogger
    {
        private readonly string _sourceName;

        public EventViewerLogger(string logName, string sourceName)
        {
            _sourceName = sourceName;

            if (!EventLog.SourceExists(_sourceName))
            {
                try
                {
                    EventLog.CreateEventSource(_sourceName, logName);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Exception in EventViewerLogger: {LogHelper.FormatException(ex)}");
                }
            }
        }

        #region ILogger Members

        public void Info(string message)
        {
            EventLog.WriteEntry(_sourceName, message, EventLogEntryType.Information);
        }

        public void Warning(string message)
        {
            EventLog.WriteEntry(_sourceName, message, EventLogEntryType.Warning);
        }

        public void Error(string message)
        {
            EventLog.WriteEntry(_sourceName, message, EventLogEntryType.Error);
        }

        #endregion
    }
}
