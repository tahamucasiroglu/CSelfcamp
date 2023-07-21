namespace NeDersinV2.API.Extensions
{
    static public class AddLoggerServiceextension
    {
        static public void SetMinLevelToWarning(this ILoggingBuilder builder) => builder.SetMinimumLevel(LogLevel.Warning);
        static public void AddLoggerToService(this IServiceCollection services) => services.AddLogging(c => c.SetMinLevelToWarning());
    }
}
