using System;

namespace ChengJiGuanLiXiTong.Builder
{
    public static class UseExtensions
    {
        public static IAppBuilder Use(
            this IAppBuilder app,
            Action<RequestContext, Action> middleware)
        {
            return app.Use(next => context =>
           {
               Action func = (Action)(() => next(context));
               middleware(context, func);
           });
        }
    }
}
