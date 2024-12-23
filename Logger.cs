using System;
using System.IO;

public class Logger
{
    private static readonly string logFilePath = "CarLogs.txt";

    public static void Log(string message)
    {
        try
        {
            using (StreamWriter sw = File.AppendText(logFilePath))
            {
                sw.WriteLine($"{DateTime.Now}: {message}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to write to log file: {ex.Message}");
        }
    }
}