using Microsoft.Extensions.Logging;

namespace DigitalArchive.Core.Logging.FileLog
{
    internal class FileLogger : ILogger
    {
        //private readonly IFileLoggerConfiguration _configuration;
        //public FileLogger(IFileLoggerConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }
            var message = string.Format("{0} [{1}] {2} {3}", "[" + DateTimeOffset.UtcNow.ToString("yyyy-MM-dd HH:mm:ss+00:00") + "]", logLevel.ToString(), formatter(state, exception), exception != null ? exception.StackTrace : "");
            WriteMessageToFile(message);
        }
        private static void WriteMessageToFile(string message)
        {
            //var configuration = ConfigurationSettings.GetAppSettingsJson();
            //var fileLoggerOptions = configuration.GetSection("Logging").GetSection("FileLogging").GetSection("Options").Get<FileLoggerOptions>();
            
            string FolderPath = "C:\\Users\\emre_\\OneDrive\\Masaüstü\\Log";
            string FileName = "log_{date}.log";
            

            if (!Directory.Exists(FolderPath))
            {
                Directory.CreateDirectory(FolderPath);
            }
            var fullFilePath = FolderPath + "/" + FileName.Replace("{date}", DateTimeOffset.UtcNow.ToString("yyyyMMdd"));

            //using (var streamWriter = new StreamWriter(fullFilePath, true))
            //{
            //    streamWriter.WriteLine(message);
            //    streamWriter.Close();
            //}
        }
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            //none gelirse loglama yapma de 
            return logLevel != LogLevel.None;
        }
    }
}