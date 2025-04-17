namespace Kaleidocode.Gists.API.Extensions
{
    public static class ConfigurationExtensions
    {
        public static string[]? GetArray(this IConfiguration cfg, string key)
            => cfg.GetSection(key).Get<string[]>();
    }
}
