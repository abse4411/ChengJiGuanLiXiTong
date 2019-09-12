using System;
using System.Collections.Generic;
using ChengJiGuanLiXiTong.Application;

namespace ChengJiGuanLiXiTong.Builder
{
    public delegate void RequestDelegate(RequestContext context);

    public class RequestContext
    {
        public IDictionary<String, String> Input { get; set; }=new Dictionary<String, String>();
        public Object Output { get; set; }
        public Int32 StatusCode { get; set; } = RequestConstants.None;
    }
}
