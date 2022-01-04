using System;
using Microsoft.Extensions.Logging;
using Serilog;
using NLog;

public class Program
{
    static void Main(string[] args)
    {
        MicrosoftLoggingExtension();
        Serilog();
        // Only one of the following needs to be Commented and Uncommented for checking the configuration
        //Nlog();
        NlogWithConfigFile();
    }

    static void MicrosoftLoggingExtension()
    {
        // create a logger factory
        var loggerFactory = LoggerFactory.Create(
            builder => builder
                        // add console as logging target
                        .AddConsole()
                        // add debug output as logging target
                        .AddDebug()
                        // set minimum level to log
                        .SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Debug)
        );

        // create a logger
        var logger = loggerFactory.CreateLogger<Program>();

        // logging
        logger.LogTrace("Microsoft Trace message");
        logger.LogDebug("Microsoft Debug message");
        logger.LogInformation("Microsoft Info message");
        logger.LogWarning("Microsoft Warning message");
        logger.LogError("Microsoft Error message");
        logger.LogCritical("Microsoft Critical message");
    }

    static void Serilog()
    {
        // create a logger
        using var logger = new LoggerConfiguration()
                                // add console as logging target
                                .WriteTo.Console()
                                // add debug output as logging target
                                .WriteTo.Debug()
                                .WriteTo.File("logs/log_serilog.txt", outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                                // set minimum level to log
                                .MinimumLevel.Debug()
                                .CreateLogger();

        // logging
        logger.Verbose("Serilog Verbose message");
        logger.Debug("Serilog Debug message");
        logger.Information("Serilog Info message");
        logger.Warning("Serilog Warning message");
        logger.Error("Serilog Error message");
        logger.Fatal("Serilog Fatal message");
    }

    static void Nlog()
    {
        // create a configuration instance
        var config = new NLog.Config.LoggingConfiguration();

        // create a console logging target
        var logConsole = new NLog.Targets.ConsoleTarget();
        // create a debug output logging target
        var logDebug = new NLog.Targets.OutputDebugStringTarget();
        // create a file output logging target
        var logFile = new NLog.Targets.FileTarget("logFile") { FileName = "logs/log_nlog.txt" };

        // send logs with levels from Info to Fatal to the console
        config.AddRule(NLog.LogLevel.Info, NLog.LogLevel.Fatal, logConsole);
        // send logs with levels from Debug to Fatal to the console
        config.AddRule(NLog.LogLevel.Debug, NLog.LogLevel.Fatal, logDebug);
        // send logs with levels from Debug to Fatal to the file
        config.AddRule(NLog.LogLevel.Debug, NLog.LogLevel.Fatal, logFile);

        // apply the configuration
        NLog.LogManager.Configuration = config;

        // create a logger
        var logger = LogManager.GetCurrentClassLogger();

        // logging
        logger.Trace("NLog Trace message");
        logger.Debug("NLog Debug message");
        logger.Info("NLog Info message");
        logger.Warn("NLog Warning message");
        logger.Error("NLog Error message");
        logger.Fatal("NLog Fatal message");
    }

    static void NlogWithConfigFile()
    {
        var logger = NLog.LogManager.GetCurrentClassLogger();
        try
        {
            // logging
            logger.Trace("NLog Config Trace message");
            logger.Debug("NLog Config Debug message");
            logger.Info("NLog Config Info message");
            logger.Warn("NLog Config Warning message");
            logger.Error("NLog Config Error message");
            logger.Fatal("NLog Config Fatal message");
        }
        catch (Exception ex)
        {
            logger.Error(ex, "Goodbye cruel world");
        }
    }
}