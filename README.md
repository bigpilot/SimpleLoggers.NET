# SimpleLoggers.NET 
### (for those of you tired of struggling with Log4Net and just want to get things done)

Logging capability is something you need in almost every project. However, I believe that full-featured loggers like Log4Net are too heavy and cumbersome to use. I therefore prefer my own simpler loggers which I've used on many projects. I usually use the EventViewerLogger and the TextFileLogger and DebugWindowLogger in specialized situations.

This project contains the following loggers:

- EventViewerLogger
- TextFileLogger
- DebugWindowLogger
- ConsoleLogger

and a simple Exception logging helper:

> LogHelper

which you can use like this:

```c#

      ILogger logger = new ConsoleLogger();

      try
      {
          throw new DivideByZeroException("Cannot divide by zero!");
      }
      catch (Exception ex)
      {
          LogHelper.LogException("Failed to divide by zero!", logger, ex);
      }
```


These loggers are intended to be used with a Dependency Injection (DI) framework such as [AutoFac](https://autofac.org/) or [Ninject](http://www.ninject.org/), but can also be manually created on the fly.

Although targeted at .NET Standard 2.0, these loggers will mostly be used in Business Logic on the server or desktop. 

## Roadmap

- a DailyTextFileLogger with timestamping in the logfile name
- a DatabaseLogger for Entity Framework (should work with most databases)

