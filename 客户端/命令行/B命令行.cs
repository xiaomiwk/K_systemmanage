using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using 通用访问;

namespace 系统管理.客户端
{
    class B命令行
    {
        IT客户端 _客户端;

        string _对象名 = "命令行";

        bool _已初始化 = false;

        public bool IsWindows { get; private set; }

        public B命令行(IT客户端 __客户端)
        {
            _客户端 = __客户端;
            _客户端.订阅事件(_对象名, "正常输出", q =>
            {
                var __参数 = HJSON.反序列化<M输出>(q["参数"]);
                on正常输出(__参数);
            });
            _客户端.订阅事件(_对象名, "异常输出", q =>
            {
                var __参数 = HJSON.反序列化<M输出>(q["参数"]);
                on异常输出(__参数);
            });
            _客户端.订阅事件(_对象名, "执行结束", q =>
            {
                var __参数 = HJSON.反序列化<M输出>(q["参数"]);
                on执行结束(__参数);
            });
            if (_客户端.连接正常)
            {
                初始化();
            }
            _客户端.已连接 += 初始化;
        }

        private void 初始化()
        {
            if (!_已初始化)
            {
                _已初始化 = true;
                IsWindows = bool.Parse(_客户端.查询属性值(_对象名, "IsWindows"));
            }
        }

        public void 创建进程(string __进程标识)
        {
            if (!_客户端.连接正常)
            {
                throw new ApplicationException("未连接");
            }
            _客户端.执行方法(_对象名, "创建进程", new Dictionary<string, string> { { "进程标识", __进程标识 }, });
        }

        public void 结束进程(string __进程标识)
        {
            if (_客户端.连接正常)
            {
                _客户端.执行方法(_对象名, "结束进程", new Dictionary<string, string> { { "进程标识", __进程标识 }, });
            }
        }

        //public void 执行(string __进程标识, M命令 __命令, Dictionary<string, string> __参数 = null)
        //{
        //    if (!_客户端.连接正常)
        //    {
        //        throw new ApplicationException("未连接");
        //    }
        //    var __命令行列表 = __命令.命令行列表;
        //    if (__命令.参数列表 != null && __命令.参数列表.Count > 0 && __参数 != null)
        //    {
        //        __命令行列表 = new List<string>(__命令行列表);
        //        for (int i = 0; i < __命令行列表.Count; i++)
        //        {
        //            foreach (var item in __参数)
        //            {
        //                __命令行列表[i] = __命令行列表[i].Replace("<" + item.Key + ">", item.Value);
        //            }
        //        }
        //    }

        //    _客户端.执行方法(_对象名, "执行", new Dictionary<string, string> {
        //        { "进程标识",__进程标识},
        //        { "命令行列表",HJSON.序列化(__命令行列表) },
        //    });
        //}

        public void 执行(string __进程标识, List<string> __命令列表)
        {
            if (!_客户端.连接正常)
            {
                throw new ApplicationException("未连接");
            }
            _客户端.执行方法(_对象名, "执行", new Dictionary<string, string> {
                { "进程标识",__进程标识},
                { "命令行列表",HJSON.序列化(__命令列表) },
            });
        }

        public void 执行(string __进程标识, string __命令)
        {
            执行(__进程标识, new List<string> { __命令 } );
        }

        public event Action<M输出> 正常输出;

        public void on正常输出(M输出 __输出)
        {
            var temp = 正常输出;
            if (temp != null)
            {
                temp(__输出);
            }
        }

        public event Action<M输出> 异常输出;

        public void on异常输出(M输出 __输出)
        {
            var temp = 异常输出;
            if (temp != null)
            {
                temp(__输出);
            }
        }

        public event Action<M输出> 执行结束;

        public void on执行结束(M输出 __输出)
        {
            var temp = 执行结束;
            if (temp != null)
            {
                temp(__输出);
            }
        }

    }
}
