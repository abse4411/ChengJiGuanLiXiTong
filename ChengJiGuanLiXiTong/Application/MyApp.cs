using System;
using ChengJiGuanLiXiTong.Builder;

namespace ChengJiGuanLiXiTong.Application
{
    public class MyApp:IApp
    {
        private readonly Action<RequestContext> _app;

        public MyApp(Action<RequestContext> app)
        {
            _app = app?? throw new ArgumentNullException(nameof(app));
        }

        public RequestResult Run(RequestContext context)
        {
            _app(context);

            return new RequestResult
            {
                Output = context.Output,
                StatusCode = context.StatusCode
            };
        }

        public RequestResult Run()
        {
            return Run(new RequestContext());
        }
    }
}
