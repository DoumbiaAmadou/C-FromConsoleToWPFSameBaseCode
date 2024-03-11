using System;
namespace HouseLib.Logging
{
  public class LoggingService : ILoggingService
  {
    LogLevel LogLevel = LogLevel.LOG;
    public LoggingService()
    {
    }

    private void Log(string log)
    {
      Console.WriteLine($"{DateTime.Now,-26}|{LogLevel}|{log}");
    }

    public void Log(string log, LogLevel level = LogLevel.LOG)
    {
      var currentLevel = LogLevel;
      SetLogLevel(level);
      Log($"{DateTime.Now,-26}|{LogLevel}|{log}");
      SetLogLevel(currentLevel);

    }

    public void SetLogLevel(LogLevel level)
    {
      LogLevel = level;
      switch (level)
      {
        case LogLevel.ERROR:
          Console.BackgroundColor = ConsoleColor.Red;
          Console.ForegroundColor = ConsoleColor.White;
          break;

        case LogLevel.INFO:
          Console.BackgroundColor = ConsoleColor.Green;
          Console.ForegroundColor = ConsoleColor.Black;
          break;
        case LogLevel.DEBUG:
          Console.BackgroundColor = ConsoleColor.Magenta;
          Console.ForegroundColor = ConsoleColor.Black;
          break;
        case LogLevel.WARNIG:
          Console.BackgroundColor = ConsoleColor.Yellow;
          Console.ForegroundColor = ConsoleColor.Black;
          break;
        case LogLevel.FATAL:
          Console.BackgroundColor = ConsoleColor.DarkRed;
          Console.ForegroundColor = ConsoleColor.White;
          break;
        default:
          Console.ResetColor();
          break;

      }
    }
  }
}

