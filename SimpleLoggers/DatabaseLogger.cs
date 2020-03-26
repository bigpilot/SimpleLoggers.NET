using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace SimpleLoggers
{
    // create a table named LogEntries in your database with the following columns:
    class LogEntry
    {
        [Key]
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public string Type { get; set; }
        public string Message { get; set; }
    }

    class LoggingContext : DbContext
    {
        private readonly string _connectionString;

        public LoggingContext()
        {
                
        }

        public LoggingContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DbSet<LogEntry> LogEntries { get; set; }

        // use this method for Integration testing
        // normally your would configure your database provider in Startup
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(_connectionString);     // alter this line to match your installed database provider!
        }
    }

    public class DatabaseLogger : ILogger
    {
        private readonly LoggingContext _dbContext;

        public DatabaseLogger()
        {
            _dbContext = new LoggingContext();
        }

        public DatabaseLogger(string connectionString)
        {
            _dbContext = new LoggingContext(connectionString);
        }

        public void Info(string message)
        {
            _dbContext.LogEntries.Add(new LogEntry() { Timestamp = DateTime.Now, Type = "Info", Message = message });
            _dbContext.SaveChanges();
        }

        public void Warning(string message)
        {
            _dbContext.LogEntries.Add(new LogEntry() { Timestamp = DateTime.Now, Type = "Warning", Message = message });
            _dbContext.SaveChanges();
        }

        public void Error(string message)
        {
            _dbContext.LogEntries.Add(new LogEntry() { Timestamp = DateTime.Now, Type = "Error", Message = message });
            _dbContext.SaveChanges();
        }
    }
}
