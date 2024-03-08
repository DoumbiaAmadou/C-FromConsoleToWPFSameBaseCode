using System;
namespace HouseLib.Logging
{
  public class LoggingService : ILoggingService
  {
    LogLevel LogLevel = LogLevel.INFO;
    public LoggingService()
    {
    }

    public void Log(string log)
    {
      Console.WriteLine($"{DateTime.Now,-26}|{LogLevel}|{log}");
    }

    public void SetLogLevel(LogLevel level)
    {
      LogLevel = level;
    }
  }
}

