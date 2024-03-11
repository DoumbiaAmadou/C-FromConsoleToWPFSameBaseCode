using System;
using System.Reflection.Emit;

namespace HouseLib.Logging
{
  public enum LogLevel
  {
    TRACE,
    LOG,
    INFO,
    WARNIG,
    DEBUG,
    ERROR,
    FATAL
  }

  public interface ILoggingService
  {
    public void SetLogLevel(LogLevel level);
    //public void Log(String log);
    void Log(string log, LogLevel level = LogLevel.LOG);
  }
}

