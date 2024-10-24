using System.Collections.Concurrent;

namespace ReserveAqui.Logging;

public class CustomerLoggerProvider : ILoggerProvider
{
    readonly CustomerLoggerProviderConfiguration loggerConfig;

    readonly ConcurrentDictionary<string, CustomerLogger> loggers =
        new ConcurrentDictionary<string, CustomerLogger>();

    public CustomerLoggerProvider(CustomerLoggerProviderConfiguration loggerConfig)
    {
        this.loggerConfig = loggerConfig;
    }

    public ILogger CreateLogger(string categoryName)
    {
        return loggers.GetOrAdd(categoryName, name => new CustomerLogger(name, loggerConfig));
    }

    public void Dispose()
    {
        loggers.Clear();
    }
}
