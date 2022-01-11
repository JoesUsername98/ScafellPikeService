using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using Microsoft.Extensions.Options;
using ScaffelPikeLogger.Configuration;

namespace ScaffelPikeLogger
{
  public class TextLogger : AbstractLogger, ITextLogger
  {
    // PRIVATE //
    private readonly LoggerConfiguration _loggingConfiguration;
    public TextLogger(LoggerConfiguration loggingConfiguration) : base()
    {
      _loggingConfiguration = loggingConfiguration ??
        throw new ArgumentNullException(nameof(loggingConfiguration));

      if (_loggingConfiguration.LoggerType != LoggerType.Text)
        throw new InvalidOperationException($"{nameof(TextLogger)} doesn't match LoggerType of " +
          $"{_loggingConfiguration.LoggerType}");


      //Create LogPath
      string logDirectory = Path.Combine(_loggingConfiguration.TextLoggerConfiguration.Directory,
        $"{DateTime.Now:yyy-MM-dd}");
      string uniqueLogName = $"{_loggingConfiguration.TextLoggerConfiguration.FileName}" + $"{DateTime.Now:HH_mm_ss}";
      string baseLogName = Path.ChangeExtension(uniqueLogName,
        _loggingConfiguration.TextLoggerConfiguration.FileExtension);
      string filepath = Path.Combine(logDirectory, baseLogName);

      Directory.CreateDirectory(logDirectory);

      _ = Task.Run(() => LogAsync(filepath, _logQueue, _tokenSource.Token));

    }

    private static async Task LogAsync(string filepath, BufferBlock<LogRecord> logQueue, CancellationToken token)
    {
      //using statements ensure dispoesal of long running task
      using (var fs = new FileStream(filepath, FileMode.CreateNew, FileAccess.Write, FileShare.Read))
      {
        using (var sw = new StreamWriter(fs) { AutoFlush = true, })
        {
          try
          {
            while (true)
            {
              var logItem = await logQueue.ReceiveAsync(token).ConfigureAwait(false);
              string formattedMessage = FormatLogItem(logItem);
              await sw.WriteAsync(formattedMessage).ConfigureAwait(false);
            }
          }
          catch (OperationCanceledException)
          {
          }
        }
      }
    }

    private static string FormatLogItem(LogRecord logItem)
    {
      return $"[{logItem.Now:yyyy-MM-dd HH-mm-ss.fffff}] [{logItem.ThreadName,-30}:{logItem.ThreadId:000}]" +
        $"[{logItem.LogLevel}] {logItem.Message}\n";
    }

    protected override void Log(LogLevel logLevel, string module, string message)
    {
      // Synchronous post to buffer block
      _logQueue.Post(new LogRecord(logLevel, module, message, DateTime.Now,
        Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.Name));
    }


    #region Dispose Pattern
    ~TextLogger() //Like a destructor
    {
      Dispose(false);
    }
    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
      lock (_lock)
      {
        if (_disposed)
          return;
      }

      _disposed = true;

      if (disposing)
      {
        // Get rid of managed resources
        _tokenSource.Cancel();
        _tokenSource.Dispose();
      }

      // get rid of unmanaged resources

    }
    #endregion
    /// <summary>
    /// Type BufferBlock is Thread safe queue with an Asynchronous API
    /// </summary>
    private readonly BufferBlock<LogRecord> _logQueue = new BufferBlock<LogRecord>();
    private readonly CancellationTokenSource _tokenSource = new CancellationTokenSource();
    private readonly object _lock = new object();
    private bool _disposed = false;
  }
}
