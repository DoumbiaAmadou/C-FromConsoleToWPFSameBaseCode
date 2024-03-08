using System;
namespace HouseLib.Logging
{
  public enum LogLevel
  {
    TRACE,
    INFO,
    WARNIG,
    DEBUG,
    FATAL
  }

  public interface ILoggingService
  {
    public void SetLogLevel(LogLevel level);
    public void Log(String log);
  }
}

