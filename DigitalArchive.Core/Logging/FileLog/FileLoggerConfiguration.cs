using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalArchive.Core.Logging.FileLog
{
    public class FileLoggerConfiguration : IFileLoggerConfiguration
    {
        private readonly IConfiguration _configuration;
        public FileLoggerConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string FileName => _configuration.GetSection("Logging:FileLog:FileName").Value;
        public string FolderPath => _configuration.GetSection("Logging:FileLog:FolderPath").Value;
    }
}
