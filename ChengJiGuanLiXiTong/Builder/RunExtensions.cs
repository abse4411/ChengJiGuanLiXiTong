using System;

namespace ChengJiGuanLiXiTong.Builder
{
    public static class RunExtensions
    {
        public static void Run(this IAppBuilder app, Action<RequestContext> handler)
        {
            if (app == null)
                throw new ArgumentNullException(nameof(app));
            if (handler == null)
                throw new ArgumentNullException(nameof(handler));
            app.Use(_ => handler);
        }
    }
}
