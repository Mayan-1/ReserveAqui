namespace ReserveAqui.Logging;

internal class CustomerLogger : ILogger
{
    readonly string loggerName;
    readonly CustomerLoggerProviderConfiguration loggerConfig;

    public CustomerLogger(string loggerName, CustomerLoggerProviderConfiguration loggerConfig)
    {
        this.loggerName = loggerName;
        this.loggerConfig = loggerConfig;
    }

    public IDisposable? BeginScope<TState>(TState state) where TState : notnull
    {
        return null;
    }

    public bool IsEnabled(LogLevel logLevel)
    {
        return logLevel == loggerConfig.LogLevel;
    }

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        string mensagem = $"{logLevel.ToString()}: {eventId.Id} - {formatter(state, exception)}\n" +
            $"Data: {DateTime.Now}\n";

        EscreverTextoNoArquivo(mensagem);
    }

    private void EscreverTextoNoArquivo(string mensagem)
    {
        string caminhoArquivo = @"C:\dev\Loggings\logs.txt";
        using(StreamWriter streamWriter = new StreamWriter(caminhoArquivo, true)) 
        {
            try
            {
                streamWriter.WriteLine(mensagem);
                streamWriter.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}