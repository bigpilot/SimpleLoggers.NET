using System;
using Xunit;
using Moq;

namespace SimpleLoggers.Test
{
    public class TestLogHelper
    {
        [Fact]
        public void when_formatting_exception_it_should_work()
        {
            try
            {
                throw new DivideByZeroException("Cannot divide by zero!");
            }
            catch (Exception ex)
            {
                var result = LogHelper.FormatException(ex);
                Assert.NotEmpty(result);
                Assert.Contains("Cannot divide by zero!", result);
            }
        }

        [Fact]
        public void when_using_formatException_it_should_work()
        {
            var logger = new Mock<ILogger>();

            try
            {
                throw new DivideByZeroException("Cannot divide by zero!");
            }
            catch (Exception ex)
            {
                LogHelper.LogException("Failed to divide by zero!", logger.Object, ex);
            }

            logger.Verify( m => m.Error(It.IsAny<string>()));
        }
    }
}
