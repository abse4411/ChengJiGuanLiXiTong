using System;
using ChengJiGuanLiXiTong.Application;

namespace ChengJiGuanLiXiTong.Builder
{
    public interface IAppBuilder
    {
        IAppBuilder Use(Func<Action<RequestContext>, Action<RequestContext>> middleware);
        IApp Build();
    }
}
