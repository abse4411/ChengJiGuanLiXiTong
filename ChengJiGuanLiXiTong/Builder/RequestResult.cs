using System;
using System.Collections.Generic;
using System.Text;
using ChengJiGuanLiXiTong.Application;

namespace ChengJiGuanLiXiTong.Builder
{
    public class RequestResult
    {
        public Object Output { get; set; }
        public Int32 StatusCode { get; set; } = RequestConstants.None;
    }
}
