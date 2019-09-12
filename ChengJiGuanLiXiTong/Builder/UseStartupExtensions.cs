namespace ChengJiGuanLiXiTong.Builder
{
    public static class UseStartupExtensions
    {
        public static IAppBuilder UseStartup(
            this IAppBuilder builder,
            Startup startup)
        {
            startup.Configure(builder);
            return builder;
        }
    }
}
