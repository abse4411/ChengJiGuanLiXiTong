using System;
using System.Collections.Generic;
using System.Linq;
using ChengJiGuanLiXiTong.Application;

namespace ChengJiGuanLiXiTong.Builder
{
    public class AppBuilder:IAppBuilder
    {
        private readonly IList<Func<Action<RequestContext>, Action<RequestContext>>> _components =
            new List<Func<Action<RequestContext>, Action<RequestContext>>>();

        public IApp Build()
        {
            Action<RequestContext> requestDelegate = context => { };
            foreach (Func<Action<RequestContext>, Action<RequestContext>> func in this._components.Reverse())
                requestDelegate = func(requestDelegate);
            return new MyApp(requestDelegate);
        }

        public IAppBuilder Use(Func<Action<RequestContext>, Action<RequestContext>> middleware)
        {
            this._components.Add(middleware);
            return (IAppBuilder)this;
        }
    }
}
