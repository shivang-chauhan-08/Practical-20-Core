using ProductManagementAPI.Model.Context;
using ProductManagementAPI.Model.Entities;

namespace ProductManagementAPI.Logging;

public class LogHelper
{
    private readonly ApplicationDBContext _context;

    public LogHelper(ApplicationDBContext context)
    {
        _context = context;
    }
    
    public async Task LogToDatabase(string message, string level)
    {
        var log = new AppLog
        {
            Message = message,
            Level = level,
            CreatedAt = DateTime.UtcNow
        };
        await _context.AppLogs.AddAsync(log);
        await _context.SaveChangesAsync();
    }
    
    public async Task LogToFile(string message)
    {
        Directory.CreateDirectory("Logs");
        string path = "Logs/log.txt";
        string logMessage = $"{DateTime.UtcNow} : {message}\n";
        await File.AppendAllTextAsync(path, logMessage);
    }
    
    public async Task Log(string message, string level)
    {
        try
        {
            await LogToDatabase(message, level);
            await LogToFile(message);
        }
        catch
        {
            await LogToFile(message);
        }
    }
}