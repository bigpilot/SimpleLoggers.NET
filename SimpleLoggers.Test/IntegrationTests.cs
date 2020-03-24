using System;
using Moq;
using Xunit;

namespace SimpleLoggers.Test
{
    public class IntegrationTests
    {
        [Fact(Skip = "Integration Test")]
        public void TestEventViewerLogger()
        {
            var logger = new EventViewerLogger("YourApplicationName", "BusinessLogicModuleName");

            WriteLogMessages(logger);
        }

        [Fact(Skip = "Integration Test")]
        public void TestTextFileLogger()
        {
            var logger = new TextFileLogger("Logfile.txt");

            WriteLogMessages(logger);
        }

        [Fact(Skip = "Integration Test")]
        public void TestDebugWindowLogger()
        {
            var logger = new DebugWindowLogger();

            WriteLogMessages(logger);
        }

        [Fact(Skip = "Integration Test")]
        public void TestConsoleLogger()
        {
            var logger = new ConsoleLogger();

            WriteLogMessages(logger);
        }

        [Fact(Skip = "Integration Test")]
        public void TestTraceLogger()
        {
            var logger = new TraceLogger();

            WriteLogMessages(logger);
        }

        [Fact(Skip = "Integration Test")]
        public void TestExceptionHelper()
        {
            var logger = new TraceLogger();

            try
            {
                throw new DivideByZeroException("Cannot divide by zero!");
            }
            catch (Exception ex)
            {
                LogHelper.LogException("Failed to divide by zero!", logger, ex);
            }

        }

        private void WriteLogMessages(ILogger logger)
        {
            logger.Warning("My first warning");
            logger.Info("Info to be logged");
            logger.Error("An error to be logged");
        }
    }
}
