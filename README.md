# csharp-logging

There are 3 widely used logging libraries in C# which are Log4Net, NLog, SeriLog. Log4Net is not actively developed and released, so NLog and SeriLog are better options for logging.

At high level, Serilog is good if logging configuration through code is preferred. NLog is good if logging configuration through config file is preferred. For WEM-80, we will be using NLog, so that log levels can be changed manually using the config file.

# How to run the project in Visual Studio
In Visual studio, press
F5 -> Run application with Debugging
Ctrl + F5 -> Run application without debugging

When running with Debugging, logs will be populated to visual studio output console.
Both log_serilog.txt and log_nlog.txt will be available in logging\bin\Debug\net5.0\logs\ folder.
