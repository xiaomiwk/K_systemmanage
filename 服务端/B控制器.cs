using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Utility.存储;
using Utility.通用;
using 通用访问;
using 通用访问.DTO;

namespace 系统管理.服务端
{
    class B控制器
    {
        IT服务端 _IT服务端;

        public void 配置()
        {
            INET.H日志输出.设置(q => Console.WriteLine(string.Format("{0}\t{1}\t{2}\n{3}\t{4}({5})\n{6}", q.等级, q.概要, q.详细, q.文件, q.方法, q.行号, q.异常)));
            _IT服务端 = FT通用访问工厂.创建服务端();

            var __命令行 = new B命令行();
            var __命令行对象 = 创建对象(_IT服务端, __命令行);
            _IT服务端.添加对象("命令行", () => __命令行对象);

            var __进程管理 = new B进程管理();
            var __进程管理对象 = 创建对象(_IT服务端, __进程管理);
            _IT服务端.添加对象("进程管理", () => __进程管理对象);

            var __FTP = new BFTP();
            var __FTP对象 = 创建对象(_IT服务端, __FTP);
            _IT服务端.添加对象("FTP", () => __FTP对象);

            var __链路监控配置 = HJSON.反序列化<M链路监控配置>(File.ReadAllText(H路径.获取绝对路径("链路监控配置.txt"), Encoding.UTF8));
            var __链路监控 = new B链路监控(__链路监控配置);
            var __链路监控对象 = 创建对象(_IT服务端, __链路监控);
            _IT服务端.添加对象("链路监控", () => __链路监控对象);

            var __进程监控配置 = HJSON.反序列化<M进程监控配置>(File.ReadAllText(H路径.获取绝对路径("进程监控配置.txt"), Encoding.UTF8));
            var __进程监控 = new B进程监控(__进程监控配置);
            var __进程监控对象 = 创建对象(_IT服务端, __进程监控);
            _IT服务端.添加对象("进程监控", () => __进程监控对象);

            var __资源监控配置 = HJSON.反序列化<M资源监控配置>(File.ReadAllText(H路径.获取绝对路径("资源监控配置.txt"), Encoding.UTF8));
            var __资源监控 = new B资源监控(__资源监控配置);
            var __资源监控对象 = 创建对象(_IT服务端, __资源监控);
            _IT服务端.添加对象("资源监控", () => __资源监控对象);

            var __业务日志对象 = 创建对象(_IT服务端);
            _IT服务端.添加对象("业务日志", () => __业务日志对象);
        }

        public void 开启()
        {
            H业务日志.记录("系统", "开启");
            _IT服务端.端口 = 8888;
            _IT服务端.开启();
        }

        public void 关闭()
        {
            _IT服务端.关闭();
            H业务日志.记录("系统", "关闭");
        }

        M对象 创建对象(IT服务端 __IT服务端, B命令行 __命令行, string __对象名称 = "命令行", string __分类 = "")
        {
            Func<IPEndPoint, string, string> __合并 = (__地址, __标识) => string.Format("{0}:{1}:{2}", __地址.Address, __地址.Port, __标识);
            Func<string, Tuple<IPEndPoint, string>> __解析 = __合成标识 =>
            {
                var __数组 = __合成标识.Split(':');
                var __地址 = new IPEndPoint(IPAddress.Parse(__数组[0]), int.Parse(__数组[1]));
                var __标识 = __数组[2];
                return new Tuple<IPEndPoint, string>(__地址, __标识);
            };
            var __对象 = new M对象(__对象名称, __分类);
            __对象.添加属性("IsWindows", () => __命令行.IsWindows.ToString(), E角色.客户);
            __对象.添加方法("创建进程", (__实参列表, __地址) =>
            {
                var __进程标识 = __合并(__地址, __实参列表["进程标识"]);
                __命令行.创建进程(__进程标识);
                return "";
            }, E角色.客户, new List<M形参>
            {
                new M形参("进程标识", "string"),
            });

            __对象.添加方法("结束进程", (__实参列表, __地址) =>
            {
                var __进程标识 = __合并(__地址, __实参列表["进程标识"]);
                __命令行.结束进程(__进程标识);
                return "";
            }, E角色.客户, new List<M形参>
            {
                new M形参("进程标识", "string"),
            });

            __对象.添加方法("执行", (__实参列表, __地址) =>
            {
                var __进程标识 = __合并(__地址, __实参列表["进程标识"]);
                var __命令行列表 = HJSON.反序列化<List<string>>(__实参列表["命令行列表"]);
                __命令行.执行(__进程标识, __命令行列表);
                return "";
            }, E角色.客户, new List<M形参>
            {
                new M形参("进程标识", "string"),
                new M形参("命令行列表", "string", E数据结构.单值数组),
            });

            __对象.添加事件("正常输出", E角色.客户, new List<M形参> {
                new M形参("参数", new M元数据 { 类型 = "M输出", 结构 = E数据结构.对象, 子成员列表 = new List<M子成员> {
                    new M子成员("进程标识", "string"),
                    new M子成员("内容", "string")
                } }),
            });

            __对象.添加事件("异常输出", E角色.客户, new List<M形参> {
                new M形参("参数", new M元数据 { 类型 = "M输出", 结构 = E数据结构.对象, 子成员列表 = new List<M子成员> {
                    new M子成员("进程标识", "string"),
                    new M子成员("内容", "string")
                } }),
            });

            __对象.添加事件("执行结束", E角色.客户, new List<M形参> {
                new M形参("参数", new M元数据 { 类型 = "M输出", 结构 = E数据结构.对象, 子成员列表 = new List<M子成员> {
                    new M子成员("进程标识", "string"),
                    new M子成员("内容", "string")
                } }),
            });
            __命令行.正常输出 += __参数 =>
            {
                var __分解 = __解析(__参数.进程标识);
                var __地址 = __分解.Item1;
                __参数.进程标识 = __分解.Item2;
                __参数.内容 = __参数.内容 == null ? null : __参数.内容.Replace("{", "").Replace("}", "").Replace("[", "").Replace("]", "");
                __IT服务端.触发事件(__对象名称, "正常输出", new Dictionary<string, string> { { "参数", HJSON.序列化(__参数) } }, new List<IPEndPoint> { __地址 });
            };
            __命令行.异常输出 += __参数 =>
            {
                var __分解 = __解析(__参数.进程标识);
                var __地址 = __分解.Item1;
                __参数.进程标识 = __分解.Item2;
                __参数.内容 = __参数.内容 == null ? null : __参数.内容.Replace("{", "").Replace("}", "").Replace("[", "").Replace("]", "");
                __IT服务端.触发事件(__对象名称, "异常输出", new Dictionary<string, string> { { "参数", HJSON.序列化(__参数) } }, new List<IPEndPoint> { __地址 });
            };
            __命令行.执行结束 += __参数 =>
            {
                var __分解 = __解析(__参数.进程标识);
                var __地址 = __分解.Item1;
                __参数.进程标识 = __分解.Item2;
                __参数.内容 = __参数.内容 == null ? null : __参数.内容.Replace("{", "").Replace("}", "").Replace("[", "").Replace("]", "");
                __IT服务端.触发事件(__对象名称, "执行结束", new Dictionary<string, string> { { "参数", HJSON.序列化(__参数) } }, new List<IPEndPoint> { __地址 });
            };
            return __对象;
        }

        M对象 创建对象(IT服务端 __IT服务端, B进程管理 __进程管理, string __对象名称 = "进程管理", string __分类 = "")
        {
            var __对象 = new M对象(__对象名称, __分类);
            __对象.添加方法("查询所有", 实参列表 =>
            {
                return HJSON.序列化(__进程管理.查询所有().Select(q => new { q.Id, q.名称, q.内存, q.路径, q.CPU }));
            }, E角色.客户);

            __对象.添加方法("结束进程", 实参列表 =>
            {
                var __id = 实参列表["Id"];
                __进程管理.结束进程(int.Parse(__id));
                return "";
            }, E角色.客户);

            return __对象;
        }

        M对象 创建对象(IT服务端 __IT服务端, BFTP __FTP, string __对象名称 = "FTP", string __分类 = "")
        {
            var __对象 = new M对象(__对象名称, __分类);
            __对象.添加属性("运行中", () => __FTP.运行中.ToString(), E角色.客户, null);
            __对象.添加属性("端口号", () => __FTP.端口号.ToString(), E角色.客户, null);
            __对象.添加属性("目录", () => __FTP.目录, E角色.客户, null);
            __对象.添加属性("编码", () => "GB2312", E角色.客户, null);
            __对象.添加方法("开启", __实参列表 =>
            {
                var __目录 = __实参列表["目录"];
                var __端口号 = int.Parse(__实参列表["端口号"]);
                __FTP.开启(__目录, __端口号);
                return "";
            }, E角色.客户, new List<M形参>
            {
                new M形参("目录", "string"),
                new M形参("端口号", "int"),
            }, null);
            __对象.添加方法("关闭", __实参列表 =>
            {
                __FTP.关闭();
                return "";
            }, E角色.客户, null, null);
            __对象.添加事件("开关变化", E角色.客户, new List<M形参> { new M形参("开", "bool") });
            __FTP.状态变化 += __参数 => __IT服务端.触发事件(__对象名称, "开关变化", new Dictionary<string, string> { { "开", __参数.ToString() } });
            return __对象;
        }

        M对象 创建对象(IT服务端 __IT服务端, B链路监控 __Ping, string __对象名称 = "链路监控", string __分类 = "")
        {
            var __对象 = new M对象(__对象名称, __分类);
            __对象.添加属性("配置", () => HJSON.序列化(__Ping.配置), E角色.客户, null);

            __对象.添加方法("查询状态", __实参列表 =>
            {
                return HJSON.序列化(__Ping.查询状态());
            }, E角色.客户, null, null);

            __对象.添加方法("修改配置", __实参列表 =>
            {
                var __配置 = HJSON.反序列化<M链路监控配置>(__实参列表["配置"]);
                __Ping.修改配置(__配置);
                File.WriteAllText(H路径.获取绝对路径("链路监控配置.txt"), HJSON.序列化(__Ping.配置), Encoding.UTF8);
                return "";
            }, E角色.客户, new List<M形参>
            {
                new M形参("配置", new M元数据 {  结构 = E数据结构.对象, 子成员列表 = new List<M子成员> {
                    new M子成员("超时", new M元数据 { 类型 = "int", 描述 = "毫秒", 默认值 = "1000" }),
                    new M子成员("频率", new M元数据 { 类型 = "int", 描述 = "毫秒/次", 默认值 = "1000" }),
                    new M子成员("阈值", new M元数据 { 类型 = "int", 描述 = "1-10, 通过10次中成功的次数表示当前通断", 默认值 = "7" }),
                    new M子成员("IP列表", new M元数据 { 类型 = "string", 描述 = "ip或域名", 结构 = E数据结构.单值数组 }),
                } }),

            }, null);

            __对象.添加事件("连接变化", E角色.客户, new List<M形参> { new M形参("地址", "string"), new M形参("旧", "bool"), new M形参("新", "bool") });
            __Ping.连接变化 += (__地址, __旧, __新) =>
            {
                H业务日志.记录("链路", string.Format("{0} {1}", __地址, __新 == true ? "通" : "断"));
                __IT服务端.触发事件(__对象名称, "连接变化", new Dictionary<string, string> { { "地址", __地址 }, { "旧", __旧.ToString() }, { "新", __新.ToString() } });
            };
            return __对象;
        }

        M对象 创建对象(IT服务端 __IT服务端, B进程监控 __监控, string __对象名称 = "进程监控", string __分类 = "")
        {
            var __对象 = new M对象(__对象名称, __分类);

            __对象.添加方法("查询状态", __实参列表 =>
            {
                return HJSON.序列化(__监控.查询状态());
            }, E角色.客户, null);

            __对象.添加方法("查询配置", __实参列表 =>
            {
                return HJSON.序列化(__监控.查询配置());
            }, E角色.客户, null);

            __对象.添加方法("设置配置", __实参列表 =>
            {
                var __配置 = HJSON.反序列化<M进程监控配置>(__实参列表["配置"]);
                __监控.设置配置(__配置);
                File.WriteAllText(H路径.获取绝对路径("进程监控配置.txt"), HJSON.序列化(__配置), Encoding.UTF8);
                return "";
            }, E角色.客户, new List<M形参>
            {
                new M形参("配置", new M元数据 { 结构 = E数据结构.对象, 子成员列表= new List<M子成员> {
                    new M形参("频率",""),
                    new M形参("列表", new M元数据 { 结构 = E数据结构.对象数组, 子成员列表= new List<M子成员> {
                        new M子成员("进程名","string"),
                        new M子成员("CPU阈值", new M元数据 { 类型 = "int?", 描述 = "可为空,1-100", 默认值 = "90" }),
                        new M子成员("内存阈值", new M元数据 { 类型 = "int?", 描述 = "可为空,单位MB", 默认值 = "2000" }),
                        new M子成员("阈值次数", new M元数据 { 类型 = "int?", 默认值 = "可为空,5" }),
                    } })
                }}),
            }, null);

            __对象.添加事件("告警", E角色.客户, new List<M形参> { new M形参("描述", "string") });
            __监控.进程开启 += (qid, __进程名, __时间) =>
            {
                var __描述 = string.Format("进程{1}（{0}）开启, {2}", qid, __进程名, __时间.ToString());
                H业务日志.记录("进程", __描述);
                __IT服务端.触发事件(__对象名称, "告警", new Dictionary<string, string> { { "描述", __描述 } });
            };
            __监控.进程关闭 += (qid, __进程名) =>
            {
                var __描述 = string.Format("进程{1}（{0}）关闭", qid, __进程名);
                H业务日志.记录("进程", __描述);
                __IT服务端.触发事件(__对象名称, "告警", new Dictionary<string, string> { { "描述", __描述 } });
            };
            __监控.阈值告警 += __描述 =>
            {
                H业务日志.记录("进程", __描述);
                __IT服务端.触发事件(__对象名称, "告警", new Dictionary<string, string> { { "描述", __描述 } });
            };
            return __对象;
        }

        M对象 创建对象(IT服务端 __IT服务端, B资源监控 __监控, string __对象名称 = "资源监控", string __分类 = "")
        {
            var __对象 = new M对象(__对象名称, __分类);
            __对象.添加属性("配置", () => HJSON.序列化(__监控.配置), E角色.客户, null);
            __对象.添加属性("总内存", () => string.Format("{0} GB", __监控.总内存 / 1024), E角色.客户, null);

            __对象.添加方法("设置配置", __实参列表 =>
            {
                var __配置 = HJSON.反序列化<M资源监控配置>(__实参列表["配置"]);
                __监控.配置 = __配置;
                File.WriteAllText(H路径.获取绝对路径("资源监控配置.txt"), HJSON.序列化(__配置), Encoding.UTF8);
                return "";
            }, E角色.客户, null, null);

            __对象.添加方法("查询状态", __实参列表 =>
            {
                return HJSON.序列化(__监控.查询状态());
            }, E角色.客户, null, null);

            __对象.添加事件("告警", E角色.客户, new List<M形参> { new M形参("描述", "string") });
            __监控.阈值告警 += __描述 =>
            {
                H业务日志.记录("进程", __描述);
                __IT服务端.触发事件(__对象名称, "告警", new Dictionary<string, string> { { "描述", __描述 } });
            };

            return __对象;
        }

        M对象 创建对象(IT服务端 __IT服务端, string __对象名称 = "业务日志", string __分类 = "")
        {
            var __对象 = new M对象(__对象名称, __分类);
            __对象.添加属性("缓存上限", () => H业务日志.缓存上限.ToString(), E角色.客户, null);

            __对象.添加方法("查询缓存", __实参列表 =>
            {
                //return HJSON.AES压缩(HJSON.序列化(H业务日志.查询缓存()));
                return HJSON.序列化(H业务日志.查询缓存());
            }, E角色.客户, null, null);

            return __对象;
        }

    }

}
