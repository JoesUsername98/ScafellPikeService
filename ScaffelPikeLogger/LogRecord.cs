using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaffelPikeLogger
{
  public struct LogRecord
  {
    public LogRecord(LogLevel logLevel, string module, string message, DateTime now, int threadId, string threadName)
    {
      LogLevel = logLevel;
      Module = module;
      Message = message;
      Now = now;
      ThreadId = threadId;
      ThreadName = threadName;
    }
    public LogLevel LogLevel { get; private set; }
    public string Module { get; private set; }
    public string Message { get; private set; }

    public DateTime Now { get; private set; }
    public int ThreadId { get; private set; }
    public string ThreadName { get; private set; }
  }
}
