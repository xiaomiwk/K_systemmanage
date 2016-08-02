using System;
using System.Collections.Generic;
using 通用访问;

namespace 系统管理.客户端
{
    public class BFTP
    {
        private IT客户端 _IT客户端;

        private string _对象名称 = "FTP";

        public BFTP(IT客户端 __IT客户端)
        {
            _IT客户端 = __IT客户端;
            _IT客户端.订阅事件(_对象名称, "开关变化", __参数 =>
            {
                var __开 = bool.Parse(__参数["开"]);
                on开关变化(__开);
            });
        }

        public bool 运行中
        {
            get
            {
                try
                {
                    return bool.Parse(_IT客户端.查询属性值(_对象名称, "运行中"));
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public int 端口号
        {
            get
            {
                try
                {
                    return int.Parse(_IT客户端.查询属性值(_对象名称, "端口号"));
                }
                catch (Exception)
                {
                    return int.MinValue;
                }
            }
        }

        public string 目录
        {
            get
            {
                try
                {
                    return _IT客户端.查询属性值(_对象名称, "目录");
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public string 编码
        {
            get
            {
                try
                {
                    return _IT客户端.查询属性值(_对象名称, "编码");
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public void 开启(string __目录, int __端口号 = 2121)
        {
            _IT客户端.执行方法(_对象名称, "开启", new Dictionary<string, string> { { "目录", __目录 }, { "端口号", __端口号.ToString() } });
        }

        public void 关闭()
        {
            _IT客户端.执行方法(_对象名称, "关闭", null);
        }

        public event Action<bool> 开关变化;

        public void on开关变化(bool __开启)
        {
            var temp = 开关变化;
            if (temp != null)
            {
                temp(__开启);
            }
        }

    }

}
